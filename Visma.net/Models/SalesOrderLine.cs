using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class SalesOrderLine : DtoProviderBase
    {
        public SalesOrderLine()
        {
            DtoFields.Add(nameof(lineNbr), new DtoValue(0));
            DtoFields.Add(nameof(quantity), new DtoValue(1));
            RequiredFields.Add("salesOrderOperation", new DtoValue("Issue"));
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }

        [JsonIgnore]
        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }
        public string alternateID
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty] public List<Attachment> attachments { get; private set; }

        public NumberName branchNumber
        {
            get => Get<NumberName>();
            set => Set(value);
        }

        public bool commissionable
        {
            get => Get<bool>();
            set => Set(value);
        }

        public bool completed
        {
            get => Get<bool>();
            set => Set(value);
        }

        public double discountAmount
        {
            get => Get<double>();
            set => Set(value);
        }

        public string discountCode
        {
            get => Get<string>();
            set => Set(value);
        }

        public double discountPercent
        {
            get => Get<double>();
            set => Set(value);
        }

        public double discUnitPrice
        {
            get => Get<double>();
            set => Set(value);
        }

        public DateTime expirationDate
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        [JsonProperty]
        public double extPrice
        {
            get; // => Get<double>();
            private set; //=> Set(value);
        }

        public bool freeItem
        {
            get => Get<bool>();
            set => Set(value);
        }

        public NumberDescription inventory
        {
            get => Get<NumberDescription>("inventoryNumber");
            set => Set(value, "inventoryNumber");
        }
        
        public string invoiceNbr
        {
            get => Get<string>();
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

        public string lotSerialNbr
        {
            get => Get<string>();
            set => Set(value);
        }

        public bool manualDiscount
        {
            get => Get<bool>();
            set => Set(value);
        }

        public bool markForPO
        {
            get => Get<bool>();
            set => Set(value);
        }

        public string note
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty] public double openQty { get; private set; }
        
        public double overshipThreshold
        {
            get => Get<double>();
            set => Set(value);
        }

        public string poSource
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public int projectTask
        {
            get => int.TryParse(Get<string>(), out var value) ? value : 0;
            set => Set(value.ToString());
        }

        [JsonProperty]
        public double qtyOnShipments
        {
            get; // => Get<double>();
            private set; // => Set(value);
        }

        public double quantity
        {
            get => Get<double>();
            set => Set(value);
        }

        public string reasonCode
        {
            get => Get<string>();
            set => Set(value);
        }

        public DateTime requestedOn
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        [JsonProperty("operation")]
        public string salesOrderOperation
        {
            get => Get<string>(defaultValue: "Issue");
            set => Set(value);
        }

        public DescriptiveDto salesPerson
        {
            get => Get<DescriptiveDto>();
            set => Set(value);
        }

        public string shipComplete
        {
            get => Get<string>();
            set => Set(value);
        }

        public DateTime shipOn
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        [JsonProperty] public int sortOrder { get; private set; }

        
        public CustomDto.SubaccountOrderLine subaccount
        {
            get => Get(defaultValue: new CustomDto.SubaccountOrderLine());
            set => Set(value);
        }
        
        public string taxCategory
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public double unbilledAmount
        {
            get; // => Get<double>();
            private set; // => Set(value);
        }

        public double undershipThreshold
        {
            get => Get<double>();
            set => Set(value);
        }

        public decimal unitCost
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public double unitPrice
        {
            get => Get<double>();
            set => Set(value);
        }

        public string uom
        {
            get => Get<string>();
            set => Set(value);
        }

        public DescriptiveDto warehouse
        {
            get => Get<DescriptiveDto>();
            set => Set(value);
        }
    }
}