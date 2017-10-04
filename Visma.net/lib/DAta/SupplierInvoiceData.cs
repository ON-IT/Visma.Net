using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class SupplierInvoiceData : BaseCrudDataClass<SupplierInvoice>
    {
        internal SupplierInvoiceData(VismaNetAuthorization auth)
            : base(auth)
		{
		    ApiControllerUri = VismaNetControllers.SupplierInvoices;
		}
    }
}
