using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ONIT.VismaNetApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib
{
    public class RetryHandler : DelegatingHandler
    {
        // Strongly consider limiting the number of retries - "retry forever" is
        // probably not the most user friendly way you could respond to "the
        // network cable got pulled out."
        private int MaxRetries = VismaNet.MaxRetries;

        public RetryHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        { }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;
            for (int i = 0; i < MaxRetries; i++)
            {
                response = await base.SendAsync(request, cancellationToken);
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.NotFound)
                {
                    return response;
                }
                Debug.WriteLine($"[{i}/{MaxRetries}] {response.StatusCode} {response.ReasonPhrase}");
                // Will give an taskCanceledException if not disposed.
                if (i < MaxRetries - 1)
                {
                    response.Dispose();
                }
            }

            return response;
        }
    }

    internal class VismaNetHttpClient
    {
        public static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ",
            DateParseHandling = DateParseHandling.DateTime,
            Converters =
            {
                new StringEnumConverter()
            },
            NullValueHandling = NullValueHandling.Ignore
        };

        private static readonly HttpClient HttpClient;

        private readonly VismaNetAuthorization _authorization;

        static VismaNetHttpClient()
        {
            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
                handler.AutomaticDecompression = DecompressionMethods.GZip |
                                                 DecompressionMethods.Deflate;
            handler.UseCookies = false;
#if NET45
#else
            handler.MaxConnectionsPerServer = VismaNet.MaxConcurrentRequests;
#endif

            HttpClient = new HttpClient(new RetryHandler(handler), false)
            {
                Timeout = TimeSpan.FromSeconds(1200)
            };
            HttpClient.DefaultRequestHeaders.Add("User-Agent",
                $"Visma.Net/{VismaNet.Version} (+https://github.com/ON-IT/Visma.Net)");
            HttpClient.DefaultRequestHeaders.ExpectContinue = false;
        }

        internal VismaNetHttpClient(VismaNetAuthorization auth = null)
        {
            _authorization = auth;
        }

        internal HttpRequestMessage PrepareMessage(HttpMethod method, string resource)
        {
            var message = new HttpRequestMessage(method, resource);
            if (_authorization != null)
            {
                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authorization.Token);
                message.Headers.Add("ipp-company-id", string.Format("{0}", _authorization.CompanyId));
                if (_authorization.BranchId > 0)
                    message.Headers.Add("branchid", _authorization.BranchId.ToString());
            }
            message.Headers.Add("ipp-application-type", VismaNetApiHelper.ApplicationType);
            message.Headers.Accept.Clear();
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(VismaNet.ApplicationName))
                message.Headers.Add("User-Agent",
                    $"Visma.Net/{VismaNet.Version} (+https://github.com/ON-IT/Visma.Net) ({VismaNet.ApplicationName})");
            return message;
        }


        internal async Task ForEachInStream<T>(string url, Func<T, Task> action) where T : DtoProviderBase
        {
            using (var result = await HttpClient.SendAsync(PrepareMessage(HttpMethod.Get, url),
                HttpCompletionOption.ResponseHeadersRead))
            using (var stream = await result.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            {
                foreach (var element in DeserializeSequenceFromJson<T>(reader))
                {
                    element.PrepareForUpdate();
                    await action(element);
                }
            }
        }

        internal async Task<T> Get<T>(string url)
        {
            url = url.Replace("http://", "https://"); // force https
            var result = await HttpClient.SendAsync(PrepareMessage(HttpMethod.Get, url));
            var stringData = await result.Content.ReadAsStringAsync();
            if (result.StatusCode != HttpStatusCode.OK)
            {
                VismaNetExceptionHandler.HandleException(stringData, null, null, url);
                return default(T);
            }
            if (string.IsNullOrEmpty(stringData))
                return default(T);

            return Deserialize<T>(stringData);
        }

        internal async Task<Stream> GetStream(string url)
        {
            url = url.Replace("http://", "https://"); // force https
            var result = await HttpClient.SendAsync(PrepareMessage(HttpMethod.Get, url));
            var streamData = await result.Content.ReadAsStreamAsync();
            if (result.StatusCode != HttpStatusCode.OK)
                VismaNetExceptionHandler.HandleException("Error downloading stream from Visma.net", null, null, url);
            return streamData;
        }

        internal async Task<T> PostMessage<T>(string url, HttpContent httpContent) where T : class
        {
            var message = PrepareMessage(HttpMethod.Post, url);
            message.Content = httpContent;
            var result = await HttpClient.SendAsync(message);
            if (!result.IsSuccessStatusCode)
                VismaNetExceptionHandler.HandleException(await result.Content.ReadAsStringAsync(), null, null, url);
            if (result.Headers.Location != null)
                if (typeof(T) == typeof(string))
                {
                    var absoluteUri = result.Headers.Location.AbsoluteUri;
                    return absoluteUri.Substring(absoluteUri.LastIndexOf("/", StringComparison.Ordinal) + 1) as T;
                }

            var content = await result.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(content))
                return JsonConvert.DeserializeObject<T>(content);

            return default(T);
        }

        internal async Task<T> Post<T>(string url, object data, string urlToGet = null)
        {
            using (var message = PrepareMessage(HttpMethod.Post, url))
            {
                var serialized = Serialize(data);
                message.Content = new StringContent(serialized, Encoding.UTF8, "application/json");

                var result = await HttpClient.SendAsync(message);

                if (result.Headers.Location != null)
                    if (urlToGet == null)
                    {
                        return await Get<T>(result.Headers.Location.AbsoluteUri);
                    }
                    else
                    {
                        var pattern = @".(.*)\/(.+)";
                        var substitution = @"$2";
                        var regex = new Regex(pattern);
                        var id = regex.Replace(result.Headers.Location.AbsoluteUri, substitution);
                        return await Get<T>($"{urlToGet}/{id}");
                    }
                if (result.StatusCode == HttpStatusCode.NoContent)
                    return await Get<T>(url);

                var stringData = await result.Content.ReadAsStringAsync();

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    VismaNetExceptionHandler.HandleException(stringData, null, serialized);
                    return default(T);
                }
                if (string.IsNullOrEmpty(stringData))
                    return default(T);
                try
                {
                    return Deserialize<T>(stringData);
                }
                catch (Exception e)
                {
                    throw new Exception("Could not serialize:" + Environment.NewLine + Environment.NewLine +
                                        stringData, e);
                }
            }
        }

        internal async Task<T> Put<T>(string url, object data, string urlToGet = null)
        {
            using (var message = PrepareMessage(HttpMethod.Put, url))
            {
                var serialized = Serialize(data);
                message.Content = new StringContent(serialized, Encoding.UTF8, "application/json");

                var result = await HttpClient.SendAsync(message);
                if (result.Headers.Location != null)
                    return await Get<T>(result.Headers.Location.AbsoluteUri);
                if (result.StatusCode == HttpStatusCode.NoContent)
                    if (urlToGet != null)
                        return await Get<T>(urlToGet);
                    else
                        return await Get<T>(url);
                var stringData = await result.Content.ReadAsStringAsync();
                if (result.StatusCode != HttpStatusCode.OK)
                {
                    VismaNetExceptionHandler.HandleException(stringData, null, serialized, url);
                    return default(T);
                }

                if (string.IsNullOrEmpty(stringData))
                    return default(T);
                return Deserialize<T>(stringData);
            }
        }

        private string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented, SerializerSettings);
        }

        private T Deserialize<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        // http://stackoverflow.com/a/24115672/491094
        internal static IEnumerable<T> DeserializeSequenceFromJson<T>(TextReader readerStream)
        {
            using (var reader = new JsonTextReader(readerStream))
            {
                var serializer = new JsonSerializer();
                if (!reader.Read() || reader.TokenType != JsonToken.StartArray)
                    throw new Exception("Expected start of array in the deserialized json string");

                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.EndArray) break;
                    var item = serializer.Deserialize<T>(reader);
                    yield return item;
                }
            }
        }

        public async Task<bool> Delete(string url)
        {
            var message = PrepareMessage(HttpMethod.Delete, url);
            var result = await HttpClient.SendAsync(message);
            return result.StatusCode == HttpStatusCode.NoContent;
        }
    }
}
