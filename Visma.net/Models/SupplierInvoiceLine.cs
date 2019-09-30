using System.Collections.Generic;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class SupplierInvoiceLine : DtoProviderBase
    {
        private List<Attachment> _attachments;

        public SupplierInvoiceLine()
        {
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
            DtoFields.Add("lineNumber", new DtoValue(0));
            DtoFields.Add("quantity", new DtoValue(1));
        }

        public Account account
        {
            get => Get(defaultValue: new Account(), key: "accountNumber");
            set => Set(value, "accountNumber");
        }

        public NumberName branchNumber
        {
            get => Get<NumberName>();
            set => Set(value);
        }

        public string splitHierarchy { get => Get<string>(); set => Set(value); }

        [JsonProperty]
        public decimal cost
        {
            get;
            private set;
        }

        public DescriptionId project { get => Get<DescriptionId>("projectId"); set => Set(value, key: "projectId"); }

        public DescriptionId projectTask { get => Get<DescriptionId>("projectTaskId"); set => Set(value, key: "projectTaskId"); }

        [JsonProperty]
        public decimal costInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public string deferralCode
        {
            get => Get<string>();
            set => Set(value);
        }

        public int? deferralSchedule
        {
            get => Get<int?>();
            set => Set(value);
        }

        [JsonProperty] public decimal discountAmount { get; private set; }

        [JsonProperty]
        public decimal discountAmountInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }

        [JsonProperty]
        public decimal discountPercent
        {
            get => Get<decimal>();
            set => Set(value);
        }

        [JsonProperty] public decimal discountUnitCost { get; private set; }

        [JsonProperty]
        public decimal discountUnitCostInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public string inventoryNumber
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public int lineNumber
        {
            get => Get<int>();
            internal set => Set(value);
        }

        [JsonProperty]
        public bool manualDiscount
        {
            get => Get<bool>();
            set => Set(value);
        }

        public string note { get => Get<string>(); set => Set(value); }

        [JsonProperty]
        public List<Attachment> attachments
        {
            get => _attachments ?? (_attachments = new List<Attachment>());
            private set => _attachments = value;
        }

        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }

        public decimal quantity
        {
            get => Get<decimal>();
            set => Set(value);
        }

        [JsonProperty] public bool stockItem { get; private set; }

        public CustomDto.Subaccount subaccount
        {
            get => Get(defaultValue: new CustomDto.Subaccount());
            set => Set(value);
        }

        [JsonProperty]
        public string poNumber { get; private set; }

        [JsonProperty] public int poLineNr { get; private set; }

        [JsonProperty] public string poReceiptNbr { get; private set;}

        [JsonProperty] public int poReceiptLineNbr { get; private set;}

        public string transactionDescription
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public decimal unitCost
        {
            get;
            private set;
        }

        public decimal unitCostInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public string uom
        {
            get => Get<string>();
            set => Set(value);
        }

        public VatCode vatCode
        {
            get => Get<VatCode>("vatCodeId");
            set => Set(value, "vatCodeId");
        }
    }
}