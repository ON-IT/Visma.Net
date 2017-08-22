﻿using System;
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
            set { Set(value); }
        }

        public DateTime? lastModifiedDateTime { get; set; }

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

        public string GetIdentificator()
        {
            return inventoryNumber;
        }
    }
}