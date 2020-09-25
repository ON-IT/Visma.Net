using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class CashSale : DtoPaginatedProviderBase, IProvideIdentificator
    {
        public CashSale()
        {
            DtoFields.Add("creditTermsId", new CreditTerms("30"));
            DtoFields.Add("documentDueDate", new DtoValue(DateTime.Today.AddDays(14)));
            DtoFields.Add("cashDiscountDate", new DtoValue(DateTime.Today));
        }

        public string cashAccount
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public Location location
        {
            get { return Get<Location>("locationId"); }
            set { Set(value, "locationId"); }
        }

        public string paymentReference
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public List<CashSaleLine> cashSaleLines
        {
            get
            {
                return Get("cashSalesLines", new List<CashSaleLine>());
            }
            set
            {
                Set(value, "cashSalesLines");
            }
        }

        public bool hold
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public CreditTerms creditTerms
        {
            get
            {
                return Get<CreditTerms>("creditTermsId", new CreditTerms("30"));
            }
            set
            {
                Set(value, "creditTermsId");
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

        public DateTime documentDate
        {
            get { return Get<DateTime>(defaultValue:DateTime.Now); }
            set { Set(value); }
        }

        public string currencyId
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

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
        public string salesPersonDescr
        {
            get { return Get<string>(); }
            private set { Set(value); }
        }

        /// <summary>
        ///     This will only contain name and number.
        /// </summary>
        [JsonProperty]
        public Customer customer
        {
            get { return Get<Customer>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public CustomerDocumentType documentType
        {
            get { return Get<CustomerDocumentType>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public CustomerDocumentStatus status
        {
            get { return Get<CustomerDocumentStatus>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal amount
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        [JsonProperty]
        public decimal amountInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        [JsonProperty]
        public decimal balance
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        [JsonProperty]
        public decimal balanceInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        [JsonProperty]
        public decimal cashDiscount
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        [JsonProperty]
        public decimal cashDiscountInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
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
        
        #region Methods
        public void Add(CashSaleLine line)
        {
            line.lineNumber = 1;
            if (cashSaleLines.Count > 0)
                line.lineNumber = Math.Max(cashSaleLines.Count + 1, cashSaleLines.Max(x => x.lineNumber) + 1);
            cashSaleLines.Add(line);
        }

        public void Add(string inventoryId, int quantity = 1)
        {
            Add(new CashSaleLine()
            {
                inventoryNumber = inventoryId,
                quantity = quantity
            });
        }
        #endregion

        //public string number
        //{
        //    get { return referenceNumber; }
        //}

        //public int internalId
        //{
        //    get
        //    {
        //        int o;
        //        if (int.TryParse(referenceNumber, out o))
        //            return o;
        //        return 0;
        //    }
        //}

        public string GetIdentificator()
        {
            return referenceNumber;
        }
    }
}