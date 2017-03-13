using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class PaymentData : BaseCrudDataClass<Payment>
    {
        internal PaymentData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.Payment;
        }

        protected PaymentData() : base(null)
        {
            ApiControllerUri = VismaNetControllers.Payment;
        }

        public async Task<VismaActionResult> ReleasePayment(Payment payment)
        {
            return await VismaNetApiHelper.PaymentAction(payment.GetIdentificator(), "release", Authorization);
        }

    }
}
