using System;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class Inventory : DtoProviderBase, IHaveInternalId, IHaveNumber
    {
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
            get { return Get<PostingClass>(); }
            set { Set(value); }
        }

        public VatCode vatCode
        {
            get { return Get<VatCode>(); }
            set { Set(value); }
        }

        public decimal? defaultPrice
        {
            get { return Get<decimal>(); }
            set { Set(value);}
        }

        public DateTime? lastModifiedDateTime { get; set; }

        [JsonIgnore]
        public int internalId
        {
            get { return inventoryId ?? 0; }
            private set { inventoryId = value; }
        }
        [JsonIgnore]

        public string number => inventoryNumber;
    }

}