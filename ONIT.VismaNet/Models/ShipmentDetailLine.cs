using System;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;

namespace ONIT.VismaNetApi.Models
{
    public class ShipmentDetailLine : DtoProviderBase
    {
        public int lineNumber
        {
            get { return Get<int>(); }
            set { Set(value); }
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

        public int inventoryId
        {
            get { return Get<int>(); }
            set { Set(value); }
        }

        public bool freeItem
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public Warehouse warehouse
        {
            get { return Get<Warehouse>(); }
            set { Set(value); }
        }

        public Location location
        {
            get { return Get<Location>(); }
            set { Set(value); }
        }

        public string uOM
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public decimal shippedQty
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal orderedQty
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal openQty
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public string lotSerialNbr
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public DateTime expirationDate
        {
            get { return Get<DateTime>(); }
            set { Set(value); }
        }

        public string reasonCode
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string description
        {
            get { return Get<string>(); }
            set { Set(value); }
        }
    }
}