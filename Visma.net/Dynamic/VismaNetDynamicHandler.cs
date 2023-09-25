using System.Dynamic;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Dynamic
{
    public abstract class VismaNetDynamicHandler : DynamicObject
    {
        protected VismaNetAuthorization Auth;
        protected Visma.Net.SalesOrderNG.Helpers.VismaNetAuthorization AuthNG;

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if(string.Equals(binder.Name, "resources", System.StringComparison.OrdinalIgnoreCase))
            {
                result = new VismaNetDynamicEndpoint(null, Auth, true);
            } else if(string.Equals(binder.Name, "dynamic", System.StringComparison.OrdinalIgnoreCase))
            {
                result = new VismaNetDynamicEndpoint(null, Auth);
            }
            else
            {
                result = new VismaNetDynamicEndpoint(binder.Name, Auth);
            }
            return true;
        }
    }
}