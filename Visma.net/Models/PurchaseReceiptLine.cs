using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class PurchaseReceiptLine : DtoProviderBase
    {
        public PurchaseReceiptLine()
        {
            DtoFields.Add(nameof(lineNbr), new DtoValue(0));
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }

        public List<Allocations> allocations
        {
            get => Get(defaultValue: new List<Allocations>());
            private set => Set(value);
        }
        [JsonIgnore]
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
        public PurchaseReceiptLineType lineType
        {
            get => Get<PurchaseReceiptLineType>();
            set => Set(value);
        }
        public NumberName branchId
        {
            get => Get<NumberName>();
            set => Set(value);
        }
        public NumberName branchNumber
        {
            get => Get<NumberName>();
            set => Set(value);
        }
        public NumberDescription inventory
        {
            get => Get("inventoryId", new NumberDescription());
            set => Set(value, "inventoryId");
        }
        public DescriptionId warehouse
        {
            get => Get("warehouseId", new DescriptionId());
            set => Set(value, "warehouseId");

        }
        public LocationSummary location
        {
            get => Get("locationId", new LocationSummary());
            set => Set(value, "locationId");
        }
        public string transactionDescription
        {
            get => Get<string>();
            set => Set(value);
        }
        public string uom
        {
            get => Get<string>();
            set => Set(value);
        }
        public decimal orderQty
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal openQty
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal receiptQty
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
        public decimal extPrice
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public decimal discountPercent
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal discountAmount
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public bool manualDiscount
        {
            get => Get<bool>();
            set => Set(value);
        }
        public NumberDescription discountCode
        {
            get => Get<NumberDescription>();
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
        public NumberDescriptionType account
        {
            get => Get("accountId", new NumberDescriptionType());
            set => Set(value, "accountId");

        }

        public string accountDescription
        {
            get => Get<string>();
            set => Set(value);
        }
        public CustomDto.Subaccount subaccount
        {
            get => Get(defaultValue: new CustomDto.Subaccount());
            set => Set(value);
        }
        public DescriptionId sub
        {
            get => Get<DescriptionId>();
            set => Set(value);
        }
        public Account actualAccount
        {
            get => Get<Account>();
            set => Set(value);
        }
        public DescriptionId actualSub
        {
            get => Get<DescriptionId>();
            set => Set(value);
        }
        public DescriptionId project
        {
            get => Get<DescriptionId>();
            set => Set(value);
        }
        public DescriptionId projectTask
        {
            get => Get<DescriptionId>();
            set => Set(value);
        }
        public DateTime expirationDate
        {
            get => Get<DateTime>();
            set => Set(value);
        }
        public string lotSerialNumber
        {
            get => Get<string>();
            set => Set(value);
        }
        public PurchaseOrderType poOrderType
        {
            get => Get<PurchaseOrderType>();
            set => Set(value);
        }

        public string poOrderNbr
        {
            get => Get<string>();
            set => Set(value);
        }

        public int poOrderLineNbr
        {
            get => Get<int>();
            set => Set(value);
        }
        public TransferOrderType transferOrderType
        {
            get => Get<TransferOrderType>();
            set => Set(value);
        }

        public string transferOrderNbr
        {
            get => Get<string>();
            set => Set(value);
        }

        public int transferOrderLineNbr
        {
            get => Get<int>();
            set => Set(value);
        }
        public bool completePoLine
        {
            get => Get<bool>();
            set => Set(value);
        }
    }
}