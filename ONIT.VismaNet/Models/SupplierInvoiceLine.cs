using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class SupplierInvoiceLine : DtoProviderBase
    {
        public SupplierInvoiceLine()
        {
            DtoFields.Add("operation", new NotDto<int>(1));
            DtoFields.Add("lineNumber", new DtoValue(0));
            DtoFields.Add("quantity", new DtoValue(1));
        }

        public ApiOperation operation
        {
            get { return Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value; }
            set { Set(new NotDto<ApiOperation>(value)); }
        }

        [JsonProperty]
        public int lineNumber
        {
            get { return Get<int>(); }
            internal set { Set(value); }
        }

        public string inventoryNumber
        {
            get { return Get<string>(); } 
            set { Set(value); }
        }

        public string transactionDescription
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public decimal quantity
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public string uom
        {
            get
            {
                return Get<string>();
            }
            set
            {
                Set(value);
            }
        }

        [JsonProperty]
        public decimal unitCost
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        public decimal unitCostInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        [JsonProperty]
        public decimal cost
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal costInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public Account account
        {
            get { return Get(defaultValue: new Account(), key: "accountNumber"); }
            set { Set(value, "accountNumber"); }
        }

        public Subaccount subaccount
        {
            get { return Get(defaultValue: new Subaccount()); }
            set { Set(value); }
        }

        public VatCode vatCode
        {
            get { return Get<VatCode>("vatCodeId"); }
            set { Set(value, "vatCodeId"); }
        }

        public string branchNumber
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public int? deferralSchedule
        {
            get
            {
                return Get<int?>();
            }
            set
            {
                Set(value);
            }
        }

        public string deferralCode
        {
            get { return Get<string>(); }
            set { Set(value);}
        }
    }
}