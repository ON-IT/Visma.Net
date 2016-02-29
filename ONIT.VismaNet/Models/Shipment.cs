using System;
using System.Collections.Generic;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class Shipment : DtoProviderBase, IHaveNumber, IHaveInternalId
    {
        public string shipmentNumber
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public ShipmentTypes shipmentType
        {
            get { return Get<ShipmentTypes>(); }
            set { Set(value); }
        }

        public ShipmentStatus status
        {
            get { return Get<ShipmentStatus>(); }
            set { Set(value); }
        }

        public bool hold
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public ShipmentOperations operation
        {
            get { return Get<ShipmentOperations>(); }
            set { Set(value); }
        }

        public DateTime shipmentDate
        {
            get { return Get<DateTime>(); }
            set { Set(value); }
        }

        public Customer customer
        {
            get { return Get<Customer>(); }
            set { Set(value); }
        }

        public Location location
        {
            get { return Get<Location>(); }
            set { Set(value); }
        }

        public Warehouse fromWarehouse
        {
            get { return Get<Warehouse>(); }
            set { Set(value); }
        }

        public Warehouse toWarehouse
        {
            get { return Get<Warehouse>(); }
            set { Set(value); }
        }

        public Currency currency
        {
            get { return Get("currencyId", new Currency()); }
            set { Set(value, key: "currencyId"); }
        }

        public UserDescription owner
        {
            get { return Get<UserDescription>(); }
            set { Set(value); }
        }

        public decimal shippedQuantity
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

        public decimal packages
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal packagesWeight
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal controlQuantity
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public ShipmentAddress deliveryAddress
        {
            get { return Get<ShipmentAddress>(); }
            set { Set(value); }
        }

        public ShipmentContact deliveryContact
        {
            get { return Get<ShipmentContact>(); }
            set { Set(value); }
        }

        public DescriptionId shipVia
        {
            get { return Get<DescriptionId>(); }
            set { Set(value); }
        }

        public DescriptionId fOBPoint
        {
            get { return Get<DescriptionId>(); }
            set { Set(value); }
        }

        public DescriptionId shippingTerms
        {
            get { return Get<DescriptionId>(); }
            set { Set(value); }
        }

        public DescriptionId shippingZone
        {
            get { return Get<DescriptionId>(); }
            set { Set(value); }
        }

        public bool residentialDelivery
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public bool saturdayDelivery
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public bool useCustomerAccount
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public bool insurance
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public decimal freightCost
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal freightAmt
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public DescriptionId transactionType
        {
            get { return Get<DescriptionId>(); }
            set { Set(value); }
        }

        public DescriptionId modeOfTrasport
        {
            get { return Get<DescriptionId>(); }
            set { Set(value); }
        }

        public bool container
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public List<ShipmentDetailLine> shipmentDetailLines
        {
            get { return Get(defaultValue: new List<ShipmentDetailLine>()); }
            set { Set(value); }
        }

        public List<ShipmentOrderLine> shipmentOrderLines
        {
            get { return Get(defaultValue: new List<ShipmentOrderLine>()); }
            set { Set(value); }
        }

        public List<PackageDetailLine> shipmentPackageLines
        {
            get { return Get(defaultValue:new List<PackageDetailLine>()); }
            set { Set(value); }
        }

        public string number => shipmentNumber;

        public int internalId
        {
            get
            {
                int x;
                if (int.TryParse(shipmentNumber, out x))
                    return x;
                return 0;
            }
        }

        internal override void PrepareForUpdate()
        {
            foreach (var detailLine in shipmentDetailLines)
            {
                detailLine.operation = ApiOperation.Update;
            }
            foreach (var detailLine in shipmentOrderLines)
            {
                detailLine.operation = ApiOperation.Update;
            }
            foreach (var detailLine in shipmentPackageLines)
            {
                detailLine.operation = ApiOperation.Update;
            }
        }
    }
}