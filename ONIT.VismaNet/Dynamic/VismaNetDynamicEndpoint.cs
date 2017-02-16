using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Exceptions;
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
        #region Typed members

        public async Task<dynamic> Get(string argument)
        {
            if (!string.IsNullOrEmpty(argument))
            {
                return await VismaNetApiHelper.Get<JObject>(argument, $"controller/api/v1/{_endpointName}", _auth);
            }
            return await Task.FromResult(default(dynamic));
        }


        #endregion
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (binder.Name.Equals("all", StringComparison.OrdinalIgnoreCase))
            {
                result = _All(binder, args);
                return true;
            }
            result = null;
            return false;
        }
        #region Dynamic members

        private async Task<dynamic> _All(InvokeMemberBinder binder, object[] args)
        {
            if (binder.CallInfo.ArgumentCount != args.Length)
            {
                throw new InvalidArgumentsException("Please use only named arguments (like numberToRead: 5)");
            }
            NameValueCollection nvc = null;
            if (binder.CallInfo.ArgumentCount > 0)
            {
                nvc = new NameValueCollection();
                foreach (
                    var keyValuePair in
                        binder.CallInfo.ArgumentNames.Select((s, i) => new KeyValuePair<string, string>(s, FormatParameter(args[i])))
                    )
                {
                    nvc.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }
            return await VismaNetApiHelper.GetAll<JObject>($"controller/api/v1/{_endpointName}", _auth, nvc);
        }

        #endregion
        private static string FormatParameter(object o)
        {
            if (o == null) return null;
            if (o is DateTime)
            {
                return ((DateTime)o).ToString(VismaNetApiHelper.VismaNetDateTimeFormat);
            }
            return o.ToString();
        }
    }
}