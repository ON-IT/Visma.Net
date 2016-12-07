using System.Text;
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
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(name);
            if (!string.IsNullOrEmpty(email))
                builder.AppendLine(email);
            if (!string.IsNullOrEmpty(web))
                builder.AppendLine(web);
            if (!string.IsNullOrEmpty(phone1))
                builder.AppendLine(phone1);
            if (!string.IsNullOrEmpty(phone2))
                builder.AppendLine(phone2);
            if (!string.IsNullOrEmpty(fax))
                builder.AppendLine(fax);

            return builder.ToString();
        }
        public bool contactIdSpecified => contactId > 0;
    }
}