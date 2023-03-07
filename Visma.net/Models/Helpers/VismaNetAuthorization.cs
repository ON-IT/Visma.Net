using System;
using System.Net.Http;

namespace ONIT.VismaNetApi.Models
{
    public class VismaNetAuthorization
    {
        public string Token { get; set; }
        public int CompanyId { get; set; }
        public bool UseProxy { get; set; }
        public int BranchId { get; set; }
        public HttpClient HttpClient { get; internal set; }
        public string VismaConnectClientId { get; set; } = null;
        public string VismaConnectClientSecret { get;set; } = null;
        public string VismaConnectTenantId { get; set; } = null;
        public string VismaConnectScopes { get; set ;} = "vismanet_erp_service_api:create vismanet_erp_service_api:delete vismanet_erp_service_api:read vismanet_erp_service_api:update";
        public string VismaConnectToken { get; set; } = null;

        public DateTimeOffset VismaConnectTokenExpire { get; set; }
    }
}