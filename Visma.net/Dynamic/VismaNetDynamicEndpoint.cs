using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Exceptions;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Dynamic
{
    public class VismaNetDynamicEndpoint : DynamicObject
    {
        private readonly VismaNetAuthorization _auth;
        private readonly bool _isResourceEndpoint;
        private readonly string _endpointName;
        private readonly string _base;

        internal VismaNetDynamicEndpoint(string endpointName, VismaNetAuthorization auth, bool isResourceEndpoint = false)
        {
            _endpointName = endpointName;
            _base = isResourceEndpoint ? "resources/v1/" : "controller/api/v1/";
            _auth = auth;
            _isResourceEndpoint = isResourceEndpoint;
        }
        #region Typed members

        public async Task<dynamic> Get(string argument = null)
        {
            if (!string.IsNullOrEmpty(argument))
            {
                return await VismaNetApiHelper.Get<JObject>(argument, $"{_base}{_endpointName}", _auth);
            } else
            {
                return await VismaNetApiHelper.Get<JObject>(argument, $"{_base}{_endpointName}", _auth);

            }
        }

        public async Task<Stream> GetStream()
        {
            return await VismaNetApiHelper.GetStream($"{_base}{_endpointName}", _auth);
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

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (string.IsNullOrEmpty(_endpointName))
            {
                result = new VismaNetDynamicEndpoint(binder.Name.ToLower(), _auth, _isResourceEndpoint);
                return true;
            }
            else
            {
                result = new VismaNetDynamicEndpoint($"{_endpointName}/{binder.Name.ToLower()}", _auth, _isResourceEndpoint);
                return true;
            }
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            var index = indexes[0]?.ToString().ToLower();
            if (string.IsNullOrEmpty(_endpointName))
            {
                result = new VismaNetDynamicEndpoint(index, _auth, _isResourceEndpoint);
                return true;
            }
            else
            {
                result = new VismaNetDynamicEndpoint($"{_endpointName}/{index}", _auth, _isResourceEndpoint);
                return true;
            }
        }
        #region Dynamic members

        private async Task<dynamic> _All(InvokeMemberBinder binder, object[] args)
        {
            if (binder.CallInfo.ArgumentCount != args.Length)
            {
                throw new InvalidArgumentsException("Please use only named arguments (like numberToRead: 5)");
            }
            if (string.IsNullOrEmpty(_endpointName))
            {
                throw new Exception("Endpoint name is missing. You are probably using the dynamic endpoint wrong.");
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
            return await VismaNetApiHelper.GetAll<JObject>($"{_base}{_endpointName}", _auth, nvc);
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