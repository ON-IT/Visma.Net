using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Dynamic
{
    public class VismaNetDynamicEndpoint : DynamicObject
    {
        private readonly VismaNetAuthorization _auth;
        private readonly string _endpointName;

        internal VismaNetDynamicEndpoint(string endpointName, VismaNetAuthorization auth)
        {
            _endpointName = endpointName;
            _auth = auth;
        }
        
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (binder.Name.Equals("get", StringComparison.OrdinalIgnoreCase))
            {
                if (args != null && args.Length > 0)
                {
                    result = _Get($"{args[0]}");
                    return true;
                }
            }
            if (binder.Name.Equals("all", StringComparison.OrdinalIgnoreCase))
            {
                result = _All(binder, args);
                return true;
            }
            result = null;
            return false;
        }

        private async Task<dynamic> _Get(string argument)
        {
            if (!string.IsNullOrEmpty(argument))
            {
                return await VismaNetApiHelper.Get<JObject>(argument, $"controller/api/v1/{_endpointName}", _auth);
            }
            return await Task.FromResult(default(dynamic));
        }

        private async Task<dynamic> _All(InvokeMemberBinder binder, object[] args)
        {
            NameValueCollection nvc = null;
            if (binder.CallInfo.ArgumentCount > 0)
            {
                nvc = new NameValueCollection();
                foreach (
                    var keyValuePair in
                        binder.CallInfo.ArgumentNames.Select((s, i) => new KeyValuePair<string, string>(s, $"{args[i]}"))
                    )
                {
                    nvc.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }
            return await VismaNetApiHelper.GetAll<JObject>($"controller/api/v1/{_endpointName}", _auth, nvc);
        }
    }
}