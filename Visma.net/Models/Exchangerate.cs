using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONIT.VismaNetApi.Models
{
    public class ExchangeRate : DtoProviderBase
    {
        [JsonProperty]
        public int currencyInfoId { get; set; }
        [JsonProperty]
        public int currencyRateId { get; set; }
        public string currencyId
        {
            get => Get<string>();
            set => Set(value);
        }
        [JsonProperty]
        public string baseCurrencyId { get; set; }
        public string rateType
        {
            get => Get<string>();
            set => Set(value);
        }
        public DateTime effectiveDate
        {
            get => Get<DateTime>();
            set => Set(value);
        }
        public decimal rate
        {
            get => Get<decimal>();
            set => Set(value);
        }
        [JsonProperty]
        public decimal recipRate { get; set; }
        public string multDiv
        {
            get => Get<string>();
            set => Set(value);
        }

    }
}
