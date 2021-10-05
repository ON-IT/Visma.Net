using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class PurchaseReceiptLandedcost : DtoProviderBase
    {
        public PurchaseReceiptLandedcost()
        {
            DtoFields.Add(nameof(lineNbr), new DtoValue(0));
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }
        public ApiOperation operation
        {
            get { return Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Update)).Value; }
            set { Set(new NotDto<ApiOperation>(value)); }
        }
        public int lineNbr
        {
            get => Get<int>();
            set => Set(value);
        }
        public string landedCostCode
        {
            get => Get<string>();
            set => Set(value);
        }
        public string description
        {
            get => Get<string>();
            set => Set(value);
        }
        public string purchaseInvoiceNbr
        {
            get => Get<string>();
            set => Set(value);
        }
        public LocationSummary location
        {
            get => Get<LocationSummary>();
            set => Set(value);
        }
        public NumberName supplier
        {
            get => Get<NumberName>();
            set => Set(value);
        }
        public DateTime apBillDate
        {
            get => Get<DateTime>();
            set => Set(value);
        }
        public string currency
        {
            get => Get<string>();
            set => Set(value);
        }
        public decimal amount
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public NumberDescription taxCategory
        {
            get => Get<NumberDescription>();
            set => Set(value);
        }
        public DescriptionId terms
        {
            get => Get<DescriptionId>();
            set => Set(value);
        }
        public NumberDescription inventory
        {
            get => Get<NumberDescription>();
            set => Set(value);
        }
        public SupplierDocumentType apDocType
        {
            get => Get<SupplierDocumentType>();
            set => Set(value);
        }
        public string apRefNbr
        {
            get => Get<string>();
            set => Set(value);
        }
        public CustomerDocumentType inDocType
        {
            get => Get<CustomerDocumentType>();
            set => Set(value);
        }
        public string inRefNbr
        {
            get => Get<string>();
            set => Set(value);
        }
        public bool postponePurchaseInvoiceCreation
        {
            get => Get<bool>();
            set => Set(value);
        }
    }
}