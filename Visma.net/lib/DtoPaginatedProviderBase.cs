using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Lib
{
    public class DtoPaginatedProviderBase : DtoProviderBase
    {
        [JsonProperty("metadata")]
        public MetaData metadata { get; internal set; }
    }
}