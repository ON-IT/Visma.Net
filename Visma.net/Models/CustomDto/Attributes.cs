using ONIT.VismaNetApi.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class Attributes : DtoProviderBase
    {
        public string value
        {
            get { return Get<string>(key: "attributeValue"); }
            set { Set(value, "attributeValue");}
        }

        public string id { 
            get { return Get<string>(key: "attributeId"); }
            set { Set(value, "attributeId");} 
        }

        [JsonProperty]
        public string description { get; private set; }
    }
}