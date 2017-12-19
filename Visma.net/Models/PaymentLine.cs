using System;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class PaymentLine : DtoProviderBase
    {
        public PaymentLine()
        {
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }

        public ApiOperation operation
        {
            get { return Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value; }
            set { Set(new NotDto<ApiOperation>(value)); }
        }
        
        public string documentType
        {
            get { return Get<string>(); }
            set { Set(value); }
        }
        
        public string refNbr
        {
            get { return Get<string>(); }
            set { Set(value); }
        }
        
        public string amountPaid
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public DateTime date
        {
            get { return Get<DateTime>(); }
            set { Set(value);}
        }
    }
}
