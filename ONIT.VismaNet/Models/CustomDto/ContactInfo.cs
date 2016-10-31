using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class ContactInfo : DtoProviderBase
    {
        public int contactId
        {
            get { return Get<int>(); }
            set { Set(value); }
        }

        public string name
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string attention
        {
            get { return Get<string>(); }
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

        public string fax
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public bool contactIdSpecified => contactId > 0;
    }
}