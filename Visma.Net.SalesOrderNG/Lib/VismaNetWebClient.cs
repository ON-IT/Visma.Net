using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Converters;
using System.Threading;


namespace Visma.Net.SalesOrderNG.Lib
{
    public class RetryHandler : DelegatingHandler
    {
        // Strongly consider limiting the number of retries - "retry forever" is
        // probably not the most user friendly way you could respond to "the
        // network cable got pulled out."
        private readonly int MaxRetries = ClientSalesOrderV3.MaxRetries;

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
                if (response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return response;
                }
                System.Diagnostics.Debug.WriteLine($"[{i}/{MaxRetries}] {response.StatusCode} {response.ReasonPhrase}");
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

        private static readonly HttpClient HttpClientStatic;

        private readonly Helpers.VismaNetAuthorization _authorization;

        private HttpClient HttpClient => _authorization.HttpClient ?? HttpClientStatic;

        static VismaNetHttpClient()
        {
            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
                handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip |
                                                 System.Net.DecompressionMethods.Deflate;
            handler.UseCookies = false;
#if NET45
#else
            handler.MaxConnectionsPerServer = ClientSalesOrderV3.MaxConcurrentRequests;
#endif

            HttpClientStatic = new HttpClient(new RetryHandler(handler), false)
            {
                Timeout = TimeSpan.FromSeconds(1200)
            };
        }

        internal VismaNetHttpClient(Helpers.VismaNetAuthorization auth = null)
        {
            _authorization = auth;
        }

        internal HttpRequestMessage PrepareMessage(HttpMethod method, string resource)
        {
            var message = new HttpRequestMessage(method, resource);
            if (_authorization != null)
            {
                if (_authorization.VismaConnectClientId != null) // new auth via Visma Connect
                {
                    // Check for token expired ( 5 minutes grace )
                    if (_authorization.VismaConnectToken == null || _authorization.VismaConnectTokenExpire.AddMinutes(-5) > DateTimeOffset.UtcNow)
                    {
                        var vToken = VismaNetApiHelper.GetTokenFromVismaConnect(_authorization.VismaConnectClientId, _authorization.VismaConnectClientSecret, _authorization.VismaConnectTenantId, _authorization.VismaConnectScopes).Result;
                        _authorization.VismaConnectToken = vToken.access_token;
                        _authorization.VismaConnectTokenExpire = vToken.expires_on;
                    }
                    message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authorization.VismaConnectToken);
                }
                else
                {
                    message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authorization.Token);
                    message.Headers.Add("ipp-company-id", string.Format("{0}", _authorization.CompanyId));
                    if (_authorization.BranchId > 0)
                        message.Headers.Add("branchid", _authorization.BranchId.ToString());
                }
            }
            message.Headers.Add("ipp-application-type", VismaNetApiHelper.ApplicationType);
            message.Headers.ExpectContinue = false;
            message.Headers.Accept.Clear();
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(ClientSalesOrderV3._ApplicationName))
            {
                message.Headers.Add("User-Agent",
                        $"Visma.Net/{ClientSalesOrderV3.Version} (+https://github.com/ON-IT/Visma.Net) ({ClientSalesOrderV3._ApplicationName})");
            }
            else
            {
                message.Headers.Add("User-Agent", $"Visma.Net/{ClientSalesOrderV3.Version} (+https://github.com/ON-IT/Visma.Net)");
            }
            return message;
        }

        internal async Task<JObject> PostMessageVismaConnect(string url, HttpContent httpContent)
        {
            var message = PrepareMessage(HttpMethod.Post, url);
            message.Content = httpContent;
            var result = await HttpClient.SendAsync(message);
            string content = await result.Content.ReadAsStringAsync();
            JObject jsonObj = null;
            if (!string.IsNullOrEmpty(content))
                jsonObj = JsonConvert.DeserializeObject<JObject>(content);

            if (!result.IsSuccessStatusCode)
            {
                if (!string.IsNullOrEmpty(content))
                {
                    throw new Exceptions.VismaConnectException($"Error: {jsonObj["error"].Value<string>()}, statuscode: {(int)result.StatusCode} {result.ReasonPhrase}", content);
                }
                else
                {
                    throw new Exceptions.VismaConnectException($"Unknown error, statuscode: {(int)result.StatusCode} {result.ReasonPhrase}");
                }

            }
            else
            {
                return jsonObj;
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
            return result.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    }
}
