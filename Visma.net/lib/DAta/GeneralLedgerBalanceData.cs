using ONIT.VismaNetApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class GeneralLedgerBalanceData : BasePaginatedCrudDataClass<GeneralLedgerBalance>
    {
        public GeneralLedgerBalanceData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.GeneralLedgerBalanceV2;
        }

        public override Task<List<GeneralLedgerBalance>> All()
        {
            throw new NotSupportedException();
        }
    }
}