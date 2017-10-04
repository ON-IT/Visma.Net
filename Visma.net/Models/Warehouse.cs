using ONIT.VismaNetApi.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Models
{
    public class Warehouse : DtoProviderBase, IProvideIdentificator
    {
		// TODO: Add all fields from warehouse
        public string warehouseID
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string description
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string GetIdentificator()
        {
            return warehouseID;
        }

    }
}
