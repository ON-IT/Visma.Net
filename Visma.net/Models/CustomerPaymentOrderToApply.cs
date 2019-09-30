using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;
using System;

namespace ONIT.VismaNetApi.Models
{
    public class CustomerPaymentOrderToApply : DtoProviderBase
    {
        public CustomerPaymentOrderToApply()
        {
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }
        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }
        public string orderType { get => Get<string>(); set => Set(value); }
        public string orderNo { get => Get<string>("orderNumber"); set => Set(value, "orderNumber"); }
        [JsonProperty]
        public string status { get; private set; }
        public decimal appliedToOrder { get => Get<decimal>(); set => Set(value); }
        [JsonProperty]
        public decimal transferredToInvoice { get; private set; }
        [JsonProperty]
        public DateTime date { get; private set; }
        [JsonProperty]
        public DateTime dueDate { get; private set; }
        [JsonProperty]
        public DateTime cashDiscountDate { get; private set; }
        [JsonProperty]
        public decimal balance { get; private set; }
        [JsonProperty]
        public string description { get; private set; }
        [JsonProperty]
        public decimal orderTotal { get; private set; }
        [JsonProperty]
        public string currency { get; private set; }
        [JsonProperty]
        public string invoiceNbr { get; private set; }
        [JsonProperty]
        public DateTime invoiceDate { get; private set; }
    }

}
