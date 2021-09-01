using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

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
    }
}