using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ONIT.VismaNetApi.Models
{
  public class CustomerCreditNote : DtoPaginatedProviderBase, IProvideIdentificator
  {
    /// <summary>
    /// Create a new credit note without auto numbering
    /// </summary>
    /// <param name="referenceNumber"></param>
    public CustomerCreditNote(string referenceNumber)
    {
      this.referenceNumber = referenceNumber;
    }

    public CustomerCreditNote()
    {
      IgnoreProperties.Add(nameof(this.referenceNumber));
    }



    #region Writable properties (CustomerInvoiceUpdateDto)
    public string externalReference
    {
      get { return Get<string>(); }
      set { Set(value); }
    }

    [JsonProperty]
    public List<CustomerInvoiceLine> lines
    {
      get { return Get(defaultValue: new List<CustomerInvoiceLine>()); }
      private set { Set(value); }
    }

    [Obsolete("Use referenceNumber")]
    public string number => referenceNumber;


    [JsonIgnore]
    [Obsolete("Use referenceNumber")]
    public int internalId
    {
      get
      {
        var id = 0;
        return int.TryParse(referenceNumber, out id) ? id : 0;
      }
    }

    public PaymentMethod paymentMethod
    {
      get => Get<PaymentMethod>("paymentMethodId");
      set => Set(value, "paymentMethodId");
    }

    public decimal exchangeRate
    {
      get { return Get<decimal>(); }
      set { Set(value); }
    }

    public string referenceNumber
    {
      get { return Get<string>(); }
      set { Set(value); }
    }
    public DateTime documentDate
    {
      get { return Get<DateTime>(); }
      set { Set(value); }
    }


    public string customerRefNumber
    {
      get { return Get<string>(); }
      set { Set(value); }
    }

    public bool hold
    {
      get { return Get<bool>(); }
      set { Set(value); }
    }

    public bool dontPrint
    {
      get => Get<bool>();
      set => Set(value);
    }

    public bool dontEmail
    {
      get => Get<bool>();
      set => Set(value);
    }

    public string postPeriod
    {
      get { return Get<string>(); }
      set { Set(value); }
    }

    public string cashAccount
    {
      get { return Get<string>(); }
      set { Set(value); }
    }

    public string invoiceText
    {
      get { return Get<string>(); }
      set { Set(value); }
    }

    public LocationSummary location
    {
      get { return Get("locationId", new LocationSummary()); }
      set { Set(value, key: "locationId"); }
    }

    [Obsolete("Use currencyId instead")]
    public Currency currency
    {
      get => new Currency
      {
        id = currencyId
      };
      set => Set(value?.id, "currencyId");
    }

    public string currencyId
    {
      get => Get<string>();
      set => Set(value);
    }

    public string project
    {
      get => Get<string>();
      set => Set(value);
    }

    public int? salesPersonID
    {
      get { return Get<int?>(); }
      set { Set(value); }
    }

    public int? contact
    {
      get { return Get<int?>(); }
      set { Set(value); }
    }

    #endregion

    #region Read only properties (CustomerInvoiceDto)

    [JsonProperty]
    public CustomerDocumentType documentType
    {
      get { return Get<CustomerDocumentType>(); }
      private set { Set(value); }
    }

    [JsonProperty]
    public InvoiceStatus status
    {
      get { return Get<InvoiceStatus>(); }
      private set { Set(value); }
    }

    public CustomerSummary customer
    {
      get => Get<CustomerSummary>("customerNumber", new CustomerSummary());
      set => Set(value, "customerNumber");
    }

    [JsonProperty]
    public decimal detailTotal
    {
      get { return Get<decimal>(); }
      private set { Set(value); }
    }

    [JsonProperty]
    public decimal detailTotalInCurrency
    {
      get { return Get<decimal>(); }
      private set { Set(value); }
    }

    [JsonProperty]
    public decimal vatTaxableTotal
    {
      get { return Get<decimal>(); }
      private set { Set(value); }
    }

    [JsonProperty]
    public decimal vatTaxableTotalInCurrency
    {
      get { return Get<decimal>(); }
      private set { Set(value); }
    }

    [JsonProperty]
    public decimal vatExemptTotal
    {
      get { return Get<decimal>(); }
      private set { Set(value); }
    }

    [JsonProperty]
    public decimal vatExemptTotalInCurrency
    {
      get { return Get<decimal>(); }
      private set { Set(value); }
    }

    public VatCode vatCode
    {
      get { return Get<VatCode>(); }
      set { Set(value); }
    }

    [JsonProperty]
    public decimal vatTotal
    {
      get { return Get<decimal>(); }
      private set { Set(value); }
    }

    [JsonProperty]
    public decimal vatTotalInCurrency
    {
      get { return Get<decimal>(); }
      private set { Set(value); }
    }

    [JsonProperty]
    public decimal balance
    {
      get { return Get<decimal>(); }
      private set { Set(value); }
    }

    [JsonProperty]
    public decimal balanceInCurrency
    {
      get { return Get<decimal>(); }
      private set { Set(value); }
    }

    public NumberName branchNumber
    {
      get => Get<NumberName>();
      set => Set(value);
    }

    [JsonProperty]
    public decimal amount
    {
      get { return Get<decimal>(); }
      private set { Set(value); }
    }

    [JsonProperty]
    public decimal amountInCurrency
    {
      get { return Get<decimal>(); }
      set { Set(value); }
    }

    [JsonProperty]
    public decimal cashDiscount
    {
      get { return Get<decimal>(); }
      private set { Set(value); }
    }

    [JsonProperty]
    public decimal cashDiscountInCurrency
    {
      get { return Get<decimal>(); }
      private set { Set(value); }
    }

    [JsonProperty]
    public DateTime lastModifiedDateTime
    {
      get { return Get<DateTime>(); }
      private set { Set(value); }
    }

    [JsonProperty]
    public DateTime createdDateTime
    {
      get { return Get<DateTime>(); }
      private set { Set(value); }
    }

    [JsonProperty]
    public string salesPersonDescr
    {
      get { return Get<string>(); }
      private set { Set(value); }
    }
    public string note
    {
      get => Get<string>();
      set => Set(value);
    }

    public CustomerVatZone customerVatZone
    {
      get => Get<CustomerVatZone>("customerVatZoneId");
      set => Set(value, "customerVatZoneId");

    }

    #endregion

    #region Methods

    public void Add(CustomerInvoiceLine line)
    {
      line.lineNumber = 1;
      if (lines.Count > 0)
        line.lineNumber = Math.Max(lines.Count + 1, lines.Max(x => x.lineNumber) + 1);
      lines.Add(line);
    }

    public void Add(string inventoryId, int quantity = 1)
    {
      Add(new CustomerInvoiceLine()
      {
        inventoryNumber = inventoryId,
        quantity = quantity
      });
    }
    #endregion

    public string GetIdentificator()
    {
      return referenceNumber;
    }
    internal override void PrepareForUpdate()
    {
      foreach (var invoiceLine in lines)
      {
        invoiceLine.operation = ApiOperation.Update;
      }
    }
  }
}