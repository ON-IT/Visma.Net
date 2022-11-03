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
      entity.InternalPrepareForUpdate();
      await VismaNetApiHelper.Update(entity, $"{entity.baccountId.Trim()}/{entity.locationId.Trim()}", ApiControllerUri, Authorization);
      //await VismaNetApiHelper.Update(entity, $"{entity.baccount.number.Trim()}/{entity.locationId.Trim()}", ApiControllerUri, Authorization);
    }

    /// <summary>
    ///     Retrieves a single entity by its entity number
    /// </summary>
    /// <param name="baccountId">baccount ID for whih to fetch locations.</param>
    /// <param name="locationId">location ID for the location to fetch.</param>
    /// <returns>T</returns>
    public async Task<Location> Get(string baccountId, string locationId)
    {
      var rsp = await VismaNetApiHelper.Get<Location>($"{baccountId.Trim()}/{locationId.Trim()}", VismaNetControllers.Location, Authorization);
      rsp.PrepareForUpdate();
      return rsp;
    }

    /// <summary>
    ///     Retrieves all entities from Visma.Net. WARNING: Slow.
    /// </summary>
    /// <returns>List of all entities</returns>
    public async Task<List<Location>> All(string baccountId)
    {
      var all = await VismaNetApiHelper.GetAllWithPagination<Location>($"{VismaNetControllers.Location}/{baccountId.Trim()}", Authorization);
      all.ForEach(x => x.PrepareForUpdate());
      return all;
    }

    /// <summary>
    ///     Retrieves all entities from Visma.Net. WARNING: Slow.
    /// </summary>
    /// <returns>List of all entities</returns>
    public async Task<List<Location>> Find(string baccountId, NameValueCollection parameters)
    {
      var all = await VismaNetApiHelper.GetAllWithPagination<Location>($"{VismaNetControllers.Location}/{baccountId.Trim()}", Authorization, parameters);
      all.ForEach(x => x.PrepareForUpdate());
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
      await VismaNetApiHelper.ForEach($"{VismaNetControllers.Location}/{baccountId.Trim()}", Authorization, (Location obj) =>
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
      await VismaNetApiHelper.ForEach($"{VismaNetControllers.Location}/{baccountId.Trim()}", Authorization, action);
    }

    /// <summary>
    ///     Retrieves all entities modified since given datetime from Visma.Net.
    /// </summary>
    /// <returns>List of all entities</returns>
    public async Task<List<Location>> GetAllModifiedSince(string baccountId, DateTime dateTime)
    {
      if (dateTime == DateTime.MinValue)
      {
        return await All(baccountId);
      }
      else
      {
        return await Find(baccountId, new NameValueCollection
                    {
                        {"LastModifiedDateTime", dateTime.ToString(VismaNetApiHelper.VismaNetDateTimeFormat)},
                        {"LastModifiedDateTimeCondition", ">"}
                    });
      }

    }

  }
}