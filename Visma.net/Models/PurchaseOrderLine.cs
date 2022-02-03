using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;
using System;

namespace ONIT.VismaNetApi.Models
{
    public class PurchaseOrderLine : DtoProviderBase
    {
        public PurchaseOrderLine()
        {
            DtoFields.Add(nameof(operation), new NotDto<ApiOperation>(ApiOperation.Insert));
            DtoFields.Add(nameof(lineNbr), new DtoValue(0));
            DtoFields.Add(nameof(orderQty), new DtoValue(1));
        }
        [JsonIgnore]
        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }
        [JsonProperty]
        public PurchaseOrderLineAccount account
        {
            get => Get(defaultValue: new PurchaseOrderLineAccount());
            set => Set(value);
        }
        public decimal amount
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public NumberName inventory
        {
            get => Get<NumberName>();
            set => Set(value);
        }
        public string lineDescription
        {
            get => Get<string>();
            set => Set(value);
        }
        public int lineNbr
        {
            get => Get<int>();
            set => Set(value);
        }
        public double orderQty
        {
            get => Get<double>();
            set => Set(value);
        }
        public CustomDto.Subaccount sub
        {
            get => Get(defaultValue: new CustomDto.Subaccount());
            set => Set(value);
        }
        public NumberDescription taxCategory
        {
            get => Get<NumberDescription>();
            set => Set(value);
        }
        public string uom
        {
            get => Get<string>();
            set => Set(value);
        }
        public NumberName branch
        {
            get => Get<NumberName>();
            set => Set(value);
        }
        public double qtyOnReceipts
        {
            get => Get<double>();
            set => Set(value);
        }
        public DescriptiveDto warehouse
        {
            get => Get<DescriptiveDto>();
            set => Set(value);
        }
        public decimal unitCost
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal unitCostInBaseCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal extCost
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
        public decimal receivedAmt
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public string alternateId
        {
            get => Get<string>();
            set => Set(value);
        }
        public double minReceipt
        {
            get => Get<double>();
            set => Set(value);
        }
        public double maxReceipt
        {
            get => Get<double>();
            set => Set(value);
        }
        public double completeOn
        {
            get => Get<double>();
            set => Set(value);
        }
        public DescriptiveDto project
        {
            get => Get<DescriptiveDto>();
            set => Set(value);
        }
        public DescriptiveDto projectTask
        {
            get => Get<DescriptiveDto>();
            set => Set(value);
        }
        public DateTime requested
        {
            get => Get<DateTime>();
            set => Set(value);
        }
        public DateTime promised
        {
            get => Get<DateTime>();
            set => Set(value);
        }
        public bool completed
        {
            get => Get<bool>();
            set => Set(value);
        }
        public bool canceled
        {
            get => Get<bool>();
            set => Set(value);
        }
        public string orderNumber
        {
            get => Get<string>();
            set => Set(value);
        }
        public string note
        {
            get => Get<string>();
            set => Set(value);
        }
    }
}