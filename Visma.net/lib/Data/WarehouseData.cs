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

        /// <summary>
        /// Not Implemented
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override Task<Warehouse> Add(Warehouse entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not Implemented
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override Task Update(Warehouse entity)
        {
            throw new NotImplementedException();
        }
    }
}

