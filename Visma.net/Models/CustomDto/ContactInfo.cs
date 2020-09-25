using System.Text;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class ContactInfo : DtoProviderBase
    {
        public string attention
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }

        [JsonProperty] public int contactId { get; private set; }

        public string email
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }

        public string fax
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }

        public string name
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }

        public string phone1
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }

        public string phone2
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }
        public string phone3
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }

        public string web
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }
        public string title
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }

        public string firstName
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }

        public string midName
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }
        public string lastName
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }
        public string employeeContact
        {
            get => Get<string>();
            set => Set(value?.Trim());
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
            if (!string.IsNullOrWhiteSpace(phone3))
                builder.AppendLine(phone3);
            if (!string.IsNullOrWhiteSpace(fax))
                builder.AppendLine(fax);
            if (!string.IsNullOrWhiteSpace(employeeContact))
                builder.AppendLine(employeeContact);
            if (!string.IsNullOrWhiteSpace(lastName))
                builder.AppendLine(lastName);
            if (!string.IsNullOrWhiteSpace(midName))
                builder.AppendLine(midName);
            if (!string.IsNullOrWhiteSpace(firstName))
                builder.AppendLine(firstName);
            if (!string.IsNullOrWhiteSpace(title))
                builder.AppendLine(title);

            return builder.ToString().Trim();
        }

        /*public bool contactIdSpecified => contactId > 0;*/
    }
}