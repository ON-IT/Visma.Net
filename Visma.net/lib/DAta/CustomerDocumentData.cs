using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib
{
	public class CustomerDocumentData
	{
	    private readonly VismaNetAuthorization _authorization;

		/// <summary> 
		/// This constructor is called by the client to create the data source. 
		/// </summary> 
		internal CustomerDocumentData(VismaNetAuthorization auth)
		{
			_authorization = auth;
		}

		protected CustomerDocumentData()
		{
			
		}

        /// <summary>
        /// Retrieves all documents
        /// </summary>
        /// <returns></returns>
	    public async Task<List<CustomerDocument>> All()
        {
            return await VismaNetApiHelper.GetAllWithPagination<CustomerDocument>(VismaNetControllers.CustomerDocument, _authorization);
        }
        
        /// <summary>
        /// Retrieves all documents
        /// </summary>
        /// <returns></returns>
	    public async Task<List<CustomerDocument>> AllModifiedSince(DateTime date)
        {
            var parameters = new NameValueCollection
                    {
                        {"LastModifiedDateTime", date.ToString(VismaNetApiHelper.VismaNetDateTimeFormat)},
                        {"LastModifiedDateTimeCondition", ">"}
                    };

            return await VismaNetApiHelper.GetAllWithPagination<CustomerDocument>(VismaNetControllers.CustomerDocument, _authorization, parameters);
        }
        
        /// <summary>
        /// Retrieves all documents for a customer
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns>List of CustomerDocument</returns>
	    public async Task<List<CustomerDocument>> ForCustomer(string customerNumber)
	    {
            if(string.IsNullOrEmpty(customerNumber))
                throw new ArgumentNullException(nameof(customerNumber));
	        return await VismaNetApiHelper.FetchCustomerDocumentsForCustomerCd(customerNumber, _authorization);
	    }

        /// <summary>
        /// Retrieves all documents for a customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<List<CustomerDocument>> ForCustomer(Customer customer)
        {
            if(customer==null)
                throw new ArgumentNullException(nameof(customer));
            return await ForCustomer(customer.number);
        }
	}
}
