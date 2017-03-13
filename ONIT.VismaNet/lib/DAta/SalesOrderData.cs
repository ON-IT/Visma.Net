using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class SalesOrderData : BaseCrudDataClass<SalesOrder>
    {
        public SalesOrderData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.SalesOrder;
        }
    }
}