using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class InvoiceBase : DtoProviderBase, IHaveNumber, IHaveInternalId
    {
       

        #region Writable properties (CustomerInvoiceUpdateDto)
        public string externalReference
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        // This is only editable from the method Add (with overloads) on Invoice
        [JsonProperty]
        public List<CustomerInvoiceLine> invoiceLines
        {
            get { return Get(defaultValue: new List<CustomerInvoiceLine>()); }
            private set { Set(value); }
        }

        [JsonIgnore]
        public string number => referenceNumber;

        [JsonIgnore]
        public int internalId
        {
            get
            {
                var id = 0;
                return int.TryParse(referenceNumber, out id) ? id : 0;
            }
        }

        public string referenceNumber
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string customerNumber
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public DateTime documentDate
        {
            get { return Get<DateTime>(); }
            set { Set(value); }
        }


        public string customerRefNumber
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public bool hold
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public string postPeriod
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string invoiceText
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public Location location
        {
            get { return Get("locationId", new Location()); }
            set { Set(value, key: "locationId"); }
        }

        public Currency currency
        {
            get { return Get("currencyId", new Currency()); }
            set { Set(value, key: "currencyId"); }
        }

        
        public int? salesPersonID
        {
            get { return Get<int?>(); }
            set { Set(value); }
        }

        #endregion

        #region Read only properties (CustomerInvoiceDto)
        
        [JsonProperty]
        public CustomerDocumentType documentType
        {
            get { return Get<CustomerDocumentType>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public InvoiceStatus status
        {
            get { return Get<InvoiceStatus>(); }
            private set { Set(value); }
        }

        /// <summary>
        /// This will just contain the name and number.
        /// </summary>
        [JsonProperty]
        public Customer customer { get; internal set; }

        [JsonProperty]
        public decimal detailTotal
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal detailTotalInCurrency
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal vatTaxableTotal
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal vatTaxableTotalInCurrency
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal vatExemptTotal
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal vatExemptTotalInCurrency
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        public VatCode vatCode
        {
            get { return Get<VatCode>(); }
            set { Set(value); }
        }

        [JsonProperty]
        public decimal vatTotal
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal vatTotalInCurrency
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal balance
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal balanceInCurrency
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
        public decimal cashDiscount
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal cashDiscountInCurrency
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public DateTime lastModifiedDateTime
        {
            get { return Get<DateTime>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public DateTime createdDateTime
        {
            get { return Get<DateTime>(); }
            private set { Set(value); }
        }
        
        [JsonProperty]
        public string salesPersonDescr
        {
            get { return Get<string>(); }
            private set { Set(value); }
        }

        #endregion

        #region Methods
        public void Add(CustomerInvoiceLine line)
        {
            line.lineNumber = 1;
            if (invoiceLines.Count > 0)
                line.lineNumber = Math.Max(invoiceLines.Count + 1, invoiceLines.Max(x => x.lineNumber) + 1);
            invoiceLines.Add(line);
        }

        public void Add(string inventoryId, int quantity = 1)
        {
            Add(new CustomerInvoiceLine()
            {
                inventoryNumber = inventoryId,
                quantity = quantity
            });
        }
        #endregion
    }
}