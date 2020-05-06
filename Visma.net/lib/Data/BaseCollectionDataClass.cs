using ONIT.VismaNetApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{

    public abstract class BaseCollectionDataClass<T> : BaseDataClass where T : DtoProviderBase, IProvideIdentificator
    {
        internal BaseCollectionDataClass(VismaNetAuthorization auth) : base(auth)
        {
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