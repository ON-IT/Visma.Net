using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Lib
{
    public class MetaData
    {
        [JsonProperty("totalCount")]
        public int totalCount { get; internal set; }

        [JsonProperty("maxPageSize")]
        public int maxPageSize { get; internal set; }
    }
}