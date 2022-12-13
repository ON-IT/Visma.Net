using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;
using System;
using System.Collections.Generic;

/*
 * Find: ([a-zA-Z]+) ([a-zA-Z]+) { get; set; }
 * Replace with: $1 $2 { get { return Get<$1>(); } set { Set(value); } }
 */

namespace ONIT.VismaNetApi.Models
{
    public class Supplier : DtoPaginatedProviderBase, IProvideIdentificator, IComparable<Supplier>, IComparable
    {
        public Supplier()
        {
            IgnoreProperties.Add(nameof(number));
        }

        /// <summary>
        ///     Create a new supplier without auto numbering
        /// </summary>
        /// <param name="supplierNumber"></param>
        public Supplier(string supplierNumber)
        {
            number = supplierNumber;
        }

        public string accountReference
        {
            get => Get<string>();
            set => Set(value);
        }

        public AccountUsedForPayment accountUsedForPayment
        {
            get => Get<AccountUsedForPayment>();
            set => Set(value);
        }

        [JsonProperty]
        public List<Attributes> attributes
        {
            get => Get("attributeLines", new NotDto<List<Attributes>>(new List<Attributes>())?.Value);
            set => Set(new NotDto<List<Attributes>>(value), "attributeLines");
        }

        public string cashAccount
        {
            get => Get<string>();
            set => Set(value);
        }

        public SupplierChargeBearer chargeBearer
        {
            get => Get<SupplierChargeBearer>();
            set => Set(value);
        }

        public string corporateId
        {
            get => Get<string>();
            set => Set(value);
        }

        public CreditTerms creditTerms
        {
            get => Get("creditTermsId", new CreditTerms("30"));
            set => Set(value);
        }

        public string currencyId
        {
            get => Get<string>();
            set => Set(value);
        }

        public string documentLanguage
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty] public string errorInfo { get; private set; }

        [JsonProperty] public JObject extras { get; private set; }

        [JsonProperty] public SupplierGLAccountDto glAccounts { get; private set; }

        [JsonProperty]
        public int internalId
        {
            get; // => Get<int>();
            private set; // => Set(value);
        }

        [JsonProperty]
        public DateTime lastModifiedDateTime
        {
            get; // => Get<DateTime>();
            private set; // set => Set(value);
        }

        [JsonProperty]
        public LocationSummary location
        {
            get; // => Get(defaultValue: new LocationSummary());
            private set; // => Set(value);
        }

        public Address mainAddress
        {
            get => Get(defaultValue: new Address());
            set => Set(value);
        }

        public ContactInfo mainContact
        {
            get => Get(defaultValue: new ContactInfo());
            set => Set(value);
        }

        public string name
        {
            get => Get<string>();
            set => Set(value);
        }

        public string number
        {
            get => Get<string>();
            set => Set(value);
        }

        public bool overrideWithClassValues
        {
            get => Get<NotDto<bool>>(defaultValue: new NotDto<bool>(false)).Value;
            set => Set(new NotDto<bool>(value));
        }

        public NumberName parentRecord
        {
            get => Get("parentRecordNumber", new NumberName());
            set => Set(value);
        }

        public PaymentBy paymentBy
        {
            get => Get<PaymentBy>();
            set => Set(value);
        }

        public int paymentLeadTime
        {
            get => Get<int>();
            set => Set(value);
        }

        public PaymentMethod paymentMethod
        {
            get => Get("paymentMethodId", new PaymentMethod());
            set => Set(value);
        }

        public string paymentRefDisplayMask
        {
            get => Get<string>();
            set => Set(value);
        }

        public bool paySeparately
        {
            get => Get<bool>();
            set => Set(value);
        }

        public Address remitAddress
        {
            get => Get(defaultValue: new Address());
            set => Set(value);
        }

        public ContactInfo remitContact
        {
            get => Get(defaultValue: new ContactInfo());
            set => Set(value);
        }

        public string status
        {
            get => Get<string>();
            set => Set(value);
        }

        public Address supplierAddress
        {
            get => Get(defaultValue: new Address());
            set => Set(value);
        }

        public SupplierClass supplierClass
        {
            get => Get("supplierClassId", new SupplierClass());
            set => Set(value, "supplierClassId");
        }

        public ContactInfo supplierContact
        {
            get => Get(defaultValue: new ContactInfo());
            set => Set(value);
        }

        public List<PaymentMethodDetailDescriptionValue> supplierPaymentMethodDetails
        {
            get => Get(defaultValue: new List<PaymentMethodDetailDescriptionValue>());
            set => Set(value);
        }

        public string vatRegistrationId
        {
            get => Get<string>();
            set => Set(value);
        }
        [JsonProperty]
        public VatZone vatZone
        {
            get => Get<VatZone>("vatZoneId");
            set => Set(value, "vatZoneId");
        }
        public bool overrideNumberSeries
        {
            get => Get<bool>();
            set => Set(value);
        }
        public string note
        {
            get => Get<string>();
            set => Set(value);
        }

        public int CompareTo(object obj)
        {
            var othersupplier = (Supplier)obj;
            if (othersupplier == null)
                return 0;
            return string.Compare(name, othersupplier.name, StringComparison.Ordinal);
        }

        public int CompareTo(Supplier other)
        {
            return string.Compare(name, other.name, StringComparison.Ordinal);
        }

        public string GetIdentificator()
        {
            return number;
        }
    }
}