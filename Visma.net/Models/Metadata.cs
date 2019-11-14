using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Models
{
    public class Metadata
    {
        [JsonProperty]
        public int totalCount { get; private set; }
    }

}
