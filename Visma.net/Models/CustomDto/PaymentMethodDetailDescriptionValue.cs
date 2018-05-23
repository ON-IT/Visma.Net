using ONIT.VismaNetApi.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class PaymentMethodDetailDescriptionValue : DtoProviderBase
    {
        public PaymentMethodDetailDescriptionValue(string paymentMethodDetailDescription)
        {
            this.paymentMethodDetailDescription = paymentMethodDetailDescription;
        }

        public string paymentMethodDetailDescription
        {
            get => Get(defaultValue: new NotDto<string>("")).Value;
            set => Set(new NotDto<string>(value));
        }
        public string paymentMethodDetailValue
        {
            get => Get<string>();
            set => Set(value); 
        }
    }
}
