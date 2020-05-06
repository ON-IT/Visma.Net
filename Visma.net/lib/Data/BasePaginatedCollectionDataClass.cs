using ONIT.VismaNetApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class BasePaginatedCollectionDataClass<T> : BaseCollectionDataClass<T> where T : DtoPaginatedProviderBase, IProvideIdentificator
    {
        internal BasePaginatedCollectionDataClass(VismaNetAuthorization auth) : base(auth)
        {
        }

        /// <summary>
        /// Gets all entities by splitting it into totalCount / pageSize tasks and fetching them in parallel.
        /// </summary>
        /// <returns></returns>
        /// <remarks>The order of the entities will be by the entity identificator. If the order matters to you, use OrderBy.</remarks>
        public override async Task<List<T>> All() => await VismaNetApiHelper.GetAllWithPagination<T>(ApiControllerUri, Authorization);

        /// <summary>
        ///     Retrieves all entities from Visma.Net.
        /// </summary>
        /// <returns>List of all entities</returns>
        public override async Task<List<T>> Find(NameValueCollection parameters) => await VismaNetApiHelper.GetAllWithPagination<T>(ApiControllerUri, Authorization, parameters);

        /// <summary>
        ///     Executes the action on all elements streamed from the API.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        [Obsolete("This no longer works as intended. Use All() or Find() instead.", true)]
        public override Task ForEach(Action<T> action)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        ///     Executes the action on all elements streamed from the API.
        /// </summary>
        /// <param name="action">This action can be async.</param>
        /// <returns></returns>
        [Obsolete("This no longer works as intended. Use All() or Find() instead.", true)]
        public override Task ForEach(Func<T, Task> action)
        {
            return Task.FromResult(true);
        }
    }
}
