using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ONIT.VismaNetApi.Models
{

    public class BackgroundStatus
    {
        [JsonProperty]
        public string id { get; set; }
        [JsonProperty]
        public string status { get; set; }
        [JsonProperty]
        public int statusCode { get; set; }
        [JsonProperty]
        public DateTime receivedUtc { get; set; }
        [JsonProperty]
        public DateTime startedUtc { get; set; }
        [JsonProperty]
        public DateTime finishedUtc { get; set; }
        [JsonProperty]
        public string webhookAddress { get; set; }
        [JsonProperty]
        public string errorMessage { get; set; }
        [JsonProperty]
        public string reference { get; set; }
        [JsonProperty]
        public string originalUri { get; set; }
        [JsonProperty]
        public bool hasResponseContent { get; set; }
        [JsonProperty]
        public bool hasRequestContent { get; set; }
        [JsonProperty]
        public string contentLocation { get; set; }
        [JsonProperty]
        public Dictionary<string, string> responseHeaders { get; set; }
    }
}
