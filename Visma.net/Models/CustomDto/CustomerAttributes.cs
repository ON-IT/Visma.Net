using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models
{
    public class CustomerAttributes : DtoProviderBase
    {
        public string attributeId {  
            get { return Get<string>(); }
            set { Set(value); }
        }
        public string attributeValue { 
            get { return Get<string>(); }
            set { Set(value); }
        }
    }
}