using System.Collections.Generic;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;
using ONIT.VismaNetApi.Models.CustomDto;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class FinAccountData : BaseDataClass
    {
        public FinAccountData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.FinAccount;
        }

        public async Task<FinAccount> Get(string accountCd)
        {
            return
                await VismaNetApiHelper.Get<FinAccount>($"{accountCd}", ApiControllerUri, Authorization);
        }

        /// <summary>
        /// Retrieves all products from Visma.Net. WARNING: Slow.
        /// </summary>
        /// <returns>List of all entities</returns>
        public async Task<List<FinAccount>> AllAsyncTask()
        {
            return await VismaNetApiHelper.GetAll<FinAccount>(ApiControllerUri, Authorization);
        }
    }
}