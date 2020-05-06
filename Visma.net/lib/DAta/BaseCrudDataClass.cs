using ONIT.VismaNetApi.Models;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{

    public abstract class BaseCrudDataClass<T> : BaseCollectionDataClass<T> where T : DtoProviderBase, IProvideIdentificator
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
    }
}