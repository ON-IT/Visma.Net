using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class ShipmentOrderLine : DtoProviderBase
    {
        public ShipmentOrderLine()
        {
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }
        public ApiOperation operation
        {
            get { return Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value; }
            set { Set(new NotDto<ApiOperation>(value)); }
        }
        public string orderType
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string orderNbr
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public decimal shippedQty
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal shippedWeight
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal shippedVolume
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public string invoiceType
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string invoiceNbr
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string inventoryDocType
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string inventoryRefNbr
        {
            get { return Get<string>(); }
            set { Set(value); }
        }
    }
}