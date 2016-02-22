using System;
using System.Collections.Generic;
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
	    public async Task<List<CustomerDocument>> AllAsyncTask()
        {
            return await VismaNetApiHelper.GetAll<CustomerDocument>(VismaNetControllers.CustomerDocument, _authorization).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves all documents
        /// </summary>
        /// <returns></returns>
	    public List<CustomerDocument> AllModifiedSince(DateTime date)
        {
            return AllModifiedSinceAsyncTask(date).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves all documents
        /// </summary>
        /// <returns></returns>
	    public async Task<List<CustomerDocument>> AllModifiedSinceAsyncTask(DateTime date)
        {
            return
                await
                    VismaNetApiHelper.GetAllModifiedSince<CustomerDocument>(VismaNetControllers.CustomerDocument, date,
                        _authorization).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves all documents
        /// </summary>
        /// <returns></returns>
	    public List<CustomerDocument> All()
        {
            return AllAsyncTask().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves all documents for a customer
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns>List of CustomerDocument</returns>
	    public async Task<List<CustomerDocument>> ForCustomerAsyncTask(string customerNumber)
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
        public async Task<List<CustomerDocument>> ForCustomerAsyncTask(Customer customer)
        {
            if(customer==null)
                throw new ArgumentNullException(nameof(customer));
            return await ForCustomerAsyncTask(customer.number);
        }

        // The sync stuff
	    public List<CustomerDocument> ForCustomer(string customerNumber)
	    {
	        return Task.Run(async () => await ForCustomerAsyncTask(customerNumber)).Result;
	    }

        public List<CustomerDocument> ForCustomer(Customer customer)
        {
            if(customer == null)
                throw new ArgumentNullException(nameof(customer));
            return ForCustomer(customer.number);
        } 
	}
}
