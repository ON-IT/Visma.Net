using ONIT.VismaNetApi.Models;
using Xunit.Abstractions;

namespace Visma.net.Tests
{
    public class SupplierTests : EntityBaseTest<Supplier>
    {
        public static string dto = @" {
    ""internalId"": 0,
    ""number"": ""string"",
    ""name"": ""string"",
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
    ""supplierClass"": {
      ""id"": ""string"",
      ""description"": ""string""
    },
    ""creditTerms"": {
      ""id"": ""string"",
      ""description"": ""string""
    },
    ""documentLanguage"": ""string"",
    ""currencyId"": ""string"",
    ""remitAddress"": {
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
    ""remitContact"": {
      ""contactId"": 0,
      ""name"": ""string"",
      ""attention"": ""string"",
      ""email"": ""string"",
      ""web"": ""string"",
      ""phone1"": ""string"",
      ""phone2"": ""string"",
      ""fax"": ""string""
    },
    ""paymentMethod"": {
      ""id"": ""string"",
      ""description"": ""string""
    },
    ""cashAccount"": ""string"",
    ""chargeBearer"": ""Payer"",
    ""accountUsedForPayment"": ""IBAN"",
    ""paymentBy"": ""DueDate"",
    ""paymentLeadTime"": 0,
    ""paymentRefDisplayMask"": ""string"",
    ""paySeparately"": true,
    ""supplierAddress"": {
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
    ""supplierContact"": {
      ""contactId"": 0,
      ""name"": ""string"",
      ""attention"": ""string"",
      ""email"": ""string"",
      ""web"": ""string"",
      ""phone1"": ""string"",
      ""phone2"": ""string"",
      ""fax"": ""string""
    },
    ""location"": {
      ""countryId"": ""string"",
      ""id"": ""string"",
      ""name"": ""string""
    },
    ""vatRegistrationId"": ""string"",
    ""corporateId"": ""string"",
    ""vatZone"": {
      ""defaultVatCategory"": ""string"",
      ""id"": ""string"",
      ""description"": ""string""
    },
    ""glAccounts"": {
      ""supplierAccount"": {
        ""type"": ""string"",
        ""number"": ""string"",
        ""description"": ""string""
      },
      ""expenseAccount"": {
        ""type"": ""string"",
        ""number"": ""string"",
        ""description"": ""string""
      },
      ""expenseAccountNonTax"": {
        ""type"": ""string"",
        ""number"": ""string"",
        ""description"": ""string""
      },
      ""expenseEUAccount"": {
        ""type"": ""string"",
        ""number"": ""string"",
        ""description"": ""string""
      },
      ""expenseAccountImport"": {
        ""type"": ""string"",
        ""number"": ""string"",
        ""description"": ""string""
      },
      ""expenseSubaccount"": {
        ""id"": ""string"",
        ""description"": ""string""
      }
    },
    ""attributes"": [
      {
        ""id"": ""string"",
        ""value"": ""string"",
        ""description"": ""string""
      }
    ],
    ""lastModifiedDateTime"": ""2018-05-24T07:13:50.183Z"",
    ""supplierPaymentMethodDetails"": [
      {
        ""paymentMethodDetailDescription"": ""string"",
        ""paymentMethodDetailValue"": ""string""
      }
    ],
    ""extras"": {},
    ""errorInfo"": ""string"",
    ""overridewithclassvalues"": true
  }";

        public static string update = @"{
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
  ""supplierClassId"": {
    ""value"": ""string""
  },
  ""overrideWithClassValues"": true,
  ""creditTermsId"": {
    ""value"": ""string""
  },
  ""documentLanguage"": {
    ""value"": ""string""
  },
  ""currencyId"": {
    ""value"": ""string""
  },
  ""paymentMethodId"": {
    ""value"": ""string""
  },
  ""cashAccount"": {
    ""value"": ""string""
  },
  ""paymentLeadTime"": {
    ""value"": 0
  },
  ""paymentRefDisplayMask"": {
    ""value"": ""string""
  },
  ""paySeparately"": {
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
  ""chargeBearer"": {
    ""value"": ""Payer""
  },
  ""accountUsedForPayment"": {
    ""value"": ""IBAN""
  },
  ""paymentBy"": {
    ""value"": ""DueDate""
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
  ""remitAddress"": {
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
  ""remitContact"": {
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
  ""supplierAddress"": {
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
  ""supplierContact"": {
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
  ""supplierPaymentMethodDetails"": [
    {
      ""paymentMethodDetailDescription"": ""string"",
      ""paymentMethodDetailValue"": {
        ""value"": ""string""
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
        public SupplierTests(ITestOutputHelper output) : base(dto, update)
        {
            this.output = output;
        }
    }
}
