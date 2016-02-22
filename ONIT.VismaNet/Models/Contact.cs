using System;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class Contact : DtoProviderBase, IHaveNumber, IHaveInternalId
    {
        public string displayName
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public bool active
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public EmployeeTitles title
        {
            get { return Get<EmployeeTitles>(); }
            set { Set(value); }
        }

        public string firstName
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string lastName
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string position
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string businessAccount
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public bool sameAsAccount
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public Address address
        {
            get { return Get<Address>(defaultValue:new Address()); }
            set { Set(value); }
        }

        public string email
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string web
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string phone1
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string phone2
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string phone3
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string fax
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public ContactMethods contactMethod
        {
            get { return Get<ContactMethods>(); }
            set { Set(value); }
        }

        public bool doNotCall
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public bool doNotFax
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public bool doNotEmail
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public bool doNotMail
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public bool noMassMail
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public bool noMarketing
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        [JsonProperty]
        public DateTime lastModifiedDateTime
        {
            get { return Get<DateTime>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public int contactId
        {
            get { return Get<int>(); }
            private set { Set(value); }
        }

        public string number => contactId.ToString();

        public int internalId => contactId;
    }
}