using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class Inventory : DtoProviderBase, IProvideIdentificator
    {
        private List<Attachment> _attachments;
        private List<CrossReference> _crossReferences;
        private List<WarehouseDetails> _warehouseDetails;

        [JsonProperty]
        public int inventoryId { get; }

        public string inventoryNumber
        {
            get => Get<string>() != null ? Get<string>().Trim() : null;
            set => Set(value);
        }

        public InventoryStatus status
        {
            get => Get<InventoryStatus>();
            set => Set(value);
        }

        public InventoryType type
        {
            get => Get<InventoryType>();
            set => Set(value);
        }

        public string description
        {
            get => Get<string>();
            set => Set(value);
        }

        public ItemClass itemClass
        {
            get => Get<ItemClass>();
            set => Set(value);
        }

        public PostingClass postingClass
        {
            get => Get<PostingClass>();
            set => Set(value);
        }

        public VatCode vatCode
        {
            get => Get<VatCode>();
            set => Set(value);
        }

        public decimal? defaultPrice
        {
            get => Get<decimal>();
            set => Set(value);
        }

        [JsonProperty]
        public decimal? pendingCost { get; private set;  }

        [JsonProperty]
        public DateTime pendingCostDate { get; private set; }

        [JsonProperty]
        public decimal? currentCost { get; private set; }

        [JsonProperty]
        public DateTime effectiveDate { get; private set;  }

        [JsonProperty]
        public decimal? lastCost { get;private set;  }

        [JsonProperty]
        public CostPriceStatistics costPriceStatistics { get; private set; }

        public DateTime? lastModifiedDateTime { get; set; }

        public string baseUnit
        {
            get => Get<string>();
            set => Set(value);
        }

        public string salesUnit
        {
            get => Get<string>();
            set => Set(value);
        }

        public string purchaseUnit
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public List<Attributes> attributes
        {
            get => Get("attributeLines", new NotDto<List<Attributes>>(new List<Attributes>())?.Value);
            set => Set(new NotDto<List<Attributes>>(value), "attributeLines");
        }

        [JsonProperty]
        public List<CrossReference> crossReferences
        {
            get => _crossReferences ?? (_crossReferences = new List<CrossReference>());
            private set => _crossReferences = value;
        }

        [JsonProperty]
        public List<Attachment> attachments
        {
            get => _attachments ?? (_attachments = new List<Attachment>());
            private set => _attachments = value;
        }

        [JsonProperty]
        public List<WarehouseDetails> warehouseDetails
        {
            get => _warehouseDetails ?? (_warehouseDetails = new List<WarehouseDetails>());
            private set => _warehouseDetails = value;
        }

        [JsonProperty]
        public string errorInfo { get; private set; }

        [JsonProperty]
        public JObject extras { get; private set; }

        public string GetIdentificator()
        {
            return inventoryNumber;
        }
    }
}