using System.Collections.Generic;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class ContactData : BaseCrudDataClass<Contact>
	{
		internal ContactData(VismaNetAuthorization auth) : base(auth)
		{
		    ApiControllerUri = VismaNetControllers.Contacts;
		}

        protected ContactData(): base(null)
        {
            ApiControllerUri = VismaNetControllers.Contacts;            
        }

        /// <summary>
        /// Fetches all contacts for a customer
        /// </summary>
        /// <param name="customerNumber">Customer Number</param>
        /// <returns></returns>
        public async Task<List<Contact>> ForCustomerAsyncTask(string customerNumber)
        {
            return await VismaNetApiHelper.FetchContactsForCustomer(customerNumber, Authorization);
        }

        /// <summary>
        /// Fetches all contacts for a supplier
        /// </summary>
        /// <param name="supplierNumber">Supplier Number</param>
        /// <returns></returns>
        public async Task<List<Contact>> ForSupplierAsyncTask(string supplierNumber)
        {
            return await VismaNetApiHelper.FetchContactsForSupplier(supplierNumber, Authorization);
        }
    }
}

