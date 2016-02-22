using System;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class EmployeeData : BaseCrudDataClass<Employee>
    {
        internal EmployeeData(VismaNetAuthorization auth)
            : base(auth)
		{
		    ApiControllerUri = VismaNetControllers.Employee;
		}

        public override Task<Employee> AddAsyncTask(Employee entity)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsyncTask(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
