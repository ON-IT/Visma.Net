using ONIT.VismaNetApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{

    public abstract class BaseCrudDataClass<T> : BaseDataClass where T : DtoProviderBase, IProvideIdentificator
    {
        internal BaseCrudDataClass(VismaNetAuthorization auth) : base(auth)
        {
        }

        /// <summary>
        ///     Creates a new entity
        /// </summary>
        /// <param name="entity">Entity to create</param>
        /// <returns>The created entity from Visma.Net</returns>
        public virtual async Task<T> Add(T entity)
        {
            var rsp = await VismaNetApiHelper.Create(entity, ApiControllerUri, Authorization);
            rsp.InternalPrepareForUpdate();
            return rsp;
        }

        /// <summary>
        ///     Updates an entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        public virtual async Task Update(T entity)
        {
            await VismaNetApiHelper.Update(entity, entity.GetIdentificator(), ApiControllerUri, Authorization);
        }

        /// <summary>
        ///     Retrieves a single entity by its entity number
        /// </summary>
        /// <param name="entityNumber">Entity number from Visma.Net</param>
        /// <returns>T</returns>
        public virtual async Task<T> Get(string entityNumber)
        {
            var rsp = await VismaNetApiHelper.Get<T>(entityNumber, ApiControllerUri, Authorization);
            rsp.InternalPrepareForUpdate();
            return rsp;
        }

        /// <summary>
        ///     Retrieves all entities from Visma.Net. WARNING: Slow.
        /// </summary>
        /// <returns>List of all entities</returns>
        public virtual async Task<List<T>> All()
        {
            var rsp = await VismaNetApiHelper.GetAll<T>(ApiControllerUri, Authorization);
            rsp.ForEach(x => x.InternalPrepareForUpdate());
            return rsp;
        }

        /// <summary>
        ///     Retrieves all entities from Visma.Net. WARNING: Slow.
        /// </summary>
        /// <returns>List of all entities</returns>
        public virtual async Task<List<T>> Find(NameValueCollection parameters)
        {
            var rsp = await VismaNetApiHelper.GetAll<T>(ApiControllerUri, Authorization, parameters);
            rsp.ForEach(x => x.InternalPrepareForUpdate());
            return rsp;
        }

        /// <summary>
        ///     Retrieves all entities from Visma.Net. WARNING: Slow.
        /// </summary>
        /// <returns>List of all entities</returns>
        public virtual async Task<List<T>> Find(object parameters)
        {
            var formFields = new NameValueCollection();
            parameters.GetType().GetProperties()
                .ToList()
                .ForEach(pi => formFields.Add(pi.Name, pi.GetValue(parameters, null).ToString()));
            return await Find(formFields);
        }

        /// <summary>
        ///     Executes the action on all elements streamed from the API.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        [Obsolete("This no longer works as intended. Use All() or Find() instead.")]
        public virtual async Task ForEach(Action<T> action)
        {
            await VismaNetApiHelper.ForEach(ApiControllerUri, Authorization, (T obj) =>
            {
                action(obj);
                return Task.FromResult(true);
            });
        }

        /// <summary>
        ///     Executes the action on all elements streamed from the API.
        /// </summary>
        /// <param name="action">This action can be async.</param>
        /// <returns></returns>
        [Obsolete("This no longer works as intended. Use All() or Find() instead.")]
        public virtual async Task ForEach(Func<T, Task> action)
        {
            await VismaNetApiHelper.ForEach(ApiControllerUri, Authorization, action);
        }

        /// <summary>
        ///     Retrieves all entities modified since given datetime from Visma.Net.
        /// </summary>
        /// <returns>List of all entities</returns>
        public virtual async Task<List<T>> GetAllModifiedSince(DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
            {
                return await All();
            }
            else
            {
                return await Find(new NameValueCollection
                    {
                        {"LastModifiedDateTime", dateTime.ToString(VismaNetApiHelper.VismaNetDateTimeFormat)},
                        {"LastModifiedDateTimeCondition", ">"}
                    });
            }
        }
    }
}