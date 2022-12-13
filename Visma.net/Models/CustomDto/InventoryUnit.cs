using System;
using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class InventoryUnit
    {
        public int unitType { get; set; }
        public ItemClass itemClass { get; set; }
        public int inventoryID { get; set; }
        public string toUnit { get; set; }
        public string sampleToUnit { get; set; }
        public string fromUnit { get; set; }
        public string unitMultDiv { get; set; }
        public decimal unitRate { get; set; }
        public decimal priceAdjustmentMultiplier { get; set; }
        public int recordID { get; set; }

        

    }
}
