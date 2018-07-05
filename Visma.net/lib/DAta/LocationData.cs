using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class LocationData : BaseDataClass 
    {
        internal LocationData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.Location;
        }

        /// <summary>
        ///     Creates a new entity
        /// </summary>
        /// <param name="entity">Entity to create</param>
        /// <returns>The created entity from Visma.Net</returns>
        public virtual async Task<Location> Add(Location entity)
        {
            var rsp = await VismaNetApiHelper.Create(entity, ApiControllerUri, Authorization);
            rsp.InternalPrepareForUpdate();
            return rsp;
        }

        /// <summary>
        ///     Updates an entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        public virtual async Task Update(Location entity)
        {
            await VismaNetApiHelper.Update(entity, $"{entity.baccount.number}/{entity.locationId}", ApiControllerUri, Authorization);
        }

        /// <summary>
        ///     Retrieves a single entity by its entity number
        /// </summary>
        /// <param name="baccountId">baccount ID for whih to fetch locations.</param>
        /// <param name="locationId">location ID for the location to fetch.</param>
        /// <returns>T</returns>
        public async Task<Location> Get(string baccountId, string locationId)
        {
            return await VismaNetApiHelper.Get<Location>($"{baccountId}/{locationId}", VismaNetControllers.Location, Authorization);
        }

        /// <summary>
        ///     Retrieves all entities from Visma.Net. WARNING: Slow.
        /// </summary>
        /// <returns>List of all entities</returns>
        public async Task<List<Location>> All(string baccountId)
        {
            var all = await VismaNetApiHelper.GetAll<Location>($"{VismaNetControllers.Location}/{baccountId}", Authorization);
            all.ForEach(x=>x.PrepareForUpdate());
            return all;
        }

        /// <summary>
        ///     Retrieves all entities from Visma.Net. WARNING: Slow.
        /// </summary>
        /// <returns>List of all entities</returns>
        public async Task<List<Location>> Find(string baccountId, NameValueCollection parameters)
        {
            var all =  await VismaNetApiHelper.GetAll<Location>($"{VismaNetControllers.Location}/{baccountId}", Authorization, parameters);
            all.ForEach(x=>x.PrepareForUpdate());
            return all;
        }

        /// <summary>
        ///     Executes the action on all elements streamed from the API.
        /// </summary>
        /// <param name="baccountId">baccount ID for whih to fetch locations.</param>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task ForEach(string baccountId, Action<Location> action)
        {
            await VismaNetApiHelper.ForEach($"{VismaNetControllers.Location}/{baccountId}", Authorization, (Location obj) =>
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
            await VismaNetApiHelper.ForEach($"{VismaNetControllers.Location}/{baccountId}", Authorization, action);
        }

        /// <summary>
        ///     Retrieves all entities modified since given datetime from Visma.Net.
        /// </summary>
        /// <returns>List of all entities</returns>
        public async Task<List<Location>> GetAllModifiedSince(string baccountId, DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
            {
                var rsp = await VismaNetApiHelper.GetAll<Location>($"{VismaNetControllers.Location}/{baccountId}", Authorization);
                rsp.ForEach(x => x.PrepareForUpdate());
                return rsp;
            }
            else
            {
                var rsp = await VismaNetApiHelper.GetAllModifiedSince<Location>($"{VismaNetControllers.Location}/{baccountId}", dateTime, Authorization);
                rsp.ForEach(x => x.PrepareForUpdate());
                return rsp;
            }

        }

    }
}