using Newtonsoft.Json;
using System;

namespace ONIT.VismaNetApi.Lib
{
    public class CreateShipmentActionResult : VismaActionResult
    {
        [JsonProperty("referenceNumber")]
        public string ReferenceNumber { get; internal set; }

        [JsonProperty("shipmentDto")]
        public Models.Shipment shipment { get; internal set; }
    }
}
