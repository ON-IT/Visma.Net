using System;
using ONIT.VismaNetApi.Models.CustomDto;

namespace ONIT.VismaNetApi.Models
{
    public class CustomerInvoice : InvoiceBase
    {
        public CreditTerms creditTerms
        {
            get { return Get("creditTermsId", new CreditTerms() { id = "30" }); }
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
            get { return Get<PaymentMethod>("paymentMethodId", new PaymentMethod { id = "30" }); }
            set { Set(value, key: "paymentMethodId"); }
        }

        public CustomerInvoice()
        {
            DtoFields.Add("creditTermsId", new CreditTerms("30"));
            DtoFields.Add("documentDueDate", new DtoValue(DateTime.Today.AddDays(14)));
            DtoFields.Add("cashDiscountDate", new DtoValue(DateTime.Today));

            IgnoreProperties.Add(nameof(this.number));
            IgnoreProperties.Add(nameof(this.referenceNumber));
        }
    }
}