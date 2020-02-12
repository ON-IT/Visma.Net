using System.Collections.Generic;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;
using ONIT.VismaNetApi.Models.CustomDto;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class CustomerData : BasePaginatedCrudDataClass<Customer>
	{
		internal CustomerData(VismaNetAuthorization auth) : base(auth)
		{
		    ApiControllerUri = VismaNetControllers.Customers;
		}

        protected CustomerData(): base(null)
        {
            ApiControllerUri = VismaNetControllers.Customers;            
        }

        public async Task<List<CustomerBalance>> GetBalanceForAll()
        {
            return
                await
                    VismaNetApiHelper.Get<List<CustomerBalance>>("balance", VismaNetControllers.Customers, Authorization);
        }

        public async Task<CustomerBalance> GetBalanceFor(string customerNumber)
        {
            return
                await
                    VismaNetApiHelper.Get<CustomerBalance>($"{customerNumber}/balance", VismaNetControllers.Customers, Authorization);
        }
    }
}

