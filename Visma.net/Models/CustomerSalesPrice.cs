using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONIT.VismaNetApi.Models
{
    public class CustomerSalesPrice : DtoPaginatedProviderBase, IProvideIdentificator
    {
        public int recordId { get; set; }
        public PriceType priceType
        {
            get { return Get<PriceType>(); }
            set { Set(value); }
        }
        public string priceCode { get; set; }
        public string inventoryId { get; set; }
        public string description { get; set; }
        public string uoM { get; set; }
        public bool promotion { get; set; }
        public decimal breakQty { get; set; }
        public decimal price { get; set; }
        public string currency { get; set; }
        public string vat { get; set; }
        public DateTime effectiveDate { get; set; }
        public DateTime expirationDate { get; set; }
        public DateTime lastModifiedDateTime { get; set; }

        public string GetIdentificator()
        {
            return recordId.ToString();
        }
    }
}
