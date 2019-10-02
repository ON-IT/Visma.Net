using ONIT.VismaNetApi.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class CustomerPaymentMethod : DtoProviderBase
    {
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
