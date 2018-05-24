using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class Payment : DtoProviderBase, IProvideIdentificator
    {
        public DateTime applicationDate
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        public string applicationPeriod
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty] public decimal appliedToDocuments { get; private set; }
        [JsonProperty] public decimal appliedToOrders { get; private set; }
        [JsonProperty] public decimal availableBalance { get; private set; }

        public string branch
        {
            get => Get<string>();
            set => Set(value);
        }

        public string cashAccount
        {
            get => Get<string>();
            set => Set(value);
        }

        public string currency
        {
            get => Get<string>();
            set => Set(value);
        }

        public NumberName customer
        {
            get => Get<NumberName>();
            set => Set(value);
        }

        [JsonProperty] public decimal deductedCharges { get; private set; }
        [JsonProperty] public decimal financeCharges { get; private set; }

        public bool hold
        {
            get => Get<bool>();
            set => Set(value);
        }

        public string invoiceText
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty] public DateTime lastModifiedDateTime { get; private set; }

        [JsonProperty]
        public LocationSummary location
        {
            get => Get<LocationSummary>();
            set => Set(value);
        }

        [JsonProperty]
        public List<OrderToApplyDetails> ordersToApply
        {
            get => Get(defaultValue: new List<OrderToApplyDetails>());
            private set => Set(value);
        }

        public decimal paymentAmount
        {
            get => Get<decimal>();
            set => Set(value);
        }

        [JsonProperty]
        public List<PaymentLine> paymentLines
        {
            get => Get(defaultValue: new List<PaymentLine>());
            private set => Set(value);
        }

        [JsonProperty]
        public DescriptiveDto paymentMethod
        {
            get => Get<DescriptiveDto>();
            set => Set(value);
        }

        public string paymentRef
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public string refNbr
        {
            get => Get<string>("referenceNumber");
            set => Set(value, "referenceNumber");
        }

        [JsonProperty] public string status { get; private set; }

        public string type
        {
            get => Get<string>();
            set => Set(value);
        }


        [JsonProperty] public decimal writeOffAmount { get; private set; }

        public string GetIdentificator()
        {
            return refNbr;
        }

        internal override void PrepareForUpdate()
        {
            foreach (var paymentLine in paymentLines)
                paymentLine.operation = ApiOperation.Update;
            foreach (var order in ordersToApply)
                order.operation = ApiOperation.Update;
        }
    }


    public class OrderToApplyDetails : DtoProviderBase
    {
        public OrderToApplyDetails()
        {
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }

        [JsonProperty]
        public decimal appliedToOrder
        {
            get => Get<decimal>();
            set => Set(value);
        }

        [JsonProperty] public decimal balance { get; set; }

        [JsonProperty] public DateTime cashDiscountDate { get; set; }

        [JsonProperty] public string currency { get; set; }

        [JsonProperty] public DateTime date { get; set; }

        [JsonProperty] public string description { get; set; }

        [JsonProperty] public DateTime dueDate { get; set; }

        [JsonProperty] public DateTime invoiceDate { get; set; }

        [JsonProperty] public string invoiceNbr { get; set; }

        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }

        [JsonProperty]
        public string orderNo
        {
            get => Get<string>("orderNumber");
            set => Set(value, "orderNumber");
        }

        [JsonProperty] public decimal orderTotal { get; set; }

        [JsonProperty]
        public string orderType
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty] public string status { get; set; }

        [JsonProperty] public decimal transferredToInvoice { get; set; }
    }
}