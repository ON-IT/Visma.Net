using System.Text;
using ONIT.VismaNetApi.Annotations;
using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class Address : DtoProviderBase
    {
        public Address()
        {
            RequiredFields.Add("county", new DtoValue(null));
        }
        public int addressId
        {
            get { return Get<int>(); }
            set { Set(value); }
        }

        public string addressLine1
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string addressLine2
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string addressLine3
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string postalCode
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string city
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public Country country
        {
            get { return Get("countryId", new Country()); }
            set { Set(value, "countryId"); }
        }

        public DescriptiveDto county
        {
            get { return Get<DescriptiveDto>(); }
            set {  Set(value);}
        }

        public State state
        {
            get { return Get("stateId", new State()); }
            set { Set(value, "stateId"); }
        }

        public bool addressIdSpecified
        {
            get { return addressId > 0; }
        }

        public bool overrideAddress
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            if(!string.IsNullOrWhiteSpace(addressLine1))
                builder.AppendLine(addressLine1);
            if (!string.IsNullOrWhiteSpace(addressLine2))
                builder.AppendLine(addressLine2);
            if (!string.IsNullOrWhiteSpace(addressLine3))
                builder.AppendLine(addressLine3);
            if (!string.IsNullOrWhiteSpace(postalCode) && !string.IsNullOrWhiteSpace(city))
            {
                builder.AppendLine($"{postalCode} {city}");
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(postalCode))
                    builder.AppendLine(postalCode);
                if (!string.IsNullOrWhiteSpace(city))
                    builder.AppendLine(city);
            }
            return builder.ToString().Trim();
        }
    }
}