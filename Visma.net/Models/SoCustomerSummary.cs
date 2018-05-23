using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Models
{
    public class SoCustomerSummary : CustomerSummary
    {
        
        [JsonProperty]
        public int internalId { get; private set; }
    }
}