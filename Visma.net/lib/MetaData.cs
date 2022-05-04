using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Lib
{
    public class MetaData
    {
        [JsonProperty]
        public int totalCount { get; internal set; }

        [JsonProperty]
        public int maxPageSize { get; internal set; }
    }
}