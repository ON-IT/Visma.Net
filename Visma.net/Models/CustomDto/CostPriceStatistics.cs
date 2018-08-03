using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class CostPriceStatistics
    {
        [JsonProperty]
        public decimal lastCost { get; private set; }
        [JsonProperty]
        public decimal averageCost { get; private set; }
        [JsonProperty]
        public decimal minCost { get; private set; }
        [JsonProperty]
        public decimal maxCost { get; private set; }
    }
}