using ONIT.VismaNetApi.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class CustomerPaymentMethod : DtoProviderBase
    {
        public CustomerPaymentMethod()
        {
        }
        public CustomerPaymentMethod(string paymentMethodId, bool isDefault = false)
        {
            this.paymentMethodId = paymentMethodId;
            this.isDefault = isDefault;
        }
        
        public override Dictionary<string, object> ToDto(bool delta = false)
        {
            if(string.IsNullOrEmpty(paymentMethodId))
                return null;
            return base.ToDto(delta);
        }

        public string paymentMethodId
        {
            get => Get<string>();
            set => Set(value);
        }
        public bool isDefault
        {
            get => Get<bool>();
            set => Set(value);
        }
    }
}
