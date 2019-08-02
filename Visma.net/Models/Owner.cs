using Newtonsoft.Json;
using ONIT.VismaNetApi.Interfaces;

namespace ONIT.VismaNetApi.Models
{
    public class Owner : IBecomeDto
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("name")]
        public string name { get; private set; }

        [JsonProperty]
        public string employeeId { get; private set; }

        public DtoValue ToDto()
        {
            return new DtoValue(id);
        }
    }
}