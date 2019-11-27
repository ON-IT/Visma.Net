using ONIT.VismaNetApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class GeneralLedgerTransactionData : BaseCrudDataClass<GeneralLedgerTransaction>
    {
        public GeneralLedgerTransactionData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.GeneralLedgerTransaction;
        }

        public override Task<List<GeneralLedgerTransaction>> All()
        {
            throw new NotSupportedException();
        }
    }
}