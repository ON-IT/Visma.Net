using ONIT.VismaNetApi.Models;
using Xunit.Abstractions;

namespace Visma.net.tests
{
    public class InventoryTests : EntityBaseTest<Inventory>
    {
        private const string dto = @"{
  ""inventoryId"": 0,
  ""inventoryNumber"": ""string"",
  ""status"": ""Active"",
  ""type"": ""NonStockItem"",
  ""description"": ""string"",
  ""itemClass"": {
    ""type"": ""NonStockItem"",
    ""attributes"": [
      {
        ""attributeId"": ""string"",
        ""description"": ""string"",
        ""sortOrder"": 0,
        ""required"": true,
        ""attributeType"": ""Text"",
        ""defaultValue"": ""string"",
        ""details"": [
          {
            ""id"": ""string"",
            ""description"": ""string""
          }
        ]
      }
    ],
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""postingClass"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""vatCode"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""defaultPrice"": 0.0,
  ""pendingCost"": 0.0,
  ""pendingCostDate"": ""2018-05-22T18:50:26.591Z"",
  ""currentCost"": 0.0,
  ""effectiveDate"": ""2018-05-22T18:50:26.591Z"",
  ""lastCost"": 0.0,
  ""lastModifiedDateTime"": ""2018-05-22T18:50:26.591Z"",
  ""baseUnit"": ""string"",
  ""salesUnit"": ""string"",
  ""purchaseUnit"": ""string"",
  ""costPriceStatistics"": {
    ""lastCost"": 0.0,
    ""averageCost"": 0.0,
    ""minCost"": 0.0,
    ""maxCost"": 0.0
  },
  ""crossReferences"": [
    {
      ""alternateType"": ""CPN"",
      ""bAccount"": {
        ""internalId"": 0,
        ""number"": ""string"",
        ""name"": ""string""
      },
      ""alternateID"": ""string"",
      ""description"": ""string""
    }
  ],
  ""attachments"": [
    {
      ""name"": ""string"",
      ""id"": ""string"",
      ""revision"": 0
    }
  ],
  ""attributes"": [
    {
      ""id"": ""string"",
      ""value"": ""string"",
      ""description"": ""string""
    }
  ],
  ""warehouseDetails"": [
    {
      ""isDefault"": true,
      ""warehouse"": ""string"",
      ""quantityOnHand"": 0.0,
      ""available"": 0.0,
      ""availableForShipment"": 0.0,
      ""lastModifiedDateTime"": ""2018-05-22T18:50:26.592Z""
    }
  ],
  ""extras"": {},
  ""errorInfo"": ""string""
}";

        private const string update = @"{
  /* ""inventoryNumber"": {
    ""value"": ""string""
  },*/
  ""status"": {
    ""value"": ""Active""
  },
  ""type"": {
    ""value"": ""NonStockItem""
  },
  ""description"": {
    ""value"": ""string""
  },
  ""itemClass"": {
    ""value"": ""string""
  },
  ""postingClass"": {
    ""value"": ""string""
  },
  ""vatCode"": {
    ""value"": ""string""
  },
  ""defaultPrice"": {
    ""value"": 0.0
  },
  ""baseUnit"": {
    ""value"": ""string""
  },
  ""salesUnit"": {
    ""value"": ""string""
  },
  ""purchaseUnit"": {
    ""value"": ""string""
  },
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

        public InventoryTests(ITestOutputHelper output) : base(dto, update)
        {
            this.output = output;
        }
    }
}