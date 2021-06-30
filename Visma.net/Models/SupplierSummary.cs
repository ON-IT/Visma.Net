using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Models
{
    public class SupplierSummary : IProvideCustomDto
    {
        public string number { get; set; }
        [JsonProperty]
        public string name { get; private set; }

        public SupplierSummary()
        {
            
        }

        public SupplierSummary(string number)
        {
            this.number = number;
        }
        public object ToDto()
        {
            return new DtoValue(number);
        }

        public static implicit operator SupplierSummary(string number)
        {
            return new SupplierSummary(number);
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(name))
                return number;
            return $"{number} [{name}]";
        }
    }
}