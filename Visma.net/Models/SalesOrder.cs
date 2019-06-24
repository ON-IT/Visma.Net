using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class SalesOrder : DtoProviderBase, IProvideIdentificator
    {
        public SalesOrder()
        {
            IgnoreProperties.Add(nameof(orderNo));
            IgnoreProperties.Add("orderNumber");
            RequiredFields.Add(nameof(orderType), new DtoValue("SO"));
        }

        [JsonProperty] public List<Attachment> attachments { get; private set; }

       public NumberName branchNumber
        {
            get => Get<NumberName>();
            set => Set(value);
        }

        public DateTime cancelBy
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        public bool canceled
        {
            get => Get<bool>();
            set => Set(value);
        }

        [JsonProperty]
        public DateTime cashDiscountDate
        {
            get; // => Get<DateTime>();
            private set; // => Set(value);
        }

        public string currency
        {
            get => Get<string>();
            set => Set(value);
        }

        public SoCustomerSummary customer
        {
            get => Get<SoCustomerSummary>();
            set => Set(value);
        }

        public string customerOrder
        {
            get => Get<string>();
            set => Set(value);
        }

        public string customerRefNo
        {
            get => Get<string>();
            set => Set(value);
        }

        public CustomerVatZone customerVATZone
        {
            get => Get<CustomerVatZone>();
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

        [JsonProperty]
        public DateTime dueDate
        {
            get; // => Get<DateTime>();
            private set; // => Set(value);
        }

        [JsonProperty] public string errorInfo { get; private set; }

        [JsonProperty] public JObject extras { get; private set; }

        public DescriptiveDto fobPoint
        {
            get => Get<DescriptiveDto>();
            set => Set(value);
        }

        public bool hold
        {
            get => Get<bool>();
            set => Set(value);
        }

        public bool insurance
        {
            get => Get<bool>();
            set => Set(value);
        }

        [JsonProperty]
        public DateTime invoiceDate
        {
            get; // => Get<DateTime>();
            private set; // => Set(value);
        }

        [JsonProperty]
        public string invoiceNbr
        {
            get; // => Get<string>();
            private set; // => Set(value);
        }

        public bool invoiceSeparately
        {
            get => Get<bool>();
            set => Set(value);
        }

        [JsonProperty] public DateTime lastModifiedDateTime { get; private set; }

        [JsonProperty]
        public List<SalesOrderLine> lines
        {
            get => Get(defaultValue: new List<SalesOrderLine>());
            private set => Set(value);
        }

        public LocationSummary location
        {
            get => Get(defaultValue: new LocationSummary());
            set => Set(value);
        }

        public string note
        {
            get => Get<string>();
            set => Set(value);
        }

        public string orderNo
        {
            get => Get<string>("orderNumber");
            set => Set(value, "orderNumber");
        }

        [JsonProperty]
        public double orderTotal
        {
            get;// => Get<double>();
            private set;// => Set(value);
        }

        public string orderType
        {
            get => Get<string>();
            set => Set(value);
        }

        public string origOrderNbr
        {
            get => Get<string>();
            set => Set(value);
        }

        public string origOrderType
        {
            get => Get<string>();
            set => Set(value);
        }
        /*
        public Owner owner
        {
            get => Get(defaultValue: new Owner());
            set => Set(value);
        }*/

        [JsonProperty]
        public string postPeriod
        {
            get; // => Get<string>();
            private set; // => Set(value);
        }

        public DescriptiveDto preferredWarehouse
        {
            get => Get<DescriptiveDto>();
            set => Set(value);
        }

        public bool printDescriptionOnInvoice
        {
            get => Get<bool>();
            set => Set(value);
        }

        public bool printNoteOnExternalDocuments
        {
            get => Get<bool>();
            set => Set(value);
        }

        public bool printNoteOnInternalDocuments
        {
            get => Get<bool>();
            set => Set(value);
        }

        public int priority
        {
            get => Get<int>();
            set => Set(value);
        }

        public int project
        {
            get => Get<int>();
            set => Set(value);
        }

        public DateTime requestOn
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        public bool residentialDelivery
        {
            get => Get<bool>();
            set => Set(value);
        }

        public DescriptiveDto salesPerson
        {
            get => Get(defaultValue: new DescriptiveDto());
            set => Set(value);
        }

        public bool saturdayDelivery
        {
            get => Get<bool>();
            set => Set(value);
        }

        public DateTime schedShipment
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        public string shipComplete
        {
            get => Get<string>();
            set => Set(value);
        }

        public DescriptiveDto shippingTerms
        {
            get => Get(defaultValue: new DescriptiveDto());
            set => Set(value);
        }

        public DescriptiveDto shippingZone
        {
            get => Get(defaultValue: new DescriptiveDto());
            set => Set(value);
        }

        public bool shipSeparately
        {
            get => Get<bool>();
            set => Set(value);
        }

        public DescriptiveDto shipVia
        {
            get => Get<DescriptiveDto>();
            set => Set(value);
        }

        public SoAddress soBillingAddress
        {
            get => Get(defaultValue: new SoAddress());
            set => Set(value);
        }

        public SoContactInfo soBillingContact
        {
            get => Get(defaultValue: new SoContactInfo());
            set => Set(value);
        }

        public SoAddress soShippingAddress
        {
            get => Get(defaultValue: new SoAddress());
            set => Set(value);
        }

        public SoContactInfo soShippingContact
        {
            get => Get(defaultValue: new SoContactInfo());
            set => Set(value);
        }

        [JsonProperty]
        public string status
        {
            get;// => Get<string>();
            private set;//( => Set(value);
        }
        [JsonProperty]

        public double taxTotal
        {
            get;// => Get<double>();
            private set; //=> Set(value);
        }

        public DescriptiveDto terms
        {
            get => Get<DescriptiveDto>();
            set => Set(value);
        }

        public TransactionType transactionType
        {
            get => Get(defaultValue: new TransactionType());
            private set => Set(value);
        }

        
        [JsonProperty]
        public double vatExemptTotal
        {
            get;// => Get<double>();
            private set;// => Set(value);
        }

        [JsonProperty]
        public double vatTaxableTotal
        {
            get;// => Get<double>();
            private set;// => Set(value);
        }

        public string GetIdentificator()
        {
            return orderNo;
        }

        internal override void PrepareForUpdate()
        {
            foreach (var salesOrderLine in lines)
            {
                salesOrderLine.operation = ApiOperation.Update;
            }

            IgnoreProperties.Add(nameof(customer));
            if (lines.Count > 0)
                IgnoreProperties.Add(nameof(currency));
        }

        #region Methods

        public void Add(SalesOrderLine line)
        {
            line.lineNbr = 1;
            if (lines.Count > 0)
                line.lineNbr = Math.Max(lines.Count + 1, lines.Max(x => x.lineNbr) + 1);
            line.operation = ApiOperation.Insert;
            lines.Add(line);
        }

        public void Add(string inventoryId, string lineDescription = null, int quantity = 1)
        {
            Add(new SalesOrderLine
            {
                inventory = inventoryId,
                quantity = quantity,
                lineDescription = lineDescription,
                operation = ApiOperation.Insert
            });
        }

        #endregion
    }
}