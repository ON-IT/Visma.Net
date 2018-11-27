using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class SupplierNumber : IProvideCustomDto
    {
        public string name { get; set; }
        public string number { get; set; }

        public object ToDto()
        {
            return new DtoValue(number);
        }

        public static implicit operator SupplierNumber(Supplier sup)
        {
            return new SupplierNumber
            {
                name = sup.name,
                number = sup.number
            };
        }
    }

    public class SupplierInvoice : DtoProviderBase, IProvideIdentificator
    {
        public SupplierInvoice()
        {
            IgnoreProperties.Add(nameof(referenceNumber));
        }

        /// <summary>
        ///     Create a new supplier invoice without auto numbering
        /// </summary>
        /// <param name="referenceNumber"></param>
        public SupplierInvoice(string referenceNumber)
        {
            this.referenceNumber = referenceNumber;
        }

        [JsonProperty]
        public SupplierApprovalDocumentStatus approvalStatus
        {
            get => Get<SupplierApprovalDocumentStatus>();
            private set => Set(value);
        }

        public decimal balance
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public decimal balanceInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public decimal cashDiscount
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public string cashDiscountDate
        {
            get => Get<string>();
            set => Set(value);
        }

        public decimal cashDiscountInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public string createdDateTime
        {
            get => Get<string>();
            set => Set(value);
        }

        public CreditTerms creditTerms
        {
            get => Get<CreditTerms>("creditTermsId");
            set => Set(value, "creditTermsId");
        }

        public string currencyId
        {
            get => Get<string>();
            set => Set(value);
        }

        public DateTime? date
        {
            get => Get<DateTime?>();
            set => Set(value);
        }

        public string description
        {
            get => Get<string>();
            set => Set(value);
        }

        public decimal detailTotal
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public decimal detailTotalInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public SupplierDocumentType documentType
        {
            get => Get<SupplierDocumentType>();
            set => Set(value);
        }

        public DateTime? dueDate
        {
            get => Get<DateTime?>();
            set => Set(value);
        }

        public decimal exchangeRate
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public string financialPeriod
        {
            get => Get<string>();
            set => Set(value);
        }

        public bool hold
        {
            get => Get<bool>();
            set => Set(value);
        }

        public List<SupplierInvoiceLine> invoiceLines
        {
            get => Get(defaultValue: new List<SupplierInvoiceLine>());
            private set => Set(value);
        }

        public string lastModifiedDateTime
        {
            get => Get<string>();
            set => Set(value);
        }

        public Location location
        {
            get => Get<Location>("locationId");
            set => Set(value, "locationId");
        }

        public string note
        {
            get => Get<string>();
            set => Set(value);
        }

        public PaymentMethod paymentMethod
        {
            get => Get<PaymentMethod>();
            set => Set(value);
        }

        public string postPeriod
        {
            get => Get<string>();
            set => Set(value);
        }

        public string referenceNumber
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public SupplierInvoiceDocumentStatus status
        {
            get => Get<SupplierInvoiceDocumentStatus>();
            private set => Set(value);
        }

        public SupplierNumber supplier
        {
            get => Get(defaultValue: new SupplierNumber(), key: "supplierNumber");
            set => Set(value, "supplierNumber");
        }

        public string supplierReference
        {
            get => Get<string>();
            set => Set(value);
        }

        public decimal vatExemptTotal
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public decimal vatExemptTotalInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public decimal vatTaxableTotal
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public decimal vatTaxableTotalInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public decimal vatTotal
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public decimal vatTotalInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public decimal withholdingTax
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public decimal withholdingTaxInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public string GetIdentificator()
        {
            return referenceNumber;
        }

        #region Methods

        public void Add(SupplierInvoiceLine line)
        {
            line.lineNumber = 1;
            if (invoiceLines.Count > 0)
                line.lineNumber = Math.Max(invoiceLines.Count + 1, invoiceLines.Max(x => x.lineNumber) + 1);
            invoiceLines.Add(line);
        }

        public void Add(string inventoryId, int quantity = 1)
        {
            Add(new SupplierInvoiceLine
            {
                inventoryNumber = inventoryId,
                quantity = quantity
            });
        }

        internal override void PrepareForUpdate()
        {
            foreach (var invoiceLine in invoiceLines)
                invoiceLine.operation = ApiOperation.Update;
        }

        #endregion
    }
}