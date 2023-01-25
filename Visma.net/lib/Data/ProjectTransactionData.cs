using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Lib.Data;
using ONIT.VismaNetApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.lib.Data
{
    public class ProjectTransactionData : BasePaginatedCrudDataClass<ProjectTransaction>
    {
        public ProjectTransactionData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.ProjectTransaction;
        }

        public override async Task<List<ProjectTransaction>> All() => throw new NotImplementedException("This method is not implemented in the Visma.net Api");
        public override async Task<List<ProjectTransaction>> Find(NameValueCollection parameters) => await VismaNetApiHelper.GetAllWithPagination<ProjectTransaction>(ApiControllerUri, Authorization, parameters);
    }
}
