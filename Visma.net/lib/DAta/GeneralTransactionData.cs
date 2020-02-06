using ONIT.VismaNetApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class GeneralLedgerTransactionData : BaseDataClass
    {
        public GeneralLedgerTransactionData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.GeneralLedgerTransaction;
        }

        /// <summary>
        ///     Retrieves all entities from Visma.Net. WARNING: Slow.
        /// </summary>
        /// <returns>List of all entities</returns>
        public virtual async Task<List<GeneralLedgerTransaction>> Find(NameValueCollection parameters)
        {
           return await VismaNetApiHelper.GetAllWithPagination<GeneralLedgerTransaction>(ApiControllerUri, Authorization, parameters);
        }
        /// <summary>
        /// Get transactions from ledger
        /// </summary>
        /// <param name="fromPeriod"></param>
        /// <param name="toPeriod"></param>
        /// <param name="account"></param>
        /// <param name="ledger">1 = ledger (default), 3 = reports, 4 = statistics</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<List<GeneralLedgerTransaction>> Find(string fromPeriod, string toPeriod, string account, string ledger = "1", NameValueCollection parameters = null)
        {
            var collection = new NameValueCollection {
                { "ledger", ledger ?? throw new ArgumentNullException(nameof(ledger))},
                { "fromPeriod", fromPeriod ?? throw new ArgumentNullException(nameof(fromPeriod)) },
                { "toPeriod", toPeriod ?? throw new ArgumentNullException(nameof(toPeriod)) },
                { "account", account ?? throw new ArgumentNullException(nameof(account)) } }
            .Join(parameters);

            return await VismaNetApiHelper.GetAllWithPagination<GeneralLedgerTransaction>(VismaNetControllers.GeneralLedgerTransaction, Authorization, collection);
        }

    }


}