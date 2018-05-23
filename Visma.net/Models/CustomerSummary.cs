using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Models
{
    public class CustomerSummary : IProvideCustomDto
    {
        public string number { get; set; }
        [JsonProperty]
        public string name { get; private set; }

        public CustomerSummary()
        {
            
        }

        public CustomerSummary(string number)
        {
            this.number = number;
        }
        public object ToDto()
        {
            return new DtoValue(number);
        }

        public static implicit operator CustomerSummary(string number)
        {
            return new CustomerSummary(number);
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(name))
                return number;
            return $"{number} [{name}]";
        }
    }
}