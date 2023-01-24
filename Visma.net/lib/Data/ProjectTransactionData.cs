using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Lib.Data;
using ONIT.VismaNetApi.Models;
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

        public override async Task<List<ProjectTransaction>> All() => await this.Find(new NameValueCollection());
        public override async Task<List<ProjectTransaction>> Find(NameValueCollection parameters)
        {
            // parameter fromPeriod and toPeriod are mandatory
            // Check if parameters are in the collection if not throw exception
            /*            if (parameters.Keys.)

                            return await VismaNetApiHelper.GetAllWithPagination<ProjectTransaction>(ApiControllerUri, Authorization, parameters);*/
        }
    }
}
