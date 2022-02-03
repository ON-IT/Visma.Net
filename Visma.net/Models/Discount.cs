using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class Discount : DtoPaginatedProviderBase, IProvideIdentificator
    {
        public string discountCode
        {
            get => Get<string>();
            set => Set(value);
        }

        public string series
        {
            get => Get<string>();
            set => Set(value);
        }

        public string description
        {
            get => Get<string>();
            set => Set(value);
        }

        public string discountBy
        {
            get => Get<string>();
            set => Set(value);
        }

        public string breakBy
        {
            get => Get<string>();
            set => Set(value);
        }

        public bool? promotional
        {
            get => Get<bool?>();
            set => Set(value);
        }

        public bool? active
        {
            get => Get<bool?>();
            set => Set(value);
        }
        [JsonProperty]
        public bool? prorateDiscount
        {
            get;
            private set; 
        }
        [JsonProperty]
        public DateTime? effectiveDate
        {
            get;
            private set;
        }
        public DateTime? expirationDate
        {
            get => Get<DateTime?>();
            set => Set(value);
        }
        [JsonProperty]
        public DateTime? lastUpdateDate
        {
            get; //=> Get<DateTime?>();
            private set; //=> Set(value);
        }
        [JsonProperty]
        public DateTime? createdDateTime
        {
            get; //=> Get<DateTime?>();
            private set; //=> Set(value);
        }
        [JsonProperty]
        public DateTime? lastModifiedDateTime
        {
            get; //=> Get<DateTime?>();
            private set; //=> Set(value);
        }

        public int lastFreeItem
        {
            get => Get<int>();
            set => Set(value);
        }
        public int freeItem
        {
            get => Get<int>();
            set => Set(value);
        }
        public int pendingFreeItem
        {
            get => Get<int>();
            set => Set(value);
        }
        public int lineCntr
        {
            get => Get<int>();
            set => Set(value);
        }

        public List<DiscountBreakpoint> discountBreakpoints
        {
            get => Get(defaultValue: new List<DiscountBreakpoint>());
            set => Set(value);
        }


        public string GetIdentificator()
        {
            return discountCode;
        }

        [JsonProperty]
        public List<JObject> customers { get; private set; }
        [JsonProperty]
        public List<JObject> items { get; private set; }
        [JsonProperty]
        public List<JObject> warehouses { get; private set; }
        [JsonProperty]
        public List<JObject> customerPriceClasses { get; private set; }
        [JsonProperty]
        public List<JObject> itemPriceClasses { get; private set; }
        [JsonProperty]
        public List<JObject> branches { get; private set; }

        public void Add(DiscountBreakpoint line)
        {
            line.lineNbr = 1;
            if (discountBreakpoints.Count > 0)
                line.lineNbr = Math.Max(discountBreakpoints.Count + 1,
                    discountBreakpoints.Max(x => x.lineNbr) + 1);
            discountBreakpoints.Add(line);
        }
        internal override void PrepareForUpdate()
        {
            foreach (var discountBreakpoint in discountBreakpoints)
            {
                discountBreakpoint.operation = ApiOperation.Update;
            }
        }
    }
    public class DiscountBreakpoint : DtoProviderBase
    {
        public DiscountBreakpoint()
        {
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
            DtoFields.Add("lineNbr", new DtoValue(0));
        }
        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }

        public int lineNbr
        {
            get => Get<int>();
            set => Set(value);
        }
        public bool? active
        {
            get => Get<bool?>();
            set => Set(value);
        }
        [JsonProperty]
        public decimal breakAmount
        {
            get;
            private set;
        }
        public decimal amountTo
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal lastBreakAmount
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal lastAmountTo
        {
            get => Get<decimal>();
            set => Set(value);
        }
        [JsonProperty]
        public decimal pendingBreakAmount
        {
            get;
            private set;
        }
        public decimal breakQuantity
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal quantityTo
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal lastBreakQuantity
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal lastQuantityTo
        {
            get => Get<decimal>();
            set => Set(value);
        }
        [JsonProperty]
        public decimal pendingBreakQuantity
        {
            get;
            private set;
        }
        [JsonProperty]
        public decimal discountAmount
        {
            get;
            private set;
        }
        [JsonProperty]
        public decimal discountPercent
        {
            get;
            private set;
        }
        public decimal lastDiscountAmount
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal lastDiscountPercent
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal lastDiscount
        {
            get => Get<decimal>();
            set => Set(value);
        }
        [JsonProperty]
        public decimal pendingDiscountAmount
        {
            get;
            private set;
        }
        [JsonProperty]
        public decimal pendingDiscountPercent
        {
            get ;
            private set;
        }
        public decimal freeItemQty
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal lastFreeItemQty
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal pendingFreeItemQty
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public DateTime? pendingDate
        {
            get => Get<DateTime?>();
            set => Set(value);
        }
        public DateTime? effectiveDate
        {
            get => Get<DateTime?>();
            set => Set(value);
        }
    }
 }