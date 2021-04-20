using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Models
{
    public class PoSupplierSummary : SupplierSummary
    {
        public PoSupplierSummary()
        {
            
        }

        public PoSupplierSummary(string number) : base(number)
        {
        }

        [JsonProperty]
        public int internalId { get; private set; }

        public static implicit operator PoSupplierSummary(string number)
        {
            return new PoSupplierSummary(number);
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(name))
                return number;
            return $"{number} [{name}]";
        }
    }
}