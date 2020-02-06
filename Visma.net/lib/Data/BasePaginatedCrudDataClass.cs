using ONIT.VismaNetApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public abstract class BasePaginatedCrudDataClass<T> : BaseCrudDataClass<T> where T : DtoPaginatedProviderBase, IProvideIdentificator
    {
        internal BasePaginatedCrudDataClass(VismaNetAuthorization auth) : base(auth)
        {
        }

        const int initialPageSize = 500;

        /// <summary>
        /// Gets all entities by splitting it into totalCount / pageSize tasks and fetching them in parallel.
        /// </summary>
        /// <returns></returns>
        /// <remarks>The order of the entities will be random. If the order matters to you, use .OrderBy.</remarks>
        public override async Task<List<T>> All() => await AllWithParams();

        /// <summary>
        ///     Retrieves all entities from Visma.Net.
        /// </summary>
        /// <returns>List of all entities</returns>
        public override async Task<List<T>> Find(NameValueCollection parameters) => await AllWithParams(parameters);

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

        private async Task<List<T>> AllWithParams(NameValueCollection nameValueCollection = null)
        {
            var basenvc = new NameValueCollection { { "pageSize", initialPageSize.ToString() } };
            if (nameValueCollection != null)
                foreach (var key in nameValueCollection.AllKeys)
                    basenvc[key] = nameValueCollection[key];

            var firstPage = await VismaNetApiHelper.GetAll<T>(ApiControllerUri, Authorization, basenvc);
            var rsp = new List<T>();
            rsp.AddRange(firstPage);
            if (firstPage.FirstOrDefault()?.metadata?.totalCount > firstPage.Count && firstPage.Count > 0)
            {
                var totalCount = firstPage.FirstOrDefault().metadata.totalCount;
                var pageSize = firstPage.Count;
                var pageCount = totalCount / pageSize;
                var tasks = Enumerable.Range(2, pageCount)
                                      .Select(page =>
                                      {
                                          var nvc = new NameValueCollection { { "pageSize", pageSize.ToString() }, { "pageNumber", page.ToString() } };
                                          if (nameValueCollection != null)
                                              foreach (var key in nameValueCollection.AllKeys)
                                                  nvc[key] = nameValueCollection[key];
                                          return VismaNetApiHelper.GetAll<T>(ApiControllerUri, Authorization, nvc);
                                      });
                var completedTasks = await Task.WhenAll(tasks);
                rsp.AddRange(completedTasks.SelectMany(x => x));
            }
            rsp.ForEach(x => x.InternalPrepareForUpdate());
            return rsp;
        }
    }
}