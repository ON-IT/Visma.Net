using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        public override Task<List<Location>> Find(NameValueCollection parameters)
        {
            throw new NotImplementedException();
        }

        public override Task ForEach(Action<Location> action)
        {
            throw new NotImplementedException();
        }

        public override Task ForEach(Func<Location, Task> action)
        {
            throw new NotImplementedException();
        }

        public override Task<List<Location>> GetAllModifiedSince(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Retrieves a single entity by its entity number
        /// </summary>
        /// <param name="baccountId">baccount ID for whih to fetch locations.</param>
        /// <param name="locationId">location ID for the location to fetch.</param>
        /// <returns>T</returns>
        public async Task<Location> Get(string baccountId, string locationId)
        {
            return await VismaNetApiHelper.Get<Location>($"{baccountId}/{locationId}", VismaNetControllers.Locations, Authorization);
        }

        /// <summary>
        ///     Retrieves all entities from Visma.Net. WARNING: Slow.
        /// </summary>
        /// <returns>List of all entities</returns>
        public async Task<List<Location>> All(string baccountId)
        {
            return await VismaNetApiHelper.GetAll<Location>($"{VismaNetControllers.Locations}/{baccountId}", Authorization);
        }

        /// <summary>
        ///     Retrieves all entities from Visma.Net. WARNING: Slow.
        /// </summary>
        /// <returns>List of all entities</returns>
        public async Task<List<Location>> Find(string baccountId, NameValueCollection parameters)
        {
            return await VismaNetApiHelper.GetAll<Location>($"{VismaNetControllers.Locations}/{baccountId}", Authorization, parameters);
        }

        /// <summary>
        ///     Executes the action on all elements streamed from the API.
        /// </summary>
        /// <param name="baccountId">baccount ID for whih to fetch locations.</param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task ForEach(string baccountId, Action<Location> action)
        {
            await VismaNetApiHelper.ForEach($"{VismaNetControllers.Locations}/{baccountId}", Authorization, (Location obj) =>
            {
                action(obj);
                return Task.FromResult(true);
            });
        }

        /// <summary>
        ///     Executes the action on all elements streamed from the API.
        /// </summary>
        /// <param name="baccountId">baccount ID for whih to fetch locations.</param>
        /// <param name="action">This action can be async.</param>
        /// <returns></returns>
        public async Task ForEach(string baccountId, Func<Location, Task> action)
        {
            await VismaNetApiHelper.ForEach($"{VismaNetControllers.Locations}/{baccountId}", Authorization, action);
        }

        /// <summary>
        ///     Retrieves all entities modified since given datetime from Visma.Net.
        /// </summary>
        /// <returns>List of all entities</returns>
        public async Task<List<Location>> GetAllModifiedSince(string baccountId, DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
            {
                var rsp = await VismaNetApiHelper.GetAll<Location>($"{VismaNetControllers.Locations}/{baccountId}", Authorization);
                rsp.ForEach(x => x.PrepareForUpdate());
                return rsp;
            }
            else
            {
                var rsp = await VismaNetApiHelper.GetAllModifiedSince<Location>($"{VismaNetControllers.Locations}/{baccountId}", dateTime, Authorization);
                rsp.ForEach(x => x.PrepareForUpdate());
                return rsp;
            }

        }

    }
}