using ONIT.VismaNetApi.Models;
using Xunit.Abstractions;

namespace Visma.net.Tests
{
    public class PaymentTests : EntityBaseTest<Payment>
    {
        public static string dto = @" {
    ""type"": ""Payment"",
    ""refNbr"": ""string"",
    ""status"": ""Hold"",
    ""hold"": true,
    ""applicationDate"": ""2018-05-24T07:13:49.881Z"",
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
    ""lastModifiedDateTime"": ""2018-05-24T07:13:49.881Z"",
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
        ""date"": ""2018-05-24T07:13:49.881Z"",
        ""dueDate"": ""2018-05-24T07:13:49.881Z"",
        ""cashDiscountDate"": ""2018-05-24T07:13:49.881Z"",
        ""balance"": 0.0,
        ""cashDiscountBalance"": 0.0,
        ""description"": ""string"",
        ""currency"": ""string"",
        ""postPeriod"": ""string"",
        ""customerOrder"": ""string"",
        ""crossRate"": 0.0,
        ""operation"": ""Insert""
      }
    ],
    ""ordersToApply"": [
      {
        ""orderType"": ""string"",
        ""orderNo"": ""string"",
        ""status"": ""Open"",
        ""appliedToOrder"": 0.0,
        ""transferredToInvoice"": 0.0,
        ""date"": ""2018-05-24T07:13:49.881Z"",
        ""dueDate"": ""2018-05-24T07:13:49.881Z"",
        ""cashDiscountDate"": ""2018-05-24T07:13:49.881Z"",
        ""balance"": 0.0,
        ""description"": ""string"",
        ""orderTotal"": 0.0,
        ""currency"": ""string"",
        ""invoiceNbr"": ""string"",
        ""invoiceDate"": ""2018-05-24T07:13:49.881Z"",
        ""operation"": ""Insert""
      }
    ]
  }";

        public static string update = @"{
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
    ""value"": ""2018-05-24T07:13:49.881Z""
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

        public PaymentTests(ITestOutputHelper output) : base(dto, update)
        {
            this.output = output;
        }
    }
}