using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Exceptions;
using ONIT.VismaNetApi.Models;
using ONIT.VismaNetApi.Models.Dimensions;

namespace ONIT.VismaNetApi.Lib
{
    public static class VismaNetApiHelper
    {
        private const int MaxReturnableEntitiesFromVismaNet = 1000;
        internal const string ApplicationType = "Visma.net Financials";
        internal const string BaseApiUrl = "https://integration.visma.net/API/";

        public const string VismaNetDateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fff";

        private static string GetApiUrlForController(string controller, string append = null,
            NameValueCollection parameters = null)
        {
            var controllerUri = string.Format("{0}/{1}{2}",
                BaseApiUrl.TrimEnd('/'),
                controller.TrimStart('/'),
                !string.IsNullOrEmpty(append) ? string.Format("{0}", append) : string.Empty);

            if (parameters == null || parameters.Count == 0)
                return controllerUri;

            return string.Format("{0}{1}{2}",
                controllerUri,
                controllerUri.IndexOf('?') > -1 ? "&" : "?",
                parameters.ToQueryString());
        }

        private static string ToQueryString(this NameValueCollection nvc)
        {
            return string.Join("&",
                nvc.AllKeys.Distinct().Select(a => a + "=" + nvc[a]));
        }

        private static VismaNetHttpClient GetHttpClient(VismaNetAuthorization auth = null)
        {
            return new VismaNetHttpClient(auth);
        }

        internal static async Task<string> GetTokenOAuth(string clientId, string secret, string code,
            string redirect_uri)
        {
            using (var webclient = GetHttpClient())
            {
                var url = GetApiUrlForController(VismaNetControllers.Token);
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("code", code),
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("client_secret", secret),
                    new KeyValuePair<string, string>("redirect_uri", redirect_uri),
                    new KeyValuePair<string, string>("grant_type", "authorization_code")
                });
                var data = await webclient.PostMessage<JObject>(url, content);
                return data["token"].Value<string>();
            }
        }

        internal static async Task<string> GetToken(string username, string password, string clientId, string secret)
        {
            using (var webclient = GetHttpClient())
            {
                var url = GetApiUrlForController(VismaNetControllers.Token);
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("client_secret", secret),
                    new KeyValuePair<string, string>("grant_type", "password")
                });
                var data = await webclient.PostMessage<JObject>(url, content);
                return data["token"].Value<string>();
            }
        }

        private static async Task<List<Customer>> GetCustomerDataTaskAsync(string url, List<Customer> listOfCustomer,
            VismaNetAuthorization auth)
        {
            using (var webClient = GetHttpClient(auth))
            {
                return await webClient.Get<List<Customer>>(url);
            }
        }

        internal static string AppendToQuery(string query, string key, object value)
        {
            var divider = "?";
            if (query.IndexOf('?') > -1)
                divider = "&";
            return string.Format("{0}{1}{2}={3}", query, divider, key, value);
        }

        internal static IEnumerable<Customer> FindCustomers(IEnumerable<string> urlParams,
            VismaNetAuthorization authorization, string orderBy = null, int numberToRead = 0)
        {
            var listOfCustomers = new List<Customer>();
            var listOfTasks = new List<Task>();

            var parameters = new NameValueCollection();
            if (!string.IsNullOrEmpty(orderBy))
                parameters.Add("OrderBy", orderBy);
            if (numberToRead > 0)
                parameters.Add("NumberToRead", string.Format("{0}", numberToRead));

            if (urlParams == null)
            {
                var apiCallUrl = GetApiUrlForController(VismaNetControllers.Customers, parameters: parameters);
                listOfTasks.Add(GetCustomerDataTaskAsync(apiCallUrl, listOfCustomers, authorization));
            }
            else
            {
                foreach (var urlParameters in urlParams)
                {
                    var apiCallUrl = GetApiUrlForController(VismaNetControllers.Customers, urlParameters, parameters);
                    listOfTasks.Add(GetCustomerDataTaskAsync(apiCallUrl, listOfCustomers, authorization));
                }
            }
            try
            {
                Task.WaitAll(listOfTasks.ToArray());
            }
            catch (AggregateException e)
            {
                var webException = e.InnerException as WebException;
                if (webException != null)
                {
                    var response = webException.Response as HttpWebResponse;
                    if (response != null && response.StatusCode == HttpStatusCode.NotFound)
                        return new List<Customer>();
                    VismaNetExceptionHandler.HandleException(webException);
                }
            }
            return listOfCustomers;
        }

        internal static async Task<T> FetchVismaNetTypeFromUrl<T>(string url, VismaNetAuthorization authorization)
        {
            using (var webclient = GetHttpClient(authorization))
            {
                url = url.Replace("http://", "https://"); // force https.
                return await webclient.Get<T>(url);
            }
        }

        internal static async Task<List<CustomerInvoice>> FetchInvoicesForCustomerCd(string customerCd,
            VismaNetAuthorization authorization)
        {
            using (var webclient = GetHttpClient(authorization))
            {
                var apiUrl = GetApiUrlForController(VismaNetControllers.Customers);
                var fullUrl = $"{apiUrl}/{customerCd}/invoice";
                return await webclient.Get<List<CustomerInvoice>>(fullUrl);
            }
        }

        internal static async Task<List<DimensionSegment>> FetchDimension(string dimension,
            VismaNetAuthorization auth)
        {
            using (var webclient = GetHttpClient(auth))
            {
                var apiUrl = GetApiUrlForController(VismaNetControllers.Dimensions,
                    string.Format("/{0}", dimension.TrimStart('/')));
                var container = await webclient.Get<DimensionContainer>(apiUrl);
                return container.segments;
            }
        }

        public static async Task UpdateDimension(string dimension, DimensionSegment value,
            VismaNetAuthorization authorization)
        {
            using (var webclient = GetHttpClient(authorization))
            {
                var apiUrl = GetApiUrlForController(VismaNetControllers.Dimensions,
                    $"/{dimension.TrimStart('/')}/{value.GetIdentificator()}");
                await webclient.Put<DimensionSegment>(apiUrl, value);
            }
        }

        private static int TryParseToInt(string value)
        {
            var val = 0;
            if (int.TryParse(value, out val))
                return val;
            return 0;
        }

        internal static async Task<List<CustomerDocument>> FetchCustomerDocumentsForCustomerCd(string customerNumber,
            VismaNetAuthorization authorization)
        {
            using (var webclient = GetHttpClient(authorization))
            {
                var endpoint = GetApiUrlForController(VismaNetControllers.Customers);
                try
                {
                    endpoint = $"{endpoint}/{customerNumber}/documents";
                    var alldocuments = new List<CustomerDocument>();
                    int count;
                    do
                    {
                        try
                        {
                            var url = endpoint;
                            if (alldocuments.Count > 0)
                            {
                                var maxId = alldocuments.Max(x => TryParseToInt(x.referenceNumber));
                                url = AppendToQuery(endpoint, "greaterThanValue", maxId);
                            }
                            var batch = await webclient.Get<List<CustomerDocument>>(url);
                            count = batch.Count;
                            if (count == 0)
                                break;
                            alldocuments.AddRange(batch);
                        }
                        catch (Exception)
                        {
                            return alldocuments;
                        }
                    } while (count == MaxReturnableEntitiesFromVismaNet);
                    return alldocuments;
                }
                catch (AggregateException e)
                {
                    VismaNetExceptionHandler.HandleException(e);
                }
                catch (WebException e)
                {
                    VismaNetExceptionHandler.HandleException(e);
                }
                return null;
            }
        }

        internal static async Task<TestConnectionResponse> TestConnection(VismaNetAuthorization auth)
        {
            using (var webclient = GetHttpClient(auth))
            {
                // Just fetch endpoint to check if we are good. This is the smalles one we know.
                var endpoint = GetApiUrlForController(VismaNetControllers.Dimensions);
                try
                {
                    var response = await webclient.Get<List<string>>(endpoint);
                    if (response != null && response.Count > 0)
                        return TestConnectionResponse.Success;
                    return TestConnectionResponse.Unknown;
                }
                catch (InvalidTokenException)
                {
                    return TestConnectionResponse.InvalidToken;
                }
                catch (Exception)
                {
                    return TestConnectionResponse.Unknown;
                }
            }
        }

        internal static async Task<T> Create<T>(T entity, string apiControllerUri, VismaNetAuthorization authorization, string apiUriToGetFrom=null)
            where T : DtoProviderBase
        {
            using (var webclient = GetHttpClient(authorization))
            {
                var apiUrl = GetApiUrlForController(apiControllerUri);
                string apiGetUrl = null;
                if (apiUriToGetFrom != null)
                {
                    apiGetUrl = GetApiUrlForController(apiUriToGetFrom);
                }
                try
                {
                    return await webclient.Post<T>(apiUrl, entity.ToDto(), apiGetUrl);
                }
                catch (AggregateException e)
                {
                    VismaNetExceptionHandler.HandleException(e);
                    return default(T);
                }
            }
        }

        internal static async Task Update<T>(T entity, string number, string apiControllerUri,
            VismaNetAuthorization authorization, string numberToGet = null)
            where T : DtoProviderBase
        {
            using (var webclient = GetHttpClient(authorization))
            {
                var apiUrl = GetApiUrlForController(apiControllerUri, $"/{number}");
                if (numberToGet == null)
                {
                    await webclient.Put<T>(apiUrl, entity.ToDto());
                }
                else
                {
                    var apiUrlToGet = GetApiUrlForController(apiControllerUri, $"/{numberToGet}");
                    await webclient.Put<T>(apiUrl, entity.ToDto(),apiUrlToGet);
                }
            }
        }

        internal static async Task<T> Get<T>(string entityNumber, string apiControllerUri,
            VismaNetAuthorization authorization)
        {
            using (var webclient = GetHttpClient(authorization))
            {
                var apiUrl = GetApiUrlForController(apiControllerUri, $"/{entityNumber}");
                return await webclient.Get<T>(apiUrl);
            }
        }

        internal static IEnumerable<T> GetAllEnumerable<T>(string apiControllerUri, VismaNetAuthorization authorization)

        {
            using (var webclient = GetHttpClient(authorization))
            {
                foreach (var entity in webclient.GetEnumerable<T>(GetApiUrlForController(apiControllerUri)))
                    yield return entity;
            }
        }

        public static async Task ForEach<T>(string apiControllerUri, VismaNetAuthorization authorization,
            Func<T, Task> action, NameValueCollection parameters = null) where T : DtoProviderBase
        {
            using (var webclient = GetHttpClient(authorization))
            {
                var endpoint = GetApiUrlForController(apiControllerUri, parameters: parameters);
                await webclient.ForEachInStream(endpoint, action);
            }
        }

        internal static async Task<List<T>> GetAll<T>(string apiControllerUri, VismaNetAuthorization authorization,
            NameValueCollection parameters = null)
        {
            var listOfEntities = new List<T>();
            using (var webclient = GetHttpClient(authorization))
            {
                var endpoint = GetApiUrlForController(apiControllerUri, parameters: parameters);
                var entities = await webclient.Get<List<T>>(endpoint);
                listOfEntities.AddRange(entities);
                return listOfEntities;
            }
        }

        internal static async Task<List<T>> GetAllModifiedSince<T>(string apiControllerUri, DateTime dateTime,
            VismaNetAuthorization authorization)
        {
            using (var webclient = GetHttpClient(authorization))
            {
                var endpoint = GetApiUrlForController(apiControllerUri,
                    parameters: new NameValueCollection
                    {
                        {"LastModifiedDateTime", dateTime.ToString(VismaNetDateTimeFormat)},
                        {"LastModifiedDateTimeCondition", ">"}
                    });

                return await webclient.Get<List<T>>(endpoint);
            }
        }

        internal static async Task<VismaActionResult> PaymentAction(string paymentNumber, string action,
            VismaNetAuthorization authorization)
        {
            if (string.IsNullOrEmpty(paymentNumber)) throw new ArgumentException(nameof(paymentNumber));

            using (var client = GetHttpClient(authorization))
            {
                var actionUrl = GetApiUrlForController($"{VismaNetControllers.Payment}/{paymentNumber}/action/{action}");
                var obj = new ReleasePayment();
                obj.type = new DtoValue("Payment");
                return await client.Post<VismaActionResult>(actionUrl, obj);
            }
        }

        internal static async Task<VismaActionResult> InvoiceAction(string invoiceNumber, string action,
            VismaNetAuthorization authorization)
        {
            if (string.IsNullOrEmpty(invoiceNumber)) throw new ArgumentException(nameof(invoiceNumber));

            using (var client = GetHttpClient(authorization))
            {
                var actionUrl =
                    GetApiUrlForController($"{VismaNetControllers.CustomerInvoice}/{invoiceNumber}/action/{action}");
                return await client.Post<VismaActionResult>(actionUrl, new object());
            }
        }

        internal static async Task<VismaActionResult> ShipmentAction(string shipmentNumber, string action,
            VismaNetAuthorization authorization)
        {
            if (string.IsNullOrEmpty(shipmentNumber)) throw new ArgumentException(nameof(shipmentNumber));

            using (var client = GetHttpClient(authorization))
            {
                var actionUrl =
                    GetApiUrlForController($"{VismaNetControllers.Shipments}/{shipmentNumber}/action/{action}");
                return await client.Post<VismaActionResult>(actionUrl, new object());
            }
        }

        internal static async Task<Stream> ShipmentPrint(string shipmentNumber, string printName,
            VismaNetAuthorization authorization)
        {
            if (string.IsNullOrEmpty(shipmentNumber)) throw new ArgumentException(nameof(shipmentNumber));

            using (var client = GetHttpClient(authorization))
            {
                var printUrl =
                    GetApiUrlForController($"{VismaNetControllers.Shipments}/{shipmentNumber}/{printName}");
                return await client.GetStream(printUrl);
            }
        }

        internal static async Task<List<CompanyContext>> GetContextsForToken(string token)
        {
            using (var client = GetHttpClient(new VismaNetAuthorization {CompanyId = 0, Token = token}))
            {
                return await client.Get<List<CompanyContext>>(GetApiUrlForController(VismaNetControllers.UserContexts));
            }
        }

		internal static async Task<Stream> GetAttachment(VismaNetAuthorization auth, string attachmentid)
		{
			using (var client = GetHttpClient(auth))
			{
				var url = GetApiUrlForController(VismaNetControllers.Attachment, $"/{attachmentid}");
				return await client.GetStream(url);
			}
		}

        internal static async Task<string> AddAttachmentToInvoice(VismaNetAuthorization auth, string number,
            Stream stream,
            string fileName)
        {
            var url = GetApiUrlForController(VismaNetControllers.CustomerInvoice, $"/{number}/attachment");
            return await AddAttachmentToController<string>(auth, url, stream, fileName);
        }

        private static async Task<T> AddAttachmentToController<T>(VismaNetAuthorization auth, string url, Stream stream,
            string fileName) where T : class
        {
            using (var request = new MultipartContent())
            using (var streamContent = new StreamContent(stream))
            using (var client = GetHttpClient(auth))
            {
                streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileName
                };
                request.Add(streamContent);
                return await client.PostMessage<T>(url, request);
            }
        }

        public static async Task<List<Contact>> FetchContactsForSupplier(string supplierNumber,
            VismaNetAuthorization authorization)
        {
            using (var webclient = GetHttpClient(authorization))
            {
                var apiUrl = GetApiUrlForController(VismaNetControllers.Suppliers);
                try
                {
                    var fullUrl = $"{apiUrl}/{supplierNumber}/contact";
                    return await webclient.Get<List<Contact>>(fullUrl);
                }
                catch (AggregateException e)
                {
                    VismaNetExceptionHandler.HandleException(e);
                }
                catch (WebException e)
                {
                    VismaNetExceptionHandler.HandleException(e);
                }
                return null;
            }
        }

        public static async Task<List<Contact>> FetchContactsForCustomer(string customerNumber,
            VismaNetAuthorization authorization)
        {
            using (var webclient = GetHttpClient(authorization))
            {
                var apiUrl = GetApiUrlForController(VismaNetControllers.Customers);
                try
                {
                    var fullUrl = $"{apiUrl}/{customerNumber}/contact";
                    return await webclient.Get<List<Contact>>(fullUrl);
                }
                catch (AggregateException e)
                {
                    VismaNetExceptionHandler.HandleException(e);
                }
                catch (WebException e)
                {
                    VismaNetExceptionHandler.HandleException(e);
                }
                return null;
            }
        }

        public static async Task<List<InventorySummary>> FetchInventorySummaryForItem(string itemNo,
           VismaNetAuthorization authorization)
        {
            using (var webclient = GetHttpClient(authorization))
            {
                var apiUrl = GetApiUrlForController(VismaNetControllers.InventorySummary);
                try
                {
                    var fullUrl = $"{apiUrl}/{itemNo}";
                    return await webclient.Get<List<InventorySummary>>(fullUrl);
                }
                catch (AggregateException e)
                {
                    VismaNetExceptionHandler.HandleException(e);
                }
                catch (WebException e)
                {
                    VismaNetExceptionHandler.HandleException(e);
                }
                return null;
            }
        }

        private class DimensionContainer
        {
            [JsonProperty]
            internal List<DimensionSegment> segments { get; set; }
        }
    }
}