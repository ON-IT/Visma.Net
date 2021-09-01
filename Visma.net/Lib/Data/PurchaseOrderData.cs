using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class PurchaseOrderData : BasePaginatedCrudDataClass<PurchaseOrder>
    {
        public PurchaseOrderData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.PurchaseOrder;
        }
    }
}
