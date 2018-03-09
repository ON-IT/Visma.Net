using ONIT.VismaNetApi.Models;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class SupplierInvoiceData : BaseCrudDataClass<SupplierInvoice>
    {
        internal SupplierInvoiceData(VismaNetAuthorization auth)
            : base(auth)
		{
		    ApiControllerUri = VismaNetControllers.SupplierInvoices;
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
            if (stream == default(Stream))
                throw new ArgumentNullException(nameof(stream), "Stream is missing");
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(Path.GetExtension(fileName)))
                throw new ArgumentNullException(nameof(fileName), "File name must be provided and have an extention");
            return await VismaNetApiHelper.AddAttachmentToInvoice(Authorization, invoiceNumber, stream, fileName, VismaNetControllers.SupplierInvoices);
        }
    }
}
