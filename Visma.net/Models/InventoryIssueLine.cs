using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class InventoryIssueLine : DtoProviderBase
    {
        public InventoryIssueLine()
        {
            DtoFields.Add(nameof(lineNumber), new DtoValue(0));
            DtoFields.Add(nameof(quantity), new DtoValue(1));
            RequiredFields.Add("tranType", new DtoValue("Issue"));
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }

        public string warehouseId
        {
            get => Get<string>();
            set => Set(value);
        }
        public decimal controlAmount
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal unitCost
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal extCost
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public decimal unitPrice
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal extPrice
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public string tranType
        {
            get => Get<string>(defaultValue: "Issue");
            set => Set(value);
        }
        [JsonIgnore]
        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }
        public int lineNumber
        {
            get => Get<int>();
            set => Set(value);
        }
        public string inventoryNumber
        {
            get => Get<string>();
            set => Set(value);
        }
        public LocationSummary locationId
        {
            get => Get<LocationSummary>();
            set => Set(value);
        }
        public decimal quantity
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public string uom
        {
            get => Get<string>();
            set => Set(value);
        }
        public DescriptionId reasonCode
        {
            get => Get<DescriptionId>();
            set => Set(value);
        }
        public string description
        {
            get => Get<string>();
            set => Set(value);
        }
        public NumberName branchNumber
        {
            get => Get<NumberName>();
            set => Set(value);
        }
        public List<Allocations> allocations
        {
            get => Get(defaultValue: new List<Allocations>());
            set { 
                if (value != null && value.Count > 0) 
                { 
                    IgnoreProperties.Add(nameof(quantity));
                    DtoFields.Remove(nameof(quantity));
                } 
                else 
                { 
                    IgnoreProperties.Remove(nameof(quantity));
                    DtoFields.Add(nameof(quantity), new DtoValue(1));
                }
                Set(value);
            }
        }
    }
}