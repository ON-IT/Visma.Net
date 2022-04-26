using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using JsonDiffPatchDotNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;

namespace Visma.net.tests
{
    public static class VismaNetTestHelpers
    {
        public static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ",
            DateParseHandling = DateParseHandling.DateTime,
            Converters =
            {
                new StringEnumConverter()
            },
            NullValueHandling = NullValueHandling.Ignore
        };

        internal static JToken CreateDtoDiff<T>(string x, string y) where T : DtoProviderBase
        {
            var inventory = JsonConvert.DeserializeObject<T>(x, SerializerSettings);
            var update = inventory.ToDto();
            var updateToken = JToken.Parse(JsonConvert.SerializeObject(update, SerializerSettings).ToLower());
            var controlToken = JToken.Parse(y.ToLower());
            var jdp = new JsonDiffPatch();
            var patch = jdp.Diff(updateToken, controlToken);
            var log = $"{patch}" + Environment.NewLine + Environment.NewLine + $"{updateToken}" + Environment.NewLine +
                                Environment.NewLine + $"{controlToken}";
            Debug.WriteLineIf(patch != null, log);
            return patch;
        }

        public static JToken RemoveFields(this JToken token, params string[] fields)
        {
            JContainer container = token as JContainer;
            if (container == null) return token;

            List<JToken> removeList = new List<JToken>();
            foreach (JToken el in container.Children())
            {
                JProperty p = el as JProperty;
                if (p != null && fields.Contains(p.Name))
                {
                    removeList.Add(el);
                }
                el.RemoveFields(fields);
            }

            foreach (JToken el in removeList)
            {
                el.Remove();
            }

            return token;
        }
    }
}