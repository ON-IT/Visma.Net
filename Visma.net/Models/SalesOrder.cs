using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
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

        [JsonProperty] public List<Attachment> attachments => Get(defaultValue: new List<Attachment>());

        public NumberName branch
        {
            get => Get<NumberName>();
            set => Set(value);
        }

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

        public DateTime cashDiscountDate
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        public string currency
        {
            get => Get<string>();
            set => Set(value);
        }

        public CustomerSummary customer
        {
            get => Get<CustomerSummary>();
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

        public DateTime dueDate
        {
            get => Get<DateTime>();
            set => Set(value);
        }

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

        public DateTime invoiceDate
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        public string invoiceNbr
        {
            get => Get<string>();
            set => Set(value);
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

        public double orderTotal
        {
            get => Get<double>();
            set => Set(value);
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

        public Owner owner
        {
            get => Get(defaultValue: new Owner());
            set => Set(value);
        }

        public string postPeriod
        {
            get => Get<string>();
            set => Set(value);
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

        public Address soBillingAddress
        {
            get => Get(defaultValue: new Address());
            set => Set(value);
        }

        public ContactInfo soBillingContact
        {
            get => Get(defaultValue: new ContactInfo());
            set => Set(value);
        }

        public Address soShippingAddress
        {
            get => Get(defaultValue: new Address());
            set => Set(value);
        }

        public ContactInfo soShippingContact
        {
            get => Get(defaultValue: new ContactInfo());
            set => Set(value);
        }

        public string status
        {
            get => Get<string>();
            set => Set(value);
        }

        public double taxTotal
        {
            get => Get<double>();
            set => Set(value);
        }

        public DescriptiveDto terms
        {
            get => Get<DescriptiveDto>();
            set => Set(value);
        }

        public DescriptiveDto transactionType
        {
            get => Get(defaultValue: new DescriptiveDto());
            set => Set(value);
        }

        public double vatExemptTotal
        {
            get => Get<double>();
            set => Set(value);
        }

        public double vatTaxableTotal
        {
            get => Get<double>();
            set => Set(value);
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

    public class SalesOrderLine : DtoProviderBase
    {
        public SalesOrderLine()
        {
            DtoFields.Add(nameof(lineNbr), new DtoValue(0));
            DtoFields.Add(nameof(quantity), new DtoValue(1));
            RequiredFields.Add("warehouse", new DtoValue(null));
            RequiredFields.Add("salesOrderOperation", new DtoValue("Issue"));
        }

        public string alternateID
        {
            get => Get<string>();
            set => Set(value);
        }

        public int branch
        {
            get => Get<int>();
            set => Set(value);
        }

        public NumberName branchNumber
        {
            get => Get<NumberName>();
            set => Set(value);
        }

        public bool commissionable
        {
            get => Get<bool>();
            set => Set(value);
        }

        public bool completed
        {
            get => Get<bool>();
            set => Set(value);
        }

        public double discountAmount
        {
            get => Get<double>();
            set => Set(value);
        }

        public string discountCode
        {
            get => Get<string>();
            set => Set(value);
        }

        public double discountPercent
        {
            get => Get<double>();
            set => Set(value);
        }

        public double discUnitPrice
        {
            get => Get<double>();
            set => Set(value);
        }

        public DateTime expirationDate
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        public double extPrice
        {
            get => Get<double>();
            set => Set(value);
        }

        public bool freeItem
        {
            get => Get<bool>();
            set => Set(value);
        }

        public NumberName inventory
        {
            get => Get<NumberName>("inventoryId");
            set => Set(value, "inventoryId");
        }

        public string invoiceNbr
        {
            get => Get<string>();
            set => Set(value);
        }

        public string lineDescription
        {
            get => Get<string>();
            set => Set(value);
        }

        public int lineNbr
        {
            get => Get<int>();
            set => Set(value);
        }

        public string lotSerialNbr
        {
            get => Get<string>();
            set => Set(value);
        }

        public bool manualDiscount
        {
            get => Get<bool>();
            set => Set(value);
        }

        public bool markForPO
        {
            get => Get<bool>();
            set => Set(value);
        }

        public double openQty
        {
            get => Get<double>();
            set => Set(value);
        }

        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }

        public double overshipThreshold
        {
            get => Get<double>();
            set => Set(value);
        }

        public string poSource
        {
            get => Get<string>();
            set => Set(value);
        }

        public int projectTask
        {
            get => Get<int>();
            set => Set(value);
        }

        public double qtyOnShipments
        {
            get => Get<double>();
            set => Set(value);
        }

        public double quantity
        {
            get => Get<double>();
            set => Set(value);
        }

        public string reasonCode
        {
            get => Get<string>();
            set => Set(value);
        }

        public DateTime requestedOn
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        public DescriptiveDto salesPerson
        {
            get => Get<DescriptiveDto>();
            set => Set(value);
        }

        public string shipComplete
        {
            get => Get<string>();
            set => Set(value);
        }

        public DateTime shipOn
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        public string taxCategory
        {
            get => Get<string>();
            set => Set(value);
        }

        public double unbilledAmount
        {
            get => Get<double>();
            set => Set(value);
        }

        public double undershipThreshold
        {
            get => Get<double>();
            set => Set(value);
        }

        public double unitPrice
        {
            get => Get<double>();
            set => Set(value);
        }

        public string uom
        {
            get => Get<string>();
            set => Set(value);
        }

        public DescriptiveDto warehouse
        {
            get => Get<DescriptiveDto>();
            set => Set(value);
        }
    }
}