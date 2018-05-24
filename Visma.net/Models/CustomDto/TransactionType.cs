using Newtonsoft.Json;
using ONIT.VismaNetApi.Interfaces;

namespace ONIT.VismaNetApi.Models
{
    public class TransactionType : IBecomeDto
    {
        public int id { get; set; }
        [JsonProperty]
        public string description { get; private set; }

        public DtoValue ToDto()
        {
            return new DtoValue(id);
        }
    }
}