using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;
using System;

namespace ONIT.VismaNetApi.Models
{
  public class CashTransactionTaxDetails : DtoProviderBase
  {
    public string vatId { get => Get<string>(); set => Set(value); }

    [JsonProperty]
    public decimal taxableAmount { get => Get<decimal>(); set => Set(value); }

    [JsonProperty]
    public decimal vatAmount { get => Get<decimal>(); set => Set(value); }

    [JsonProperty]
    public decimal expenseAmount { get => Get<decimal>(); set => Set(value); }

  }

}
