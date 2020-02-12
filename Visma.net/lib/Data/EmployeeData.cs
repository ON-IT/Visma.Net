using System;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class EmployeeData : BasePaginatedCrudDataClass<Employee>
    {
        internal EmployeeData(VismaNetAuthorization auth)
            : base(auth)
		{
		    ApiControllerUri = VismaNetControllers.Employee;
		}

        public override Task<Employee> Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public override Task Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
