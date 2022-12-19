using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class CustomerGLAccountDto
    {
        [JsonProperty] public GLAccountDetailsDto customerLedgerAccount { get; private set; }
        [JsonProperty] public SubaccountGlAccount customerLedgerSubAccount { get; private set; }
        [JsonProperty] public GLAccountDetailsDto salesAccount { get; private set; }

        [JsonProperty] public GLAccountDetailsDto salesEuAccount { get; private set; }

        [JsonProperty] public GLAccountDetailsDto salesExportAccount { get; private set; }

        [JsonProperty] public GLAccountDetailsDto salesNonTaxableAccount { get; private set; }

        [JsonProperty] public Subaccount salesSubaccount { get; private set; }
    }

    public class SupplierGLAccountDto
    {
        [JsonProperty] public GLAccountDetailsDto supplierAccount { get; private set; }

        [JsonProperty] public GLAccountDetailsDto expenseAccount { get; private set; }

        [JsonProperty] public GLAccountDetailsDto expenseAccountNonTax { get; private set; }

        [JsonProperty] public GLAccountDetailsDto expenseEUAccount { get; private set; }
        [JsonProperty] public GLAccountDetailsDto expenseAccountImport { get; private set; }

        [JsonProperty] public SubaccountGlAccount expenseSubaccount { get; private set; }
    }
    
}