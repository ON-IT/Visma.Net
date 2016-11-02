using System;
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

        public CustomerInvoice()
        {
            IgnoreProperties.Add(nameof(this.number));
            IgnoreProperties.Add(nameof(this.referenceNumber));
        }
        /// <summary>
        /// Create a new customer invoice without auto numbering
        /// </summary>
        /// <param name="number"></param>
        public CustomerInvoice(string number)
        {
            this.number = number;
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