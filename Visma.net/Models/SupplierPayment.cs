using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;
using System;
using System.Collections.Generic;

namespace ONIT.VismaNetApi.Models
{
    public class SupplierPayment : DtoPaginatedProviderBase, IProvideIdentificator
    {
        public string type { get => Get<string>(); set => Set(value); }
        public string refNbr { get => Get<string>("referenceNumber"); set => Set(value, "referenceNumber"); }
        public string status { get; set; }
        public bool hold { get => Get<bool>(); set => Set(value); }
        public DateTime applicationDate { get => Get<DateTime>(); set => Set(value); }
        public string applicationPeriod { get => Get<string>(); set => Set(value); }
        public string paymentRef { get => Get<string>(); set => Set(value); }
        public CustomerSummary supplier { get => Get<CustomerSummary>(); set => Set(value); }
        public LocationSummary location { get => Get<LocationSummary>(); set => Set(value); }
        public PaymentMethod paymentMethod { get => Get<PaymentMethod>(); set => Set(value); }
        public string cashAccount { get => Get<string>(); set => Set(value); }
        public CurrencySummary currency { get => Get<CurrencySummary>(); set => Set(value); }
        public string description { get => Get<string>(); set => Set(value); }
        public decimal paymentAmount { get => Get<decimal>(); set => Set(value); }
        [JsonProperty]
        public decimal financeCharges { get => Get<decimal>(); set => Set(value); }
        [JsonProperty]
        public decimal unappliedBalance { get => Get<decimal>(); set => Set(value); }
        [JsonProperty]
        public decimal appliedAmount { get => Get<decimal>(); set => Set(value); }
        [JsonProperty]
        public decimal deductedCharges { get; private set; }
        [JsonProperty]
        public bool released { get => Get<bool>(); set => Set(value); }
        [JsonProperty]
        public DateTime lastModifiedDateTime { get; private set; }
        public string branch { get => Get<string>(); set => Set(value); }
        [JsonProperty]
        public List<SupplierPaymentLine> paymentLines
        {
            get => Get(defaultValue: new List<SupplierPaymentLine>());
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
        }
    }
}
