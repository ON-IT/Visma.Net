using System;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class BranchData : BaseCrudDataClass<Branch>
    {
        public BranchData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.Branch;
        }

        protected BranchData() : base(null)
        {
            ApiControllerUri = VismaNetControllers.Branch;
        }

        public override Task<Branch> AddAsyncTask(Branch entity)
        {
            throw new NotImplementedException("Not support by /branch");
        }

        public override Task UpdateAsyncTask(Branch entity)
        {
            throw new NotImplementedException("Not support by /branch");
        }
    }
}
