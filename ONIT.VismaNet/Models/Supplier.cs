using System;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
/*
 * Find: ([a-zA-Z]+) ([a-zA-Z]+) { get; set; }
 * Replace with: $1 $2 { get { return Get<$1>(); } set { Set(value); } }
 */
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class Supplier : DtoProviderBase, IProvideIdentificator
    {
        public Supplier()
        {
            IgnoreProperties.Add(nameof(this.number));
        }
        /// <summary>
        /// Create a new supplier without autonumbering
        /// </summary>
        /// <param name="supplierNumber"></param>
        public Supplier(string supplierNumber)
        {
            number = supplierNumber;
        }


        public int internalId
        {
            get { return Get<int>(); }
            set {  Set(value); }
        }

        public string number
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string name
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string status
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public Address mainAddress
        {
            get { return Get<Address>(defaultValue:new Address()); }
            set { Set(value); }
        }

        public ContactInfo mainContact
        {
            get { return Get<ContactInfo>(defaultValue:new ContactInfo()); }
            set { Set(value); }
        }

        public string accountReference
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public NumberName parentRecord
        {
            get { return Get<NumberName>("parentRecordNumber", new NumberName()); }
            set { Set(value); }
        }

        public CreditTerms creditTerms
        {
            get { return Get<CreditTerms>("creditTermsId", defaultValue:new CreditTerms("30")); }
            set { Set(value); }
        }

        public string documentLanguage
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string currencyId
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public Address remitAddress
        {
            get { return Get<Address>(defaultValue:new Address()); }
            set { Set(value); }
        }

        public ContactInfo remitContact
        {
            get { return Get<ContactInfo>(defaultValue:new ContactInfo()); }
            set { Set(value); }
        }

        public PaymentMethod paymentMethod
        {
            get { return Get<PaymentMethod>("paymentMethodId", defaultValue:new PaymentMethod()); }
            set { Set(value); }
        }

        public string cashAccount
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public SupplierChargeBearer chargeBearer
        {
            get { return Get<SupplierChargeBearer>(); }
            set { Set(value); }
        }

        public AccountUsedForPayment accountUsedForPayment
        {
            get { return Get<AccountUsedForPayment>(); }
            set { Set(value); }
        }

        public PaymentBy paymentBy
        {
            get { return Get<PaymentBy>(); }
            set { Set(value); }
        }

        public int paymentLeadTime
        {
            get { return Get<int>(); }
            set { Set(value); }
        }

        public string paymentRefDisplayMask
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public bool paySeparately
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public Address supplierAddress
        {
            get { return Get(defaultValue:new Address()); }
            set { Set(value); }
        }

        public ContactInfo supplierContact
        {
            get { return Get(defaultValue:new ContactInfo()); }
            set { Set(value); }
        }

        public Location location
        {
            get { return Get(defaultValue:new Location()); }
            set { Set(value); }
        }

        public string vatRegistrationId
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string corporateId
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public VatCode vatZone
        {
            get { return Get<VatCode>("vatZoneId", defaultValue:new VatCode("01")); }
            set { Set(value); }
        }

        [JsonProperty]
        public DateTime lastModifiedDateTime
        {
            get { return Get<DateTime>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public SupplierClass supplierClass
        {
            get { return Get("supplierClassId", defaultValue: new SupplierClass()); }
            private set { Set(value);}

        }

        public string GetIdentificator()
        {
            return number;
        }
    }
}