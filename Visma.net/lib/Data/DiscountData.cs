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
    public class DiscountData : BasePaginatedCrudDataClass<Discount>
    {
        public DiscountData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.Discount;
        }

        public override Task<List<Discount>> All()
        {
            // Redirect to V2 endpoint with correct structure.
            return VismaNetApiHelper.GetAllWithPagination<Discount>(VismaNetControllers.DiscountV2, Authorization);
        }

        public override Task<List<Discount>> Find(NameValueCollection parameters)
        {
            return VismaNetApiHelper.GetAllWithPagination<Discount>(VismaNetControllers.DiscountV2, Authorization, parameters);
        }
    }
}
