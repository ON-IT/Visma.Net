﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;
using System;
using System.Collections.Generic;

namespace ONIT.VismaNetApi.Models
{
    public class Customer : DtoPaginatedProviderBase, IProvideIdentificator, IComparable<Customer>, IComparable
    {
        public Customer()
        {
            IgnoreProperties.Add(nameof(number));
        }

        /// <summary>
        ///     Create a new customer without autonumbering
        /// </summary>
        /// <param name="customerNumber"></param>
        public Customer(string customerNumber)
        {
            number = customerNumber;
        }

        public bool acceptAutoInvoices
        {
            get => Get<bool>();
            set => Set(value);
        }

        public string accountReference
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public List<Attributes> attributes
        {
            get => Get("attributeLines", new NotDto<List<Attributes>>(new List<Attributes>())?.Value);
            set => Set(new NotDto<List<Attributes>>(value), "attributeLines");
        }

        public string corporateId
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty] public DateTime createdDateTime { get; private set; }

        public int creditDaysPastDue
        {
            get => Get<int>();
            set => Set(value);
        }

        public decimal creditLimit
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public CreditTerms creditTerms
        {
            get => Get("creditTermsId", new CreditTerms());
            set => Set(value, "creditTermsId");
        }


        public CreditRule creditVerification
        {
            get => Get<CreditRule>();
            set => Set(value);
        }

        public string currencyId
        {
            get => Get<string>();
            set => Set(value);
        }

        public CustomerClass customerClass
        {
            get => Get("customerClassId", new CustomerClass());
            set => Set(value, "customerClassId");
        }

        public Address deliveryAddress
        {
            get => Get(defaultValue: new Address());
            set => Set(value);
        }

        public ContactInfo deliveryContact
        {
            get => Get(defaultValue: new ContactInfo());
            set => Set(value);
        }

        [JsonProperty]
        public List<DirectDebitLine> directDebitLines
        {
            get => Get(defaultValue: new List<DirectDebitLine>());
            set => Set(value);
        }

        [JsonProperty] public string errorInfo { get; private set; }

        [JsonProperty] public JObject extras { get; private set; }

        [JsonProperty] public CustomerGLAccountDto glAccounts {
            get => Get(defaultValue: new CustomerGLAccountDto());
            private set => Set(value); 
        }

        [JsonProperty] public int internalId { get; private set; }


        public Address invoiceAddress
        {
            get => Get(defaultValue: new Address());
            set => Set(value);
        }

        public ContactInfo invoiceContact
        {
            get => Get(defaultValue: new ContactInfo());
            set => Set(value);
        }

        public bool invoiceToDefaultLocation
        {
            get => Get<bool>();
            set => Set(value);
        }

        [JsonProperty] public DateTime lastModifiedDateTime { get; private set; }

        [JsonProperty] public LocationSummary location { get; private set; }

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

        public string note
        {
            get => Get<string>();
            set => Set(value);
        }
        public string gln
        {
            get => Get<string>();
            set => Set(value);
        }
        

        [JsonProperty]
        public string number
        {
            get => Get<string>();
            set => Set(value);
        }

        public bool overrideNumberSeries
        {
            get => Get<bool>();
            set => Set(value);
        }

        public bool overrideWithClassValues
        {
            get => Get(defaultValue: new NotDto<bool>(false)).Value;
            set => Set(new NotDto<bool>(value));
        }

        public NumberName parentRecord
        {
            get => Get<NumberName>("parentRecordNumber");
            set => Set(value, "parentRecordNumber");
        }

        /*
        [JsonProperty("defaultPaymentMethodId")]
        internal string defaultPaymentMethodId
        {
            get => defaultPaymentMethod?.paymentMethodId;
            set => defaultPaymentMethod = new CustomerPaymentMethod(value, true);
        }*/

        public CustomerPaymentMethod defaultPaymentMethod
        {
            get => Get<CustomerPaymentMethod>();
            set => Set(value);
        }

        public DescriptiveDto priceClass
        {
            get => Get("priceClassId", new DescriptiveDto());
            set => Set(value, "priceClassId");
        }

        public bool printInvoices
        {
            get => Get<bool>();
            set => Set(value);
        }

        public bool printMultiCurrencyStatements
        {
            get => Get<bool>();
            set => Set(value);
        }

        public bool printStatements
        {
            get => Get<bool>();
            set => Set(value);
        }

        public bool sendInvoicesByEmail
        {
            get => Get<bool>();
            set => Set(value);
        }

        public bool sendStatementsByEmail
        {
            get => Get<bool>();
            set => Set(value);
        }

        public StatementTypes statementType
        {
            get => Get<StatementTypes>();
            set => Set(value);
        }

        public CustomerStatus status
        {
            get => Get<CustomerStatus>();
            set => Set(value);
        }


        public string vatRegistrationId
        {
            get => Get<string>();
            set => Set(value);
        }

        public VatZone vatZone
        {
            get => Get<VatZone>("vatZoneId");
            set => Set(value, "vatZoneId");
        }


        public int CompareTo(object obj)
        {
            var otherCustomer = (Customer)obj;
            if (otherCustomer == null)
                return 0;
            return string.Compare(name, otherCustomer.name, StringComparison.Ordinal);
        }

        public int CompareTo(Customer other)
        {
            return string.Compare(name, other.name, StringComparison.Ordinal);
        }

        public string GetIdentificator()
        {
            return number;
        }

        internal override void PrepareForUpdate()
        {
            base.PrepareForUpdate();
            foreach (var line in directDebitLines)
            {
                line.operation = ApiOperation.Update;
            }
        }
    }
}