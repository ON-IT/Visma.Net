using System;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class WarehouseData : BaseCrudDataClass<Warehouse>
    {
        internal WarehouseData(VismaNetAuthorization auth)
            : base(auth)
        {
            ApiControllerUri = VismaNetControllers.Warehouse;
        }

        public override Task<Warehouse> Add(Warehouse entity)
        {
            throw new NotImplementedException();
        }

        public override Task Update(Warehouse entity)
        {
            throw new NotImplementedException();
        }
    }
}

