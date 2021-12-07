using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;
using System;
using System.Collections.Generic;

namespace ONIT.VismaNetApi.Models
{
  public class CashTransaction : DtoPaginatedProviderBase, IProvideIdentificator
  {
    //public string status { get; set; }

    public string refNbr { get => Get<string>("referenceNumber"); set => Set(value, "referenceNumber"); }
    public bool hold { get => Get<bool>(); set => Set(value); }

    public DateTime tranDate { get => Get<DateTime>(); set => Set(value); }

    public string financialPeriod { get => Get<string>(); set => Set(value); }
    public string finPeriod { get => Get<string>(); set => Set(value); }
    public string description { get => Get<string>(); set => Set(value); }

    public Account cashAccount { get => Get<Account>(); set => Set(value); }
    public EntryType entryType { get => Get<EntryType>(); set => Set(value); }
    public string documentRef { get => Get<string>(); set => Set(value); }


    [JsonProperty]
    public decimal controlTotal { get => Get<decimal>(); set => Set(value); }

    [JsonProperty]
    public decimal vatAmount { get => Get<decimal>(); set => Set(value); }

    public string vatZone { get => Get<string>(); set => Set(value); }

    public TaxCalulationModes taxCalculationMode { get; set; }

    //public CustomerSummary customer { get => Get<CustomerSummary>(); set => Set(value); }
    //public LocationSummary location { get => Get<LocationSummary>(); set => Set(value); }
    //public PaymentMethod paymentMethod { get => Get<PaymentMethod>(); set => Set(value); }
   

    [JsonProperty]
    public List<CashTransactionDetails> cashTransactionDetails
    {
      get => Get(defaultValue: new List<CashTransactionDetails>());
      private set => Set(value);
    }

    [JsonProperty]
    public List<CashTransactionTaxDetails> cashTransactionTaxDetails
    {
      get => Get(defaultValue: new List<CashTransactionTaxDetails>());
      private set => Set(value);
    }

    public string GetIdentificator()
    {
      return refNbr;
    }

    internal override void PrepareForUpdate()
    {
      foreach (var line in this.cashTransactionDetails)
        line.operation = ApiOperation.Update;
    }
    

  }

  
}
