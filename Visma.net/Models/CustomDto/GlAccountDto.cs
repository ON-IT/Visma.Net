using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class GLAccountDto
    {
        [JsonProperty] public GLAccountDetailsDto salesAccount { get; private set; }

        [JsonProperty] public GLAccountDetailsDto salesEuAccount { get; private set; }

        [JsonProperty] public GLAccountDetailsDto salesExportAccount { get; private set; }

        [JsonProperty] public GLAccountDetailsDto salesNonTaxableAccount { get; private set; }

        [JsonProperty] public DescriptiveDto salesSubaccount { get; private set; }
    }
}