using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models
{
    public class ReleasePayment : DtoProviderBase
    {
        public DtoValue type
        {
            get { return Get<DtoValue>(); }
            set { Set(value); }
        }
    }
}
