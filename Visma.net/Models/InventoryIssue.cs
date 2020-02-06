using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class InventoryIssue : DtoPaginatedProviderBase, IProvideIdentificator
    {
       internal override void PrepareForUpdate()
        {
            foreach (var issueLine in issueLines)
            {
                issueLine.operation = ApiOperation.Update;
            }
        }

        [JsonProperty]
        public List<InventoryIssueLine> issueLines
        {
            get => Get(defaultValue: new List<InventoryIssueLine>());
            private set => Set(value);
        }

        public decimal controlAmount
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

        public Address address
        {
            get => Get<Address>();
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
        [JsonProperty] public decimal totalAmount { get; private set; }
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