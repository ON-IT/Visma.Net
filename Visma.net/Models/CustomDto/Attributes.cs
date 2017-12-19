using ONIT.VismaNetApi.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class Attributes : DescriptiveDto
    {
        public string value { get; set; }
    }
}
namespace ONIT.VismaNetApi.Models { 

    public class CustomerAttributes : DtoProviderBase
    {
        public string attributeId {  
            get { return Get<string>(); }
            set { Set(value); }
}
        public string attributeValue { 
            get { return Get<string>(); }
            set { Set(value); }
        }
    }
}
