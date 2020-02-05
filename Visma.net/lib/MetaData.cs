using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Lib
{
    public class MetaData
    {
        [JsonProperty]
        public int totalCount { get; internal set; }
    }
}