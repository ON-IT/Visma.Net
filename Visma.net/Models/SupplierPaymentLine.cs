using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;
using System;

namespace ONIT.VismaNetApi.Models
{
    public class SupplierPaymentLine : DtoProviderBase
    {
        public SupplierPaymentLine()
        {
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }
        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }
        public string documentType { get => Get<string>(); set => Set(value); }
        [JsonProperty]
        public string branch { get; private set; }
        [JsonProperty]
        public string batchNumber { get; private set; }
        public string refNbr { get => Get<string>("invoiceRefNbr"); set => Set(value, "refNbr"); }
        public decimal amountPaid { get => Get<decimal>(); set => Set(value); }
        public decimal cashDiscountTaken { get => Get<decimal>(); set => Set(value); }
        [JsonProperty]
        public decimal withholdingTax { get => Get<decimal>(); set => Set(value); }
        [JsonProperty]
        public DateTime applicationDate { get => Get<DateTime>(); set => Set(value); }
        [JsonProperty]
        public string applicationPeriod { get => Get<string>(); set => Set(value); }
        [JsonProperty]
        public DateTime date { get => Get<DateTime>(); set => Set(value); }
        [JsonProperty]
        public DateTime dueDate { get => Get<DateTime>(); set => Set(value); }
        [JsonProperty]
        public DateTime cashDiscountDate { get => Get<DateTime>(); set => Set(value); }
        [JsonProperty]
        public decimal balance { get; private set; }
        [JsonProperty]
        public decimal cashDiscountBalance { get; private set; }
        [JsonProperty]
        public string description { get; private set; }
        [JsonProperty]
        public string currency { get; private set; }
        [JsonProperty]
        public string postPeriod { get; private set; }
        [JsonProperty]
        public string supplierRef { get; private set; }
        public decimal crossRate { get => Get<decimal>(); set => Set(value); }
    }

}
