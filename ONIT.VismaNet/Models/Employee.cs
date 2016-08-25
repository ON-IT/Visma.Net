using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;

namespace ONIT.VismaNetApi.Models
{
    public class Employee : DtoProviderBase, IHaveNumber, IHaveInternalId
    {
            public int employeeId { get { return Get<int>(); } set { Set(value); } }
            public string employeeNumber { get { return Get<string>(); } set { Set(value); } }
            public string employeeName { get { return Get<string>(); } set { Set(value); } }
            public string status { get { return Get<string>(); } set { Set(value); } }
            public ContactInfo contact { get { return Get<ContactInfo>(defaultValue:new ContactInfo()); } set { Set(value); } }
            public Address address { get { return Get<Address>(defaultValue: new Address()); } set { Set(value); } }

        public string number
        {
            get
            {
                return employeeNumber;
            }
        }

        public int internalId
        {
            get
            {
                return employeeId;
            }
        }
    }
}
