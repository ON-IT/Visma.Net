using FluentAssertions;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi;
using ONIT.VismaNetApi.Models;
using RichardSzalay.MockHttp;
using System.Net.Http;
using Xunit;
using Xunit.Abstractions;

namespace Visma.net.Tests
{
    public class CustomerPaymentBackgroundTest
    {
        protected ITestOutputHelper output;
        public CustomerPaymentBackgroundTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public async void CallToCustomerPaymentRelease_WithCallbackUrl_ContainsHeaderAndReturnsBackgroundJob()
        {
            var data = @"{
                          ""id"": ""string"",
                          ""status"": ""string"",
                          ""statusCode"": 0,
                          ""receivedUtc"": ""2022-11-10T09:34:05.215Z"",
                          ""startedUtc"": ""2022-11-10T09:34:05.215Z"",
                          ""finishedUtc"": ""2022-11-10T09:34:05.215Z"",
                          ""webhookAddress"": ""string"",
                          ""errorMessage"": ""string"",
                          ""reference"": ""string"",
                          ""originalUri"": ""string"",
                          ""hasResponseContent"": true,
                          ""hasRequestContent"": true,
                          ""contentLocation"": ""string"",
                          ""responseHeaders"": {
                            ""additionalProp1"": ""string"",
                            ""additionalProp2"": ""string"",
                            ""additionalProp3"": ""string""
                          }
                    }";
            var mock = new MockHttpMessageHandler();
            mock.When("/API/controller/api/v1/customerpayment/*/action/release")
                .WithHeaders("erp-api-background", "https://1.1.1.1")
                .Respond((ctx) =>
                {
                    output.WriteLine(ctx?.RequestUri?.ToString());
                    return new StringContent(data);
                });

            var vismaNet = new VismaNet(123123, "123", httpClient: mock.ToHttpClient());

            var payment = await vismaNet.CustomerPayment.Release(new CustomerPayment
            {
                refNbr = "123456"
            }, "https://1.1.1.1");

            payment.Should().NotBeNull();
            JObject.FromObject(payment).Should().BeEquivalentTo(JObject.Parse(data));
            mock.VerifyNoOutstandingExpectation();
            mock.VerifyNoOutstandingRequest();
        }
    }
}
