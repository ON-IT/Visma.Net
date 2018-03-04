using System;
using System.Collections.Generic;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class CustomerInvoice : InvoiceBase
    {
        public CreditTerms creditTerms
        {
            get { return Get<CreditTerms>("creditTermsId"); }
            set { Set(value, "creditTermsId"); }
        }
        public DateTime documentDueDate
        {
            get { return Get<DateTime>(); }
            set { Set(value); }
        }

        public string paymentReference
        {
            get { return Get<string>(); }
            set { Set(value); }
        }
        public DateTime cashDiscountDate
        {
            get { return Get<DateTime>(); }
            set { Set(value); }
        }

        public PaymentMethod paymentMethod
        {
            get { return Get<PaymentMethod>("paymentMethodId"); }
            set { Set(value, "paymentMethodId"); }
        }

        public List<TaxDetail> TaxDetails { get; set; }

        public CustomerInvoice()
        {
            IgnoreProperties.Add(nameof(this.referenceNumber));
            IgnoreProperties.Add(nameof(this.exchangeRate));
        }
        /// <summary>
        /// Create a new customer invoice without auto numbering
        /// </summary>
        /// <param name="referenceNumber"></param>
        public CustomerInvoice(string referenceNumber)
        {
            this.referenceNumber = referenceNumber;
        }

        internal override void PrepareForUpdate()
        {
            foreach (var customerInvoiceLine in invoiceLines)
            {
                customerInvoiceLine.operation = ApiOperation.Update;
            }
        }
    }
}