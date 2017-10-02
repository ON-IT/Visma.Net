using ONIT.VismaNetApi.Models;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class SalesOrderData : BaseCrudDataClass<SalesOrder>
    {
        public SalesOrderData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.SalesOrder;
        }

        public override async Task Update(SalesOrder entity)
        {
            if (entity.orderType != "SO") // SO ordertypes are special.
            {
                await VismaNetApiHelper.Update(entity, entity.GetIdentificator(), ApiControllerUri, Authorization,$"{entity.orderType}/{entity.GetIdentificator()}");
            }
            else
            {
                await VismaNetApiHelper.Update(entity, entity.GetIdentificator(), ApiControllerUri, Authorization);
            }
        }
    }
}