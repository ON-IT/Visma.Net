using ONIT.VismaNetApi.Models;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class InventoryReceiptData : BasePaginatedCrudDataClass<InventoryReceipt>
    {
        public InventoryReceiptData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.InventoryReceipt;
        }
        public async Task<VismaActionResult> Release(InventoryReceipt inventoryReceipt)
        {
            return await VismaNetApiHelper.Action(Authorization, ApiControllerUri, inventoryReceipt.GetIdentificator(), "release");
        }

    }
}