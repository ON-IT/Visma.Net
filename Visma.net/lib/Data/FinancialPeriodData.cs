using System.Collections.Generic;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;
using ONIT.VismaNetApi.Models.CustomDto;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class FinancialPeriodData : BaseDataClass
    {
        public FinancialPeriodData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.FinancialPeriod;
        }

        public async Task<FinancialPeriod> Get(string financialPeriodId)
        {
            return
                await VismaNetApiHelper.Get<FinancialPeriod>($"{financialPeriodId}", ApiControllerUri, Authorization);
        }

        /// <summary>
        /// Retrieves all financialperiods from Visma.Net.
        /// </summary>
        /// <returns>List of all entities</returns>
        public async Task<List<FinancialPeriod>> All()
        {
            return await VismaNetApiHelper.GetAll<FinancialPeriod>(ApiControllerUri, Authorization);
        }
    }
}