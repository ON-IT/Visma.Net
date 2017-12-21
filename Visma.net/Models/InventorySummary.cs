using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONIT.VismaNetApi.Models
{
    public class InventorySummary : DtoProviderBase
    {
        public NumberName inventory {get; set;}
        public IdName location { get; set; }
        public DescriptiveDto warehouse { get; set; }
        public decimal available { get; set; }
        public decimal availableForShipment { get; set; }
        public decimal notAvailable { get; set; }
        public decimal soBooked { get; set; }
        public decimal soAllocated { get; set; }
        public decimal soShipped { get; set; }
        public decimal soBackOrdered { get; set; }

        public decimal inIssues { get; set; }
        public decimal inReceipts { get; set; }
        public decimal inAssemblyDemand { get; set; }
        public decimal inAssemblySupply { get; set; }
        public decimal purchasePrepared { get; set; }
        public decimal purchaseOrders { get; set; }
        public decimal poReceipts { get; set; }
        public decimal expired { get; set; }
        public decimal onHand { get; set; }

        public decimal soToPurchase { get; set; }
        public decimal purchaseForSOPrepared { get; set; }

        public decimal purchaseForSOReceipts { get; set; }
        public decimal soToDropShip { get; set; }
        public decimal dropShipForSO { get; set; }
        public decimal dropShipForSOPrepared { get; set; }
        public decimal dropShipForSOReceipts { get; set; }

        public decimal estimatedUnitCost { get; set; }
        public decimal estimatedTotalCost { get; set; }

        public string baseUnit { get; set; }
    }
}
