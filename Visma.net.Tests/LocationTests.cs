using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Models;
using Xunit.Abstractions;

namespace Visma.net.Tests
{
  public class LocationTests : EntityBaseTest<Location>
  {
   private static readonly string dto =
        @"{  
  //          ""baccount"": {
  //  ""internalId"": 0,
  //  ""number"": ""string"",
  //  ""name"": ""string""
  //},
 ""baccountId"": ""string"",
  ""locationId"": ""string"",
  ""locationName"": ""string"",
  ""active"": true,
  ""address"": {
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
  ""contact"": {
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
  ""vatZone"": {
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
  ""ediCode"": ""string"",
  ""gln"": ""string"",
  ""corporateId"": ""string"",
  ""lastModifieDateTime"": ""2019-06-25T09:14:36.754Z"",
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

public static string update = @"{
  ""baccountId"": {
    ""value"": ""string""
  },
  ""locationId"": {
    ""value"": ""string""
  },
  ""locationName"": {
    ""value"": ""string""
  },
  ""active"": {
    ""value"": true
  },
  ""addressIsSameAsMain"": {
    ""value"": true
  },
  ""address"": {
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
  ""contactIsSameAsMain"": {
    ""value"": true
  },
  ""contact"": {
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
  ""vatRegistrationId"": {
    ""value"": ""string""
  },
  ""vatZone"": {
    ""value"": ""string""
  },
  ""ediCode"": {
    ""value"": ""string""
  },
  ""gln"": {
    ""value"": ""string""
  },
  ""corporateId"": {
    ""value"": ""string""
  }
}";
    public LocationTests(ITestOutputHelper output) : base(dto, update)
    {
      this.output = output;
    }

    public override string PrepareDtoForUpdate(string src)
    {
      var jtoken = JToken.Parse(src);
      jtoken["contactIsSameAsMain"] = true;
      jtoken["addressIsSameAsMain"] = true;
      return base.PrepareDtoForSerializer(jtoken.ToString());
    }

    public override string PrepareDtoForSerializer(string src)
    {
      var jtoken = JToken.Parse(src);
      jtoken["contactIsSameAsMain"] = true;
      jtoken["addressIsSameAsMain"] = true;
      return base.PrepareDtoForSerializer(jtoken.ToString());
    }
  }
}
