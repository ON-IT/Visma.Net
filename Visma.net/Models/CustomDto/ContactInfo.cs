using System.Text;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class ContactInfo : DtoProviderBase
    {
       /* public bool overrideContact
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }
*/
        [JsonProperty]
        public int contactId
        {
            get;
            private set;
        }

        public string name
        {
            get { return Get<string>(); }
            set { Set(value?.Trim()); }
        }

        public string attention
        {
            get { return Get<string>(); }
            set { Set(value?.Trim()); }
        }

        public string email
        {
            get { return Get<string>(); }
            set { Set(value?.Trim()); }
        }

        public string web
        {
            get { return Get<string>(); }
            set { Set(value?.Trim()); }
        }

        public string phone1
        {
            get { return Get<string>(); }
            set { Set(value?.Trim()); }
        }

        public string phone2
        {
            get { return Get<string>(); }
            set { Set(value?.Trim()); }
        }

        public string fax
        {
            get { return Get<string>(); }
            set { Set(value?.Trim()); }
        }
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(name);
            if (!string.IsNullOrWhiteSpace(attention))
                builder.AppendLine(attention);
            if (!string.IsNullOrWhiteSpace(email))
                builder.AppendLine(email);
            if (!string.IsNullOrWhiteSpace(web))
                builder.AppendLine(web);
            if (!string.IsNullOrWhiteSpace(phone1))
                builder.AppendLine(phone1);
            if (!string.IsNullOrWhiteSpace(phone2))
                builder.AppendLine(phone2);
            if (!string.IsNullOrWhiteSpace(fax))
                builder.AppendLine(fax);

            return builder.ToString().Trim();
        }
        /*public bool contactIdSpecified => contactId > 0;*/
    }
}