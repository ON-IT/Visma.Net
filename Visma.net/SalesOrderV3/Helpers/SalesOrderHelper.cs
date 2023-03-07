using ONIT.VismaNetApi.SalesOrderV3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONIT.VismaNetApi.SalesOrderV3.Helpers
{
    public class SalesOrderHelper
    {
        public static NewSalesOrderCommand CreateV3SalesOrder(ONIT.VismaNetApi.Models.SalesOrder oldOrder)
        {
            NewSalesOrderCommand newOrder = new NewSalesOrderCommand();

            return newOrder;
        }
    }
}
