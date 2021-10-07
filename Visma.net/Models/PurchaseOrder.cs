<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;
=======
﻿using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
>>>>>>> Stashed changes

namespace ONIT.VismaNetApi.Models
{
    public class PurchaseOrder : DtoPaginatedProviderBase, IProvideIdentificator
    {
        public PurchaseOrder()
        {
            IgnoreProperties.Add(nameof(orderNbr));
<<<<<<< Updated upstream
            IgnoreProperties.Add("orderNumber");
            RequiredFields.Add(nameof(orderType), new DtoValue("PO"));
        }

        public PurchaseOrder(string orderNo,string orderType)
        {
            this.orderNbr = orderNo;
            this.orderType = orderType;
            RequiredFields.Add(nameof(orderType), new DtoValue(orderType));
        }


       public NumberName branchNumber
        {
            get => Get<NumberName>();
            set => Set(value);
        }


       [JsonProperty]
       public double controlTotal
       {
         get;// => Get<double>();
         private set;// => Set(value);
       }

       [JsonProperty]
       public double controlTotalInBaseCurrency
       {
         get;
         private set;
       }

=======
            IgnoreProperties.Add("orderNbr");
            RequiredFields.Add(nameof(orderType), new DtoValue("PO"));

        }

        public PurchaseOrder(string orderNo, string orderType)
        {
          this.orderNbr = orderNo;
          this.orderType = orderType;
          RequiredFields.Add(nameof(orderType), new DtoValue(orderType));
        }

>>>>>>> Stashed changes
        public string currency
        {
            get => Get<string>();
            set => Set(value);
        }
<<<<<<< Updated upstream

   
=======
>>>>>>> Stashed changes
        public DateTime date
        {
            get => Get<DateTime>();
            set => Set(value);
        }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
        public string description
        {
            get => Get<string>();
            set => Set(value);
        }

<<<<<<< Updated upstream

        [JsonProperty]
        public double exchangeRate
        {
            get;
            private set;
        }


        public bool hold
        {
            get => Get<bool>();
            set => Set(value);
        }


        [JsonProperty] public DateTime lastModifiedDateTime { get; private set; }

=======
        public bool hold
        {
          get => Get<bool>();
          set => Set(value);
        }

    [JsonProperty] public DateTime lastModifiedDateTime { get; private set; }
>>>>>>> Stashed changes
        [JsonProperty]
        public List<PurchaseOrderLine> lines
        {
            get => Get(defaultValue: new List<PurchaseOrderLine>());
            private set => Set(value);
        }

<<<<<<< Updated upstream

        public LocationSummary location
        {
            get => Get(defaultValue: new LocationSummary());
            set => Set(value);
        }

=======
        [JsonProperty] public decimal lineTotal { get; private set; }

        [JsonProperty] public decimal lineTotalInBaseCurrency { get; private set; }
>>>>>>> Stashed changes
        public string note
        {
            get => Get<string>();
            set => Set(value);
        }

        public string orderNbr
        {
<<<<<<< Updated upstream
            get => Get<string>("orderNumber");
            set => Set(value, "orderNumber");
        }

        [JsonProperty]
        public double lineTotal
        {
            get;// => Get<double>();
            private set;// => Set(value);
        }

        [JsonProperty]
        public double lineTotalInBaseCurrency
        {
            get;
            private set;
        }

        public string orderType
        {
            get => Get<string>();
            set => Set(value);
        }

        /*
        public Owner owner
        {
            get => Get(defaultValue: new Owner());
            set => Set(value);
        }
        */

        public DateTime promisedOn
=======
            get => Get<string>("orderNbr");
            set => Set(value, "orderNbr");
        }
        public Owner owner
        {
            get => Get(defaultValue: new Owner());
            set => Set(value);
        }
        [JsonProperty] public decimal orderTotal { get; private set; }

        [JsonProperty] public decimal orderTotalInBaseCurrency { get; private set; }

        public string orderType
        {
          get => Get<string>();
          set => Set(value);
        }

    public DateTime promisedOn
>>>>>>> Stashed changes
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        [JsonProperty]
        public PoAddress poShippingAddress
        {
          get => Get(defaultValue: new PoAddress());
          set => Set(value);
        }

<<<<<<< Updated upstream
        [JsonProperty]
        public string status
        {
            get;// => Get<string>();
            private set;//( => Set(value);
        }

        public PoSupplierSummary supplier
        {
          get => Get<PoSupplierSummary>();
          set => Set(value);
        }


        [JsonProperty]
        public double taxTotal
        {
            get;// => Get<double>();
            private set; //=> Set(value);
        }

        [JsonProperty]
        public double taxTotalInBaseCurrency
        {
            get;
            private set;
        }

    
        [JsonProperty]
        public double vatExemptTotal
        {
            get;// => Get<double>();
            private set;// => Set(value);
        }

        [JsonProperty]
        public double vatExemptTotalInBaseCurrency
        {
            get;
            private set;
        }

=======

    public SoCustomerSummary supplier
        {
            get => Get<SoCustomerSummary>();
            set => Set(value);
        }
        public string supplierRef
        {
            get => Get<string>();
            set => Set(value);
        }
        [JsonProperty]
        public List<TaxDetail> taxDetails { get; private set; }
        [JsonProperty] public decimal taxTotal { get; private set; }
        [JsonProperty] public decimal taxTotalInBaseCurrency { get; private set; }
        [JsonProperty] public decimal vatExemptTotal { get; private set; }
        [JsonProperty] public decimal vatExemptTotalInBaseCurrency { get; private set; }
        public void Add(PurchaseOrderLine line)
        {
            line.lineNbr = 1;
            if (lines.Count > 0)
                line.lineNbr = Math.Max(lines.Count + 1, lines.Max(x => x.lineNbr) + 1);
            lines.Add(line);
        }
>>>>>>> Stashed changes
        public string GetIdentificator()
        {
            return orderNbr;
        }
<<<<<<< Updated upstream

        internal override void PrepareForUpdate()
        {
            foreach (var line in lines)
            {
                line.operation = ApiOperation.Update;
            }

            IgnoreProperties.Add(nameof(supplier));
            if (lines.Count > 0)
                IgnoreProperties.Add(nameof(currency));
        }

        #region Methods

        public void Add(PurchaseOrderLine line)
        {
            line.lineNbr = 1;
            if (lines.Count > 0)
                line.lineNbr = Math.Max(lines.Count + 1, lines.Max(x => x.lineNbr) + 1);
            line.operation = ApiOperation.Insert;
            lines.Add(line);
        }

        public void Add(string inventoryId, string lineDescription = null, int quantity = 1)
        {
            Add(new PurchaseOrderLine()
            {
                inventory = inventoryId,
                orderQty = quantity,
                lineDescription = lineDescription,
                operation = ApiOperation.Insert
            });
        }

        #endregion
    }
}
=======
        internal override void PrepareForUpdate()
        {
            foreach (var purchaseOrderLine in lines)
            {
                purchaseOrderLine.operation = ApiOperation.Update;
            }
        }
    }
}
>>>>>>> Stashed changes
