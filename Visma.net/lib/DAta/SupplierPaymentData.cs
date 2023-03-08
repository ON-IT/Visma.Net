using ONIT.VismaNetApi.Models;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class SupplierPaymentData : BasePaginatedCrudDataClass<SupplierPayment>
    {
        internal SupplierPaymentData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.SupplierPayment;
        }

        protected SupplierPaymentData() : base(null)
        {
            ApiControllerUri = VismaNetControllers.SupplierPayment;
        }

        public async Task<VismaActionResult> Release(SupplierPayment payment)
        {
            return await VismaNetApiHelper.Action(Authorization, ApiControllerUri, payment.GetIdentificator(), "release", new { type = new DtoValue(payment.type) });
        }

    }
}
