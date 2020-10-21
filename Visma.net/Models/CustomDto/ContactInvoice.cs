using System.Text;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class ContactInvoice : DtoProviderBase
    {
        [JsonProperty] public int contactId { get; private set; }

        public string email
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }

        public string businessName
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }
        public string attention
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }
        
        public string phone1
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }
        public bool overrideContact
        {
            get => Get<bool>();
            set => Set(value);
        }


        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(businessName);
            if (!string.IsNullOrWhiteSpace(attention))
                builder.AppendLine(attention);
            if (!string.IsNullOrWhiteSpace(email))
                builder.AppendLine(email);
            if (!string.IsNullOrWhiteSpace(phone1))
                builder.AppendLine(phone1);
            return builder.ToString().Trim();
        }
    }
}