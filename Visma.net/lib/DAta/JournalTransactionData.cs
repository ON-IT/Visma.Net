using ONIT.VismaNetApi.Models;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class JournalTransactionData : BaseCrudDataClass<JournalTransaction>
    {
        public JournalTransactionData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.JournalTransaction;
        }

        public async Task AddAttachment(JournalTransaction journalTransaction, byte[] data, string filename)
        {
            await VismaNetApiHelper.AddAttachment(Authorization, ApiControllerUri, journalTransaction.GetIdentificator(), data, filename);
        }

        public async Task AddAttachment(JournalTransaction journalTransaction, int lineNumber, byte[] data, string filename)
        {
            await VismaNetApiHelper.AddAttachment(Authorization, ApiControllerUri, $"{journalTransaction.GetIdentificator()}/{lineNumber}", data, filename);
        }

        public async Task<VismaActionResult> Release(JournalTransaction transaction)
        {
            return await VismaNetApiHelper.Action(Authorization, ApiControllerUri, transaction.GetIdentificator(), "release");
        }

        public async Task<VismaActionResult> Release(string transactionNumber)
        {
            return await VismaNetApiHelper.Action(Authorization, ApiControllerUri, transactionNumber, "release");
        }
    }
}
