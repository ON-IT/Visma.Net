using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class PurchaseOrderLineAccount : IProvideCustomDto
    {
        [JsonProperty]
        public string description { get; private set; }
        public string number { get; set; }
        public string type { get; set; }
        public object ToDto()
        {
            return new DtoValue(number);
        }

        public static implicit operator PurchaseOrderLineAccount(string number)
        {
            return new PurchaseOrderLineAccount
            {
                number = number
            };
        }

    }
}