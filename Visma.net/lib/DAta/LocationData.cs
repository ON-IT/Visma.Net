using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class LocationData : BaseCrudDataClass<Location>
    {
        internal LocationData(VismaNetAuthorization auth) : base(auth)
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