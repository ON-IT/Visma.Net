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
        public string number { get; set; }
        public string name { get; set; }

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

    public class SupplierInvoice : DtoProviderBase, IHaveNumber, IHaveInternalId
    {
        public SupplierInvoice()
        {
            IgnoreProperties.Add(nameof(number));
            IgnoreProperties.Add(nameof(referenceNumber));
        }
        public string financialPeriod
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public List<SupplierInvoiceLine> invoiceLines
        {
            get { return Get(defaultValue: new List<SupplierInvoiceLine>()); }
            private set { Set(value); }
        }

        public SupplierNumber supplier
        {
            get { return Get(defaultValue: new SupplierNumber(), key: "supplierNumber"); }
            set { Set(value, "supplierNumber"); }
        }

        public bool hold
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public Location location
        {
            get { return Get<Location>("locationId"); }
            set { Set(value, "locationId"); }
        }

        public CreditTerms creditTerms
        {
            get { return Get<CreditTerms>(); }
            set { Set(value); }
        }

        public string cashDiscountDate
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public decimal detailTotal
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal detailTotalInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal vatTaxableTotal
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal vatTaxableTotalInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal vatExemptTotal
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal vatExemptTotalInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal vatTotal
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal vatTotalInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal withholdingTax
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal withholdingTaxInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public SupplierDocumentType documentType
        {
            get { return Get<SupplierDocumentType>(); }
            set { Set(value); }
        }

        public string referenceNumber
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string postPeriod
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public DateTime? date
        {
            get { return Get<DateTime?>(); }
            set { Set(value); }
        }

        public DateTime? dueDate
        {
            get { return Get<DateTime?>(); }
            set { Set(value); }
        }

        [JsonProperty]
        public SupplierApprovalDocumentStatus approvalStatus
        {
            get { return Get<SupplierApprovalDocumentStatus>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public SupplierInvoiceDocumentStatus status
        {
            get { return Get<SupplierInvoiceDocumentStatus>(); }
            private set { Set(value); }
        }

        public string currencyId
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public decimal balance
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal balanceInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal cashDiscount
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal cashDiscountInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public PaymentMethod paymentMethod
        {
            get { return Get<PaymentMethod>(); }
            set { Set(value); }
        }

        public string supplierReference
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string createdDateTime
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string lastModifiedDateTime
        {
            get { return Get<string>(); }
            set { Set(value); }
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

        public string number
        {
            get { return referenceNumber; }
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
            {
                invoiceLine.operation = ApiOperation.Update;
            }
        }

        #endregion
    }
}