using System.Dynamic;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Dynamic
{
    public abstract class VismaNetDynamicHandler : DynamicObject
    {
        protected VismaNetAuthorization Auth;

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = new VismaNetDynamicEndpoint(binder.Name, Auth);
            return true;
        }
    }
}