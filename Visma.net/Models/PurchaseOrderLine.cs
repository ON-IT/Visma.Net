<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
=======
﻿using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
>>>>>>> Stashed changes
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class PurchaseOrderLine : DtoProviderBase
    {
        public PurchaseOrderLine()
        {
<<<<<<< Updated upstream
            DtoFields.Add(nameof(lineNbr), new DtoValue(0));
            DtoFields.Add(nameof(orderQty), new DtoValue(1));
            RequiredFields.Add("PurchaseOrderOperation", new DtoValue("Issue"));
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }

=======
            DtoFields.Add(nameof(operation), new NotDto<ApiOperation>(ApiOperation.Insert));
            DtoFields.Add(nameof(lineNbr), new DtoValue(0));
            DtoFields.Add(nameof(orderQty), new DtoValue(1));
        }
>>>>>>> Stashed changes
        [JsonIgnore]
        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }
<<<<<<< Updated upstream

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
        

=======
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
>>>>>>> Stashed changes
        public string lineDescription
        {
            get => Get<string>();
            set => Set(value);
<<<<<<< Updated upstream
    }
        public PurchaseRecieptLineType lineType
        {
          get => Get<PurchaseRecieptLineType>();
          set => Set(value);
        }
        

=======
        }
>>>>>>> Stashed changes
        public int lineNbr
        {
            get => Get<int>();
            set => Set(value);
        }
<<<<<<< Updated upstream


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
=======
    public PurchaseRecieptLineType lineType
    {
      get => Get<PurchaseRecieptLineType>();
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
    public CustomDto.Subaccount sub
        {
            get => Get(defaultValue: new CustomDto.Subaccount());
>>>>>>> Stashed changes
            set => Set(value);
        }
        public NumberDescription taxCategory
        {
<<<<<<< Updated upstream
          get => Get<NumberDescription>();
          set => Set(value);
        }


=======
            get => Get<NumberDescription>();
            set => Set(value);
        }
    public decimal unitCost
    {
      get => Get<decimal>();
      set => Set(value);
    }
>>>>>>> Stashed changes
    public string uom
        {
            get => Get<string>();
            set => Set(value);
        }
<<<<<<< Updated upstream

        public DescriptiveDto warehouse
        {
            get => Get<DescriptiveDto>();
            set => Set(value);
        }

    }
=======
    public DescriptiveDto warehouse
    {
      get => Get<DescriptiveDto>();
      set => Set(value);
    }
  }
>>>>>>> Stashed changes
}