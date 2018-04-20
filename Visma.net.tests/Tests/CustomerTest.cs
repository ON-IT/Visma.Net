using ONIT.VismaNetApi.Models;
using Xunit.Abstractions;

namespace Visma.net.tests
{
    public class CustomerTest : EntityBaseTest<Customer>
    {
        private static readonly  string dto = @"{
  ""internalId"": 0,
  ""name"": ""string"",
  ""number"": ""string"",
  ""status"": ""Active"",
  ""mainAddress"": {
    ""addressId"": 0,
    ""addressLine1"": ""string"",
    ""addressLine2"": ""string"",
    ""addressLine3"": ""string"",
    ""postalCode"": ""string"",
    ""city"": ""string"",
    ""country"": {
      ""id"": ""string"",
      ""name"": ""string""
    },
    ""county"": {
      ""id"": ""string"",
      ""name"": ""string""
    }
  },
  ""mainContact"": {
    ""contactId"": 0,
    ""name"": ""string"",
    ""attention"": ""string"",
    ""email"": ""string"",
    ""web"": ""string"",
    ""phone1"": ""string"",
    ""phone2"": ""string"",
    ""fax"": ""string""
  },
  ""accountReference"": ""string"",
  ""parentRecord"": {
    ""number"": ""string"",
    ""name"": ""string""
  },
  ""customerClass"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""creditTerms"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""currencyId"": ""string"",
  ""creditVerification"": ""Disabled"",
  ""creditLimit"": 0.0,
  ""creditDaysPastDue"": 0,
  ""invoiceAddress"": {
    ""addressId"": 0,
    ""addressLine1"": ""string"",
    ""addressLine2"": ""string"",
    ""addressLine3"": ""string"",
    ""postalCode"": ""string"",
    ""city"": ""string"",
    ""country"": {
      ""id"": ""string"",
      ""name"": ""string""
    },
    ""county"": {
      ""id"": ""string"",
      ""name"": ""string""
    }
  },
  ""invoiceContact"": {
    ""contactId"": 0,
    ""name"": ""string"",
    ""attention"": ""string"",
    ""email"": ""string"",
    ""web"": ""string"",
    ""phone1"": ""string"",
    ""phone2"": ""string"",
    ""fax"": ""string""
  },
  ""printInvoices"": true,
  ""acceptAutoInvoices"": true,
  ""sendInvoicesByEmail"": true,
  ""printStatements"": true,
  ""sendStatementsByEmail"": true,
  ""printMultiCurrencyStatements"": true,
  ""statementType"": ""OpenItem"",
  ""deliveryAddress"": {
    ""addressId"": 0,
    ""addressLine1"": ""string"",
    ""addressLine2"": ""string"",
    ""addressLine3"": ""string"",
    ""postalCode"": ""string"",
    ""city"": ""string"",
    ""country"": {
      ""id"": ""string"",
      ""name"": ""string""
    },
    ""county"": {
      ""id"": ""string"",
      ""name"": ""string""
    }
  },
  ""deliveryContact"": {
    ""contactId"": 0,
    ""name"": ""string"",
    ""attention"": ""string"",
    ""email"": ""string"",
    ""web"": ""string"",
    ""phone1"": ""string"",
    ""phone2"": ""string"",
    ""fax"": ""string""
  },
  ""vatRegistrationId"": ""string"",
  ""corporateId"": ""string"",
  ""vatZone"": {
    ""defaultVatCategory"": ""string"",
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""location"": {
    ""countryId"": ""string"",
    ""id"": ""string"",
    ""name"": ""string""
  },
  ""attributes"": [
    {
      ""id"": ""string"",
      ""value"": ""string"",
      ""description"": ""string""
    }
  ],
  ""lastModifiedDateTime"": ""2018-04-13T10:44:45.538Z"",
  ""createdDateTime"": ""2018-04-13T10:44:45.538Z"",
  ""directDebitLines"": [
    {
      ""id"": ""string"",
      ""operation"": ""insert"",
      ""mandateId"": ""string"",
      ""mandateDescription"": ""string"",
      ""dateOfSignature"": ""2018-04-13T10:44:45.000Z"",
      ""isDefault"": true,
      ""oneTime"": true,
      ""bic"": ""string"",
      ""iban"": ""string"",
      ""lastCollectionDate"": ""2018-04-13T10:44:45.000Z"",
      ""maxAmount"": 0.0,
      ""expirationDate"": ""2018-04-13T10:44:45.000Z""
    }
  ],
  ""priceClass"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""extras"": {},
  ""errorInfo"": ""string"",
  ""overrideWithClassValues"": true,
  ""note"": ""string""
}";

        private static readonly string update = @"{
  ""name"": {
    ""value"": ""string""
  },
  ""status"": {
    ""value"": ""Active""
  },
  ""accountReference"": {
    ""value"": ""string""
  },
  ""parentRecordNumber"": {
    ""value"": ""string""
  },
  ""currencyId"": {
    ""value"": ""string""
  },
  ""creditLimit"": {
    ""value"": 0.0
  },
  ""creditDaysPastDue"": {
    ""value"": 0
  },
  ""overrideWithClassValues"": true,
  ""customerClassId"": {
    ""value"": ""string""
  },
  ""creditTermsId"": {
    ""value"": ""string""
  },
  ""printInvoices"": {
    ""value"": true
  },
  ""acceptAutoInvoices"": {
    ""value"": true
  },
  ""sendInvoicesByEmail"": {
    ""value"": true
  },
  ""printStatements"": {
    ""value"": true
  },
  ""sendStatementsByEmail"": {
    ""value"": true
  },
  ""printMultiCurrencyStatements"": {
    ""value"": true
  },
  ""vatRegistrationId"": {
    ""value"": ""string""
  },
  ""corporateId"": {
    ""value"": ""string""
  },
  ""vatZoneId"": {
    ""value"": ""string""
  },
  ""note"": {
    ""value"": ""string""
  },
  ""mainAddress"": {
    ""value"": {
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
  ""mainContact"": {
    ""value"": {
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
  ""creditVerification"": {
    ""value"": ""Disabled""
  },
  ""invoiceAddress"": {
    ""value"": {
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
  ""invoiceContact"": {
    ""value"": {
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
  ""statementType"": {
    ""value"": ""OpenItem""
  },
  ""deliveryAddress"": {
    ""value"": {
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
  ""deliveryContact"": {
    ""value"": {
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
  ""priceClassId"": {
    ""value"": ""string""
  },
  ""directDebitLines"": [
    {
      ""operation"": ""Insert"",
      ""id"": ""string"",
      ""mandateId"": {
        ""value"": ""string""
      },
      ""mandateDescription"": {
        ""value"": ""string""
      },
      ""dateOfSignature"": {
        ""value"": ""2018-04-13T10:44:45.000Z""
      },
      ""isDefault"": {
        ""value"": true
      },
      ""oneTime"": {
        ""value"": true
      },
      ""bic"": {
        ""value"": ""string""
      },
      ""iban"": {
        ""value"": ""string""
      },
      ""lastCollectionDate"": {
        ""value"": ""2018-04-13T10:44:45.000Z""
      },
      ""maxAmount"": {
        ""value"": 0.0
      },
      ""expirationDate"": {
        ""value"": ""2018-04-13T10:44:45.000Z""
      }
    }
  ],
  ""attributeLines"": [
    {
      ""attributeId"": {
        ""value"": ""string""
      },
      ""attributeValue"": {
        ""value"": ""string""
      }
    }
  ]
}";
        public CustomerTest(ITestOutputHelper output) : base (dto, update)
        {
            this.output = output;
        }
    }
}