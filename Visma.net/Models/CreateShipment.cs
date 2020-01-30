using ONIT.VismaNetApi.Lib;
using System;

namespace ONIT.VismaNetApi.Models
{
    public class CreateShipment 
    {
        public string orderType
        {
            get;
            set;
        }
        public bool returnShipmentDto
        {
            get;
            set;
        }
        public DateTime shipmentDate
        {
            get;
            set;
        }
        public string shipmentWarehouse
        {
            get;
            set;
        }
        public string operation
        {
            get;
            set;
        }


    }
}
