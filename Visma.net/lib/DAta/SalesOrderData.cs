using System;
using System.Collections.Generic;
using ONIT.VismaNetApi.Models;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class SalesOrderData : BaseCrudDataClass<SalesOrder>
    {
        public SalesOrderData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.SalesOrder;
        }

        public override async Task Update(SalesOrder entity)
        {
            if (entity.orderType != "SO") // SO ordertypes are special.
            {
                await VismaNetApiHelper.Update(entity, entity.GetIdentificator(), ApiControllerUri, Authorization,$"{entity.orderType}/{entity.GetIdentificator()}");
            }
            else
            {
                await VismaNetApiHelper.Update(entity, entity.GetIdentificator(), ApiControllerUri, Authorization);
            }
        }

        public override async Task<SalesOrder> Add(SalesOrder entity)
        {
            SalesOrder rsp;
            if (entity.orderType != "SO")
            {
                 rsp = await VismaNetApiHelper.Create(entity, ApiControllerUri, Authorization, $"{ApiControllerUri}/{entity.orderType}");
            }
            else
            {
                rsp = await VismaNetApiHelper.Create(entity, ApiControllerUri, Authorization);
            }
            rsp.InternalPrepareForUpdate();
            return rsp;
        }
    }

    public class LocationData : BaseCrudDataClass<Location>
    {
        internal LocationData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.Locations;
        }

        protected LocationData() : base(null)
        {
            ApiControllerUri = VismaNetControllers.Locations;
        }

        public override Task<Location> Get(string entityNumber)
        {
            throw new NotImplementedException();
        }

        public override Task<List<Location>> All()
        {
            throw new NotImplementedException();
        }

        public async Task<Location> Get(string baccountId, string locationId)
        {
            return await VismaNetApiHelper.Get<Location>($"{baccountId}/{locationId}", VismaNetControllers.Locations, Authorization);
        }

        public async Task<List<Location>> All(string baccountId)
        {
            return await VismaNetApiHelper.GetAll<Location>($"{VismaNetControllers.Locations}/{baccountId}", Authorization);
        }
    }
}