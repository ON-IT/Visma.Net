using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;
using Xunit.Abstractions;

namespace Visma.net.tests
{
    public class CustomerDocumentTests : EntityBaseTest<CustomerDocument>
    {
        private static string dto = @"{
    ""documentDueDate"": ""2018-05-22T07:27:28.158Z"",
    ""branch"": {
      ""number"": ""string"",
      ""name"": ""string""
    },
    ""customer"": {
      ""number"": ""string"",
      ""name"": ""string""
    },
    ""documentType"": ""Invoice"",
    ""referenceNumber"": ""string"",
    ""postPeriod"": ""string"",
    ""financialPeriod"": ""string"",
    ""closedFinancialPeriod"": ""string"",
    ""documentDate"": ""2018-05-22T07:27:28.158Z"",
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
    ""lastModifiedDateTime"": ""2018-05-22T07:27:28.158Z"",
    ""createdDateTime"": ""2018-05-22T07:27:28.158Z"",
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
      ""subaccountNumber"": ""string"",
      ""subaccountId"": 0,
      ""description"": ""string"",
      ""id"": 0,
      ""lastModifiedDateTime"": ""2018-05-22T07:27:28.158Z"",
      ""segments"": [
        {
          ""segmentId"": 0,
          ""segmentDescription"": ""string"",
          ""segmentValue"": ""string"",
          ""segmentValueDescription"": ""string""
        }
      ],
      ""extras"": {},
      ""errorInfo"": ""string"",
      ""metadata"":{
            ""totalCount"": 0
        }
    },
    ""extras"": {},
    ""errorInfo"": ""string""
  }";
        public CustomerDocumentTests(ITestOutputHelper output) : base(dto, null)
        {
            this.output = output;
        }
    }
}
