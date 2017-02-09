using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{

    /*
     {
  "project": {
    "value": 0
  },
  "printDescriptionOnInvoice": {
    "value": true
  },
  "printNoteOnExternalDocuments": {
    "value": true
  },
  "printNoteOnInternalDocuments": {
    "value": true
  },
  "soBillingContact": {
    "value": {
      "overrideContact": {
        "value": true
      },
      "name": {
        "value": "string"
      },
      "attention": {
        "value": "string"
      },
      "email": {
        "value": "string"
      },
      "web": {
        "value": "string"
      },
      "phone1": {
        "value": "string"
      },
      "phone2": {
        "value": "string"
      },
      "fax": {
        "value": "string"
      }
    }
  },
  "soBillingAddress": {
    "value": {
      "overrideAddress": {
        "value": true
      },
      "addressLine1": {
        "value": "string"
      },
      "addressLine2": {
        "value": "string"
      },
      "addressLine3": {
        "value": "string"
      },
      "postalCode": {
        "value": "string"
      },
      "city": {
        "value": "string"
      },
      "countryId": {
        "value": "string"
      },
      "county": {
        "value": "string"
      }
    }
  },
  "branch": {
    "value": 0
  },
  "branchNumber": {
    "value": "string"
  },
  "customerVATZone": {
    "value": "string"
  },
  "invoiceSeparately": {
    "value": true
  },
  "terms": {
    "value": "string"
  },
  "salesPerson": {
    "value": "string"
  },
  "owner": {
    "value": "string"
  },
  "origOrderType": {
    "value": "string"
  },
  "origOrderNbr": {
    "value": "string"
  },
  "soShippingContact": {
    "value": {
      "overrideContact": {
        "value": true
      },
      "name": {
        "value": "string"
      },
      "attention": {
        "value": "string"
      },
      "email": {
        "value": "string"
      },
      "web": {
        "value": "string"
      },
      "phone1": {
        "value": "string"
      },
      "phone2": {
        "value": "string"
      },
      "fax": {
        "value": "string"
      }
    }
  },
  "soShippingAddress": {
    "value": {
      "overrideAddress": {
        "value": true
      },
      "addressLine1": {
        "value": "string"
      },
      "addressLine2": {
        "value": "string"
      },
      "addressLine3": {
        "value": "string"
      },
      "postalCode": {
        "value": "string"
      },
      "city": {
        "value": "string"
      },
      "countryId": {
        "value": "string"
      },
      "county": {
        "value": "string"
      }
    }
  },
  "schedShipment": {
    "value": "2016-10-30T19:06:15.292Z"
  },
  "shipSeparately": {
    "value": true
  },
  "shipComplete": {
    "value": "BackOrderAllowed"
  },
  "cancelBy": {
    "value": "2016-10-30T19:06:15.292Z"
  },
  "canceled": {
    "value": true
  },
  "preferredWarehouse": {
    "value": "string"
  },
  "shipVia": {
    "value": "string"
  },
  "fobPoint": {
    "value": "string"
  },
  "priority": {
    "value": 0
  },
  "shippingTerms": {
    "value": "string"
  },
  "shippingZone": {
    "value": "string"
  },
  "residentialDelivery": {
    "value": true
  },
  "saturdayDelivery": {
    "value": true
  },
  "insurance": {
    "value": true
  },
  "transactionType": {
    "value": 0
  },
  "lines": []
  "orderType": {
    "value": "string"
  },
  "orderNumber": {
    "value": "string"
  },
  "hold": {
    "value": true
  },
  "date": {
    "value": "2016-10-30T19:06:15.294Z"
  },
  "requestOn": {
    "value": "2016-10-30T19:06:15.294Z"
  },
  "customerOrder": {
    "value": "string"
  },
  "customerRefNo": {
    "value": "string"
  },
  "customer": {
    "value": "string"
  },
  "location": {
    "value": "string"
  },
  "currency": {
    "value": "string"
  },
  "description": {
    "value": "string"
  },
  "recalculateShipment": true
}
     * */
    public class SalesOrder : DtoProviderBase, IProvideIdentificator
    {
        public SalesOrder()
        {
            IgnoreProperties.Add(nameof(orderNo));
            IgnoreProperties.Add("orderNumber");
            RequiredFields.Add(nameof(orderType), new DtoValue("SO"));
        }
        public int project { get { return Get<int>(); } set { Set(value); } }
        public bool printDescriptionOnInvoice { get { return Get<bool>(); } set { Set(value); } }
        public bool printNoteOnExternalDocuments { get { return Get<bool>(); } set { Set(value); } }
        public bool printNoteOnInternalDocuments { get { return Get<bool>(); } set { Set(value); } }
        public Contact soBillingContact { get { return Get<Contact>(defaultValue:new Contact()); } set { Set(value); } }
        public Address soBillingAddress { get { return Get<Address>(defaultValue: new Address()); } set { Set(value); } }
        public NumberName branch { get { return Get<NumberName>(); } set { Set(value); } }
        public NumberName branchNumber { get { return Get<NumberName>(); } set { Set(value); } }
        public CustomerVatZone customerVATZone { get { return Get<CustomerVatZone>(); } set { Set(value); } }
        public bool invoiceSeparately { get { return Get<bool>(); } set { Set(value); } }
        public string invoiceNbr { get { return Get<string>(); } set { Set(value); } }
        public DateTime invoiceDate { get { return Get<DateTime>(); } set { Set(value); } }
        public DescriptiveDto terms { get { return Get<DescriptiveDto>(); } set { Set(value); } }
        public DateTime dueDate { get { return Get<DateTime>(); } set { Set(value); } }
        public DateTime cashDiscountDate { get { return Get<DateTime>(); } set { Set(value); } }
        public string postPeriod { get { return Get<string>(); } set { Set(value); } }
        public DescriptiveDto salesPerson { get { return Get<DescriptiveDto>(defaultValue:new DescriptiveDto()); } set { Set(value); } }
        public Owner owner { get { return Get<Owner>(defaultValue:new Owner()); } set { Set(value); } }
        public string origOrderType { get { return Get<string>(); } set { Set(value); } }
        public string origOrderNbr { get { return Get<string>(); } set { Set(value); } }
        public ContactInfo soShippingContact { get { return Get<ContactInfo>(defaultValue:new ContactInfo()); } set { Set(value); } }
        public Address soShippingAddress { get { return Get<Address>(defaultValue:new Address()); } set { Set(value); } }
        public DateTime schedShipment { get { return Get<DateTime>(); } set { Set(value); } }
        public bool shipSeparately { get { return Get<bool>(); } set { Set(value); } }
        public string shipComplete { get { return Get<string>(); } set { Set(value); } }
        public DateTime cancelBy { get { return Get<DateTime>(); } set { Set(value); } }
        public bool canceled { get { return Get<bool>(); } set { Set(value); } }
        public DescriptiveDto preferredWarehouse { get { return Get<DescriptiveDto>(); } set { Set(value); } }
        public DescriptiveDto shipVia { get { return Get<DescriptiveDto>(); } set { Set(value); } }
        public DescriptiveDto fobPoint { get { return Get<DescriptiveDto>(); } set { Set(value); } }
        public int priority { get { return Get<int>(); } set { Set(value); } }
        public DescriptiveDto shippingTerms { get { return Get<DescriptiveDto>(defaultValue:new DescriptiveDto()); } set { Set(value); } }
        public DescriptiveDto shippingZone { get { return Get<DescriptiveDto>(defaultValue: new DescriptiveDto()); } set { Set(value); } }
        public bool residentialDelivery { get { return Get<bool>(); } set { Set(value); } }
        public bool saturdayDelivery { get { return Get<bool>(); } set { Set(value); } }
        public bool insurance { get { return Get<bool>(); } set { Set(value); } }
        public DescriptiveDto transactionType { get { return Get<DescriptiveDto>(defaultValue: new DescriptiveDto()); } set { Set(value); } }

        [JsonProperty]
        public List<SalesOrderLine> lines
        {
            get { return Get(defaultValue: new List<SalesOrderLine>()); } 
            private set { Set(value); }
        }

        public string orderType { get { return Get<string>(); } set { Set(value); } }
        public string orderNo { get { return Get<string>("orderNumber"); } set { Set(value, "orderNumber"); } }
        public string status { get { return Get<string>(); } set { Set(value); } }
        public bool hold { get { return Get<bool>(); } set { Set(value); } }
        public DateTime date { get { return Get<DateTime>(); } set { Set(value); } }
        public DateTime requestOn { get { return Get<DateTime>(); } set { Set(value); } }
        public string customerOrder { get { return Get<string>(); } set { Set(value); } }
        public string customerRefNo { get { return Get<string>(); } set { Set(value); } }
        public CustomerSummary customer { get { return Get<CustomerSummary>(); } set { Set(value); } }
        public Location location { get { return Get<Location>(defaultValue: new Location()); } set { Set(value); } }
        public string currency { get { return Get<string>(); } set { Set(value); } }
        public string description { get { return Get<string>(); } set { Set(value); } }
        public double orderTotal { get { return Get<int>(); } set { Set(value); } }
        public double vatTaxableTotal { get { return Get<int>(); } set { Set(value); } }
        public double vatExemptTotal { get { return Get<int>(); } set { Set(value); } }
        public double taxTotal { get { return Get<int>(); } set { Set(value); } }
        [JsonProperty]
        public DateTime lastModifiedDateTime { get; private set; }

        #region Methods
        public void Add(SalesOrderLine line)
        {
            line.lineNbr = 1;
            if (lines.Count > 0)
                line.lineNbr = Math.Max(lines.Count + 1, lines.Max(x => x.lineNbr) + 1);
            line.operation = ApiOperation.Insert;
            lines.Add(line);
        }

        public void Add(string inventoryId, string lineDescription = null, int quantity = 1)
        {
            Add(new SalesOrderLine()
            {
                inventory = inventoryId,
                quantity = quantity,
                lineDescription = lineDescription,
                operation = ApiOperation.Insert
            });
        }
        #endregion
        public string GetIdentificator()
        {
            return orderNo;
        }

        internal override void PrepareForUpdate()
        {
            foreach (var salesOrderLine in lines)
            {
                salesOrderLine.operation = ApiOperation.Update;
            }
            IgnoreProperties.Add(nameof(customer));
            if(lines.Count > 0)
                IgnoreProperties.Add(nameof(currency));
        }
    }
    
    /*
     "lines": [
    {
      "branch": {
        "value": 0
      },
      "branchNumber": {
        "value": "string"
      },
      "invoiceNbr": {
        "value": "string"
      },
      "salesOrderOperation": {
        "value": "Issue"
      },
      "freeItem": {
        "value": true
      },
      "requestedOn": {
        "value": "2016-10-30T19:06:15.293Z"
      },
      "shipOn": {
        "value": "2016-10-30T19:06:15.293Z"
      },
      "shipComplete": {
        "value": "BackOrderAllowed"
      },
      "undershipThreshold": {
        "value": 0
      },
      "overshipThreshold": {
        "value": 0
      },
      "completed": {
        "value": true
      },
      "markForPO": {
        "value": true
      },
      "poSource": {
        "value": "DropShipToOrder"
      },
      "lotSerialNbr": {
        "value": "string"
      },
      "expirationDate": {
        "value": "2016-10-30T19:06:15.293Z"
      },
      "reasonCode": {
        "value": "string"
      },
      "salesPerson": {
        "value": "string"
      },
      "taxCategory": {
        "value": "string"
      },
      "commissionable": {
        "value": true
      },
      "alternateID": {
        "value": "string"
      },
      "projectTask": {
        "value": "string"
      },
      "operation": "Insert",
      "lineNbr": {
        "value": 0
      },
      "inventoryId": {
        "value": "string"
      },
      "warehouse": {
        "value": "string"
      },
      "uom": {
        "value": "string"
      },
      "quantity": {
        "value": 0
      },
      "unitPrice": {
        "value": 0
      },
      "discountCode": {
        "value": "string"
      },
      "manualDiscount": {
        "value": true
      },
      "discUnitPrice": {
        "value": 0
      },
      "lineDescription": {
        "value": "string"
      }
    }
  ],

     * */


    public class SalesOrderLine : DtoProviderBase
    {
        public SalesOrderLine()
        {
            DtoFields.Add(nameof(lineNbr), new DtoValue(0));
            DtoFields.Add(nameof(quantity), new DtoValue(1));
            RequiredFields.Add("warehouse", new DtoValue(null));
            RequiredFields.Add("uom", new DtoValue(null));
            RequiredFields.Add("salesOrderOperation", new DtoValue("Issue"));
        }
        public ApiOperation operation
        {
            get { return Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value; }
            set { Set(new NotDto<ApiOperation>(value)); }
        }
        public int branch { get { return Get<int>(); } set { Set(value); } }
        public NumberName branchNumber { get { return Get<NumberName>(); } set { Set(value); } }
        public string invoiceNbr { get { return Get<string>(); } set { Set(value); } }
        public bool freeItem { get { return Get<bool>(); } set { Set(value); } }
        public DateTime requestedOn { get { return Get<DateTime>(); } set { Set(value); } }
        public DateTime shipOn { get { return Get<DateTime>(); } set { Set(value); } }
        public string shipComplete { get { return Get<string>(); } set { Set(value); } }
        public double undershipThreshold { get { return Get<double>(); } set { Set(value); } }
        public double overshipThreshold { get { return Get<double>(); } set { Set(value); } }
        public bool completed { get { return Get<bool>(); } set { Set(value); } }
        public bool markForPO { get { return Get<bool>(); } set { Set(value); } }
        public string poSource { get { return Get<string>(); } set { Set(value); } }
        public string lotSerialNbr { get { return Get<string>(); } set { Set(value); } }
        public DateTime expirationDate { get { return Get<DateTime>(); } set { Set(value); } }
        public string reasonCode { get { return Get<string>(); } set { Set(value); } }
        public DescriptiveDto salesPerson { get { return Get<DescriptiveDto>(); } set { Set(value); } }
        public string taxCategory { get { return Get<string>(); } set { Set(value); } }
        public bool commissionable { get { return Get<bool>(); } set { Set(value); } }
        public string alternateID { get { return Get<string>(); } set { Set(value); } }
        public int projectTask { get { return Get<int>(); } set { Set(value); } }
        public int lineNbr { get { return Get<int>(); } set { Set(value); } }
        public NumberName inventory { get { return Get<NumberName>("inventoryId"); } set { Set(value, "inventoryId"); } }
        public DescriptiveDto warehouse { get { return Get<DescriptiveDto>(); } set { Set(value); } }
        public string uom { get { return Get<string>(); } set { Set(value); } }
        public double quantity { get { return Get<int>(); } set { Set(value); } }
        public double qtyOnShipments { get { return Get<int>(); } set { Set(value); } }
        public double openQty { get { return Get<int>(); } set { Set(value); } }
        public double unitPrice { get { return Get<int>(); } set { Set(value); } }
        public string discountCode { get { return Get<string>(); } set { Set(value); } }
        public double discountPercent { get { return Get<int>(); } set { Set(value); } }
        public double discountAmount { get { return Get<int>(); } set { Set(value); } }
        public bool manualDiscount { get { return Get<bool>(); } set { Set(value); } }
        public double discUnitPrice { get { return Get<int>(); } set { Set(value); } }
        public double extPrice { get { return Get<int>(); } set { Set(value); } }
        public double unbilledAmount { get { return Get<int>(); } set { Set(value); } }
        public string lineDescription { get { return Get<string>(); } set { Set(value); } }
    }
}
