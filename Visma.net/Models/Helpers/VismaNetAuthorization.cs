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
    }
}