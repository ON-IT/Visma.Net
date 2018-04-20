using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class TaxDetail : DtoProviderBase
    {
        public decimal taxableAmount
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public string taxId
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public decimal vatRate { get; private set; }

        public decimal vatAmount
        {
            get => Get<decimal>();
            set => Set(value);
        }
        [JsonProperty]
        public int recordId { get; private set; }

        [JsonProperty]
        public NumberDescription vatId { get; private set; }
    }
}