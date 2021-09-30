using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ONIT.VismaNetApi.Models
{
    public class PurchaseOrder : DtoPaginatedProviderBase, IProvideIdentificator
    {
        public PurchaseOrder()
        {
            IgnoreProperties.Add(nameof(orderNbr));
            IgnoreProperties.Add("orderNbr");

        }
        public string currency
        {
            get => Get<string>();
            set => Set(value);
        }
        public DateTime date
        {
            get => Get<DateTime>();
            set => Set(value);
        }
        public string description
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty] public DateTime lastModifiedDateTime { get; private set; }
        [JsonProperty]
        public List<PurchaseOrderLine> lines
        {
            get => Get(defaultValue: new List<PurchaseOrderLine>());
            private set => Set(value);
        }

        [JsonProperty] public decimal lineTotal { get; private set; }

        [JsonProperty] public decimal lineTotalInBaseCurrency { get; private set; }
        public string note
        {
            get => Get<string>();
            set => Set(value);
        }

        public string orderNbr
        {
            get => Get<string>("orderNbr");
            set => Set(value, "orderNbr");
        }
        public Owner owner
        {
            get => Get(defaultValue: new Owner());
            set => Set(value);
        }
        [JsonProperty] public decimal orderTotal { get; private set; }

        [JsonProperty] public decimal orderTotalInBaseCurrency { get; private set; }
        public DateTime promisedOn
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        public SoCustomerSummary supplier
        {
            get => Get<SoCustomerSummary>();
            set => Set(value);
        }
        public string supplierRef
        {
            get => Get<string>();
            set => Set(value);
        }
        [JsonProperty]
        public List<TaxDetail> taxDetails { get; private set; }
        [JsonProperty] public decimal taxTotal { get; private set; }
        [JsonProperty] public decimal taxTotalInBaseCurrency { get; private set; }
        [JsonProperty] public decimal vatExemptTotal { get; private set; }
        [JsonProperty] public decimal vatExemptTotalInBaseCurrency { get; private set; }
        public void Add(PurchaseOrderLine line)
        {
            line.lineNbr = 1;
            if (lines.Count > 0)
                line.lineNbr = Math.Max(lines.Count + 1, lines.Max(x => x.lineNbr) + 1);
            lines.Add(line);
        }
        public string GetIdentificator()
        {
            return orderNbr;
        }
        internal override void PrepareForUpdate()
        {
            foreach (var purchaseOrderLine in lines)
            {
                purchaseOrderLine.operation = ApiOperation.Update;
            }
        }
    }
}
