﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;

namespace ONIT.VismaNetApi.Models
{
  public class Location : DtoPaginatedProviderBase, IProvideIdentificator
  {
    public Location(string baccountId, string locationId, bool standAloneLocation = false)
    {
      this.baccount = new Baccount();
      this.baccount.number = baccountId;
      //this.baccountId = baccountId;
      this.locationId = locationId;


      //IgnoreProperties.Add(nameof(baccount));
      //if (!standAloneLocation)
      //{
      //    IgnoreProperties.Add("baccountId");
      //    IgnoreProperties.Add(nameof(locationId));
      //}


    }

    internal override void PrepareForUpdate()
    {
    //  IgnoreProperties.Add(nameof(baccount));
      IgnoreProperties.Add("baccountId");
      IgnoreProperties.Add(nameof(locationId));
    }

    public bool active
    {
      get => Get<bool>();
      set => Set(value);
    }

    public Address address
    {
      get => Get<Address>();
      set => Set(value);
    }

    public bool addressIsSameAsMain
    {
      get => Get<bool>();
      set => Set(value);
    }

    public Baccount baccount
    {
        get => Get<Baccount>("baccountId");
        set => Set(value, "baccountId");
    }

    //public string baccountId
    //{
    //  get => Get<string>();
    //  set => Set(value);
    //}

    public ContactInfo contact
    {
      get => Get<ContactInfo>();
      set => Set(value);
    }

    public bool contactIsSameAsMain
    {
      get => Get<bool>();
      set => Set(value);
    }

    public string ediCode
    {
      get => Get<string>();
      set => Set(value);
    }

    public string gln
    {
      get => Get<string>();
      set => Set(value);
    }

    public string locationId
    {
      get => Get<string>();
      set => Set(value);
    }

    public string locationName
    {
      get => Get<string>();
      set => Set(value);
    }

    public string vatRegistrationId
    {
      get => Get<string>();
      set => Set(value);
    }

    public string corporateId
    {
      get => Get<string>();
      set => Set(value);
    }

    public VatZone vatZone
    {
      get => Get<VatZone>();
      set => Set(value);
    }

    [JsonProperty]
    public DateTime lastModifieDateTime { get; private set; }

    [JsonProperty]
    public JObject extras { get; private set; }

    [JsonProperty]
    public string errorInfo { get; private set; }

    public string GetIdentificator()
    {
      return baccount?.number;
    }
  }
}