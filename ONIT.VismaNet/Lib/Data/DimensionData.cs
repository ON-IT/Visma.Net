using System.Collections.Generic;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;
using ONIT.VismaNetApi.Models.Dimensions;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class DimensionData : BaseDataClass
    {
        /*[
         * "ACCGROUP","ACCOUNT","BIZACCT","CASHACCOUNT",
         * "CONTRACT","CONTRACTITEM","CUSTOMER","EMPLOYEE","INLOCATION",
         * "INSITE","INSUBITEM","INVENTORY","LOCATION","MLISTCD","PROJECT",
         * "PROTASK","SALESPER","SUBACCOUNT","TMCONTRACT","VENDOR"]
         * */


        public DimensionData(VismaNetAuthorization auth) : base(auth)
        {
        }

        public List<DimensionSegment> this[Dimension dimension]
        {
            get { return Task.Run(async () => await Get(dimension)).Result; }
        }

        public async Task<List<DimensionSegment>> Get(Dimension dimension)
        {
            return await VismaNetApiHelper.FetchDimension(string.Format("{0}", dimension), Authorization);
        }
    }
}