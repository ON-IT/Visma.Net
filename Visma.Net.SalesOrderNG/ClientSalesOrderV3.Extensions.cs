using Visma.Net.SalesOrderNG.Exceptions;
using Visma.Net.SalesOrderNG.Models;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Visma.Net.SalesOrderNG.Lib;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace Visma.Net.SalesOrderNG
{
    public partial class ClientSalesOrderV3
    {
        Helpers.VismaNetAuthorization _authorization;

        public static string Version { get; private set; }
        /// <summary>
        /// Provide a name for your application. This will make it easier for Visma to identify your integration in their logs.
        /// </summary>
        public static string _ApplicationName { get; set; }

        private static int maxConcurrentRequests;
        /// <summary>
        /// Gets or sets the maximum number of concurrent requests sent to the API. Min: 1, Max: 8.
        /// </summary>
        public static int MaxConcurrentRequests
        {
            get
            {
                var requestLimit = maxConcurrentRequests > 0 ? maxConcurrentRequests : 8;
                return requestLimit > 8 ? 8 : requestLimit;
            }

            set => maxConcurrentRequests = value > 0 ? value : maxConcurrentRequests;
        }

        private static int maxRetries;
        /// <summary>
        /// Gets or sets the maximum number of retries sent to the API. Min: 1, Max: 5, Default: 5.
        /// </summary>
        public static int MaxRetries
        {
            get { return maxRetries > 0 ? maxRetries : 5; }
            set => maxRetries = (value > 0 && value < 6) ? value : 5;
        }

        public ClientSalesOrderV3(Helpers.VismaNetAuthorization auth, string ApplicationName) : this()
        {
            _authorization = auth;
            _ApplicationName = ApplicationName;
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        }

        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder)
        {
            urlBuilder.Insert(0, VismaNetControllers.SalesOrderV3BaseUrl);
            AddVismaNetAuth(request);

            JwtSecurityToken jwtToken = null;
            if (!string.IsNullOrEmpty(_authorization.Token))
            {
                jwtToken = new JwtSecurityToken(_authorization.Token);
            }
            else if (!string.IsNullOrEmpty(_authorization.VismaConnectToken))
            {
                jwtToken = new JwtSecurityToken(_authorization.VismaConnectToken);
            }
            else
            {
                throw new VismaConnectException("No token found");
            }
            

            if (!_authorization.VismaConnectScopes.Contains("visma.net.erp.salesorder") && !jwtToken.Claims.Any(c => c.Value.Contains("visma.net.erp.salesorder")))
            {
                throw new VismaConnectException("Scope has to contain visma.net.erp.salesorder scopes to use SalesOrderV3");
            }
            
        }

        private void AddVismaNetAuth(HttpRequestMessage request)
        {
            if (_authorization.VismaConnectClientId != null) // new auth via Visma Connect
            {
                // Check for token expired ( 5 minutes grace )
                if (_authorization.VismaConnectToken == null || _authorization.VismaConnectTokenExpire.AddMinutes(-5) < DateTimeOffset.UtcNow)
                {
                    var vToken = VismaNetApiHelper.GetTokenFromVismaConnect(_authorization.VismaConnectClientId, _authorization.VismaConnectClientSecret, _authorization.VismaConnectTenantId, _authorization.VismaConnectScopes).Result;
                    _authorization.VismaConnectToken = vToken.access_token;
                    _authorization.VismaConnectTokenExpire = vToken.expires_on;
                }
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authorization.VismaConnectToken);
            }
            else if (!string.IsNullOrEmpty(_authorization.Token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authorization.Token);
            }
            else
            {
                throw new VismaNetExceptionClientIdMissing();
            }
        }

        public async Task<IEnumerable<CustomerDto>> getAllCustomer(string filter = null)
        {
            int InitialPageSize = 100;
            var firstPage = await Customers_GetList_Async(filter, InitialPageSize, 0);
            var rsp = new List<CustomerDto>();
            if (firstPage == null)
                return rsp;

            rsp.AddRange(firstPage.Result.Value);
            var count = firstPage.Result.Value.Count();
            if (firstPage.Result.TotalCount > count && count > 0)
            {
                var totalCount = (int)firstPage.Result.TotalCount;
                var pageSize = count;
                var pageCount = totalCount / pageSize;
                var semaphore = new SemaphoreSlim(ClientSalesOrderV3.MaxConcurrentRequests);
                var taskList = new List<Task<SwaggerResponse<CustomerDtoPagedResult>>>();
                foreach (var page in Enumerable.Range(1, pageCount))
                {
                    await semaphore.WaitAsync();
                    taskList.Add(Task.Run(async () =>
                    {
                        try
                        {
                            return await Customers_GetList_Async(filter, pageSize, page);
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    }));
                }
                var tasks = await Task.WhenAll(taskList);
                rsp.AddRange(tasks.SelectMany(x => x.Result.Value));
            }
            return rsp;
        }

        public async Task<IEnumerable<SalesOrderListDto>> getAllSalesOrder(string customerId = null, string status = null, DateTimeOffset? modifiedSince = null, string orderBy = null, string filter = null)
        {
            int InitialPageSize = 100;
            var firstPage = await SalesOrders_GetList_Async(customerId, status, modifiedSince, InitialPageSize, 0, orderBy, filter);
            var rsp = new List<SalesOrderListDto>();
            if (firstPage == null)
                return rsp;

            rsp.AddRange(firstPage.Result.Value);
            var count = firstPage.Result.Value.Count();
            if (firstPage.Result.TotalCount > count && count > 0)
            {
                var totalCount = (int)firstPage.Result.TotalCount;
                var pageSize = count;
                var pageCount = totalCount / pageSize;
                var semaphore = new SemaphoreSlim(ClientSalesOrderV3.MaxConcurrentRequests);
                var taskList = new List<Task<SwaggerResponse<SalesOrderListDtoPagedResult>>>();
                foreach (var page in Enumerable.Range(1, pageCount))
                {
                    await semaphore.WaitAsync();
                    taskList.Add(Task.Run(async () =>
                    {
                        try
                        {
                            return await SalesOrders_GetList_Async(customerId, status, modifiedSince, pageSize, page, orderBy, filter);
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    }));
                }
                var tasks = await Task.WhenAll(taskList);
                rsp.AddRange(tasks.SelectMany(x => x.Result.Value));
            }
            return rsp;
        }

        public async Task<IEnumerable<SalesOrderListDto>> getAllSalesOrderOfType(string type, string customerId = null, string status = null, DateTimeOffset? modifiedSince = null, string orderBy = null, string filter = null)
        {
            int InitialPageSize = 100;
            var firstPage = await SalesOrders_GetList_typeAsync(type,customerId, status, modifiedSince, InitialPageSize, 0, orderBy, filter);
            var rsp = new List<SalesOrderListDto>();
            if (firstPage == null)
                return rsp;

            rsp.AddRange(firstPage.Result.Value);
            var count = firstPage.Result.Value.Count();
            if (firstPage.Result.TotalCount > count && count > 0)
            {
                var totalCount = (int)firstPage.Result.TotalCount;
                var pageSize = count;
                var pageCount = totalCount / pageSize;
                var semaphore = new SemaphoreSlim(ClientSalesOrderV3.MaxConcurrentRequests);
                var taskList = new List<Task<SwaggerResponse<SalesOrderListDtoPagedResult>>>();
                foreach (var page in Enumerable.Range(1, pageCount))
                {
                    await semaphore.WaitAsync();
                    taskList.Add(Task.Run(async () =>
                    {
                        try
                        {
                            return await SalesOrders_GetList_typeAsync(type, customerId, status, modifiedSince, pageSize, page, orderBy, filter);
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    }));
                }
                var tasks = await Task.WhenAll(taskList);
                rsp.AddRange(tasks.SelectMany(x => x.Result.Value));
            }
            return rsp;
        }

        public async Task<IEnumerable<SalesOrderLineDto>> getAllSalesOrderLine(string type = null, string orderId = null)
        {
            int InitialPageSize = 100;
            var firstPage = await SalesOrders_GetItemLines_typeorderIdlinesAsync(type, orderId,  InitialPageSize, 0);
            var rsp = new List<SalesOrderLineDto>();
            if (firstPage == null)
                return rsp;

            rsp.AddRange(firstPage.Result.Value);
            var count = firstPage.Result.Value.Count();
            if (firstPage.Result.TotalCount > count && count > 0)
            {
                var totalCount = (int)firstPage.Result.TotalCount;
                var pageSize = count;
                var pageCount = totalCount / pageSize;
                var semaphore = new SemaphoreSlim(ClientSalesOrderV3.MaxConcurrentRequests);
                var taskList = new List<Task<SwaggerResponse<SalesOrderLineDtoPagedResult>>>();
                foreach (var page in Enumerable.Range(1, pageCount))
                {
                    await semaphore.WaitAsync();
                    taskList.Add(Task.Run(async () =>
                    {
                        try
                        {
                            return await SalesOrders_GetItemLines_typeorderIdlinesAsync(type, orderId, InitialPageSize, 0);
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    }));
                }
                var tasks = await Task.WhenAll(taskList);
                rsp.AddRange(tasks.SelectMany(x => x.Result.Value));
            }
            return rsp;
        }

        public async Task<SalesOrderDto> createNewSalesOrder(NewSalesOrderCommand newSalesOrder, IEnumerable<SalesOrderExpansions> expansions = null)
        {
            var resp = await SalesOrders_CreateNewItem_Async(newSalesOrder);
            // https://salesorder.visma.net/api/v3/SalesOrders/SO/000223
            var uri = resp.Headers.FirstOrDefault(h => h.Key == "Location").Value.First();
            Uri uri1 = new Uri(uri);
            var ordno = uri1.Segments[uri1.Segments.Length - 1].Replace("/", "");
            var type = uri1.Segments[uri1.Segments.Length - 2].Replace("/","");
            var ord = await SalesOrders_GetItemAsync_typeorderIdAsync(type, ordno,expansions);
            return ord.Result;
        }

    }
}