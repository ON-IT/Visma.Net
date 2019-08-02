using ONIT.VismaNetApi.Models;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class CustomerPaymentData : BaseCrudDataClass<CustomerPayment>
    {
        internal CustomerPaymentData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.CustomerPayment;
        }

        protected CustomerPaymentData() : base(null)
        {
            ApiControllerUri = VismaNetControllers.CustomerPayment;
        }

        public async Task<VismaActionResult> Release(CustomerPayment payment)
        {
            return await VismaNetApiHelper.Action(Authorization, ApiControllerUri, payment.GetIdentificator(), "release", new { type = new DtoValue(payment.type) });
        }

        public async Task<VismaActionResult> Void(CustomerPayment payment)
        {
            return await VismaNetApiHelper.Action(Authorization, ApiControllerUri, payment.GetIdentificator(), "void", new { type = new DtoValue(payment.type) });
        }
    }
}
