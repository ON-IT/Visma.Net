using Newtonsoft.Json;
using ONIT.VismaNetApi.Interfaces;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class TypeOfWork : IBecomeDto
    {
        public string rutRotType { get; set; }
        [JsonProperty]
        public string description { get; private set; }
        [JsonProperty]
        public string xmlTag { get; private set; }
        public DtoValue ToDto()
        {
            return new DtoValue(rutRotType);
        }
    }
}