using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class JournalTransactionData : BaseCrudDataClass<JournalTransaction>
    {
        public JournalTransactionData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.JournalTransaction;
        }
    }
}