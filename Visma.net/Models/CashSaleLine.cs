using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;

namespace ONIT.VismaNetApi.Models
{
    public class CashSaleLine : DtoProviderBase
    {
        /* READABLE */
        //public class CashSaleLineDto
        //{
        //    public decimal UnitPrice { get; set; }
        //    public decimal ManualAmount { get; set; }
        //    public decimal Amount { get; set; }
        //    public decimal AmountInCurrency { get; set; }
        //    public decimal DiscountAmount { get; set; }
        //    public string DiscountCode { get; set; }
        //}

        /* WRITABLE */

        //public class CashSaleLinesUpdateDto
        //{
        //    public ApiOperation Operation { get; set; }
        //    public DtoValue<string> InventoryNumber { get; set; }
        //    public DtoValue<int> LineNumber { get; set; }
        //    public DtoValue<string> Description { get; set; }
        //    public DtoValue<decimal> Quantity { get; set; }
        //    public DtoValue<decimal> UnitPriceInCurrency { get; set; }
        //    public DtoValue<decimal> ManualAmountInCurrency { get; set; }
        //    public DtoValue<string> AccountNumber { get; set; } // "Account"
        //    public DtoValue<string> VatCodeId { get; set; } // "VatCode"
        //    public DtoValue<string> UOM { get; set; }
        //    public DtoValue<decimal> DiscountPercent { get; set; }
        //    public DtoValue<decimal> DiscountAmountInCurrency { get; set; }
        //    public DtoValue<bool> ManualDiscount { get; set; }
        //    public SegmentUpdateDto[] Subaccount { get; set; }
        //    public DtoValue<string> Salesperson { get; set; }
        //    public DtoValue<int> DeferralSchedule { get; set; }
        //    public DtoValue<string> DeferralCode { get; set; }
        //    public DtoValue<string> Note { get; set; }
        //}

        public CashSaleLine()
        {
            DtoFields.Add("operation", new NotDto<int>(1));
            DtoFields.Add("lineNumber", new DtoValue(0));
            DtoFields.Add("quantity", new DtoValue(1));
        }

        public int lineNumber
        {
            get { return Get<int>(); }
            set { Set(value); }
        }

        public string inventoryNumber
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string description
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public decimal quantity
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal unitPriceInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal manualAmountInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }


        public Account account
        {
            get { return Get("accountNumber", new Account()); }
            set { Set(value, "accountNumber"); }
        }

        public VatCode vatCode
        {
            get { return Get<VatCode>("vatCodeId"); }
            set { Set(value, "vatCodeId"); }
        }

        public string uom
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public decimal discountPercent
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal discountAmountInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public bool manualDiscount
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public ONIT.VismaNetApi.Models.CustomDto.Subaccount subaccount
        {
            get { return Get<ONIT.VismaNetApi.Models.CustomDto.Subaccount>(); }
            set { Set(value); }
        }

        public int deferralSchedule
        {
            get { return Get<int>(); }
            set { Set(value); }
        }

        /* READ ONLY PROPERTIES */

        [JsonProperty]
        public decimal unitPrice
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal manualAmount
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal amount
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal amountInCurrency
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal discountAmount
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public string discountCode
        {
            get { return Get<string>(); }
            private set { Set(value); }
        }
    }
}