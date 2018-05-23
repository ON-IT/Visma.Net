using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class GLAccountDetailsDto
    {
        [JsonProperty] public string description { get; private set; }

        [JsonProperty] public string number { get; private set; }

        [JsonProperty] public string type { get; private set; }
    }
}