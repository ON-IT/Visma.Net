using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models
{
    public class Visibility : DtoProviderBase
    {
        public bool visibleInGl { get { return Get<bool>(); } set { Set(value); } }
        public bool visibleInAp { get { return Get<bool>(); } set { Set(value); } }
        public bool visibleInAr { get { return Get<bool>(); } set { Set(value); } }
        public bool visibleInSo { get { return Get<bool>(); } set { Set(value); } }
        public bool visibleInPo { get { return Get<bool>(); } set { Set(value); } }
        public bool visibleInEp { get { return Get<bool>(); } set { Set(value); } }
        public bool visibleInIn { get { return Get<bool>(); } set { Set(value); } }
        public bool visibleInCa { get { return Get<bool>(); } set { Set(value); } }
        public bool visibleInCr { get { return Get<bool>(); } set { Set(value); } }
    }
}