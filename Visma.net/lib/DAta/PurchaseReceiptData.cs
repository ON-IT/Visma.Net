using ONIT.VismaNetApi.Models;
using ONIT.VismaNetApi.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class PurchaseReceiptData : BaseCrudDataClass<PurchaseReceipt>
    {
        public PurchaseReceiptData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.PurchaseReceipt;
        }
        public async Task<VismaActionResult> Release(InventoryIssue inventoryIssue)
        {
            return await VismaNetApiHelper.Action(Authorization, ApiControllerUri, inventoryIssue.GetIdentificator(), "release");
        }

    }
}