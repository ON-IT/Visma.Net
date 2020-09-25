using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;
using System;
using System.Collections.Generic;

namespace ONIT.VismaNetApi.Models
{
    public class InventoryReceipt : DtoPaginatedProviderBase, IProvideIdentificator
    {
        internal override void PrepareForUpdate()
        {
            foreach (var issueLine in receiptLines)
            {
                issueLine.operation = ApiOperation.Update;
            }
        }

        [JsonProperty]
        public List<InventoryRecieptLine> receiptLines
        {
            get => Get(defaultValue: new List<InventoryRecieptLine>());
            private set => Set(value);
        }

        public string transferNumber
        {
            get => Get<string>();
            set => Set(value);
        }

        public decimal controlCost
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public string referenceNumber
        {
            get => Get<string>();
            set => Set(value);
        }
        public bool hold
        {
            get => Get<bool>();
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
        public string externalReference
        {
            get => Get<string>();
            set => Set(value);
        }
        public string description
        {
            get => Get<string>();
            set => Set(value);
        }
        public decimal controlQuantity
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public NumberName branchNumber
        {
            get => Get<NumberName>();
            set => Set(value);
        }
        [JsonProperty] public decimal totalQuantity { get; private set; }
        [JsonProperty] public DateTime lastModifieDateTime { get; private set; }
        [JsonProperty] public JObject extras { get; private set; }
        [JsonProperty] public string batchNumber { get; private set; }
        [JsonProperty] public string errorInfo { get; private set; }

        [JsonProperty] public List<Attachment> attachments { get; private set; }

        public string GetIdentificator()
        {
            return referenceNumber;
        }
    }
}