using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Models;
using Xunit.Abstractions;

namespace Visma.net.Tests
{
    public class CustomerPaymentTests : EntityBaseTest<CustomerPayment>
    {
        private static readonly string dto = @"
{
  ""type"": ""Payment"",
  ""refNbr"": ""string"",
  ""status"": ""Hold"",
  ""hold"": true,
  ""applicationDate"": ""2019-06-24T12:06:30.952Z"",
  ""applicationPeriod"": ""string"",
  ""paymentRef"": ""string"",
  ""customer"": {
    ""number"": ""string"",
    ""name"": ""string""
  },
  ""location"": {
    ""countryId"": ""string"",
    ""id"": ""string"",
    ""name"": ""string""
  },
  ""paymentMethod"": {
    ""id"": ""string"",
    ""description"": ""string""
  },
  ""cashAccount"": ""string"",
  ""currency"": ""string"",
  ""paymentAmount"": 0.0,
  ""invoiceText"": ""string"",
  ""appliedToDocuments"": 0.0,
  ""appliedToOrders"": 0.0,
  ""availableBalance"": 0.0,
  ""writeOffAmount"": 0.0,
  ""financeCharges"": 0.0,
  ""deductedCharges"": 0.0,
  ""branch"": ""string"",
  ""lastModifiedDateTime"": ""2019-06-24T12:06:30.952Z"",
  ""paymentLines"": [
    {
      ""documentType"": ""Invoice"",
      ""refNbr"": ""string"",
      ""amountPaid"": 0.0,
      ""cashDiscountTaken"": 0.0,
      ""balanceWriteOff"": 0.0,
      ""writeOffReasonCode"": {
        ""id"": ""string"",
        ""description"": ""string""
      },
      ""date"": ""2019-06-24T12:06:30.952Z"",
      ""dueDate"": ""2019-06-24T12:06:30.952Z"",
      ""cashDiscountDate"": ""2019-06-24T12:06:30.952Z"",
      ""balance"": 0.0,
      ""cashDiscountBalance"": 0.0,
      ""description"": ""string"",
      ""currency"": ""string"",
      ""postPeriod"": ""string"",
      ""customerOrder"": ""string"",
      ""crossRate"": 0.0
    }
  ],
  ""ordersToApply"": [
    {
      ""orderType"": ""string"",
      ""orderNo"": ""string"",
      ""status"": ""Open"",
      ""appliedToOrder"": 0.0,
      ""transferredToInvoice"": 0.0,
      ""date"": ""2019-06-24T12:06:30.952Z"",
      ""dueDate"": ""2019-06-24T12:06:30.952Z"",
      ""cashDiscountDate"": ""2019-06-24T12:06:30.952Z"",
      ""balance"": 0.0,
      ""description"": ""string"",
      ""orderTotal"": 0.0,
      ""currency"": ""string"",
      ""invoiceNbr"": ""string"",
      ""invoiceDate"": ""2019-06-24T12:06:30.952Z""
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
}
";

        private static readonly string update =
            @"{
  ""referenceNumber"": {
    ""value"": ""string""
  },
  ""type"": {
    ""value"": ""Payment""
  },
  ""hold"": {
    ""value"": true
  },
  ""applicationDate"": {
    ""value"": ""2019-06-24T12:06:30.952Z""
  },
  ""applicationPeriod"": {
    ""value"": ""string""
  },
  ""paymentRef"": {
    ""value"": ""string""
  },
  ""customer"": {
    ""value"": ""string""
  },
  ""location"": {
    ""value"": ""string""
  },
  ""paymentMethod"": {
    ""value"": ""string""
  },
  ""cashAccount"": {
    ""value"": ""string""
  },
  ""currency"": {
    ""value"": ""string""
  },
  ""paymentAmount"": {
    ""value"": 0.0
  },
  ""invoiceText"": {
    ""value"": ""string""
  },
  ""branch"": {
    ""value"": ""string""
  },
  ""ordersToApply"": [
    {
      ""operation"": ""Insert"",
      ""orderType"": {
        ""value"": ""string""
      },
      ""orderNumber"": {
        ""value"": ""string""
      },
      ""appliedToOrder"": {
        ""value"": 0.0
      }
    }
  ],
  ""paymentLines"": [
    {
      ""operation"": ""Insert"",
      ""documentType"": {
        ""value"": ""Invoice""
      },
      ""refNbr"": {
        ""value"": ""string""
      },
      ""amountPaid"": {
        ""value"": 0.0
      },
      ""cashDiscountTaken"": {
        ""value"": 0.0
      },
      ""balanceWriteOff"": {
        ""value"": 0.0
      },
      ""writeOffReasonCode"": {
        ""value"": ""string""
      },
      ""crossRate"": {
        ""value"": 0.0
      }
    }
  ]
}";
        public CustomerPaymentTests(ITestOutputHelper output) : base(dto, update)
        {
            this.output = output;
        }

        public override string PrepareDtoForSerializer(string src)
        {
            var jtoken = JToken.Parse(src);
            jtoken["paymentLines"][0]["operation"] = "Insert";
            jtoken["ordersToApply"][0]["operation"] = "Insert";
            return base.PrepareDtoForSerializer(jtoken.ToString());
        }
    }
}
