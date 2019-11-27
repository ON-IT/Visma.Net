using System;
using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class SupplierDetails
    {
        public bool active { get; set; }
        [JsonProperty("default")]
        public bool Isdefault { get; set; }
        public string supplierId { get; set; }
        public string supplierName { get; set; }
        public string location { get; set; }
        public string warehouse { get; set; }
        public string purchaseUnit { get; set; }
        public string supplierItemId { get; set; }
        public string currencyId { get; set; }
        public decimal shipmentLeadTime { get; set; }
        public decimal leadTime { get; set; }
        public decimal minOrderFreq { get; set; }
        public decimal minOrderQty { get; set; }
        public decimal maxOrderQty { get; set; }
        public decimal lotSize { get; set; }
        public decimal eoq { get; set; }
        public decimal lastSupplierPrice { get; set; }
        [JsonProperty("override")]
        public bool IsOverride { get; set; }

}
}
