using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class Inventory : DtoProviderBase, IProvideIdentificator
    {
        private List<CrossReference> _crossReferences;
        private List<Attributes> _attributes;
        private List<Attachment> _attachments;
        private List<WarehouseDetails> _warehouseDetails;
        private costPriceStatistics _costPriceStatistics;

        public int? inventoryId
        {
            get { return Get<int>(); }
            set { Set(value); }
        }

        public string inventoryNumber
        {
            get { return Get<string>() != null ? Get<string>().Trim() : null; }
            set { Set(value); }
        }

        public InventoryStatus status
        {
            get { return Get<InventoryStatus>(); }
            set { Set(value); }
        }

        public InventoryType type
        {
            get { return Get<InventoryType>(); }
            set { Set(value); }
        }

        public string description
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public ItemClass itemClass
        {
            get { return Get<ItemClass>(); }
            set { Set(value); }
        }

        public PostingClass postingClass
        {
            get { return Get<PostingClass>(key:"postClassId"); }
            set { Set(value,key:"postClassId"); }
        }

        public VatCode vatCode
        {
            get { return Get<VatCode>(); }
            set { Set(value); }
        }

        public decimal? defaultPrice
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public DateTime? lastModifiedDateTime { get; set; }

        public string baseUnit { get; set; }
        public string salesUnit { get; set; }
        public string purchaseUnit { get; set; }
  
        [JsonProperty]
        public List<Attributes> attributes
        {
            get { return _attributes ?? (_attributes = new List<Attributes>()); }
            private set { _attributes = value; }
        }

        [JsonProperty]
        public List<CrossReference> crossReferences
        {
            get { return _crossReferences ?? (_crossReferences = new List<CrossReference>()); }
            private set { _crossReferences = value; }
        }
        [JsonProperty]
        public List<Attachment> attachments
        {
            get { return _attachments ?? (_attachments = new List<Attachment>()); }
            private set { _attachments = value; }
        }

        [JsonProperty]
        public List<WarehouseDetails> warehouseDetails
        {
            get { return _warehouseDetails ?? (_warehouseDetails = new List<WarehouseDetails>()); }
            private set { _warehouseDetails = value; }
        }

        public costPriceStatistics costPriceStatistics
        {
            get { return _costPriceStatistics ?? (_costPriceStatistics = new costPriceStatistics()); }
            private set { _costPriceStatistics = value; } 
        }

        public string GetIdentificator()
        {
            return inventoryNumber;
        }

    }

    public class costPriceStatistics
    {
        public decimal lastCost { get; set; }
        public decimal averageCost { get; set; }
        public decimal minCost { get; set; }
        public decimal maxCost { get; set; }
    }
}