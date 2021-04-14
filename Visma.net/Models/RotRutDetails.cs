using System.Collections.Generic;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models
{
  public class RotRutDetails : DtoProviderBase, IProvideCustomDto
  {

    public string appartment
    {
      get => Get<string>();
      set => Set(value);
    }

    [JsonProperty]
    public decimal distributedAmount { get; private set; }

    public bool distributedAutomaticaly
    {
      get => Get<bool>();
      set => Set(value);
    }

    public List<RotRutDistribution> distribution
    {
      get => Get(defaultValue: new List<RotRutDistribution>());
      set => Set(value);
    }

    [JsonProperty]
    public string docType { get; private set; }



    public string estate
    {
      get => Get<string>();
      set => Set(value);
    }

    [JsonProperty]
    public decimal materialCost { get; private set; }

    [JsonProperty]
    public string organizationNbr
    {
      get => Get<string>();
      set => Set(value);
    }

    [JsonProperty]
    public decimal otherCost { get; private set; }

    [JsonProperty]
    public string refNbr { get; private set; }

    [JsonProperty]
    public decimal totalDeductableAmount { get; private set; }

    public string type
    {
      get => Get<string>();
      set => Set(value);
    }

    [JsonProperty]
    public decimal workPrice { get; private set; }

    public object ToDto()
    {
      if (type == null)
      {
        return null;
      }

      return ToDto(false);
    }
  }
}