using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Models
{
    public class SoCustomerSummary : CustomerSummary
    {
        public SoCustomerSummary()
        {
            
        }

        public SoCustomerSummary(string number) : base(number)
        {
        }

        [JsonProperty]
        public int internalId { get; private set; }

        public static implicit operator SoCustomerSummary(string number)
        {
            return new SoCustomerSummary(number);
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(name))
                return number;
            return $"{number} [{name}]";
        }
    }
}