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

        public async Task<BackgroundStatus> GetStatus(string statusId)
        {
            return await VismaNetApiHelper.Get<BackgroundStatus>(statusId, ApiControllerUri, Authorization);
        }
        public async Task<T> GetContent<T>(string statusId) 
        {
            return await VismaNetApiHelper.Get<T>($"{statusId}/content", ApiControllerUri, Authorization);
        }
    }
}
