using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;
using Xunit.Abstractions;

namespace Visma.net.tests.Tests
{
    public class LocationTests : EntityBaseTest<Location>
    {
        private static string dto =
            @"{
    ""baccount"": {
      ""internalId"": 0,
      ""number"": ""string"",
      ""name"": ""string""
    },
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
        ""name"": ""string""
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
      ""defaultVatCategory"": ""string"",
      ""id"": ""string"",
      ""description"": ""string""
    },
    ""ediCode"": ""string"",
    ""gln"": ""string"",
    ""lastModifieDateTime"": ""2018-07-02T07:28:21.273Z"",
    ""extras"": {
      ""additionalProp1"": {},
      ""additionalProp2"": {},
      ""additionalProp3"": {}
    },
    ""errorInfo"": ""string"",
    ""addressissameasmain"": true,
    ""contactissameasmain"": true
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
  }
}";
        public LocationTests(ITestOutputHelper output) : base(dto, update)
        {
            this.output = output;
        }
    }
}
