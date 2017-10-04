using System;
using System.Collections.Generic;
using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models
{
    public class Payment : DtoProviderBase, IProvideIdentificator
    {
        public string refNbr
        {
            get { return Get<string>(); }
            set { Set(value); }
        }
        
        public string type
        {
            get { return Get<string>(); }
            set { Set(value); }
        }
        public string cashAccount
        {
            get { return Get<string>(); }
            set { Set(value); }
        }
        public NumberName customer
        {
            get { return Get<NumberName>(); }
            set { Set(value); }
        }

        public decimal paymentAmount
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public List<PaymentLine> paymentLines
        {
            get { return Get(defaultValue: new List<PaymentLine>()); }
            private set { Set(value); }
        }

        public DateTime applicationDate
        {
            get
            {
                return Get<DateTime>();
            }
            set
            {
                Set(value);
            }
        }
        public string GetIdentificator()
        {
            return refNbr;
        }
    }
}
