using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public abstract class BaseCrudDataClass<T> : BaseDataClass where T : DtoProviderBase, IHaveNumber, IHaveInternalId
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
            return await VismaNetApiHelper.Create(entity, ApiControllerUri, Authorization);
        }
        
        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        public virtual async Task UpdateAsyncTask(T entity)
        {
            await VismaNetApiHelper.Update(entity, entity.number, ApiControllerUri, Authorization);
        }
        
        /// <summary>
        /// Retrieves a single entity by its entity number
        /// </summary>
        /// <param name="entityNumber">Entity number from Visma.Net</param>
        /// <returns>T</returns>
        public virtual async Task<T> GetAsyncTask(string entityNumber)
        {
            return await VismaNetApiHelper.Get<T>(entityNumber, ApiControllerUri, Authorization);
        }
        
        /// <summary>
        /// Retrieves all entities from Visma.Net. WARNING: Slow.
        /// </summary>
        /// <returns>List of all entities</returns>
        public virtual async Task<List<T>> AllAsyncTask()
        {
            return await VismaNetApiHelper.GetAll<T>(ApiControllerUri, Authorization);
        }

        /// <summary>
        /// Retrieves all entities from Visma.Net. WARNING: Slow.
        /// </summary>
        /// <returns>List of all entities</returns>
        public virtual async Task<List<T>> FindAsyncTask(NameValueCollection parameters)
        {
            return await VismaNetApiHelper.GetAll<T>(ApiControllerUri, Authorization, parameters);
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
            return await VismaNetApiHelper.GetAll<T>(ApiControllerUri, Authorization, formFields);
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
        /// Retrieves all entities modified since given datetime from Visma.Net.
        /// </summary>
        /// <returns>List of all entities</returns>
        public virtual async Task<List<T>> GetAllModifiedSinceAsyncTask(DateTime dateTime)
        {
            if(dateTime == DateTime.MinValue)
                return await VismaNetApiHelper.GetAll<T>(ApiControllerUri, Authorization);
            return await VismaNetApiHelper.GetAllModifiedSince<T>(ApiControllerUri, dateTime, Authorization);
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
}
