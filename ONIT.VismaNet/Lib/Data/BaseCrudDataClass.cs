using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public abstract class BaseCrudDataClass<T> : BaseDataClass where T : DtoProviderBase, IProvideIdentificator
    {
        internal BaseCrudDataClass(VismaNetAuthorization auth) : base(auth)
        {
        }

        /// <summary>
        /// Creates a new entity
        /// </summary>
        /// <param name="entity">Entity to create</param>
        /// <returns>The created entity from Visma.Net</returns>
        public virtual async Task<T> AddAsyncTask(T entity)
        {
            var rsp = await VismaNetApiHelper.Create(entity, ApiControllerUri, Authorization);
            rsp.InternalPrepareForUpdate();
            return rsp;
        }
        
        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        public virtual async Task UpdateAsyncTask(T entity)
        {
            await VismaNetApiHelper.Update(entity, entity.GetIdentificator(), ApiControllerUri, Authorization);
        }
        
        /// <summary>
        /// Retrieves a single entity by its entity number
        /// </summary>
        /// <param name="entityNumber">Entity number from Visma.Net</param>
        /// <returns>T</returns>
        public virtual async Task<T> GetAsyncTask(string entityNumber)
        {
            var rsp = await VismaNetApiHelper.Get<T>(entityNumber, ApiControllerUri, Authorization);
            rsp.InternalPrepareForUpdate();
            return rsp;
        }
        
        /// <summary>
        /// Retrieves all entities from Visma.Net. WARNING: Slow.
        /// </summary>
        /// <returns>List of all entities</returns>
        public virtual async Task<List<T>> AllAsyncTask()
        {
            var rsp = await VismaNetApiHelper.GetAll<T>(ApiControllerUri, Authorization);
            rsp.ForEach(x=>x.InternalPrepareForUpdate());
            return rsp;
        }

        /// <summary>
        /// Retrieves all entities from Visma.Net. WARNING: Slow.
        /// </summary>
        /// <returns>List of all entities</returns>
        public virtual async Task<List<T>> FindAsyncTask(NameValueCollection parameters)
        {
            var rsp = await VismaNetApiHelper.GetAll<T>(ApiControllerUri, Authorization, parameters);
            rsp.ForEach(x=>x.InternalPrepareForUpdate());
            return rsp;
        }

        /// <summary>
        /// Retrieves all entities from Visma.Net. WARNING: Slow.
        /// </summary>
        /// <returns>List of all entities</returns>
        public virtual async Task<List<T>> FindAsyncTask(object parameters)
        {
            var formFields = new NameValueCollection();
            parameters.GetType().GetProperties()
                .ToList()
                .ForEach(pi => formFields.Add(pi.Name, pi.GetValue(parameters, null).ToString()));
            var rsp = await VismaNetApiHelper.GetAll<T>(ApiControllerUri, Authorization, formFields);
            rsp.ForEach(x=>x.InternalPrepareForUpdate());
            return rsp;
        }



        /// <summary>
        /// Retrieves all entities from Visma.Net. WARNING: Slow.
        /// </summary>
        /// <returns>List of all entities</returns>
        public virtual IEnumerable<T> GetEnumerable()
        {
            return VismaNetApiHelper.GetAllEnumerable<T>(ApiControllerUri, Authorization);
        }
        /// <summary>
        /// Executes the action on all elements streamed from the API.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual async Task ForEach(Action<T> action)
        {
            await VismaNetApiHelper.ForEach(ApiControllerUri, Authorization, action);
        }

        /// <summary>
        /// Retrieves all entities modified since given datetime from Visma.Net.
        /// </summary>
        /// <returns>List of all entities</returns>
        public virtual async Task<List<T>> GetAllModifiedSinceAsyncTask(DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
            {
                var rsp = await VismaNetApiHelper.GetAll<T>(ApiControllerUri, Authorization);
                rsp.ForEach(x => x.PrepareForUpdate());
                return rsp;
            }
            else
            {
                var rsp = await VismaNetApiHelper.GetAllModifiedSince<T>(ApiControllerUri, dateTime, Authorization);
                rsp.ForEach(x => x.PrepareForUpdate());
                return rsp;
            }
        }

        #region Sync methods

        [Obsolete("Please use async method", true)]
        public virtual T Add(T entity)
        {
            return Task.Run(async () => await AddAsyncTask(entity)).Result;
        }

        [Obsolete("Please use async method", true)]
        public virtual void Update(T entity)
        {
            Task.Run(async () => await UpdateAsyncTask(entity));
        }

        [Obsolete("Please use async method", true)]
        public virtual List<T> All()
        {
            return Task.Run(async () => await AllAsyncTask()).Result;
        }

        [Obsolete("Please use async method", true)]
        public virtual T Get(string entityNumber)
        {
            return Task.Run(async () => await GetAsyncTask(entityNumber)).Result;
        }
        #endregion

    }

    public class SalesOrderData : BaseCrudDataClass<SalesOrder>
    {
        public SalesOrderData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.SalesOrder;
        }
    }
}
