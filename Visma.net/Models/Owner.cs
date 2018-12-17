using Newtonsoft.Json;
using ONIT.VismaNetApi.Interfaces;

namespace ONIT.VismaNetApi.Models
{
    public class Owner : IBecomeDto
    {
        [JsonProperty("id.value")]
        public string id { get; set; }
        [JsonProperty("name.value")]
        public string name { get; set; }
        public DtoValue ToDto()
        {
            return new DtoValue(id);
        }
    }
}