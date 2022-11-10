using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi;
using ONIT.VismaNetApi.Models;
using RichardSzalay.MockHttp;
using System.Net.Http;
using System.Threading.Tasks;
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

        record MessageContent(string message);
        readonly string backgroundTaskData = @"{""id"":""73ac0029-1e4f-4adc-a7eb-318cd25ba4bf"",""status"":""Finished"",""statusCode"":400,""receivedUtc"":""2022-11-10T10:20:53.75+01:00"",""startedUtc"":""2022-11-10T10:20:54.393+01:00"",""finishedUtc"":""2022-11-10T10:20:55.788+01:00"",""webhookAddress"":""https://google.com"",""originalUri"":""https://finance.visma.net/0921001005/api/v1/customerPayment/400654/action/release"",""hasResponseContent"":true,""hasRequestContent"":true,""contentLocation"":""https://integration.visma.net/API/controller/api/v1/background/73ac0029-1e4f-4adc-a7eb-318cd25ba4bf/content"", ""errorMessage"":null, ""reference"": null, ""responseHeaders"": null}";

        [Fact]
        public async Task BackgroundGetContent_ForValidId_ReturnsSerializedContent()
        {
            var data = @"{

  ""message"": ""Payment can't be updated because it is already released.""

}";
            var mock = new MockHttpMessageHandler();
            mock.When("/API/controller/api/v1/background/*/content")
             .Respond((ctx) =>
             {
                 output.WriteLine(ctx?.RequestUri?.ToString());
                 return new StringContent(data);
             });
            mock.Fallback.Respond((ctx) =>
            {
                output.WriteLine($"FALLBACK: {ctx.RequestUri}");
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            });
            var vismaNet = new VismaNet(123, "123", httpClient: mock.ToHttpClient());
            var status = await vismaNet.Background.GetContent<MessageContent>("73ac0029-1e4f-4adc-a7eb-318cd25ba4bf");
            JObject.FromObject(status).Should().BeEquivalentTo(JObject.Parse(data));
        }

        [Fact]
        public async Task BackgroundGetStatus_WithValidStatus_ReturnsStatusInfo()
        {
            var mock = new MockHttpMessageHandler();
            mock.When("/API/controller/api/v1/background/*")
                .Respond((ctx) =>
                {
                    output.WriteLine(ctx?.RequestUri?.ToString());
                    return new StringContent(backgroundTaskData);
                });
            var vismaNet = new VismaNet(123, "123", httpClient: mock.ToHttpClient());
            var status = await vismaNet.Background.GetStatus("73ac0029-1e4f-4adc-a7eb-318cd25ba4bf");
            output.WriteLine(JsonConvert.SerializeObject(status, Formatting.Indented));
            JObject.FromObject(status).Should().BeEquivalentTo(JObject.Parse(backgroundTaskData));
            mock.VerifyNoOutstandingExpectation();
            mock.VerifyNoOutstandingRequest();
        }

        [Fact]
        public async Task CallToCustomerPaymentRelease_WithCallbackUrl_ContainsHeaderAndReturnsBackgroundJob()
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
                    return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted)
                    {
                        Content = new StringContent(data),
                        Headers =
                        {
                            {"Location", "https://integration.visma.net/API/controllers/api/v1/background/73ac0029-1e4f-4adc-a7eb-318cd25ba4bf" }
                        }
                    };
                });

            mock.When("https://integration.visma.net/API/controllers/api/v1/background/73ac0029-1e4f-4adc-a7eb-318cd25ba4bf")
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
