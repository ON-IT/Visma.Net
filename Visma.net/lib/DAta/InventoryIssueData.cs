using ONIT.VismaNetApi.Models;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class InventoryIssueData : BasePaginatedCrudDataClass<InventoryIssue>
    {
        public InventoryIssueData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.InventoryIssue;
        }
        public async Task<VismaActionResult> Release(InventoryIssue inventoryIssue)
        {
            return await VismaNetApiHelper.Action(Authorization, ApiControllerUri, inventoryIssue.GetIdentificator(), "release");
        }

    }
}