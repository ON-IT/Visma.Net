using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Models;
using Xunit.Abstractions;

namespace Visma.net.tests.Tests
{
    public class SupplierInvoiceTests : EntityBaseTest<SupplierInvoice>
    {
        private static string dto = @"{
 /*
    ""taxDetailLines"": [
    {
      ""taxId"": ""string"",
      ""recordId"": 0,
      ""vatId"": {
        ""number"": ""string"",
        ""description"": ""string""
      },
      ""vatRate"": 0.0,
      ""taxableAmount"": 0.0,
      ""vatAmount"": 0.0
    }
  ],
*/
  ""attachments"": [
    {
      ""name"": ""string"",
      ""id"": ""string"",
      ""revision"": 0
    }
  ],
  ""approvalDetails"": {
    ""attachmentID"": ""string"",
    ""comment"": ""string""
  },
  ""invoiceLines"": [
    {
      ""lineNumber"": 0,
      ""inventoryNumber"": ""string"",
      ""stockItem"": true,
      ""transactionDescription"": ""string"",
      ""quantity"": 0.0,
      ""uom"": ""string"",
      ""unitCost"": 0.0,
      ""unitCostInCurrency"": 0.0,
      ""cost"": 0.0,
      ""costInCurrency"": 0.0,
      ""discountPercent"": 0.0,
      ""discountAmount"": 0.0,
      ""discountAmountInCurrency"": 0.0,
      ""discountUnitCost"": 0.0,
      ""discountUnitCostInCurrency"": 0.0,
      ""manualDiscount"": true,
      ""account"": {
        ""type"": ""Asset"",
        ""externalCode1"": ""string"",
        ""externalCode2"": ""string"",
        ""number"": ""string"",
        ""description"": ""string""
      },
      ""subaccount"": {
        ""subaccountNumber"": ""string"",
        ""subaccountId"": 0,
        ""description"": ""string"",
        ""lastModifiedDateTime"": ""2019-06-25T10:26:04.176Z"",
        ""segments"": [
          {
            ""segmentId"": 0,
            ""segmentDescription"": ""string"",
            ""segmentValue"": ""string"",
            ""segmentValueDescription"": ""string""
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
      },
      ""deferralSchedule"": 0,
      ""deferralCode"": ""string"",
      ""vatCode"": {
        ""id"": ""string"",
        ""description"": ""string""
      },
      ""poNumber"": ""string"",
      ""poLineNr"": 0,
      ""poReceiptNbr"": ""string"",
      ""poReceiptLineNbr"": 0,
      ""branchNumber"": {
        ""number"": ""string"",
        ""name"": ""string""
      },
      ""note"": ""string"",
      ""splitHierarchy"": ""string"",
      ""project"": {
        ""id"": ""string"",
        ""description"": ""string""
      },
      ""projectTask"": {
        ""id"": ""string"",
        ""description"": ""string""
      },
      ""attachments"": [
        {
          ""name"": ""string"",
          ""id"": ""string"",
          ""revision"": 0
        }
      ]
    }
  ],
  ""hold"": true,
  ""exchangeRate"": 0.0,
  ""paymentRefNo"": ""string"",
  ""creditTerms"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""cashDiscountDate"": ""2019-06-25T10:26:04.176Z"",
  ""detailTotal"": 0.0,
  ""detailTotalInCurrency"": 0.0,
  ""discountTotal"": 0.0,
  ""discountTotalInCurrency"": 0.0,
  ""vatTaxableTotal"": 0.0,
  ""vatTaxableTotalInCurrency"": 0.0,
  ""vatExemptTotal"": 0.0,
  ""vatExemptTotalInCurrency"": 0.0,
  ""withholdingTax"": 0.0,
  ""withholdingTaxInCurrency"": 0.0,
  ""buyerReference"": ""string"",
  ""roundingDiff"": 0.0,
  ""roundingDiffInCurrency"": 0.0,
  ""taxCalculationMode"": ""TaxSetting"",
  ""supplierTaxZone"": {
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
  ""supplier"": {
    ""number"": ""string"",
    ""name"": ""string""
  },
  ""documentType"": ""Check"",
  ""referenceNumber"": ""string"",
  ""postPeriod"": ""string"",
  ""financialPeriod"": ""string"",
  ""date"": ""2019-06-25T10:26:04.176Z"",
  ""dueDate"": ""2019-06-25T10:26:04.176Z"",
  ""approvalStatus"": ""New"",
  ""status"": ""Hold"",
  ""currencyId"": ""string"",
  ""balance"": 0.0,
  ""balanceInCurrency"": 0.0,
  ""cashDiscount"": 0.0,
  ""cashDiscountInCurrency"": 0.0,
  ""paymentMethod"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""supplierReference"": ""string"",
  ""description"": ""string"",
  ""createdDateTime"": ""2019-06-25T10:26:04.176Z"",
  ""lastModifiedDateTime"": ""2019-06-25T10:26:04.176Z"",
  ""note"": ""string"",
  ""closedFinancialPeriod"": ""string"",
  ""location"": {
    ""countryId"": ""string"",
    ""id"": ""string"",
    ""name"": ""string""
  },
  ""vatTotal"": 0.0,
  ""vatTotalInCurrency"": 0.0,
  ""branchNumber"": {
    ""number"": ""string"",
    ""name"": ""string""
  },
  ""payDate"": ""2019-06-25T10:26:04.176Z"",
  ""paymentMessage"": ""string"",
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

        private static string update = @"{
  ""documentType"": {
    ""value"": ""Invoice""
  },
  ""referenceNumber"": {
    ""value"": ""string""
  },
  ""hold"": {
    ""value"": true
  },
  ""date"": {
    ""value"": ""2019-06-25T10:26:04.176Z""
  },
  ""postPeriod"": {
    ""value"": ""string""
  },
  ""financialPeriod"": {
    ""value"": ""string""
  },
  ""supplierReference"": {
    ""value"": ""string""
  },
  ""description"": {
    ""value"": ""string""
  },
  ""supplierNumber"": {
    ""value"": ""string""
  },
  ""locationId"": {
    ""value"": ""string""
  },
  ""currencyId"": {
    ""value"": ""string""
  },
  ""paymentRefNo"": {
    ""value"": ""string""
  },
  ""creditTermsId"": {
    ""value"": ""string""
  },
  ""dueDate"": {
    ""value"": ""2019-06-25T10:26:04.176Z""
  },
  ""cashDiscountDate"": {
    ""value"": ""2019-06-25T10:26:04.176Z""
  },
  ""note"": {
    ""value"": ""string""
  },
  ""exchangeRate"": {
    ""value"": 0.0
  },
  ""branchNumber"": {
    ""value"": ""string""
  },
  ""roundingDiffInCurrency"": {
    ""value"": 0.0
  },
  ""taxCalculationMode"": {
    ""value"": ""TaxSetting""
  },
  ""supplierTaxZone"": {
    ""value"": ""string""
  },
  ""cashAccount"": {
    ""value"": ""string""
  },
  ""paymentMethod"": {
    ""value"": ""string""
  },
  ""payDate"": {
    ""value"": ""2019-06-25T10:26:04.176Z""
  },
  ""paymentMessage"": {
    ""value"": ""string""
  },
/*
  ""taxDetailLines"": [
    {
      ""taxId"": {
        ""value"": ""string""
      },
      ""taxableAmount"": {
        ""value"": 0.0
      },
      ""vatAmount"": {
        ""value"": 0.0
      }
    }
  ],
*/
  ""invoiceLines"": [
    {
      ""operation"": ""Insert"",
      ""lineNumber"": {
        ""value"": 0
      },
      ""inventoryNumber"": {
        ""value"": ""string""
      },
      ""transactionDescription"": {
        ""value"": ""string""
      },
      ""quantity"": {
        ""value"": 0.0
      },
      ""uom"": {
        ""value"": ""string""
      },
      ""unitCostInCurrency"": {
        ""value"": 0.0
      },
      ""costInCurrency"": {
        ""value"": 0.0
      },
      ""discountPercent"": {
        ""value"": 0.0
      },
      ""discountAmountInCurrency"": {
        ""value"": 0.0
      },
      ""discountUnitCostInCurrency"": {
        ""value"": 0.0
      },
      ""manualDiscount"": {
        ""value"": true
      },
      ""accountNumber"": {
        ""value"": ""string""
      },
      ""subaccount"": [
        {
          ""segmentId"": 0,
          ""segmentValue"": ""string""
        }
      ],
      ""deferralSchedule"": {
        ""value"": 0
      },
      ""deferralCode"": {
        ""value"": ""string""
      },
      ""vatCodeId"": {
        ""value"": ""string""
      },
      ""branch"": {
        ""value"": ""string""
      },
      ""branchNumber"": {
        ""value"": ""string""
      },
      ""note"": {
        ""value"": ""string""
      },
      ""projectId"": {
        ""value"": ""string""
      },
      ""projectTaskId"": {
        ""value"": ""string""
      },
      ""splitLine"": {
        ""value"": true
      },
      ""undoSplitLine"": {
        ""value"": true
      },
      ""splitHierarchy"": {
        ""value"": ""string""
      },
      ""linkLine"": {
        ""purchaseType"": ""PurchaseOrder"",
        ""purchaseNumber"": {
          ""value"": ""string""
        },
        ""purchaseLineNbr"": {
          ""value"": 0
        }
      }
    }
  ],
  ""approvalDetails"": {
    ""attachmentID"": {
      ""value"": ""string""
    },
    ""comment"": {
      ""value"": ""string""
    }
  },
  ""addPOReceiptLines"": [
    {
      ""poReceiptNumber"": {
        ""value"": ""string""
      },
      ""poReceiptLineNumber"": {
        ""value"": 0
      }
    }
  ],
  ""addPurchaseOrders"": [
    {
      ""poOrderNumber"": {
        ""value"": ""string""
      }
    }
  ]
}";
        public SupplierInvoiceTests(ITestOutputHelper output) : base(dto, update)
        {
            this.output = output;
        }

        public override string PrepareDtoForSerializer(string src)
        {
            var jtoken = JToken.Parse(src);
            jtoken["invoiceLines"][0]["operation"] = "Insert";
            return base.PrepareDtoForSerializer(jtoken.ToString());
        }

        public override string PrepareDtoForUpdate(string src)
        {

            var jtoken = JToken.Parse(src);
            // rutRotType is wrong in dto vs. update
            //  jtoken["invoiceLines"][0]["typeOfWork"]["rutRotType"] = "string";
            return jtoken.ToString(Formatting.Indented);
        }
    }
}
