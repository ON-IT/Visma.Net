using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Exceptions;
using ONIT.VismaNetApi.Models;
using ONIT.VismaNetApi.Models.Dimensions;
using ONIT.VismaNetApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib
{
    public static class VismaNetApiHelper
    {
        private const int MaxReturnableEntitiesFromVismaNet = 1000;
        internal const string ApplicationType = "Visma.net Financials";
        internal const string BaseApiUrl = "https://integration.visma.net/API/";

        public const string VismaNetDateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fff";

        public static Task<bool> DeleteInvoice(string invoiceNumber, VismaNetAuthorization auth)
        {
            var url = GetApiUrlForController(VismaNetControllers.CustomerInvoice, $"/{invoiceNumber}");
            ;
            return GetHttpClient(auth)
                .Delete(url);
        }

        public static async Task<List<Contact>> FetchContactsForCustomer(string customerNumber,
            VismaNetAuthorization authorization)
        {
            var webclient = GetHttpClient(authorization);
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

        public static async Task<List<Contact>> FetchContactsForSupplier(string supplierNumber,
            VismaNetAuthorization authorization)
        {
            var webclient = GetHttpClient(authorization);
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

        public static async Task<List<ItemClass>> GetAllItemClasses(VismaNetAuthorization authorization)
        {
            var webclient = GetHttpClient(authorization);
            {
                var apiUrl = GetApiUrlForController(VismaNetControllers.Inventory);
                try
                {
                    var fullUrl = $"{apiUrl}/itemClass";
                    return await webclient.Get<List<ItemClass>>(fullUrl);
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

        public static async Task<List<CustomerSalesPrice>> FetchCustomerSalesPricesForItem(string itemNo,
            VismaNetAuthorization authorization, PriceType priceType = PriceType.Undefined)
        {
            var webclient = GetHttpClient(authorization);
            {
                var apiUrl = GetApiUrlForController(VismaNetControllers.CustomerSalesPrices);
                try
                {
                    string fullUrl = string.Empty;
                    if (priceType == PriceType.Undefined)
                    {
                        fullUrl = $"{apiUrl}?inventoryId={itemNo}";
                    }
                    else
                    {
                        fullUrl = $"{apiUrl}?priceType={priceType.ToString()}&inventoryId={itemNo}";
                    }

                    return await webclient.Get<List<CustomerSalesPrice>>(fullUrl);
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
            var webclient = GetHttpClient(authorization);
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

        public static async Task ForEach<T>(string apiControllerUri, VismaNetAuthorization authorization,
            Func<T, Task> action, NameValueCollection parameters = null) where T : DtoProviderBase
        {
            var webclient = GetHttpClient(authorization);
            {
                var endpoint = GetApiUrlForController(apiControllerUri, parameters: parameters);
                await webclient.ForEachInStream(endpoint, action);
            }
        }

        public static async Task UpdateDimension(string dimension, DimensionSegment value,
            VismaNetAuthorization authorization)
        {
            var webclient = GetHttpClient(authorization);
            {
                var apiUrl = GetApiUrlForController(VismaNetControllers.Dimensions,
                    $"/{dimension.TrimStart('/')}/{value.GetIdentificator()}");
                await webclient.Put<DimensionSegment>(apiUrl, value.ToDto());
            }
        }


        internal static Task<string> AddAttachmentToInvoice(VismaNetAuthorization auth, string number,
            byte[] bytes,
            string fileName)
        {
            var url = GetApiUrlForController(VismaNetControllers.CustomerInvoice, $"/{number}/attachment");
            return AddAttachmentToController<string>(auth, url, bytes, fileName);
        }

        internal static Task<string> AddAttachmentToInvoice(VismaNetAuthorization auth, string number,
            Stream stream,
            string fileName)
        {
            var url = GetApiUrlForController(VismaNetControllers.CustomerInvoice, $"/{number}/attachment");
            return AddAttachmentToController<string>(auth, url, stream, fileName);
        }

        internal static Task<string> AddAttachmentToCreditNote(VismaNetAuthorization auth, string number,
            byte[] bytes,
            string fileName)
        {
            var url = GetApiUrlForController(VismaNetControllers.CustomerCreditNote, $"/{number}/attachment");
            return AddAttachmentToController<string>(auth, url, bytes, fileName);
        }

        internal static Task<string> AddAttachmentToCreditNote(VismaNetAuthorization auth, string number,
            Stream stream,
            string fileName)
        {
            var url = GetApiUrlForController(VismaNetControllers.CustomerCreditNote, $"/{number}/attachment");
            return AddAttachmentToController<string>(auth, url, stream, fileName);
        }

        internal static Task<string> AddAttachmentToSupplierInvoice(VismaNetAuthorization auth, string number,
            byte[] bytes,
            string fileName)
        {
            var url = GetApiUrlForController(VismaNetControllers.SupplierInvoices, $"/{number}/attachment");
            return AddAttachmentToController<string>(auth, url, bytes, fileName);
        }

        internal static Task<string> AddAttachmentToJournalTransaction(VismaNetAuthorization auth, string batch,
            byte[] bytes,
            string fileName,
            JournalTransactionModule module = JournalTransactionModule.ModuleGL)
        {

            var url = GetApiUrlForController(VismaNetControllers.JournalTransactionV2, $"/module/{module.ToString().Substring(6)}/{batch}/attachment");
            return AddAttachmentToController<string>(auth, url, bytes, fileName);
        }

        internal static string AppendToQuery(string query, string key, object value)
        {
            var divider = "?";
            if (query.IndexOf('?') > -1)
                divider = "&";
            return $"{query}{divider}{key}={value}";
        }

        internal static async Task<T> Create<T>(T entity, string apiControllerUri, VismaNetAuthorization authorization,
            string apiUriToGetFrom = null)
            where T : DtoProviderBase
        {
            var webclient = GetHttpClient(authorization);
            {
                var apiUrl = GetApiUrlForController(apiControllerUri);
                string apiGetUrl = null;
                if (apiUriToGetFrom != null)
                    apiGetUrl = GetApiUrlForController(apiUriToGetFrom);
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

        internal static async Task<List<CustomerDocument>> FetchCustomerDocumentsForCustomerCd(string customerNumber,
            VismaNetAuthorization authorization)
        {
            var webclient = GetHttpClient(authorization);
            {
                var endpoint = GetApiUrlForController(VismaNetControllers.Customers);
                try
                {
                    var url = $"{endpoint}/{customerNumber}/document";
                    return await webclient.Get<List<CustomerDocument>>(url);
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
            var webClient = GetHttpClient(auth);
            {
                var apiUrl = GetApiUrlForController(VismaNetControllers.Dimensions, $"/{dimension.TrimStart('/')}");
                var container = await webClient.Get<DimensionContainer>(apiUrl);
                return container.segments;
            }
        }

        internal static async Task<List<ExchangeRate>> FetchExchangeRates(string toCurrencyId, DateTime effectiveDate, VismaNetAuthorization auth)
        {
            var webClient = GetHttpClient(auth);
            {
                var apiUrl = GetApiUrlForController(VismaNetControllers.CurrencyRate, $"?toCurrency={toCurrencyId.TrimStart('/')}&fromDate={effectiveDate.ToString("yyyy-MM-dd")}&toDate={effectiveDate.ToString("yyyy-MM-dd")}");
                return await webClient.Get<List<ExchangeRate>>(apiUrl);
            }
        }

        internal static async Task<List<ExchangeRate>> AddExchangeRate(ExchangeRate exchangeRate, VismaNetAuthorization auth)
        {
            var webClient = GetHttpClient(auth);
            {
                var apiUrl = GetApiUrlForController(VismaNetControllers.CurrencyRate, $"/");
                return await webClient.Post<List<ExchangeRate>>(apiUrl, exchangeRate.ToDto(), $"{GetApiUrlForController(VismaNetControllers.CurrencyRate)}?toCurrency={exchangeRate.toCurrencyId.TrimStart('/')}&fromDate={exchangeRate.effectiveDate.ToString("yyyy-MM-dd")}&toDate={exchangeRate.effectiveDate.ToString("yyyy-MM-dd")}", true);
            }
        }

        internal static async Task<List<ExchangeRate>> UpdateExchangeRate(ExchangeRate exchangeRate, VismaNetAuthorization auth)
        {
            var webClient = GetHttpClient(auth);
            {
                var apiUrl = GetApiUrlForController(VismaNetControllers.CurrencyRate, $"/");
                return await webClient.Put<List<ExchangeRate>>(apiUrl, exchangeRate.ToDto(), $"{GetApiUrlForController(VismaNetControllers.CurrencyRate)}?toCurrency={exchangeRate.toCurrencyId.TrimStart('/')}&fromDate={exchangeRate.effectiveDate.ToString("yyyy-MM-dd")}&toDate={exchangeRate.effectiveDate.ToString("yyyy-MM-dd")}", true);
            }
        }


        internal static async Task<List<CustomerInvoice>> FetchInvoicesForCustomerCd(string customerCd,
            VismaNetAuthorization authorization)
        {
            var webclient = GetHttpClient(authorization);
            {
                var apiUrl = GetApiUrlForController(VismaNetControllers.Customers);
                var fullUrl = $"{apiUrl}/{customerCd}/invoice";
                return await webclient.Get<List<CustomerInvoice>>(fullUrl) ?? new List<CustomerInvoice>();
            }
        }

        internal static async Task<T> FetchVismaNetTypeFromUrl<T>(string url, VismaNetAuthorization authorization)
        {
            var webclient = GetHttpClient(authorization);
            {
                url = url.Replace("http://", "https://"); // force https.
                return await webclient.Get<T>(url);
            }
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
                parameters.Add("NumberToRead", $"{numberToRead}");

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
                if (e.InnerException is WebException webException)
                {
                    if (webException.Response is HttpWebResponse response &&
                        response.StatusCode == HttpStatusCode.NotFound)
                        return new List<Customer>();
                    VismaNetExceptionHandler.HandleException(webException);
                }
            }

            return listOfCustomers;
        }

        internal static async Task<T> Get<T>(string entityNumber, string apiControllerUri,
            VismaNetAuthorization authorization, string numberToGet = null)
        {
            var webclient = GetHttpClient(authorization);
            {
                if (entityNumber == null && numberToGet == null)
                {
                    var apiUrl = GetApiUrlForController(apiControllerUri, string.Empty);
                    return await webclient.Get<T>(apiUrl);
                }
                else if (numberToGet == null)
                {
                    var apiUrl = GetApiUrlForController(apiControllerUri, $"/{entityNumber}");
                    return await webclient.Get<T>(apiUrl);
                }
                else
                {
                    var apiUrl = GetApiUrlForController(apiControllerUri, $"/{numberToGet}");
                    return await webclient.Get<T>(apiUrl);
                }
            }
        }

        internal static async Task<List<T>> GetAll<T>(string apiControllerUri, VismaNetAuthorization authorization,
            NameValueCollection parameters = null)
        {
            var webclient = GetHttpClient(authorization);
            var endpoint = GetApiUrlForController(apiControllerUri, parameters: parameters);
            return await webclient.Get<List<T>>(endpoint);
        }

        internal static async Task<T> GetAllAsDefined<T>(string apiControllerUri, VismaNetAuthorization authorization,
            NameValueCollection parameters = null)
        {
            var webclient = GetHttpClient(authorization);
            var endpoint = GetApiUrlForController(apiControllerUri, parameters: parameters);
            return await webclient.Get<T>(endpoint);
        }

        private static NameValueCollection CreatePagionationParameters(int pageSize, int page, NameValueCollection parameters)
        {
            var pagination = new NameValueCollection {
                    { "pageSize", pageSize.ToString() },
                    { "pageNumber", page.ToString() }
                };

            if (parameters != null)
            {
                var nvc = new NameValueCollection(parameters);
                return nvc.Join(pagination);
            }

            return pagination;
        }

        public static NameValueCollection Join(this NameValueCollection destination, NameValueCollection source)
        {
            if (source == null)
                return destination;
            foreach (var key in source.AllKeys)
                destination[key] = source[key];
            return destination;
        }

        const int initialPageSize = 1000;
        public static async Task<List<T>> GetAllWithPagination<T>(string ApiControllerUri, VismaNetAuthorization Authorization, NameValueCollection parameters = null) where T : DtoPaginatedProviderBase, IProvideIdentificator
        {
            var firstPage = await GetAll<T>(ApiControllerUri, Authorization, CreatePagionationParameters(initialPageSize, 1, parameters));
            var rsp = new List<T>();
            if (firstPage == null)
                return rsp;
            rsp.AddRange(firstPage);
            var count = firstPage.Sum(x => x.GetSubCount());
            if (firstPage.FirstOrDefault()?.metadata?.totalCount > count && count > 0)
            {
                var totalCount = firstPage[0].metadata.totalCount;
                var pageSize = count;
                var pageCount = totalCount / pageSize;
                var semaphore = new SemaphoreSlim(VismaNet.MaxConcurrentRequests);
                var taskList = new List<Task<List<T>>>();
                foreach (var page in Enumerable.Range(2, pageCount))
                {
                    await semaphore.WaitAsync();
                    taskList.Add(Task.Run(async () =>
                    {
                        try
                        {
                            return await GetAll<T>(ApiControllerUri, Authorization, CreatePagionationParameters(pageSize, page, parameters));
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    }));
                }
                var tasks = await Task.WhenAll(taskList);
                rsp.AddRange(tasks.SelectMany(x => x));
            }
            rsp.ForEach(x => x.InternalPrepareForUpdate());
            return rsp.OrderBy(x => x.GetIdentificator()).ToList();
        }

        internal static Task<List<T>> GetAllAsyncTask<T>(string apiControllerUri, VismaNetAuthorization authorization,
            NameValueCollection parameters = null)
        {
            var webclient = GetHttpClient(authorization);
            var endpoint = GetApiUrlForController(apiControllerUri, parameters: parameters);
            return webclient.Get<List<T>>(endpoint);
        }

        internal static async Task<List<T>> GetAllModifiedSince<T>(string apiControllerUri, DateTime dateTime,
            VismaNetAuthorization authorization)
        {
            var webclient = GetHttpClient(authorization);
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

        internal static async Task<Stream> GetStream(string apiControllerUri, VismaNetAuthorization authorization)
        {
            var client = GetHttpClient(authorization);
            {
                var endpoint = GetApiUrlForController(apiControllerUri);

                return await client.GetStream(endpoint);
            }
        }

        internal static async Task<Stream> GetAttachment(VismaNetAuthorization auth, string attachmentid)
        {
            var client = GetHttpClient(auth);
            {
                var url = GetApiUrlForController(VismaNetControllers.Attachment, $"/{attachmentid}");
                return await client.GetStream(url);
            }
        }

        internal static async Task<List<CompanyContext>> GetContextsForToken(string token)
        {
            var client = GetHttpClient(new VismaNetAuthorization { CompanyId = 0, Token = token });
            {
                return await client.Get<List<CompanyContext>>(GetApiUrlForController(VismaNetControllers.UserContext));
            }
        }

        internal static async Task<string> GetToken(string username, string password, string clientId, string secret)
        {
            var webclient = GetHttpClient();
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

        internal static async Task<string> GetTokenOAuth(string clientId, string secret, string code,
            string redirect_uri)
        {
            var webclient = GetHttpClient();
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

        public static async Task<VismaConnectToken> GetTokenFromVismaConnect(string clientId, string secret, string tenant_id, string scope = "vismanet_erp_service_api:create vismanet_erp_service_api:delete vismanet_erp_service_api:read vismanet_erp_service_api:update")
        {
            try
            {
                var webclient = GetHttpClient(new VismaNetAuthorization());
                {
                    var url = VismaNetControllers.VismaConnectToken;
                    var content = new FormUrlEncodedContent(new[]
                    {
                    new KeyValuePair<string, string>("client_id", clientId),
                    new KeyValuePair<string, string>("client_secret", secret),
                    new KeyValuePair<string, string>("tenant_id", tenant_id),
                    new KeyValuePair<string, string>("scope", scope),
                    new KeyValuePair<string, string>("grant_type", "client_credentials")
                });
                    var data = await webclient.PostMessageVismaConnect(url, content);

                    
                    return new VismaConnectToken { access_token = data["access_token"].Value<string>(), expires_on = DateTimeOffset.UtcNow.AddSeconds(data["expires_in"].Value<int>()) };
                }
            } catch (Exception ex) 
            {
                throw ex;
            }
        }

        internal static async Task<VismaActionResult> InvoiceAction(string invoiceNumber, string action,
            VismaNetAuthorization authorization)
        {
            if (string.IsNullOrEmpty(invoiceNumber)) throw new ArgumentException(nameof(invoiceNumber));

            var client = GetHttpClient(authorization);
            var actionUrl =
                GetApiUrlForController($"{VismaNetControllers.CustomerInvoice}/{invoiceNumber}/action/{action}");
            return await client.Post<VismaActionResult>(actionUrl, new object());
        }

        internal static async Task<VismaActionResult> Action(VismaNetAuthorization authorization, string controller, string entityNumber, string actionName, object dto = null)
        {
            var client = GetHttpClient(authorization);
            var actionUrl = GetApiUrlForController($"{controller}/{entityNumber}/action/{actionName}");
            return await client.Post<VismaActionResult>(actionUrl, dto ?? new object());
        }

        internal static async Task<BackgroundStatus> BackgroundAction(VismaNetAuthorization authorization, string controller, string entityNumber, string actionName, string erpApiBackground, object dto = null)
        {
            var client = GetHttpClient(authorization);
            var actionUrl = GetApiUrlForController($"{controller}/{entityNumber}/action/{actionName}");
            return await client.Post<BackgroundStatus>(actionUrl, dto ?? new object(), erpApiBackground: erpApiBackground);
        }

        internal static async Task<CreateShipmentActionResult> CreateShipmentAction(VismaNetAuthorization authorization, string controller, string entityNumber, string actionName, object dto = null)
        {
            var client = GetHttpClient(authorization);
            var actionUrl = GetApiUrlForController($"{controller}/{entityNumber}/action/{actionName}");
            return await client.Post<CreateShipmentActionResult>(actionUrl, dto ?? new object());
        }

        internal static async Task<Stream> InvoicePrint(string RefNr, VismaNetAuthorization authorization)
        {
            if (string.IsNullOrEmpty(RefNr)) throw new ArgumentException(nameof(RefNr));

            var client = GetHttpClient(authorization);
            {
                var printUrl =
                    GetApiUrlForController($"{VismaNetControllers.CustomerInvoice}/{RefNr}/print");
                return await client.GetStream(printUrl);
            }
        }

        internal static async Task<VismaActionResult> PaymentAction(string paymentNumber, string action,
            VismaNetAuthorization authorization)
        {
            if (string.IsNullOrEmpty(paymentNumber)) throw new ArgumentException(nameof(paymentNumber));

            var client = GetHttpClient(authorization);
            {
                var actionUrl =
                    GetApiUrlForController($"{VismaNetControllers.Payment}/{paymentNumber}/action/{action}");
                var obj = new ReleasePayment();
                obj.type = new DtoValue("Payment");
                return await client.Post<VismaActionResult>(actionUrl, obj);
            }
        }

        internal static async Task<VismaActionResult> ShipmentAction(string shipmentNumber, string action,
            VismaNetAuthorization authorization)
        {
            if (string.IsNullOrEmpty(shipmentNumber)) throw new ArgumentException(nameof(shipmentNumber));

            var client = GetHttpClient(authorization);
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

            var client = GetHttpClient(authorization);
            {
                var printUrl =
                    GetApiUrlForController($"{VismaNetControllers.Shipments}/{shipmentNumber}/{printName}");
                return await client.GetStream(printUrl);
            }
        }

        internal static async Task<TestConnectionResponse> TestConnection(VismaNetAuthorization auth)
        {
            var webClient = GetHttpClient(auth);
            {
                // Just fetch endpoint to check if we are good. This is the smalles one we know.
                var endpoint = GetApiUrlForController(VismaNetControllers.Dimensions);
                try
                {
                    var response = await webClient.Get<List<string>>(endpoint);
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

        internal static async Task Update<T>(T entity, string number, string apiControllerUri,
            VismaNetAuthorization authorization, string numberToGet = null)
            where T : DtoProviderBase
        {
            var webclient = GetHttpClient(authorization);
            {
                var apiUrl = GetApiUrlForController(apiControllerUri, $"/{number}");
                if (numberToGet == null)
                {
                    await webclient.Put<T>(apiUrl, entity.ToDto());
                }
                else
                {
                    var apiUrlToGet = GetApiUrlForController(apiControllerUri, $"/{numberToGet}");
                    await webclient.Put<T>(apiUrl, entity.ToDto(), apiUrlToGet);
                }
            }
        }

        internal static async Task AddAttachment(VismaNetAuthorization authorization, string controller, string entityNumber, byte[] bytes, string fileName)
        {
            var url = GetApiUrlForController(controller, $"/{entityNumber}/attachment");
            var client = GetHttpClient(authorization);

            var content = new ByteArrayContent(bytes);
            content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                FileName = fileName,
                Name = "v"
            };
            var request = new MultipartFormDataContent
            {
                content
            };
            await client.PostMessage<object>(url, request);
        }

        internal static async Task<T> AddAttachmentToController<T>(VismaNetAuthorization auth, string url, byte[] bytes,
            string fileName) where T : class
        {
            using (var stream = new MemoryStream(bytes))
            {
                return await AddAttachmentToController<T>(auth, url, stream, fileName);
            }
        }

        internal static async Task<T> AddAttachmentToController<T>(VismaNetAuthorization auth, string url, Stream input,
            string fileName) where T : class
        {
            var client = GetHttpClient(auth);
            input.Seek(0, SeekOrigin.Begin);
            using (var stream = new MemoryStream())
            {
                await input.CopyToAsync(stream);
                stream.Seek(0, SeekOrigin.Begin);
                var content = new StreamContent(stream);
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    FileName = fileName,
                    Name = "v"
                };
                var request = new MultipartFormDataContent
                {
                    content
                };
                return await client.PostMessage<T>(url, request);
            }
        }

        internal static string GetApiUrlForController(string controller, string append = null,
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

        private static async Task<List<Customer>> GetCustomerDataTaskAsync(string url, List<Customer> listOfCustomer,
            VismaNetAuthorization auth)
        {
            var webClient = GetHttpClient(auth);
            {
                return await webClient.Get<List<Customer>>(url);
            }
        }

        private static VismaNetHttpClient GetHttpClient(VismaNetAuthorization auth = null)
        {
            return new VismaNetHttpClient(auth);
        }

        private static string ToQueryString(this NameValueCollection nvc)
        {
            return string.Join("&",
                nvc.AllKeys.Distinct().Select(a => a + "=" + nvc[a]));
        }

        private static int TryParseToInt(string value)
        {
            if (int.TryParse(value, out var val))
                return val;
            return 0;
        }

        private class DimensionContainer
        {
            [JsonProperty] internal List<DimensionSegment> segments { get; set; }
        }
    }
}