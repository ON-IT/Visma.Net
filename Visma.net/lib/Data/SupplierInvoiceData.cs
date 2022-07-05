﻿using ONIT.VismaNetApi.Models;
using ONIT.VismaNetApi.Models.Enums;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class SupplierInvoiceData : BasePaginatedCrudDataClass<SupplierInvoice>
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
                rsp = await VismaNetApiHelper.Get<SupplierInvoice>(entityNumber, ApiControllerUri, Authorization, $"{documentType}/{entityNumber}");
            }
            rsp.InternalPrepareForUpdate();
            return rsp;
        }

        public override async Task<SupplierInvoice> Add(SupplierInvoice entity)
        {
            SupplierInvoice rsp;
            if (entity.documentType != SupplierDocumentType.Invoice)
            {
                rsp = await VismaNetApiHelper.Create(entity, ApiControllerUri, Authorization, $"{ApiControllerUri}/{entity.documentType}");
            }
            else
            {
                rsp = await VismaNetApiHelper.Create(entity, ApiControllerUri, Authorization);
            }
            rsp.InternalPrepareForUpdate();
            return rsp;
        }


        public override async Task Update(SupplierInvoice entity)
        {
            if (entity.documentType != SupplierDocumentType.Invoice)
            {
                await VismaNetApiHelper.Update(entity, entity.GetIdentificator(), ApiControllerUri, Authorization, $"{entity.documentType}/{entity.GetIdentificator()}");
            }
            else
            {
                await VismaNetApiHelper.Update(entity, entity.GetIdentificator(), ApiControllerUri, Authorization);
            }
        }

        public async Task<string> AddAttachmentToInvoice(SupplierInvoice invoice, string content, string fileName)
        {
            return await AddAttachmentToInvoice(invoice.referenceNumber, Encoding.UTF8.GetBytes(content), fileName, invoice.documentType);
        }

        public async Task<string> AddAttachmentToInvoice(SupplierInvoice invoice, byte[] content, string fileName)
        {
            return await AddAttachmentToInvoice(invoice.referenceNumber, content, fileName, invoice.documentType);
        }

        public async Task<string> AddAttachmentToInvoice(string invoiceNumber, string content, string fileName, SupplierDocumentType documentType = SupplierDocumentType.Invoice)
        {
                return await AddAttachmentToInvoice(invoiceNumber, Encoding.UTF8.GetBytes(content), fileName, documentType);
        }

        public async Task<string> AddAttachmentToInvoice(string invoiceNumber, byte[] byteArray, string fileName, SupplierDocumentType documentType = SupplierDocumentType.Invoice)
        {
            if (byteArray == default(byte[]))
                throw new ArgumentNullException(nameof(byteArray), "ByteArray is missing");
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(Path.GetExtension(fileName)))
                throw new ArgumentNullException(nameof(fileName), "File name must be provided and have an extention");
            if(documentType != SupplierDocumentType.Invoice)
            {
                invoiceNumber = $"documentType/{documentType}/{invoiceNumber}";
            }
            return await VismaNetApiHelper.AddAttachmentToSupplierInvoice(Authorization, invoiceNumber, byteArray, fileName);
        }

        public async Task<string> AddAttachmentToInvoice(SupplierInvoice invoice, Stream stream, string fileName)
        {
            return await AddAttachmentToInvoice(invoice.referenceNumber, stream, fileName, invoice.documentType);
        }
            public async Task<string> AddAttachmentToInvoice(string invoiceNumber, Stream stream, string fileName, SupplierDocumentType documentType = SupplierDocumentType.Invoice)
        {
            if (stream == default(Stream))
                throw new ArgumentNullException(nameof(stream), "Stream is missing");
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(Path.GetExtension(fileName)))
                throw new ArgumentNullException(nameof(fileName), "File name must be provided and have an extention");

            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                if (documentType != SupplierDocumentType.Invoice)
                {
                    invoiceNumber = $"documentType/{documentType}/{invoiceNumber}";
                }
                return await VismaNetApiHelper.AddAttachmentToSupplierInvoice(Authorization, invoiceNumber, memoryStream.ToArray(), fileName);
            }

        }
    }
}
