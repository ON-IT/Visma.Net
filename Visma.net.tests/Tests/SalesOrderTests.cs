using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Models;
using Xunit.Abstractions;

namespace Visma.net.tests.Tests
{
    public class SalesOrderTests : EntityBaseTest<SalesOrder>
    {
        private static readonly string dto = @"
{
  ""project"": 0,
  ""printDescriptionOnInvoice"": true,
  ""printNoteOnExternalDocuments"": true,
  ""printNoteOnInternalDocuments"": true,
  ""soBillingContact"": {
    ""overrideContact"": true,
    ""contactId"": 0,
    ""name"": ""string"",
    ""attention"": ""string"",
    ""email"": ""string"",
    ""web"": ""string"",
    ""phone1"": ""string"",
    ""phone2"": ""string"",
    ""fax"": ""string""
  },
  ""soBillingAddress"": {
    ""overrideAddress"": true,
    ""addressId"": 0,
    ""addressLine1"": ""string"",
    ""addressLine2"": ""string"",
    ""addressLine3"": ""string"",
    ""postalCode"": ""string"",
    ""city"": ""string"",
    ""country"": {
      ""id"": ""string"",
      ""name"": ""string"",
      ""extras"": {
        ""additionalProp1"": {},
        ""additionalProp2"": {},
        ""additionalProp3"": {}
      },
      ""errorInfo"": ""string"",
      ""metadata"": {
        ""totalCount"": 0
      }
    },
    ""county"": {
      ""id"": ""string"",
      ""name"": ""string""
    }
  },
  ""customerVATZone"": {
    ""id"": ""string"",
    ""description"": ""string"",
    ""defaultVatCategory"": ""string"",
    ""defaultTaxCategory"": {
      ""number"": ""string"",
      ""description"": ""string""
    },
    ""extras"": {
      ""additionalProp1"": {},
      ""additionalProp2"": {},
      ""additionalProp3"": {}
    },
    ""errorInfo"": ""string"",
    ""metadata"": {
      ""totalCount"": 0
    }
  },
  ""invoiceSeparately"": true,
  ""invoiceNbr"": ""string"",
  ""invoiceDate"": ""2019-06-25T07:53:56.740Z"",
  ""terms"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""dueDate"": ""2019-06-25T07:53:56.740Z"",
  ""cashDiscountDate"": ""2019-06-25T07:53:56.740Z"",
  ""postPeriod"": ""string"",
  ""salesPerson"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  /* ""owner"": {
    ""id"": ""string"",
    ""employeeId"": ""string"",
    ""name"": ""string""
  }, */
  ""origOrderType"": ""string"",
  ""origOrderNbr"": ""string"",
  ""soShippingContact"": {
    ""overrideContact"": true,
    ""contactId"": 0,
    ""name"": ""string"",
    ""attention"": ""string"",
    ""email"": ""string"",
    ""web"": ""string"",
    ""phone1"": ""string"",
    ""phone2"": ""string"",
    ""fax"": ""string""
  },
  ""soShippingAddress"": {
    ""overrideAddress"": true,
    ""addressId"": 0,
    ""addressLine1"": ""string"",
    ""addressLine2"": ""string"",
    ""addressLine3"": ""string"",
    ""postalCode"": ""string"",
    ""city"": ""string"",
    ""country"": {
      ""id"": ""string"",
      ""name"": ""string"",
      ""extras"": {
        ""additionalProp1"": {},
        ""additionalProp2"": {},
        ""additionalProp3"": {}
      },
      ""errorInfo"": ""string"",
      ""metadata"": {
        ""totalCount"": 0
      }
    },
    ""county"": {
      ""id"": ""string"",
      ""name"": ""string""
    }
  },
  ""schedShipment"": ""2019-06-25T07:53:56.740Z"",
  ""shipSeparately"": true,
  ""shipComplete"": ""BackOrderAllowed"",
  ""cancelBy"": ""2019-06-25T07:53:56.740Z"",
  ""canceled"": true,
  ""preferredWarehouse"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""shipVia"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""fobPoint"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""priority"": 0,
  ""shippingTerms"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""shippingZone"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""residentialDelivery"": true,
  ""saturdayDelivery"": true,
  ""insurance"": true,
  ""transactionType"": {
    ""Id"": 0,
    ""description"": ""string""
  },
  ""lines"": [
    {
      ""invoiceNbr"": ""string"",
      ""operation"": ""Issue"",
      ""freeItem"": true,
      ""requestedOn"": ""2019-06-25T07:53:56.740Z"",
      ""shipOn"": ""2019-06-25T07:53:56.740Z"",
      ""shipComplete"": ""BackOrderAllowed"",
      ""undershipThreshold"": 0.0,
      ""overshipThreshold"": 0.0,
      ""completed"": true,
      ""markForPO"": true,
      ""poSource"": ""DropShipToOrder"",
      ""lotSerialNbr"": ""string"",
      ""expirationDate"": ""2019-06-25T07:53:56.740Z"",
      ""reasonCode"": ""string"",
      ""salesPerson"": {
        ""id"": ""string"",
        ""description"": ""string""
      },
      ""taxCategory"": ""string"",
      ""commissionable"": true,
      ""alternateID"": ""string"",
      ""projectTask"": 0,
/*
      ""subaccount"": {
        ""id"": ""string"",
        ""description"": ""string""
      },
*/
      ""lineNbr"": 0,
      ""sortOrder"": 0,
      ""inventory"": {
        ""number"": ""string"",
        ""description"": ""string""
      },
      ""warehouse"": {
        ""id"": ""string"",
        ""description"": ""string""
      },
      ""uom"": ""string"",
      ""quantity"": 0.0,
      ""qtyOnShipments"": 0.0,
      ""openQty"": 0.0,
      ""unitCost"": 0.0,
      ""unitPrice"": 0.0,
      ""discountCode"": ""string"",
      ""discountPercent"": 0.0,
      ""discountAmount"": 0.0,
      ""manualDiscount"": true,
      ""discUnitPrice"": 0.0,
      ""extPrice"": 0.0,
      ""unbilledAmount"": 0.0,
      ""lineDescription"": ""string"",
      ""branchNumber"": {
        ""number"": ""string"",
        ""name"": ""string""
      },
      ""note"": ""string"",
      ""attachments"": [
        {
          ""name"": ""string"",
          ""id"": ""string"",
          ""revision"": 0
        }
      ]
    }
  ],
  ""orderType"": ""string"",
  ""orderNo"": ""string"",
  ""status"": ""Open"",
  ""hold"": true,
  ""date"": ""2019-06-25t07:53:56.740z"",
  ""requestOn"": ""2019-06-25t07:53:56.740z"",
  ""customerOrder"": ""string"",
  ""customerRefNo"": ""string"",
  ""customer"": {
    ""internalId"": 0,
    ""number"": ""string"",
    ""name"": ""string""
  },
  ""location"": {
    ""countryId"": ""string"",
    ""id"": ""string"",
    ""name"": ""string""
  },
  ""currency"": ""string"",
  ""description"": ""string"",
  ""orderTotal"": 0.0,
  ""vatTaxableTotal"": 0.0,
  ""vatExemptTotal"": 0.0,
  ""taxTotal"": 0.0,
  ""lastModifiedDateTime"": ""2019-06-25t07:53:56.740z"",
  ""branchNumber"": {
    ""number"": ""string"",
    ""name"": ""string""
  },
  ""note"": ""string"",
  ""attachments"": [
    {
      ""name"": ""string"",
      ""id"": ""string"",
      ""revision"": 0
    }
  ],
  ""extras"": {
    ""additionalProp1"": {},
    ""additionalProp2"": {},
    ""additionalProp3"": {}
  },
  ""errorInfo"": ""string"",
  ""metadata"": {
    ""totalCount"": 0
  }
}";

        public static string update = @"
{
  ""project"": {
    ""value"": 0
  },
  ""printDescriptionOnInvoice"": {
    ""value"": true
  },
  ""printNoteOnExternalDocuments"": {
    ""value"": true
  },
  ""printNoteOnInternalDocuments"": {
    ""value"": true
  },
  ""soBillingContact"": {
    ""value"": {
      ""overrideContact"": {
        ""value"": true
      },
      ""name"": {
        ""value"": ""string""
      },
      ""attention"": {
        ""value"": ""string""
      },
      ""email"": {
        ""value"": ""string""
      },
      ""web"": {
        ""value"": ""string""
      },
      ""phone1"": {
        ""value"": ""string""
      },
      ""phone2"": {
        ""value"": ""string""
      },
      ""fax"": {
        ""value"": ""string""
      }
    }
  },
  ""soBillingAddress"": {
    ""value"": {
      ""overrideAddress"": {
        ""value"": true
      },
      ""addressLine1"": {
        ""value"": ""string""
      },
      ""addressLine2"": {
        ""value"": ""string""
      },
      ""addressLine3"": {
        ""value"": ""string""
      },
      ""postalCode"": {
        ""value"": ""string""
      },
      ""city"": {
        ""value"": ""string""
      },
      ""countryId"": {
        ""value"": ""string""
      },
      ""county"": {
        ""value"": ""string""
      }
    }
  },
  ""customerVATZone"": {
    ""value"": ""string""
  },
  ""invoiceSeparately"": {
    ""value"": true
  },
  ""terms"": {
    ""value"": ""string""
  },
  ""salesPerson"": {
    ""value"": ""string""
  },
  /* ""owner"": {
    ""value"": ""string""
  }, */
  ""origOrderType"": {
    ""value"": ""string""
  },
  ""origOrderNbr"": {
    ""value"": ""string""
  },
  ""soShippingContact"": {
    ""value"": {
      ""overrideContact"": {
        ""value"": true
      },
      ""name"": {
        ""value"": ""string""
      },
      ""attention"": {
        ""value"": ""string""
      },
      ""email"": {
        ""value"": ""string""
      },
      ""web"": {
        ""value"": ""string""
      },
      ""phone1"": {
        ""value"": ""string""
      },
      ""phone2"": {
        ""value"": ""string""
      },
      ""fax"": {
        ""value"": ""string""
      }
    }
  },
  ""soShippingAddress"": {
    ""value"": {
      ""overrideAddress"": {
        ""value"": true
      },
      ""addressLine1"": {
        ""value"": ""string""
      },
      ""addressLine2"": {
        ""value"": ""string""
      },
      ""addressLine3"": {
        ""value"": ""string""
      },
      ""postalCode"": {
        ""value"": ""string""
      },
      ""city"": {
        ""value"": ""string""
      },
      ""countryId"": {
        ""value"": ""string""
      },
      ""county"": {
        ""value"": ""string""
      }
    }
  },
  ""schedShipment"": {
    ""value"": ""2019-06-25t07:53:56.740z""
  },
  ""shipSeparately"": {
    ""value"": true
  },
  ""shipComplete"": {
    ""value"": ""BackOrderAllowed""
  },
  ""cancelBy"": {
    ""value"": ""2019-06-25t07:53:56.740z""
  },
  ""canceled"": {
    ""value"": true
  },
  ""preferredWarehouse"": {
    ""value"": ""string""
  },
  ""shipVia"": {
    ""value"": ""string""
  },
  ""fobPoint"": {
    ""value"": ""string""
  },
  ""priority"": {
    ""value"": 0
  },
  ""shippingTerms"": {
    ""value"": ""string""
  },
  ""shippingZone"": {
    ""value"": ""string""
  },
  ""residentialDelivery"": {
    ""value"": true
  },
  ""saturdayDelivery"": {
    ""value"": true
  },
  ""insurance"": {
    ""value"": true
  },
  ""transactionType"": {
    ""value"": 0
  },
  ""lines"": [
    {
      ""invoiceNbr"": {
        ""value"": ""string""
      },
      ""salesOrderOperation"": {
        ""value"": ""Issue""
      },
      ""freeItem"": {
        ""value"": true
      },
      ""requestedOn"": {
        ""value"": ""2019-06-25t07:53:56.740z""
      },
      ""shipOn"": {
        ""value"": ""2019-06-25t07:53:56.740z""
      },
      ""shipComplete"": {
        ""value"": ""BackOrderAllowed""
      },
      ""undershipThreshold"": {
        ""value"": 0.0
      },
      ""overshipThreshold"": {
        ""value"": 0.0
      },
      ""completed"": {
        ""value"": true
      },
      ""markForPO"": {
        ""value"": true
      },
      ""poSource"": {
        ""value"": ""DropShipToOrder""
      },
      ""lotSerialNbr"": {
        ""value"": ""string""
      },
      ""expirationDate"": {
        ""value"": ""2019-06-25t07:53:56.740z""
      },
      ""reasonCode"": {
        ""value"": ""string""
      },
      ""salesPerson"": {
        ""value"": ""string""
      },
      ""taxCategory"": {
        ""value"": ""string""
      },
      ""commissionable"": {
        ""value"": true
      },
      ""alternateID"": {
        ""value"": ""string""
      },
      ""projectTask"": {
        ""value"": ""string""
      },
      /*""subaccount"": [
        {
          ""segmentId"": 0,
          ""segmentValue"": ""string""
        }
      ],*/
      ""branchNumber"": {
        ""value"": ""string""
      },
      ""operation"": ""Insert"",
      ""lineNbr"": {
        ""value"": 0
      },
/*
      ""inventoryId"": {
        ""value"": ""string""
      },
*/
      ""inventoryNumber"": {
        ""value"": ""string""
      },
      ""warehouse"": {
        ""value"": ""string""
      },
      ""uom"": {
        ""value"": ""string""
      },
      ""quantity"": {
        ""value"": 0.0
      },
      ""unitCost"": {
        ""value"": 0.0
      },
      ""unitPrice"": {
        ""value"": 0.0
      },
      ""discountPercent"": {
        ""value"": 0.0
      },
      ""discountAmount"": {
        ""value"": 0.0
      },
      ""discountCode"": {
        ""value"": ""string""
      },
      ""manualDiscount"": {
        ""value"": true
      },
      ""discUnitPrice"": {
        ""value"": 0.0
      },
      ""lineDescription"": {
        ""value"": ""string""
      },
      ""note"": {
        ""value"": ""string""
      }
    }
  ],
  ""orderType"": {
    ""value"": ""string""
  },
/*
  ""orderNumber"": {
    ""value"": ""string""
  },
*/
  ""hold"": {
    ""value"": true
  },
  ""date"": {
    ""value"": ""2019-06-25t07:53:56.740z""
  },
  ""requestOn"": {
    ""value"": ""2019-06-25t07:53:56.740z""
  },
  ""customerOrder"": {
    ""value"": ""string""
  },
  ""customerRefNo"": {
    ""value"": ""string""
  },
  ""customer"": {
    ""value"": ""string""
  },
  ""location"": {
    ""value"": ""string""
  },
/*
  ""gln"": {
    ""value"": ""string""
  },
  ""vatRegistrationId"": {
    ""value"": ""string""
  },
*/
  ""currency"": {
    ""value"": ""string""
  },
  ""description"": {
    ""value"": ""string""
  },
 /* ""recalculateShipment"": true,*/
  ""branchNumber"": {
    ""value"": ""string""
  },
  ""note"": {
    ""value"": ""string""
  }
}";

        public SalesOrderTests(ITestOutputHelper output) : base(dto, update)
        {
            this.output = output;
        }


        public override string PrepareUpdateDto(string src)
        {
            var jtoken = JToken.Parse(src);
            jtoken["lines"][0]["projectTask"]["value"] = "0";
            return jtoken.ToString(Formatting.Indented);
        }
    }
}