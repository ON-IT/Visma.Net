using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class PurchaseOrderLine : DtoProviderBase
    {
        public PurchaseOrderLine()
        {
            DtoFields.Add(nameof(lineNbr), new DtoValue(0));
            DtoFields.Add(nameof(orderQty), new DtoValue(1));
            RequiredFields.Add("PurchaseOrderOperation", new DtoValue("Issue"));
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }

        [JsonIgnore]
        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }

        public NumberName branchNumber
        {
            get => Get<NumberName>();
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

   
        //public NumberDescription discountCode
        //{
        //  get => Get<NumberDescription>("discountCode");
        //  set => Set(value, "discountCode");
        //}

        public double discountPercent
        {
            get => Get<double>();
            set => Set(value);
        }




        public NumberDescription inventory
        {
            get => Get<NumberDescription>("inventory");
            set => Set(value);
        }
        

        public string lineDescription
        {
            get => Get<string>();
            set => Set(value);
    }
        public PurchaseRecieptLineType lineType
        {
          get => Get<PurchaseRecieptLineType>();
          set => Set(value);
        }
        

        public int lineNbr
        {
            get => Get<int>();
            set => Set(value);
        }


        public bool manualDiscount
        {
            get => Get<bool>();
            set => Set(value);
        }


        public double orderQty
        {
          get => Get<double>();
          set => Set(value);
        }

        [JsonProperty]
        public NumberDescription project
        {
          get => Get<NumberDescription>();
          set => Set(value);
        }




    public string reasonCode
        {
            get => Get<string>();
            set => Set(value);
        }

        public DateTime requested
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        [JsonProperty("operation")]
        public string PurchaseOrderOperation
        {
            get => Get<string>(defaultValue: "Issue");
            set => Set(value);
        }



        [JsonProperty] public int sortOrder { get; private set; }

        
        public decimal unitCost
        {
            get => Get<decimal>();
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

        public DescriptiveDto warehouse
        {
            get => Get<DescriptiveDto>();
            set => Set(value);
        }

    }
}