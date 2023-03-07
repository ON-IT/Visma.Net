using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;
using System;
using System.Collections.Generic;

namespace ONIT.VismaNetApi.Models
{
    public class CustomerPayment : DtoPaginatedProviderBase, IProvideIdentificator
    {
        public string type { get => Get<string>(); set => Set(value); }
        public string refNbr { get => Get<string>("referenceNumber"); set => Set(value, "referenceNumber"); }
        public string status { get; set; }
        public bool hold { get => Get<bool>(); set => Set(value); }
        public DateTime applicationDate { get => Get<DateTime>(); set => Set(value); }
        public string applicationPeriod { get => Get<string>(); set => Set(value); }
        public string paymentRef { get => Get<string>(); set => Set(value); }
        public CustomerSummary customer { get => Get<CustomerSummary>(); set => Set(value); }
        public LocationSummary location { get => Get<LocationSummary>(); set => Set(value); }
        public PaymentMethod paymentMethod { get => Get<PaymentMethod>(); set => Set(value); }
        public string cashAccount { get => Get<string>(); set => Set(value); }
        public string currency { get => Get<string>(); set => Set(value); }
        public decimal paymentAmount { get => Get<decimal>(); set => Set(value); }
        public decimal paymentAmountInCurrency { get => Get<decimal>(); set => Set(value); }
        public string invoiceText { get => Get<string>(); set => Set(value); }
        [JsonProperty]
        public decimal appliedToDocuments { get; private set; }
        [JsonProperty]
        public decimal appliedToOrders { get; private set; }
        [JsonProperty]
        public decimal availableBalance { get; private set; }
        [JsonProperty]
        public decimal writeOffAmount { get; private set; }
        [JsonProperty]
        public decimal financeCharges { get; private set; }
        [JsonProperty]
        public decimal deductedCharges { get; private set; }
        public string branch { get => Get<string>(); set => Set(value); }
        [JsonProperty]
        public DateTime lastModifiedDateTime { get; private set; }
        [JsonProperty]
        public List<CustomerPaymentLine> paymentLines
        {
            get => Get(defaultValue: new List<CustomerPaymentLine>());
            private set => Set(value);
        }
        [JsonProperty]
        public List<CustomerPaymentOrderToApply> ordersToApply
        {
            get => Get(defaultValue: new List<CustomerPaymentOrderToApply>());
            private set => Set(value);
        }
        [JsonProperty]
        public JObject extras { get; private set; }
        public string errorInfo { get; set; }
        
        public string GetIdentificator()
        {
            return refNbr;
        }

        internal override void PrepareForUpdate()
        {
            foreach (var line in this.paymentLines)
                line.operation = ApiOperation.Update;

            foreach (var orderToApply in ordersToApply)
                orderToApply.operation = ApiOperation.Update;
        }
    }
}
