using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Models;
using Xunit.Abstractions;

namespace Visma.net.Tests
{
    public class SalesOrderTests : EntityBaseTest<SalesOrder>
    {
        private static readonly string dto = @"
{
  ""project"": 0,
  ""projectCD"": ""string"",
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
      ""errorInfo"": ""string"",
      ""metadata"": {
        ""totalCount"": 0,
        ""maxPageSize"": 0
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
    ""errorInfo"": ""string"",
    ""metadata"": {
      ""totalCount"": 0,
      ""maxPageSize"": 0
    }
  },
  ""invoiceSeparately"": true,
  ""invoiceNbr"": ""string"",
  ""invoiceDate"": ""2022-04-26T12:18:39.596Z"",
  ""terms"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""dueDate"": ""2022-04-26T12:18:39.596Z"",
  ""cashDiscountDate"": ""2022-04-26T12:18:39.596Z"",
  ""postPeriod"": ""string"",
  ""salesPerson"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""commissionPercent"": ""string"",
  ""commissionAmount"": ""string"",
  ""commissionableAmount"": ""string"",
  ""owner"": {
    ""id"": ""00000000-0000-0000-0000-000000000000"",
    ""employeeId"": ""string"",
    ""name"": ""string""
  },
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
      ""errorInfo"": ""string"",
      ""metadata"": {
        ""totalCount"": 0,
        ""maxPageSize"": 0
      }
    },
    ""county"": {
      ""id"": ""string"",
      ""name"": ""string""
    }
  },
  ""schedShipment"": ""2022-04-26T12:18:39.596Z"",
  ""shipSeparately"": true,
  ""shipComplete"": ""BackOrderAllowed"",
  ""cancelBy"": ""2022-04-26T12:18:39.596Z"",
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
    ""id"": 0,
    ""description"": ""string""
  },
  ""paymentMethod"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""cashAccount"": ""string"",
  ""paymentRef"": ""string"",
  ""isRotRutDeductible"": true,
  ""emailed"": true,
  ""lines"": [
    {
      ""invoiceNbr"": ""string"",
      ""operation"": ""Issue"",
      ""freeItem"": true,
      ""requestedOn"": ""2022-04-26T12:18:39.596Z"",
      ""shipOn"": ""2022-04-26T12:18:39.596Z"",
      ""shipComplete"": ""BackOrderAllowed"",
      ""undershipThreshold"": 0,
      ""overshipThreshold"": 0,
      ""completed"": true,
      ""markForPO"": true,
      ""poSource"": ""DropShipToOrder"",
      ""lotSerialNbr"": ""string"",
      ""expirationDate"": ""2022-04-26T12:18:39.596Z"",
      ""reasonCode"": ""string"",
      ""salesPerson"": {
        ""id"": ""string"",
        ""description"": ""string""
      },
      ""taxCategory"": ""string"",
      ""commissionable"": true,
      ""alternateID"": ""string"",
      ""projectTask"": 0,
      ""projectTaskCd"": ""string"",
      ""subaccount"": {
        ""id"": ""string"",
        ""description"": ""string""
      },
      ""externalLink"": ""string"",
      ""isRotRutDeductible"": true,
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
      ""quantity"": 0,
      ""qtyOnShipments"": 0,
      ""openQty"": 0,
      ""unitCost"": 0,
      ""unitPrice"": 0,
      ""unitPriceInBaseCurrency"": 0,
      ""discountCode"": ""string"",
      ""discountPercent"": 0,
      ""discountAmount"": 0,
      ""manualDiscount"": true,
      ""discUnitPrice"": 0,
      ""extPrice"": 0,
      ""unbilledAmount"": 0,
      ""lineDescription"": ""string"",
      ""branchNumber"": {
        ""number"": ""string"",
        ""name"": ""string""
      },
      ""note"": ""string"",
      ""attachments"": [
        {
          ""name"": ""string"",
          ""id"": ""00000000-0000-0000-0000-000000000000"",
          ""revision"": 0
        }
      ]
    }
  ],
  ""shipments"": [
    {
      ""shipmentType"": ""string"",
      ""shipmentNo"": ""string"",
      ""shipmentDate"": ""2022-04-26T12:18:39.596Z"",
      ""shippedQty"": 0,
      ""shippedWeight"": 0,
      ""shippedVolume"": 0,
      ""invoiceType"": ""string"",
      ""invoiceNo"": ""string"",
      ""inventoryDocType"": ""string"",
      ""inventoryRefNo"": ""string""
    }
  ],
  ""orderType"": ""string"",
  ""orderNo"": ""string"",
  ""status"": ""Open"",
  ""hold"": true,
  ""date"": ""2022-04-26T12:18:39.596Z"",
  ""requestOn"": ""2022-04-26T12:18:39.596Z"",
  ""customerOrder"": ""string"",
  ""customerRefNo"": ""string"",
  ""customer"": {
    ""internalId"": 0,
    ""number"": ""string"",
    ""name"": ""string""
  },
  ""contactId"": 0,
  ""location"": {
    ""countryId"": ""string"",
    ""id"": ""string"",
    ""name"": ""string""
  },
  ""currency"": ""string"",
  ""description"": ""string"",
  ""orderTotal"": 0,
  ""orderTotalInBaseCurrency"": 0,
  ""vatTaxableTotal"": 0,
  ""vatTaxableTotalInBaseCurrency"": 0,
  ""vatExemptTotal"": 0,
  ""vatExemptTotalInBaseCurrency"": 0,
  ""taxTotal"": 0,
  ""taxTotalInBaseCurrency"": 0,
  ""exchangeRate"": 0,
  ""discountTotal"": 0,
  ""discountTotalInBaseCurrency"": 0,
  ""lastModifiedDateTime"": ""2022-04-26T12:18:39.596Z"",
  ""branchNumber"": {
    ""number"": ""string"",
    ""name"": ""string""
  },
  ""note"": ""string"",
  ""attachments"": [
    {
      ""name"": ""string"",
      ""id"": ""00000000-0000-0000-0000-000000000000"",
      ""revision"": 0
    }
  ],
  ""errorInfo"": ""string"",
  ""metadata"": {
    ""totalCount"": 0,
    ""maxPageSize"": 0
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
  ""owner"": {
    ""value"": ""00000000-0000-0000-0000-000000000000""
  },
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
    ""value"": ""2022-04-26T12:19:24.981Z""
  },
  ""shipSeparately"": {
    ""value"": true
  },
  ""shipComplete"": {
    ""value"": ""BackOrderAllowed""
  },
  ""cancelBy"": {
    ""value"": ""2022-04-26T12:19:24.981Z""
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
  ""paymentMethod"": {
    ""value"": ""string""
  },
  ""cashAccount"": {
    ""value"": ""string""
  },
  ""paymentRef"": {
    ""value"": ""string""
  },
  ""isRotRutDeductible"": {
    ""value"": true
  },
  ""emailed"": {
    ""value"": true
  },
  ""rotRutDetails"": {
    ""distributedAutomaticaly"": {
      ""value"": true
    },
    ""type"": {
      ""value"": ""Rut""
    },
    ""appartment"": {
      ""value"": ""string""
    },
    ""estate"": {
      ""value"": ""string""
    },
    ""organizationNbr"": {
      ""value"": ""string""
    },
    ""distribution"": [
      {
        ""operation"": ""Insert"",
        ""lineNbr"": {
          ""value"": 0
        },
        ""personalId"": {
          ""value"": ""string""
        },
        ""amount"": {
          ""value"": 0
        },
        ""extra"": {
          ""value"": true
        }
      }
    ]
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
        ""value"": ""2022-04-26T12:19:24.981Z""
      },
      ""shipOn"": {
        ""value"": ""2022-04-26T12:19:24.981Z""
      },
      ""shipComplete"": {
        ""value"": ""BackOrderAllowed""
      },
      ""undershipThreshold"": {
        ""value"": 0
      },
      ""overshipThreshold"": {
        ""value"": 0
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
        ""value"": ""2022-04-26T12:19:24.981Z""
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
      ""subaccount"": [
        {
          ""segmentId"": 0,
          ""segmentValue"": ""string""
        }
      ],
      ""externalLink"": {
        ""value"": ""string""
      },
      ""isRotRutDeductible"": {
        ""value"": true
      },
      ""branchNumber"": {
        ""value"": ""string""
      },
      ""operation"": ""Insert"",
      ""lineNbr"": {
        ""value"": 0
      },
      ""inventoryId"": {
        ""value"": ""string""
      },
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
        ""value"": 0
      },
      ""unitCost"": {
        ""value"": 0
      },
      ""unitPrice"": {
        ""value"": 0
      },
      ""discountPercent"": {
        ""value"": 0
      },
      ""discountAmount"": {
        ""value"": 0
      },
      ""discountCode"": {
        ""value"": ""string""
      },
      ""manualDiscount"": {
        ""value"": true
      },
      ""discUnitPrice"": {
        ""value"": 0
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
  ""orderNumber"": {
    ""value"": ""string""
  },
  ""hold"": {
    ""value"": true
  },
  ""date"": {
    ""value"": ""2022-04-26T12:19:24.981Z""
  },
  ""requestOn"": {
    ""value"": ""2022-04-26T12:19:24.981Z""
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
  ""contactId"": {
    ""value"": 0
  },
  ""gln"": {
    ""value"": ""string""
  },
  ""vatRegistrationId"": {
    ""value"": ""string""
  },
  ""currency"": {
    ""value"": ""string""
  },
  ""description"": {
    ""value"": ""string""
  },
  ""recalculateShipment"": {
    ""value"": true
  },
  ""branchNumber"": {
    ""value"": ""string""
  },
  ""note"": {
    ""value"": ""string""
  },
  ""overrideNumberSeries"": {
    ""value"": true
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