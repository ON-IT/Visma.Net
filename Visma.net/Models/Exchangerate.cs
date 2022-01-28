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
        public int id { get; set; }
        public string fromCurrencyId
        {
            get => Get<string>();
            set => Set(value);
        }
        public string toCurrencyId
        {
            get => Get<string>();
            set => Set(value);
        }
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
        public decimal rateReciprocal { get; set; }
        public string multDiv
        {
            get => Get<string>();
            set => Set(value);
        }

    }
}
