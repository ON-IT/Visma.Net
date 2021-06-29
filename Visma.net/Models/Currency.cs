using ONIT.VismaNetApi.Lib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Models
{
    public class Currency : DtoProviderBase, IProvideIdentificator
    {
        public string id { get; set; }
        public string description { get; set; }

        public string GetIdentificator()
        {
            return id;
        }

        

    }
}
