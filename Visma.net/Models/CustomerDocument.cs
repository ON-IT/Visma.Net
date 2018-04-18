using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;

namespace ONIT.VismaNetApi.Models
{
    public class CustomerDocument : DtoProviderBase
    {
        [JsonProperty]
        public Account account { get; private set; }

        [JsonProperty]
        public CustomDto.Subaccount subaccount { get; private set; }

        [JsonProperty]
        public NumberName branch { get; private set; }

        [JsonProperty]
        public NumberName branchNumber { get; private set; }

        [JsonProperty]
        public DateTime documentDueDate { get; private set; }

        [JsonProperty]
        public CustomerSummary customer { get; private set; }

        [JsonProperty]
        public string documentType { get; private set; }

        [JsonProperty]
        public string referenceNumber { get; private set; }

        [JsonProperty]
        public string postPeriod { get; private set; }

        [JsonProperty]
        public string closedFinancialPeriod { get; private set; }
        
        [JsonProperty]
        public string customerRefNumber { get; private set; }

        [JsonProperty]
        public DescriptionId project { get; private set; }

        [JsonProperty]
        public string cashAccount { get; private set; }

        [JsonProperty]
        public string financialPeriod { get; private set; }

        [JsonProperty]
        public DateTime documentDate { get; private set; }
        [JsonProperty]
        public PaymentMethod paymentMethod { get; private set; }
        [JsonProperty]
        public string status { get; private set; }

        [JsonProperty]
        public string currencyId { get; private set; }

        [JsonProperty]
        public decimal amount { get; private set; }

        [JsonProperty]
        public decimal amountInCurrency { get; private set; }

        [JsonProperty]
        public decimal balance { get; private set; }

        [JsonProperty]
        public decimal balanceInCurrency { get; private set; }

        [JsonProperty]
        public decimal cashDiscount { get; private set; }

        [JsonProperty]
        public decimal cashDiscountInCurrency { get; private set; }

        [JsonProperty]
        public string invoiceText { get; private set; }

        [JsonProperty]
        public DateTime lastModifiedDateTime { get; private set; }

        [JsonProperty]
        public DateTime createdDateTime { get; private set; }

        [JsonProperty]
        public string note { get; private set; }

        [JsonProperty]
        public decimal vatTotal { get; private set; }

        [JsonProperty]
        public decimal vatTotalInCurrency { get; private set; }

        [JsonProperty]
        public LocationSummary location { get; private set; }

        [JsonProperty]
        public JObject extras { get; private set; }

        [JsonProperty]
        public string errorInfo { get; set; }

    }
}