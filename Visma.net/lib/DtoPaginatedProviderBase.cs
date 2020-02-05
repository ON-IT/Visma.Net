using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Lib
{
    public class DtoPaginatedProviderBase : DtoProviderBase
    {
        [JsonProperty]
        public MetaData metadata { get; internal set;}
    }
}