using Newtonsoft.Json;
using ONIT.VismaNetApi.Interfaces;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class Ledger : IProvideCustomDto
    {
        [JsonProperty]
        public string id { get; private set; }
        public string description { get; private set; }
        
        public static implicit operator Ledger(string id)
        {
            return new Ledger
            {
                id = id
            };
        }
        public object ToDto()
        {
            return new DtoValue(id);
        }
    }
}