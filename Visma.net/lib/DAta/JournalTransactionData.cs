using ONIT.VismaNetApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class JournalTransactionData : BasePaginatedCrudDataClass<JournalTransaction>
    {
        public JournalTransactionData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.JournalTransactionV2;
        }

        /// <summary>
        /// Gets all entities by splitting it into totalCount / pageSize tasks and fetching them in parallel.
        /// </summary>
        /// <returns></returns>
        /// <remarks>The order of the entities will be by the entity identificator. If the order matters to you, use OrderBy.</remarks>
        public override async Task<List<JournalTransaction>> All() => PostProcessJournalTransactions(await VismaNetApiHelper.GetAllWithPagination<JournalTransaction>(ApiControllerUri, Authorization));

        /// <summary>
        ///     Retrieves all entities from Visma.Net.
        /// </summary>
        /// <returns>List of all entities</returns>
        public override async Task<List<JournalTransaction>> Find(NameValueCollection parameters) => PostProcessJournalTransactions(await VismaNetApiHelper.GetAllWithPagination<JournalTransaction>(ApiControllerUri, Authorization, parameters));


        public async Task<string> AddAttachmentToJournalTransaction(string batchNumber, string content, string fileName)
        {
            return await AddAttachmentToJournalTransaction(batchNumber, Encoding.UTF8.GetBytes(content), fileName);
        }

        public async Task<string> AddAttachmentToJournalTransaction(string batchNumber, byte[] byteArray, string fileName)
        {
            if (byteArray == default(byte[]))
                throw new ArgumentNullException(nameof(byteArray), "ByteArray is missing");
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(Path.GetExtension(fileName)))
                throw new ArgumentNullException(nameof(fileName), "File name must be provided and have an extention");
            return await VismaNetApiHelper.AddAttachmentToJournalTransaction(Authorization, batchNumber, byteArray, fileName);
        }

        public async Task<VismaActionResult> Release(JournalTransaction transaction)
        {
            return await VismaNetApiHelper.Action(Authorization, ApiControllerUri, transaction.GetIdentificator(), "release");
        }

        public async Task<VismaActionResult> Release(string transactionNumber)
        {
            return await VismaNetApiHelper.Action(Authorization, ApiControllerUri, transactionNumber, "release");
        }
        private static List<JournalTransaction> PostProcessJournalTransactions(List<JournalTransaction> source)
        {
            var dict = new Dictionary<string, JournalTransaction>();
            foreach (var invoice in source)
            {
                if (dict.ContainsKey(invoice.batchNumber))
                {
                    dict[invoice.batchNumber].journalTransactionLines.AddRange(invoice.journalTransactionLines);
                }
                else
                {
                    dict[invoice.batchNumber] = invoice;
                }
            }
            return dict.Values.ToList();
        }
    }
}
