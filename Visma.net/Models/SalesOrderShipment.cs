using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class SalesOrderShipment : DtoProviderBase
    {
        public string shipmentType
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string shipmentNo
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public DateTime shipmentDate
        {
            get { return Get<DateTime>(); }
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

        public string invoiceNo
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string inventoryDocType
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string inventoryRefNo
        {
            get { return Get<string>(); }
            set { Set(value); }
        }
    }
}