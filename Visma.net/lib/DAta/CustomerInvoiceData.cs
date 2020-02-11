using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Helpers;
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
        ///     AddLarge Invoice entity runs invoicerows in first POST 500 lines then PUT:s in batches of 500 lines
        /// </summary>
        public async Task<CustomerInvoice> AddLarge(CustomerInvoice entity)
        {
            CustomerInvoice rsp = null;
            bool firstbatch = true;
            List<CustomerInvoiceLine> AllLines = new List<CustomerInvoiceLine>();
            AllLines.AddRange(entity.invoiceLines);
            foreach (var lines in AllLines.Batch(500))
            {
                entity.invoiceLines.Clear();
                entity.invoiceLines.AddRange(lines);
                if (firstbatch)
                {
                    rsp = await VismaNetApiHelper.Create(entity, ApiControllerUri, Authorization);
                    rsp.InternalPrepareForUpdate();
                    firstbatch = false;
                }
                else
                {
                    rsp.invoiceLines.Clear();
                    rsp.invoiceLines.AddRange(lines);
                    await VismaNetApiHelper.Update(entity,rsp.GetIdentificator(), ApiControllerUri, Authorization);
                }
            }
            rsp = await Get(rsp.GetIdentificator());
            return rsp;
        }


        public async Task<string> AddAttachmentToInvoice(string invoiceNumber, string content, string fileName)
        {
            return await AddAttachmentToInvoice(invoiceNumber, Encoding.UTF8.GetBytes(content), fileName);
        }

        public async Task<string> AddAttachmentToInvoice(string invoiceNumber, byte[] byteArray, string fileName)
        {
            if (byteArray == default(byte[]))
                throw new ArgumentNullException(nameof(byteArray), "ByteArray is missing");
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(Path.GetExtension(fileName)))
                throw new ArgumentNullException(nameof(fileName), "File name must be provided and have an extention");
            return await VismaNetApiHelper.AddAttachmentToInvoice(Authorization, invoiceNumber, byteArray, fileName);
        }

        public async Task<string> AddAttachmentToInvoice(string invoiceNumber, Stream stream, string fileName)
        {
            if (stream == default(Stream))
                throw new ArgumentNullException(nameof(stream), "Stream is missing");
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(Path.GetExtension(fileName)))
                throw new ArgumentNullException(nameof(fileName), "File name must be provided and have an extention");

            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return await VismaNetApiHelper.AddAttachmentToInvoice(Authorization, invoiceNumber, stream, fileName);
            }
        }

        public async Task<bool> Delete(string invoiceNumber)
        {
            return await VismaNetApiHelper.DeleteInvoice(invoiceNumber, Authorization);
        }

        /// <summary>
        ///     Fetches all invoices for a customer
        /// </summary>
        /// <param name="customerNumber">customerCd</param>
        /// <returns></returns>
        public async Task<List<CustomerInvoice>> ForCustomer(string customerNumber)
        {
            return await VismaNetApiHelper.FetchInvoicesForCustomerCd(customerNumber, Authorization);
        }

        /// <summary>
        ///     Fetches all invoices for a given customer
        /// </summary>
        /// <param name="customer">An instance of Customer</param>
        /// <returns></returns>
        public async Task<List<CustomerInvoice>> ForCustomer(Customer customer)
        {
            return await ForCustomer(customer.number);
        }

        public async Task<Stream> PrintInvoice(CustomerInvoice invoice)
        {
            return await VismaNetApiHelper.InvoicePrint(invoice.GetIdentificator(), Authorization);
        }

        public async Task<VismaActionResult> ReleaseInvoice(CustomerInvoice invoice)
        {
            return await VismaNetApiHelper.InvoiceAction(invoice.GetIdentificator(), "release", Authorization);
        }

        public async Task<VismaActionResult> ReverseInvoice(CustomerInvoice invoice)
        {
            return await VismaNetApiHelper.InvoiceAction(invoice.GetIdentificator(), "reverse", Authorization);
        }
    }
}