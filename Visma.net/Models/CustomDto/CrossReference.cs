using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class CrossReference
    {
        [JsonProperty]
        public string alternateType { get; private set; }
        [JsonProperty]
        public Baccount bAccount { get; private set; }
        [JsonProperty]
        public string alternateID { get; private set; }
        [JsonProperty]
        public string description { get; private set; }
    }
}