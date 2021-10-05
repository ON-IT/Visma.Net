﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class PurchaseReceipt : DtoPaginatedProviderBase, IProvideIdentificator
    {
       internal override void PrepareForUpdate()
        {
            foreach (var issueLine in lines)
            {
                issueLine.operation = ApiOperation.Update;
            }
        }

        [JsonProperty]
        public List<PurchaseReceiptLine> lines
        {
            get => Get(defaultValue: new List<PurchaseReceiptLine>());
            private set => Set(value);
        }
        [JsonProperty]
        public List<PurchaseReceiptLandedcost> landedCost
        {
            get => Get(defaultValue: new List<PurchaseReceiptLandedcost>());
            private set => Set(value);
        }

        public PurchaseReceiptType receiptType
        {
            get => Get<PurchaseReceiptType>();
            set => Set(value);
        }
        public string receiptNbr
        {
            get => Get<string>();
            set => Set(value);
        }
        public bool hold
        {
            get => Get<bool>();
            set => Set(value);
        }
        public PurchaseReceiptStatus status
        {
            get => Get<PurchaseReceiptStatus>();
            set => Set(value);
        }
        public DateTime date
        {
            get => Get<DateTime>();
            set => Set(value);
        }
        public string postPeriod
        {
            get => Get<string>();
            set => Set(value);
        }

        public decimal controlCost
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public DescriptionId warehouseId
        {
            get => Get<DescriptionId>();
            set => Set(value);
        }
        public NumberName supplierId
        {
            get => Get<NumberName>();
            set => Set(value);
        }
        public LocationSummary locationId
        {
            get => Get<LocationSummary>();
            set => Set(value);
        }
        public string currency
        {
            get => Get<string>();
            set => Set(value);
        }
        public bool createBill
        {
            get => Get<bool>();
            set => Set(value);
        }
        public string supplierRef
        {
            get => Get<string>();
            set => Set(value);
        }
        public decimal controlQty
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal controlAmount
        {
            get => Get<decimal>();
            set => Set(value);
        }


        public NumberName branchNumber
        {
            get => Get<NumberName>();
            set => Set(value);
        }
        [JsonProperty] public decimal totalQty { get; private set; }
        [JsonProperty] public decimal vatExemptTotal { get; private set; }
        [JsonProperty] public decimal vatTaxableTotal { get; private set; }
        [JsonProperty] public decimal totalAmt { get; private set; }
        [JsonProperty] public decimal controlTotal { get; private set; }
        [JsonProperty] public DateTime lastModifieDateTime { get; private set; }
        [JsonProperty] public JObject extras { get; private set; }
        [JsonProperty] public string batchNumber { get; private set; }
        [JsonProperty] public string errorInfo { get; private set; }

        [JsonProperty] public List<Attachment> attachments { get; private set; }

        public string GetIdentificator()
        {
            return receiptNbr;
        }
    }
}