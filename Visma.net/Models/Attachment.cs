using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ONIT.VismaNetApi.Models
{
	public class Attachment
	{	
        [JsonProperty]
		public string name { get; private set; }
        [JsonProperty]
		public string id { get; private set;  }
        [JsonProperty]
		public int revision { get; private set;  }
	}
}
