using Newtonsoft.Json;
using ONIT.VismaNetApi.Interfaces;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class Account : IProvideCustomDto
    {
        [JsonProperty]
        public string description { get; private set; }
        public string number { get; set; }
        public AccountTypes type { get; set;  }
        [JsonProperty]
        public string externalCode1 { get; private set; }
        [JsonProperty]
        public string externalCode2 { get; private set; }
        public object ToDto()
        {
            return new DtoValue(number);
        }
        
        public static implicit operator Account(string number)
        {
            return new Account
            {
                number = number
            };
        }
    }
}