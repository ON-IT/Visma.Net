using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;

namespace ONIT.VismaNetApi.Models
{
    public class Location : DtoProviderBase, IProvideIdentificator
    {
        public string baccountId
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string locationId
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string locationName
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public bool active
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public bool addressIsSameAsMain
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public Address address { get { return Get<Address>(); } set { Set(value); } }

        public bool contactIsSameAsMain
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public ContactInfo contact { get { return Get<ContactInfo>(); } set { Set(value); } }

        public string vatRegistrationId
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public VatZone vatZone
        {
            get { return Get<VatZone>("vatZoneId"); }
            set { Set(value); }
        }

        public string ediCode
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string gln
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string GetIdentificator()
        {
            return baccountId;
        }
    }
}
