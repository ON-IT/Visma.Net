using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class SupplierDocumentData : BasePaginatedCrudDataClass<SupplierDocument>
    {
        public SupplierDocumentData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.SupplierDocument;
        }

    }
}