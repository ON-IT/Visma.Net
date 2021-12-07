using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;
using System;

namespace ONIT.VismaNetApi.Models
{
  public class CashTransactionDetails : DtoProviderBase
  {
    public CashTransactionDetails()
    {
      DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
    }
    public ApiOperation operation
    {
      get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
      set => Set(new NotDto<ApiOperation>(value));
    }
    public string branchNumber { get => Get<string>(); set => Set(value); }
    public string inventoryNumber { get => Get<string>(); set => Set(value); }

    public string description { get => Get<string>(); set => Set(value); }

    [JsonProperty]
    public decimal quantity { get => Get<decimal>(); set => Set(value); }
    public string uom { get => Get<string>(); set => Set(value); }

    [JsonProperty]
    public decimal price { get => Get<decimal>(); set => Set(value); }

    [JsonProperty]
    public decimal amount { get => Get<decimal>(); set => Set(value); }

    public string offsetAccount { get => Get<string>(); set => Set(value); }

    [JsonProperty] 
    public Subaccount offsetSubaccount { get; private set; }

    public string vatCode { get => Get<string>(); set => Set(value); }


    public bool notInvoiceable
    {
      get => Get<bool>();
      set => Set(value);
    }

    public string project { get => Get<string>(); set => Set(value); }
    public string projectTask { get => Get<string>(); set => Set(value); }
  }

}
