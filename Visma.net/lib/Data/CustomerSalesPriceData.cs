using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Lib.Data;
using ONIT.VismaNetApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class CustomerSalesPriceData : BasePaginatedCrudDataClass<CustomerSalesPrice>
    {
        public CustomerSalesPriceData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.CustomerSalesPrices;
        }

        public override Task<CustomerSalesPrice> Add(CustomerSalesPrice entity)
        {
            throw new NotImplementedException("Not supported by /customersalesprice");
        }

        public override Task Update(CustomerSalesPrice entity)
        {
            throw new NotImplementedException("Not supported by /customersalesprice");
        }

        public override Task<CustomerSalesPrice> Get(string entityNumber)
        {
            throw new NotImplementedException("Not supported by /customersalesprice");
        }
    }
}
