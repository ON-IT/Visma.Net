using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib
{
    internal class VismaNetHttpClient : IDisposable
    {
        private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            DateFormatString = "yyyy-MM-dd HH:mm:ss",
            Converters =
            {
                new StringEnumConverter()
            }
        };

        private static readonly HttpClient httpClient;

        private readonly VismaNetAuthorization authorization;

        static VismaNetHttpClient()
        {
            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
                handler.AutomaticDecompression = DecompressionMethods.GZip |
                                                 DecompressionMethods.Deflate;
            handler.UseCookies = false;
            httpClient = new HttpClient(handler, true);
            httpClient.Timeout = TimeSpan.FromSeconds(300);
            httpClient.DefaultRequestHeaders.Add("User-Agent",
                $"Visma.Net/{VismaNet.Version} (+https://github.com/ON-IT/Visma.Net)");
            httpClient.DefaultRequestHeaders.ExpectContinue = false;
        }

        internal VismaNetHttpClient(VismaNetAuthorization auth = null)
        {
            authorization = auth;
        }

        #region IDisposable implementation

        public void Dispose()
        {
            // http://stackoverflow.com/questions/11178220/is-httpclient-safe-to-use-concurrently
            //if (httpClient != null)
            //    httpClient.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion

        internal HttpRequestMessage PrepareMessage(HttpMethod method, string resource)
        {
            var message = new HttpRequestMessage(method, resource);
            if (authorization != null)
            {
                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authorization.Token);
                message.Headers.Add("ipp-company-id", string.Format("{0}", authorization.CompanyId));
                if (authorization.BranchId > 0)
                    message.Headers.Add("branchid", authorization.BranchId.ToString());
            }
            message.Headers.Add("ipp-application-type", VismaNetApiHelper.ApplicationType);
            message.Headers.Accept.Clear();
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(VismaNet.ApplicationName))
                message.Headers.Add("User-Agent",
                    $"Visma.Net/{VismaNet.Version} (+https://github.com/ON-IT/Visma.Net) ({VismaNet.ApplicationName})");
            return message;
        }

        internal WebRequest prepareWebRequest(HttpMethod method, string resource)
        {
            var message = (HttpWebRequest) WebRequest.Create(resource);
            message.Method = method.Method;

            message.AutomaticDecompression = DecompressionMethods.GZip |
                                             DecompressionMethods.Deflate;

            if (authorization != null)
            {
                message.Headers["Authorization"] = string.Format("Bearer {0}", authorization.Token);
                message.Headers["ipp-company-id"] = string.Format("{0}", authorization.CompanyId);
                if (authorization.BranchId > 0)
                    message.Headers["branchid"] = authorization.BranchId.ToString();
            }
            message.Headers["ipp-application-type"] = VismaNetApiHelper.ApplicationType;
            message.Accept = "application/json";
            message.ContentType = "application/json";
            return message;
        }


        //internal IEnumerable<T> GetEnumerable2<T>(string url)
        //{
        //    HttpResponseMessage result = Task.Run(async () => await httpClient.SendAsync(PrepareMessage(HttpMethod.Get, url), HttpCompletionOption.ResponseHeadersRead)).Result;
        //    Stream stream = Task.Run(async () => await result.Content.ReadAsStreamAsync()).Result;
        //    if (result.StatusCode != HttpStatusCode.OK)
        //    {
        //        throw new Exception("Could not read from Visma.net");
        //    }

        //    using (var reader = new StreamReader(stream, Encoding.Default, true))
        //        foreach (T element in DeserializeSequenceFromJson<T>(reader))
        //            yield return element;
        //}

        internal async Task ForEachInStream<T>(string url, Func<T, Task> action) where T : DtoProviderBase
        {
            using (var result = await httpClient.SendAsync(PrepareMessage(HttpMethod.Get, url),
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

        internal IEnumerable<T> GetEnumerable<T>(string url)
        {
            var request = prepareWebRequest(HttpMethod.Get, url);
            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream(), Encoding.Default, true))
            {
                foreach (var element in DeserializeSequenceFromJson<T>(reader))
                    yield return element;
            }
        }

        internal async Task<T> Get<T>(string url)
        {
            url = url.Replace("http://", "https://"); // force https
            var result = await httpClient.SendAsync(PrepareMessage(HttpMethod.Get, url));
            var stringData = await result.Content.ReadAsStringAsync();
            if (result.StatusCode != HttpStatusCode.OK)
            {
                VismaNetExceptionHandler.HandleException(stringData);
                return default(T);
            }
            if (string.IsNullOrEmpty(stringData))
                return default(T);

			return await Deserialize<T>(stringData);
        }

		internal async Task<Stream> GetStream(string url)
		{
			url = url.Replace("http://", "https://"); // force https
			var result = await httpClient.SendAsync(PrepareMessage(HttpMethod.Get, url));
			var streamData = await result.Content.ReadAsStreamAsync();
			if (result.StatusCode != HttpStatusCode.OK)
			{
				throw new Exception("Error downloading stream");
			}
			return streamData;

		}

		internal async Task<T> PostMessage<T>(string url, HttpContent httpContent) where T : class
        {
            var message = PrepareMessage(HttpMethod.Post, url);
            using (message.Content = httpContent)
            {
                var result = await httpClient.SendAsync(message);
                if (!result.IsSuccessStatusCode)
                    VismaNetExceptionHandler.HandleException(await result.Content.ReadAsStringAsync());
                if (result.Headers.Location != null)
                    if (typeof(T) == typeof(string))
                    {
                        var absoluteUri = result.Headers.Location.AbsoluteUri;
                        return absoluteUri.Substring(absoluteUri.LastIndexOf("/") + 1) as T;
                    }

                var content = await result.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(content))
                    return JsonConvert.DeserializeObject<T>(content);

                return default(T);
            }
        }

        internal async Task<T> Post<T>(string url, object data)
        {
            var message = PrepareMessage(HttpMethod.Post, url);
            using (message.Content = new StringContent(await Serialize(data), Encoding.UTF8, "application/json"))
            {
                var result = await httpClient.SendAsync(message);

                if (result.Headers.Location != null)
                    return await Get<T>(result.Headers.Location.AbsoluteUri);
                if (result.StatusCode == HttpStatusCode.NoContent)
                    return await Get<T>(url);

                var stringData = await result.Content.ReadAsStringAsync();

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    VismaNetExceptionHandler.HandleException(stringData);
                    return default(T);
                }
                if (string.IsNullOrEmpty(stringData))
                    return default(T);
                try
                {
                    return await Deserialize<T>(stringData);
                }
                catch (Exception)
                {
                    throw new Exception("Could not serialize:" + Environment.NewLine + Environment.NewLine +
                                        stringData);
                }
            }
        }

        internal async Task<T> Put<T>(string url, object data, string urlToGet=null)
        {
            var message = PrepareMessage(HttpMethod.Put, url);
            using (var content = new StringContent(await Serialize(data), Encoding.UTF8, "application/json"))
            {
                message.Content = content;
                var result = await httpClient.SendAsync(message);
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
                    VismaNetExceptionHandler.HandleException(stringData);
                    return default(T);
                }

                if (string.IsNullOrEmpty(stringData))
                    return default(T);
                return await Deserialize<T>(stringData);
            }
        }

        private async Task<string> Serialize(object obj)
        {
            return
                await
                    Task.Factory.StartNew(() => JsonConvert.SerializeObject(obj, Formatting.None, _serializerSettings));
        }

        private async Task<T> Deserialize<T>(string str)
        {
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(str));
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
    }
}