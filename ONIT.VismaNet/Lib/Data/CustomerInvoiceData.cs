using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
	public class CustomerInvoiceData : BaseCrudDataClass<CustomerInvoice>
	{
        /// <summary>
		///     This constructor is called by the client to create the data source.
		/// </summary>
		internal CustomerInvoiceData(VismaNetAuthorization auth) : base(auth)
		{
		    ApiControllerUri = VismaNetControllers.CustomerInvoice;
		}

	    protected CustomerInvoiceData() : base(null)
	    {
            ApiControllerUri = VismaNetControllers.CustomerInvoice;
	        
	    }

        /// <summary>
        /// Fetches all invoices for a customer
        /// </summary>
        /// <param name="customerNumber">customerCd</param>
        /// <returns></returns>
        public async Task<List<CustomerInvoice>> ForCustomerAsyncTask(string customerNumber)
        {
            return await VismaNetApiHelper.FetchInvoicesForCustomerCd(customerNumber, Authorization);
        }
        
        /// <summary>
        /// Fetches all invoices for a given customer
        /// </summary>
        /// <param name="customer">An instance of Customer</param>
        /// <returns></returns>
        public async Task<List<CustomerInvoice>> ForCustomerAsyncTask(Customer customer)
        {
            return await ForCustomerAsyncTask(customer.number);
        }

        public List<CustomerInvoice> ForCustomer(string customerNumber)
        {
            try
            {
                return Task.Run(async () => await ForCustomerAsyncTask(customerNumber)).Result;
            }
            catch (AggregateException e)
            {
                VismaNetExceptionHandler.HandleException(e);
                return null;
            }
        }

	    public List<CustomerInvoice> ForCustomer(Customer customer)
        {
            try
            {
                return Task.Run(async () => await ForCustomerAsyncTask(customer)).Result;
            }
            catch (AggregateException e)
            {
                VismaNetExceptionHandler.HandleException(e);
                return null;
            }
        }

	    public async Task<VismaActionResult> ReleaseInvoice(CustomerInvoice invoice)
	    {
	        return await VismaNetApiHelper.InvoiceAction(invoice.number, "release", Authorization);
	    }

        public async Task<VismaActionResult> ReverseInvoice(CustomerInvoice invoice)
        {
            return await VismaNetApiHelper.InvoiceAction(invoice.number, "reverse", Authorization);
        }

	    public async Task<string> AddAttachmentToInvoice(string invoiceNumber, string content, string fileName)
	    {
	        using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
	        {
	            return await AddAttachmentToInvoice(invoiceNumber, memoryStream, fileName);
	        }
	    }
        public async Task<string> AddAttachmentToInvoice(string invoiceNumber, Stream stream, string fileName)
	    {
            if(stream == default(Stream))
                throw new ArgumentNullException(nameof(stream), "Stream is missing");
            if(string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(Path.GetExtension(fileName)))
                throw new ArgumentNullException(nameof(fileName), "File name must be provided and have an extention");
	        return await VismaNetApiHelper.AddAttachmentToInvoice(Authorization, invoiceNumber, stream, fileName);
	    }
    }
}

