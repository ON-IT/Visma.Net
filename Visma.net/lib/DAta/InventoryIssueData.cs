using ONIT.VismaNetApi.Models;
using ONIT.VismaNetApi.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class InventoryIssueData : BaseCrudDataClass<InventoryIssue>
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