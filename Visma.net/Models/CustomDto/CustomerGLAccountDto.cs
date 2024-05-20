using Newtonsoft.Json;
using ONIT.VismaNetApi.Interfaces;
using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class CustomerGLAccountDto : DtoProviderBase
    {
        [JsonProperty] public GLAccountDetailsDto customerLedgerAccount
        {
            get => Get(defaultValue: new GLAccountDetailsDto());
            private set => Set(value);
        }

        [JsonProperty] public SubaccountGlAccount customerLedgerSubAccount
        {
            get => Get(defaultValue: new SubaccountGlAccount());
            private set => Set(value);
        }
        [JsonProperty] public GLAccountDetailsDto salesAccount 
        { 
            get => Get(defaultValue: new GLAccountDetailsDto());
            private set => Set(value);
        }

        [JsonProperty] public GLAccountDetailsDto salesEuAccount
        {
            get => Get(defaultValue: new GLAccountDetailsDto());
            private set => Set(value);
        }


        [JsonProperty] public GLAccountDetailsDto salesExportAccount
        {
            get => Get(defaultValue: new GLAccountDetailsDto());
            private set => Set(value);
        }


        [JsonProperty] public GLAccountDetailsDto salesNonTaxableAccount
        {
            get => Get(defaultValue: new GLAccountDetailsDto());
            private set => Set(value);
        }


        [JsonProperty] public SubaccountGlAccount salesSubaccount
        {
            get => Get(defaultValue: new SubaccountGlAccount());
            private set => Set(value);
        }

    }

    public class SupplierGLAccountDto : DtoProviderBase
    {
        [JsonProperty] public GLAccountDetailsDto supplierAccount {
            get => Get<GLAccountDetailsDto>(defaultValue: new GLAccountDetailsDto());
            private set => Set(value);
        }
        [JsonProperty]
        public IdDescription supplierSubaccount
        {
            get => Get<IdDescription>(defaultValue: new IdDescription());
            private set => Set(value);
        }

        [JsonProperty] public GLAccountDetailsDto expenseAccount {
            get => Get<GLAccountDetailsDto>(defaultValue: new GLAccountDetailsDto());
            private set => Set(value);
        }

        [JsonProperty] public GLAccountDetailsDto expenseAccountNonTax {
            get => Get<GLAccountDetailsDto>(defaultValue: new GLAccountDetailsDto());
            private set => Set(value);
        }

        [JsonProperty] public GLAccountDetailsDto expenseEUAccount {
            get => Get<GLAccountDetailsDto>(defaultValue: new GLAccountDetailsDto());
            private set => Set(value);
        }
        [JsonProperty] public GLAccountDetailsDto expenseAccountImport {
            get => Get<GLAccountDetailsDto>(defaultValue: new GLAccountDetailsDto());
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