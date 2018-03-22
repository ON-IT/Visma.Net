using System;
using System.Collections.Generic;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class CustomerInvoice : InvoiceBase
    {
        public CustomerInvoice()
        {
            IgnoreProperties.Add(nameof(referenceNumber));
            IgnoreProperties.Add(nameof(exchangeRate));
        }

        /// <summary>
        ///     Create a new customer invoice without auto numbering
        /// </summary>
        /// <param name="referenceNumber"></param>
        public CustomerInvoice(string referenceNumber)
        {
            this.referenceNumber = referenceNumber;
        }

        public CreditTerms creditTerms
        {
            get => Get<CreditTerms>("creditTermsId");
            set => Set(value, "creditTermsId");
        }

        public DateTime documentDueDate
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        public string paymentReference
        {
            get => Get<string>();
            set => Set(value);
        }

        public string note
        {
            get => Get<string>();
            set => Set(value);
        }

        public DateTime cashDiscountDate
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        public PaymentMethod paymentMethod
        {
            get => Get<PaymentMethod>("paymentMethodId");
            set => Set(value, "paymentMethodId");
        }

        public List<TaxDetail> TaxDetails { get; set; }

        internal override void PrepareForUpdate()
        {
            foreach (var customerInvoiceLine in invoiceLines)
                customerInvoiceLine.operation = ApiOperation.Update;
        }
    }
}