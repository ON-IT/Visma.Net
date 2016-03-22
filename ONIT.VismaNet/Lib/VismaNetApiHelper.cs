using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Models;
using ONIT.VismaNetApi.Models.Dimensions;

namespace ONIT.VismaNetApi.Lib
{
    internal static class VismaNetApiHelper
    {
        private const int MaxReturnableEntitiesFromVismaNet = 1000;
        internal const string ApplicationType = "Visma.net Financials";
        private const string BaseApiUrl = "https://integration.visma.net/API/";

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

        internal static async Task<string> GetToken(string username, string password, string clientId, string secret)
        {
            using (var webclient = GetHttpClient())
            {
                var url = GetApiUrlForController(VismaNetControllers.Token);
                try
                {
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("username", username),
                        new KeyValuePair<string, string>("password", password),
                        new KeyValuePair<string, string>("client_id", clientId),
                        new KeyValuePair<string, string>("client_secret", secret),
                        new KeyValuePair<string, string>("grant_type", "password"),
                    });
                    var data = await webclient.PostMessage<JObject>(url, content);
                    return data["token"].Value<string>();
                }
                catch (AggregateException exception)
                {
                    VismaNetExceptionHandler.HandleException(exception);
                    return null;
                }
            }
        }

        private static async Task<List<Customer>> GetCustomerDataTaskAsync(string url, List<Customer> listOfCustomer,
            VismaNetAuthorization auth)
        {
            using (var webClient = GetHttpClient(auth))
            {
                try
                {
                    return await webClient.Get<List<Customer>>(url);
                }
                catch (AggregateException e)
                {
                    VismaNetExceptionHandler.HandleException(e);
                    return null;
                }
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
                try
                {
                    var fullUrl = $"{apiUrl}/{customerCd}/invoice";
                    return await webclient.Get<List<CustomerInvoice>>(fullUrl);
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

        internal static async Task<List<DimensionSegment>> FetchDimension(string dimension,
            VismaNetAuthorization auth)
        {
            using (var webclient = GetHttpClient(auth))
            {
                var apiUrl = GetApiUrlForController(VismaNetControllers.Dimensions,
                    string.Format("/{0}", dimension.TrimStart('/')));
                try
                {
                    var container = await webclient.Get<DimensionContainer>(apiUrl);
                    return container.segments;
                }
                catch (AggregateException e)
                {
                    VismaNetExceptionHandler.HandleException(e);
                }
                catch (WebException e)
                {
                    VismaNetExceptionHandler.HandleException(e);
                }
            }
            return null;
        }

        private static int TryParseToInt(string value)
        {
            var val = 0;
            if (int.TryParse(value, out val))
            {
                return val;
            }
            return 0;
        }
        /*
        internal static async Task<List<CustomerDocument>> FetchAllCustomerDocumentsAsyncTask(
            VismaNetAuthorization authorization)
        {
            using (var webclient = GetHttpClient(authorization))
            {
                var endpoint = GetApiUrlForController(VismaNetControllers.CustomerDocument);
                var alldocuments = new List<CustomerDocument>();
                var count = 0;
                do
                {
                    try
                    {
                        if (alldocuments.Count > 0)
                        {
                            var maxId = alldocuments.Max(x => TryParseToInt(x.referenceNumber));
                            endpoint = GetApiUrlForController(VismaNetControllers.CustomerDocument,
                                parameters: new NameValueCollection
                                {
                                    {"greaterThanValue", $"{maxId}"},
                                    {"numberToRead", $"{MaxReturnableEntitiesFromVismaNet}"}
                                });
                        }
                        var batch = await webclient.Get<List<CustomerDocument>>(endpoint);
                        count = batch.Count;
                        alldocuments.AddRange(batch);
                    }
                    catch
                    {
                        count = 0;
                    }
                } while (count == MaxReturnableEntitiesFromVismaNet);
                return alldocuments;
            }
        }*/

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

        internal static async Task<bool> TestConnection(VismaNetAuthorization auth)
        {
            using (var webclient = GetHttpClient(auth))
            {
                // Just fetch endpoint to check if we are good. This is the smalles one we know.
                var endpoint = GetApiUrlForController(VismaNetControllers.Dimensions);
                try
                {
                    var response = await webclient.Get<List<string>>(endpoint);
                    if (response != null && response.Count > 0)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal static async Task<T> Create<T>(T entity, string apiControllerUri, VismaNetAuthorization authorization)
            where T : DtoProviderBase
        {
            using (var webclient = GetHttpClient(authorization))
            {
                var apiUrl = GetApiUrlForController(apiControllerUri);
                try
                {
                    return await webclient.Post<T>(apiUrl, entity.ToDto());
                }
                catch (AggregateException e)
                {
                    VismaNetExceptionHandler.HandleException(e);
                    return default(T);
                }
            }
        }

        internal static async Task Update<T>(T entity, string number, string apiControllerUri,
            VismaNetAuthorization authorization)
            where T : DtoProviderBase
        {
            using (var webclient = GetHttpClient(authorization))
            {
                var apiUrl = GetApiUrlForController(apiControllerUri, $"/{number}");
                try
                {
                    await webclient.Put<T>(apiUrl, entity.ToDto());
                }
                catch (AggregateException e)
                {
                    VismaNetExceptionHandler.HandleException(e);
                }
            }
        }

        internal static async Task<T> Get<T>(string entityNumber, string apiControllerUri,
            VismaNetAuthorization authorization)
        {
            using (var webclient = GetHttpClient(authorization))
            {
                var apiUrl = GetApiUrlForController(apiControllerUri, $"/{entityNumber}");
                try
                {
                    return await webclient.Get<T>(apiUrl);
                }
                catch (AggregateException e)
                {
                    VismaNetExceptionHandler.HandleException(e);
                    return default(T);
                }
            }
        }

        internal static IEnumerable<T> GetAllEnumerable<T>(string apiControllerUri, VismaNetAuthorization authorization)
            
        {
            using (var webclient = GetHttpClient(authorization))
                foreach (var entity in webclient.GetEnumerable<T>(GetApiUrlForController(apiControllerUri)))
                    yield return entity;
        }

        internal static async Task<List<T>> GetAll<T>(string apiControllerUri, VismaNetAuthorization authorization, NameValueCollection parameters = null)
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
                            {"LastModifiedDateTime", dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fff")},
                            {"LastModifiedDateTimeCondition", ">"}
                        });
                
                return await webclient.Get<List<T>>(endpoint);
                
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

        internal static async Task<List<CompanyContext>> GetContextsForToken(string token)
        {
            using (var client = GetHttpClient(new VismaNetAuthorization {CompanyId = 0, Token = token}))
            {
                return await client.Get<List<CompanyContext>>(GetApiUrlForController(VismaNetControllers.UserContexts));
            }
        }

        internal static async Task<string> AddAttachmentToInvoice(VismaNetAuthorization auth, string number, Stream stream,
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

        private class DimensionContainer
        {
            [JsonProperty]
            internal List<DimensionSegment> segments { get; set; }
        }

        public static async Task<List<Contact>> FetchContactsForSupplier(string supplierNumber, VismaNetAuthorization authorization)
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

        public static async Task<List<Contact>> FetchContactsForCustomer(string customerNumber, VismaNetAuthorization authorization)
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
    }
}