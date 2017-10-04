using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class PackageDetailLine : DtoProviderBase
    {
        public PackageDetailLine()
        {
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }
        public ApiOperation operation
        {
            get { return Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value; }
            set { Set(new NotDto<ApiOperation>(value));}
        }
        public int lineNumber
        {
            get { return Get<int>(); }
            set { Set(value); }
        }

        public bool confirmed
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public string boxId
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string type
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string description
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public decimal weight
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public string uom
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public decimal declaredValue
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal coDAmount
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public string trackingNumber
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string customRefNbr1
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string customRefNbr2
        {
            get { return Get<string>(); }
            set { Set(value); }
        }
    }
}