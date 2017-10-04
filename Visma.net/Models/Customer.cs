using System;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class Customer : DtoProviderBase, IProvideIdentificator, IComparable<Customer>, IComparable
    {
		public Customer ()
		{
			IgnoreProperties.Add (nameof(this.number));
		}

        /// <summary>
        /// Create a new customer without autonumbering
        /// </summary>
        /// <param name="customerNumber"></param>
        public Customer(string customerNumber)
        {
            number = customerNumber;
        }
     
        [JsonProperty]
        public string number
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        [JsonProperty]
        public int internalId
        {
            get { return Get<int>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public DateTime lastModifiedDateTime
        {
            get { return Get<DateTime>(); }
            private set { Set(value); }
        }
        
        public string name
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public CustomerStatus status
        {
            get { return Get<CustomerStatus>(); }
            set { Set(value); }
        }


        public string accountReference
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string parentRecordNumber
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string currencyId
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public decimal creditLimit
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public int creditDaysPastDue
        {
            get { return Get<int>(); }
            set { Set(value); }
        }

        public bool overrideWithClassValues
        {
            get { return Get<NotDto<bool>>(defaultValue:new NotDto<bool>(false)).Value; }
            set { Set(new NotDto<bool>(value)); }
        }

        public CustomerClass customerClass
        {
            get { return Get("customerClassId", new CustomerClass()); }
            set { Set(value, "customerClassId"); }
        }

        public CreditTerms creditTerms
        {
            get { return Get("creditTermsId", new CreditTerms()); }
            set { Set(value); }
        }

        public bool printInvoices
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public bool acceptAutoInvoices
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public bool sendInvoicesByEmail
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public bool printStatements
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public bool sendStatementsByEmail
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public bool printMultiCurrencyStatements
        {
            get { return Get<bool>(); }
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

        public string note
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public VatCode vatZone
        {
            get { return Get<VatCode>("vatZoneId"); }
            set { Set(value, "vatZoneId"); }
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


        public CreditRule creditVerification
        {
            get { return Get<CreditRule>(); }
            set { Set(value); }
        }


        public Address invoiceAddress
        {
			get { return Get<Address>(defaultValue: new Address()); }
            set { Set(value); }
        }

        public ContactInfo invoiceContact
        {
			get { return Get(defaultValue:new ContactInfo()); }
            set { Set(value); }
        }

        public StatementTypes statementType
        {
            get { return Get<StatementTypes>(); }
            set { Set(value); }
        }

        public Address deliveryAddress
        {
            get { return Get<Address>(defaultValue:new Address()); }
            set { Set(value); }
        }

        public ContactInfo deliveryContact
        {
            get { return Get<ContactInfo>(defaultValue:new ContactInfo()); }
            set { Set(value); }
        }

        
        public DescriptiveDto priceClass {
            get { return Get<DescriptiveDto>("priceClassId"); }
            set { Set(value, "priceClassId"); }
        }

        public int CompareTo(Customer other)
        {
            return string.Compare(name, other.name, StringComparison.Ordinal);
        }

        public int CompareTo(object obj)
        {
            var otherCustomer = (Customer) obj;
            if (otherCustomer == null)
                return 0;
            return string.Compare(this.name, otherCustomer.name, StringComparison.Ordinal);
        }

        public string GetIdentificator()
        {
            return number;
        }
    }
}