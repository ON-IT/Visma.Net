using ONIT.VismaNetApi.Models;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class CustomerPaymentData : BasePaginatedCrudDataClass<CustomerPayment>
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

        /// <summary>
        ///  Release a customer payment as a background task
        /// </summary>
        /// <param name="payment">Customer Payment to release</param>
        /// <param name="callback">If a URL value is provided, then API endpoint will be queued and executed in background. When the execution of the background operation is finished, the system will POST the response to the specified URL. The endpoint itself responds in this case with a 202-Accepted status and a reference to a state document for the background operation.</param>
        /// <returns></returns>
        public async Task<BackgroundStatus> Release(CustomerPayment payment, string callback)
        {
            return await VismaNetApiHelper.BackgroundAction(Authorization, ApiControllerUri, payment.GetIdentificator(), "release", callback, new { type = new DtoValue(payment.type) });
        }

        public async Task<VismaActionResult> Void(CustomerPayment payment)
        {
            return await VismaNetApiHelper.Action(Authorization, ApiControllerUri, payment.GetIdentificator(), "void", new { type = new DtoValue(payment.type) });
        }
    }
}
