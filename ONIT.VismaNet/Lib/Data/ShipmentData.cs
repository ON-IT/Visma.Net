using System;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class ShipmentData : BaseCrudDataClass<Shipment>
    {
        public ShipmentData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.Shipments;
        }
        
        public override Task<Shipment> Add(Shipment entity)
        {
            throw new NotImplementedException();
        }
    }
}