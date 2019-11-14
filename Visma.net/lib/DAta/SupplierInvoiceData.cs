using ONIT.VismaNetApi.Models;
using ONIT.VismaNetApi.Models.Enums;
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
        public async Task<SupplierInvoice> Get(string entityNumber, SupplierDocumentType documentType = SupplierDocumentType.Invoice)
        {
            SupplierInvoice rsp;
            if (documentType == SupplierDocumentType.Invoice) // documentType = invoice use default endpoint.
            {
                rsp = await VismaNetApiHelper.Get<SupplierInvoice>(entityNumber, ApiControllerUri, Authorization);
            }
            else
            {
                rsp = await VismaNetApiHelper.Get<SupplierInvoice>(entityNumber, ApiControllerUri, Authorization, $"{documentType.ToString()}/{entityNumber}");
            }
            rsp.InternalPrepareForUpdate();
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
            return await VismaNetApiHelper.AddAttachmentToSupplierInvoice(Authorization, invoiceNumber, byteArray, fileName);
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
                return await VismaNetApiHelper.AddAttachmentToSupplierInvoice(Authorization, invoiceNumber, memoryStream.ToArray(), fileName);
            }

        }
    }
}
