using ONIT.VismaNetApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class GeneralLedgerBalanceData : BaseCrudDataClass<GeneralLedgerBalance>
    {
        public GeneralLedgerBalanceData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.GeneralLedgerBalance;
        }

        public override Task<List<GeneralLedgerBalance>> All()
        {
            throw new NotSupportedException();
        }
    }
}