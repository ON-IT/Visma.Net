using ONIT.VismaNetApi.Models;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class CustomerCreditNoteData : BaseCrudDataClass<CustomerCreditNote>
    {
        /// <summary>
		///     This constructor is called by the client to create the data source.
		/// </summary>
		internal CustomerCreditNoteData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.CustomerCreditNote;
        }

        protected CustomerCreditNoteData() : base(null)
        {
            ApiControllerUri = VismaNetControllers.CustomerCreditNote;
        }

    public override async Task<CustomerCreditNote> Add(CustomerCreditNote entity)
    {
      CustomerCreditNote rsp = null;
      System.Diagnostics.Trace.TraceInformation($"Starting post AddLarge CustomerCreditNote {DateTime.Now.ToString()}");
      rsp = await VismaNetApiHelper.Create(entity, VismaNetControllers.CustomerCreditNoteV2, Authorization, ApiControllerUri);
      System.Diagnostics.Trace.TraceInformation($"Finished post AddLarge CustomerCreditNote {DateTime.Now.ToString()}");
      rsp.InternalPrepareForUpdate();

      //rsp = await Get(rsp.GetIdentificator());
      return rsp;
    }


    public async Task<string> AddAttachmentToCreditNote(string creditNoteNumber, string content, string fileName)
        {
            return await AddAttachmentToCreditNote(creditNoteNumber, Encoding.UTF8.GetBytes(content), fileName);
        }

        public async Task<string> AddAttachmentToCreditNote(string creditNoteNumber, byte[] byteArray, string fileName)
        {
            if (byteArray == default(byte[]))
                throw new ArgumentNullException(nameof(byteArray), "ByteArray is missing");
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(Path.GetExtension(fileName)))
                throw new ArgumentNullException(nameof(fileName), "File name must be provided and have an extention");
            return await VismaNetApiHelper.AddAttachmentToCreditNote(Authorization, creditNoteNumber, byteArray, fileName);
        }

        public async Task<string> AddAttachmentToCreditNote(string creditNoteNumber, Stream stream, string fileName)
        {
            if (stream == default(Stream))
                throw new ArgumentNullException(nameof(stream), "Stream is missing");
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(Path.GetExtension(fileName)))
                throw new ArgumentNullException(nameof(fileName), "File name must be provided and have an extention");

            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return await VismaNetApiHelper.AddAttachmentToCreditNote(Authorization, creditNoteNumber, stream, fileName);
            }
        }
    }
}

