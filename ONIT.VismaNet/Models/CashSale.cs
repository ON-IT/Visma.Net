using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class CashSale : DtoProviderBase, IHaveNumber, IHaveInternalId
    {
        // WRITEABLE
        //public class CashSaleUpdateDto
        //{
        //    public DtoValue<string> CashAccount { get; set; }
        //    public DtoValue<string> PaymentReference { get; set; }
        //    public CashSaleLinesUpdateDto[] CashSalesLines { get; set; }
        //    public DtoValue<string> ReferenceNumber { get; set; }
        //    public DtoValue<string> CustomerNum-ber { get; set; }
        //    public DtoValue<DateTime> DocumentDate { get; set; }
        //    public DtoValue<bool> Hold { get; set; }
        //    public DtoValue<string> PostPeriod { get; set; }
        //    public DtoValue<string> InvoiceText { get; set; }
        //    public DtoValue<string> LocationId { get; set; }
        //    public DtoValue<string> CurrencyId { get; set; }
        //    public DtoValue<string> CreditTermsId { get; set; } // "CreditTerms"
        //    public DtoValue<DateTime> CashDiscountDate { get; set; }
        //    public DtoValue<string> PaymentMethodId { get; set; } // "PaymentMethod" (PaymentMethodDto)
        //    public DtoValue<Nullable<int>> SalesPersonID { get; set; }
        //    public DtoValue<string> Note { get; set; }
        //}

        /* READABLE */
        //public class CashSaleDto
        //{
        //    public LocationDto Location { get; set; }
        //    public decimal DetailTotal { get; set; }
        //    public decimal DetailTotalInCurrency { get; set; }
        //    public decimal VatTaxableTotal { get; set; }
        //    public decimal VatTaxableTotalInCurrency { get; set; }
        //    public decimal VatExemptTotal { get; set; }
        //    public decimal VatExemptTotalInCurrency { get; set; }
        //    public decimal VatTotal { get; set; }
        //    public decimal VatTotalInCurrency { get; set; }
        //    public string SalesPersonDescr { get; set; }
        //    public CustomerNumberDto Customer { get; set; }
        //    public Nullable<CustomerDocumentTypes> DocumentType { get; set; }
        //    public Nullable<CustomerDocumentStatuses> Status { get; set; }
        //    public decimal Amount { get; set; }
        //    public decimal AmountInCurrency { get; set; }
        //    public decimal Balance { get; set; }
        //    public decimal BalanceInCurrency { get; set; }
        //    public decimal CashDiscount { get; set; }
        //    public decimal CashDiscountInCurrency { get; set; }
        //    public string CustomerRefNumber { get; set; }
        //    public Nullable<DateTime> LastModifiedDateTime { get; set; }
        //    public Nullable<DateTime> CreatedDateTime { get; set; }
        //}

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
        public CustomerDocumentStatus? status
        {
            get { return Get<CustomerDocumentStatus?>(); }
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

        public string number
        {
            get { return referenceNumber; }
        }

        public int internalId
        {
            get
            {
                int o;
                if (int.TryParse(referenceNumber, out o))
                    return o;
                return 0;
            }
        }
    }
}