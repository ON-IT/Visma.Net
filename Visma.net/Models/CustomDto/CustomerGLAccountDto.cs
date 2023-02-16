using Newtonsoft.Json;
using ONIT.VismaNetApi.Interfaces;
using ONIT.VismaNetApi.Lib;

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

        [JsonProperty] public SubaccountGlAccount salesSubaccount { get; private set; }
    }

    public class SupplierGLAccountDto : DtoProviderBase
    {
        [JsonProperty] public GLAccountDetailsDto supplierAccount {
            get => Get<GLAccountDetailsDto>();
            private set => Set(value);
        }

        [JsonProperty] public GLAccountDetailsDto expenseAccount {
            get => Get<GLAccountDetailsDto>();
            private set => Set(value);
        }

        [JsonProperty] public GLAccountDetailsDto expenseAccountNonTax {
            get => Get<GLAccountDetailsDto>();
            private set => Set(value);
        }

        [JsonProperty] public GLAccountDetailsDto expenseEUAccount {
            get => Get<GLAccountDetailsDto>();
            private set => Set(value);
        }
        [JsonProperty] public GLAccountDetailsDto expenseAccountImport {
            get => Get<GLAccountDetailsDto>();
            private set => Set(value);
        }

        [JsonProperty] public IdDescription expenseSubaccount { 
            get => Get<IdDescription>(); 
            private set => Set(value); 
        }

        public DtoValue ToDto()
        {
            return new DtoValue(this);
        }
    }
    
}