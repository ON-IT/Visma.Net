using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Models;
using Xunit.Abstractions;

namespace Visma.net.tests.Tests
{
    public class CustomerInvoiceTests : EntityBaseTest<CustomerInvoice>
    {
        private static string dto = @"{
  ""creditTerms"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""documentDueDate"": ""2018-05-22T07:27:28.176Z"",
  ""cashDiscountDate"": ""2018-05-22T07:27:28.176Z"",
  ""externalReference"": ""string"",
  ""isRotRutDeductible"": true,
  ""exchangeRate"": 0.0,
  ""dunningLetterDate"": ""2018-05-22T07:27:28.176Z"",
  ""dunningLetterLevel"": 0,
  ""contact"": {
    ""id"": 0,
    ""name"": ""string""
  },
  ""attachments"": [
    {
      ""name"": ""string"",
      ""id"": ""string"",
      ""revision"": 0
    }
  ],
  ""taxDetails"": [
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
  ""invoiceLines"": [
    {
      ""termStartDate"": ""2018-05-22T07:27:28.176Z"",
      ""termEndDate"": ""2018-05-22T07:27:28.176Z"",
      ""isRotRutDeductible"": true,
      ""itemType"": ""Service"",
      ""typeOfWork"": {
        ""rutRotType"": ""Rut"",
        ""description"": ""string"",
        ""xmlTag"": ""string""
      },
      ""deductableAmount"": 0.0,
      ""attachments"": [
        {
          ""name"": ""string"",
          ""id"": ""string"",
          ""revision"": 0
        }
      ],
      ""projectTask"": {
        ""id"": ""string"",
        ""description"": ""string""
      },
      ""lineNumber"": 0,
      ""inventoryNumber"": ""string"",
      ""description"": ""string"",
      ""quantity"": 0.0,
      ""unitPrice"": 0.0,
      ""unitPriceInCurrency"": 0.0,
      ""manualAmount"": 0.0,
      ""manualAmountInCurrency"": 0.0,
      ""amount"": 0.0,
      ""amountInCurrency"": 0.0,
      ""account"": {
        ""type"": ""Asset"",
        ""externalCode1"": ""string"",
        ""externalCode2"": ""string"",
        ""number"": ""string"",
        ""description"": ""string""
      },
      ""vatCode"": {
        ""id"": ""string"",
        ""description"": ""string""
      },
      ""uom"": ""string"",
      ""discountPercent"": 0.0,
      ""discountAmount"": 0.0,
      ""discountAmountInCurrency"": 0.0,
      ""manualDiscount"": true,
      ""subaccount"": {
        ""subaccountId"": 0,
        ""description"": ""string"",
        ""id"": 0,
        ""lastModifiedDateTime"": ""2018-05-22T07:27:28.176Z"",
        ""segments"": [
          {
            ""segmentId"": 0,
            ""segmentDescription"": ""string"",
            ""segmentValue"": ""string"",
            ""segmentValueDescription"": ""string""
          }
        ],
        ""extras"": {},
        ""errorInfo"": ""string""
      },
      ""salesperson"": ""string"",
      ""seller"": {
        ""id"": ""string"",
        ""description"": ""string""
      },
      ""deferralSchedule"": 0,
      ""deferralCode"": ""string"",
      ""discountCode"": ""string"",
      ""note"": ""string"",
      ""branchNumber"": {
        ""number"": ""string"",
        ""name"": ""string""
      }
    }
  ],
  ""hold"": true,
  ""detailTotal"": 0.0,
  ""detailTotalInCurrency"": 0.0,
  ""vatTaxableTotal"": 0.0,
  ""vatTaxableTotalInCurrency"": 0.0,
  ""vatExemptTotal"": 0.0,
  ""vatExemptTotalInCurrency"": 0.0,
  ""salesPersonID"": 0,
  ""salesPersonDescr"": ""string"",
  ""salesPerson"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""paymentReference"": ""string"",
  ""customer"": {
    ""number"": ""string"",
    ""name"": ""string""
  },
  ""documentType"": ""Invoice"",
  ""referenceNumber"": ""string"",
  ""postPeriod"": ""string"",
  ""financialPeriod"": ""string"",
  ""closedFinancialPeriod"": ""string"",
  ""documentDate"": ""2018-05-22T07:27:28.176Z"",
  ""status"": ""Hold"",
  ""currencyId"": ""string"",
  ""amount"": 0.0,
  ""amountInCurrency"": 0.0,
  ""balance"": 0.0,
  ""balanceInCurrency"": 0.0,
  ""cashDiscount"": 0.0,
  ""cashDiscountInCurrency"": 0.0,
  ""paymentMethod"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""customerRefNumber"": ""string"",
  ""invoiceText"": ""string"",
  ""lastModifiedDateTime"": ""2018-05-22T07:27:28.176Z"",
  ""createdDateTime"": ""2018-05-22T07:27:28.176Z"",
  ""note"": ""string"",
  ""vatTotal"": 0.0,
  ""vatTotalInCurrency"": 0.0,
  ""location"": {
    ""countryId"": ""string"",
    ""id"": ""string"",
    ""name"": ""string""
  },
  ""branchNumber"": {
    ""number"": ""string"",
    ""name"": ""string""
  },
  ""cashAccount"": ""string"",
  ""project"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""account"": {
    ""type"": ""Asset"",
    ""externalCode1"": ""string"",
    ""externalCode2"": ""string"",
    ""number"": ""string"",
    ""description"": ""string""
  },
  ""subaccount"": {
    ""subaccountId"": 0,
    ""description"": ""string"",
    ""id"": 0,
    ""lastModifiedDateTime"": ""2018-05-22T07:27:28.177Z"",
    ""segments"": [
      {
        ""segmentId"": 0,
        ""segmentDescription"": ""string"",
        ""segmentValue"": ""string"",
        ""segmentValueDescription"": ""string""
      }
    ],
    ""extras"": {},
    ""errorInfo"": ""string""
  },
  ""extras"": {},
  ""errorInfo"": ""string""
}";

        private static string update = @"{
  ""paymentMethodId"": {
    ""value"": ""string""
  },
  ""creditTermsId"": {
    ""value"": ""string""
  },
  ""currencyId"": {
    ""value"": ""string""
  },
  ""customerRefNumber"": {
    ""value"": ""string""
  },
  ""cashDiscountDate"": {
    ""value"": ""2018-05-22T07:27:28.176Z""
  },
  ""documentDueDate"": {
    ""value"": ""2018-05-22T07:27:28.176Z""
  },
  ""externalReference"": {
    ""value"": ""string""
  },
  ""exchangeRate"": {
    ""value"": 0.0
  },
  ""domesticServicesDeductibleDocument"": {
    ""value"": true
  },
/*
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
          ""value"": 0.0
        },
        ""extra"": {
          ""value"": true
        }
      }
    ]
  },
*/
  ""paymentReference"": {
    ""value"": ""string""
  },
  ""contact"": {
    ""value"": 0
  },
  ""project"": {
    ""value"": ""string""
  },
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
  ""invoiceLines"": [
    {
      ""discountCode"": {
        ""value"": ""string""
      },
      ""domesticServicesDeductible"": {
        ""value"": true
      },
      ""itemType"": {
        ""value"": ""Service""
      },
      ""typeOfWork"": {
        ""value"": ""string""
      },
      ""taskId"": {
        ""value"": ""string""
      },
      ""operation"": ""Insert"",
      ""inventoryNumber"": {
        ""value"": ""string""
      },
      ""lineNumber"": {
        ""value"": 0
      },
      ""description"": {
        ""value"": ""string""
      },
      ""quantity"": {
        ""value"": 0.0
      },
      ""unitPriceInCurrency"": {
        ""value"": 0.0
      },
      ""manualAmountInCurrency"": {
        ""value"": 0.0
      },
      ""accountNumber"": {
        ""value"": ""string""
      },
      ""vatCodeId"": {
        ""value"": ""string""
      },
      ""uom"": {
        ""value"": ""string""
      },
      ""discountPercent"": {
        ""value"": 0.0
      },
      ""discountAmountInCurrency"": {
        ""value"": 0.0
      },
      ""manualDiscount"": {
        ""value"": true
      },
      ""subaccount"": [
        {
          ""segmentId"": 0,
          ""segmentValue"": ""string""
        }
      ],
      ""salesperson"": {
        ""value"": ""string""
      },
      ""deferralSchedule"": {
        ""value"": 0
      },
      ""deferralCode"": {
        ""value"": ""string""
      },
      ""termStartDate"": {
        ""value"": ""2018-05-22T07:27:28.176Z""
      },
      ""termEndDate"": {
        ""value"": ""2018-05-22T07:27:28.176Z""
      },
      ""note"": {
        ""value"": ""string""
      },
      ""branchNumber"": {
        ""value"": ""string""
      }
    }
  ],
  ""customerNumber"": {
    ""value"": ""string""
  },
  ""documentDate"": {
    ""value"": ""2018-05-22T07:27:28.176Z""
  },
  ""hold"": {
    ""value"": true
  },
  ""postPeriod"": {
    ""value"": ""string""
  },
  ""financialPeriod"": {
    ""value"": ""string""
  },
  ""invoiceText"": {
    ""value"": ""string""
  },
  ""locationId"": {
    ""value"": ""string""
  },
  //""vatExemptTotalInCurrency"": 0.0,
  ""salesPersonID"": {
    ""value"": 0
  },
  ""salesperson"": {
    ""value"": ""string""
  },
  ""note"": {
    ""value"": ""string""
  },
  ""branchNumber"": {
    ""value"": ""string""
  },
  ""cashAccount"": {
    ""value"": ""string""
  }
}";
        public CustomerInvoiceTests(ITestOutputHelper output) : base(dto, update)
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
            jtoken["invoiceLines"][0]["typeOfWork"]["rutRotType"] = "string";
           return jtoken.ToString(Formatting.Indented);
        }
    }
}
