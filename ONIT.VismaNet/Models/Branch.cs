using System;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;

namespace ONIT.VismaNetApi.Models
{
    public class Branch : DtoProviderBase, IProvideIdentificator
    {
        public string number { get { return Get<string>();} set { Set(value); } }
        public string name { get { return Get<string>(); } set { Set(value); } }
        public Address mainAddress { get { return Get<Address>(); } set { Set(value); } }
        public ContactInfo mainContact { get { return Get<ContactInfo>(); } set { Set(value); } }
        public Address deliveryAddress { get { return Get<Address>(); } set { Set(value); } }
        public ContactInfo deliveryContact { get { return Get<ContactInfo>(); } set { Set(value); } }
        public string corporateId { get { return Get<string>(); } set { Set(value); } }
        public string vatRegistrationId { get { return Get<string>(); } set { Set(value); } }
        public IdName defaultCountry { get { return Get<IdName>(); } set { Set(value); } }
        public DescriptiveDto industryCode { get { return Get<DescriptiveDto>(); } set { Set(value); } }
        public DescriptiveDto currency { get { return Get<DescriptiveDto>(); } set { Set(value); } }
        public VatCode vatZone { get { return Get<VatCode>("vatZoneId", new VatCode()); } set { Set(value, "vatZoneId"); } }
        public DateTime lastModifiedDateTime { get { return Get<DateTime>(); } private set { Set(value); } }
        public string GetIdentificator()
        {
            return number;
        }
    }
}
