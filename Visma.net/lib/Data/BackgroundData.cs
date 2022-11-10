using ONIT.VismaNetApi.Models;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class BackgroundData : BaseDataClass
    {
        public BackgroundData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.Background;
        }

        protected BackgroundData() : base(null)
        {
            ApiControllerUri = VismaNetControllers.Branch;
        }

        public async Task<BackgroundData> GetStatus(string statusId)
        {
            return await VismaNetApiHelper.Get<BackgroundData>(statusId, ApiControllerUri, Authorization);
        }
        public async Task<T> GetContent<T>(string statusId) where T : class, new()
        {
            return await VismaNetApiHelper.Get<T>(statusId, ApiControllerUri, Authorization);
        }
    }
}
