using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Models;
using Xunit.Abstractions;

namespace Visma.net.tests.Tests
{
    public class JournalTransactionsTests : EntityBaseTest<JournalTransaction>
    {
        private static readonly string dto = @"{
    ""module"": ""ModuleGL"",
    ""batchNumber"": ""string"",
    ""status"": ""Hold"",
    ""hold"": true,
    ""transactionDate"": ""2018-05-22T07:27:28.561Z"",
    ""postPeriod"": ""string"",
    ""financialPeriod"": ""string"",
    ""ledger"": ""string"",
    ""ledgerDescription"": ""string"",
    ""currencyId"": ""string"",
    ""exchangeRate"": 0.0,
    ""autoReversing"": true,
    ""reversingEntry"": true,
    ""description"": ""string"",
    ""originalBatchNumber"": ""string"",
    ""debitTotal"": 0.0,
    ""debitTotalInCurrency"": 0.0,
    ""creditTotal"": 0.0,
    ""creditTotalInCurrency"": 0.0,
    ""controlTotal"": 0.0,
    ""controlTotalInCurrency"": 0.0,
    ""createVatTransaction"": true,
    ""skipVatAmountValidation"": true,
    ""lastModifiedDateTime"": ""2018-05-22T07:27:28.561Z"",
    ""transactionCode"": ""string"",
    ""transactionCodeDescription"": ""string"",
    ""branch"": ""string"",
    ""journalTransactionLines"": [
      {
        ""lineNumber"": 0,
        ""accountNumber"": ""string"",
        ""description"": ""string"",
        ""subaccount"": {
          ""subaccountNumber"": ""string"",
          ""subaccountId"": 0,
          ""description"": ""string"",
          ""id"": 0,
          ""lastModifiedDateTime"": ""2018-05-22T07:27:28.561Z"",
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
        ""referenceNumber"": ""string"",
        ""debitAmount"": 0.0,
        ""debitAmountInCurrency"": 0.0,
        ""creditAmount"": 0.0,
        ""creditAmountInCurrency"": 0.0,
        ""transactionDescription"": ""string"",
        ""vatCode"": {
          ""id"": ""string"",
          ""description"": ""string""
        },
        ""vat"": {
          ""id"": ""string"",
          ""description"": ""string""
        },
        ""branch"": ""string"",
        ""customerSupplier"": ""string"",
        ""transactionType"": ""string"",
        ""module"": ""ModuleGL"",
        ""uom"": ""string"",
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
    ""attachments"": [
      {
        ""name"": ""string"",
        ""id"": ""string"",
        ""revision"": 0
      }
    ],
    ""extras"": {},
    ""errorInfo"": ""string""
  }";

        private static readonly string update = @"{
  ""batchNumber"": {
    ""value"": ""string""
  },
  ""hold"": {
    ""value"": true
  },
  ""transactionDate"": {
    ""value"": ""2018-05-22T07:27:28.561Z""
  },
  ""postPeriod"": {
    ""value"": ""string""
  },
  ""financialPeriod"": {
    ""value"": ""string""
  },
  ""ledger"": {
    ""value"": ""string""
  },
  ""currencyId"": {
    ""value"": ""string""
  },
  ""exchangeRate"": {
    ""value"": 0.0
  },
  ""autoReversing"": {
    ""value"": true
  },
  ""description"": {
    ""value"": ""string""
  },
  ""controlTotalInCurrency"": {
    ""value"": 0.0
  },
  ""createVatTransaction"": {
    ""value"": true
  },
  ""skipVatAmountValidation"": {
    ""value"": true
  },
  ""transactionCode"": {
    ""value"": ""string""
  },
  ""branch"": {
    ""value"": ""string""
  },
  ""journalTransactionLines"": [
    {
      ""operation"": ""Insert"",
      ""lineNumber"": {
        ""value"": 0
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
      ""referenceNumber"": {
        ""value"": ""string""
      },
      ""transactionDescription"": {
        ""value"": ""string""
      },
      ""debitAmountInCurrency"": {
        ""value"": 0.0
      },
      ""creditAmountInCurrency"": {
        ""value"": 0.0
      },
      ""vatCodeId"": {
        ""value"": ""string""
      },
      ""vatId"": {
        ""value"": ""string""
      },
      ""branch"": {
        ""value"": ""string""
      },
      ""uom"": {
        ""value"": ""string""
      }
    }
  ]
}";

        public JournalTransactionsTests(ITestOutputHelper output) : base(dto, update)
        {
            this.output = output;
        }

        public override string PrepareDtoForSerializer(string src)
        {
            var jtoken = JToken.Parse(src);
            jtoken["journalTransactionLines"][0]["operation"] = "Insert";
            return base.PrepareDtoForSerializer(jtoken.ToString());
        }
    }
}