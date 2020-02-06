using System;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;
using System.IO;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class ShipmentData : BasePaginatedCrudDataClass<Shipment>
    {
        public ShipmentData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.Shipments;
        }
        
        public override Task<Shipment> Add(Shipment entity)
        {
            throw new NotImplementedException();
        }
        public async Task<VismaActionResult> ConfirmShipment(Shipment shipment)
        {
            return await VismaNetApiHelper.ShipmentAction(shipment.GetIdentificator(), "confirmShipment", Authorization);
        }

        public async Task<Stream> PrintShipmentConfirmation (Shipment shipment)
        {
            return await VismaNetApiHelper.ShipmentPrint(shipment.GetIdentificator(), "printShipmentConfirmation", Authorization);
        }

        public async Task<Stream> PrintPickList(Shipment shipment)
        {
            return await VismaNetApiHelper.ShipmentPrint(shipment.GetIdentificator(), "printPickList", Authorization);
        }
    }
}