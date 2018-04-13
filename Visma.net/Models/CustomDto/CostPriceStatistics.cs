using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class CostPriceStatistics
    {
        [JsonProperty]
        public decimal lastCost { get; }
        [JsonProperty]
        public decimal averageCost { get; }
        [JsonProperty]
        public decimal minCost { get; }
        [JsonProperty]
        public decimal maxCost { get; }
    }
}