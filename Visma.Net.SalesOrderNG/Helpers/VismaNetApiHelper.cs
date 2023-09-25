using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

namespace Visma.Net.SalesOrderNG
{
    public static class VismaNetApiHelper
    {
        private const int MaxReturnableEntitiesFromVismaNet = 1000;
        internal const string ApplicationType = "Visma.net Financials";
        internal const string BaseApiUrl = "https://integration.visma.net/API/";

        public const string VismaNetDateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fff";

       

        internal static string AppendToQuery(string query, string key, object value)
        {
            var divider = "?";
            if (query.IndexOf('?') > -1)
                divider = "&";
            return $"{query}{divider}{key}={value}";
        }

        
        public static async Task<VismaConnectToken> GetTokenFromVismaConnect(string clientId, string secret, string tenant_id, string scope = "vismanet_erp_service_api:create vismanet_erp_service_api:delete vismanet_erp_service_api:read vismanet_erp_service_api:update")
        {
            try
            {
                var webclient = GetHttpClient(new Helpers.VismaNetAuthorization());
                {
                    var url = Lib.VismaNetControllers.VismaConnectToken;
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

        private static Lib.VismaNetHttpClient GetHttpClient(Helpers.VismaNetAuthorization auth = null)
        {
            return new Lib.VismaNetHttpClient(auth);
        }

    }
}