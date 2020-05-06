using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Lib.Data;
using ONIT.VismaNetApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class CustomerSalesPriceData : BasePaginatedCrudDataClass<CustomerSalesPrice>
    {
        public CustomerSalesPriceData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.CustomerSalesPrices;
        }
    }
}
