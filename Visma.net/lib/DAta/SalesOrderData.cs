using ONIT.VismaNetApi.Models;
using System.Collections.Generic;
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
                await VismaNetApiHelper.Update(entity, entity.GetIdentificator(), ApiControllerUri, Authorization, $"{entity.orderType}/{entity.GetIdentificator()}");
            }
            else
            {
                await VismaNetApiHelper.Update(entity, entity.GetIdentificator(), ApiControllerUri, Authorization);
            }
        }

        public override async Task<SalesOrder> Add(SalesOrder entity)
        {
            SalesOrder rsp;
            if (entity.orderType != "SO")
            {
                rsp = await VismaNetApiHelper.Create(entity, ApiControllerUri, Authorization, $"{ApiControllerUri}/{entity.orderType}");
            }
            else
            {
                rsp = await VismaNetApiHelper.Create(entity, ApiControllerUri, Authorization);
            }
            rsp.InternalPrepareForUpdate();
            return rsp;
        }

        public async Task<SalesOrder> Get(string entityNumber, string orderType = null)
        {
            SalesOrder rsp;
            if (orderType == null || orderType == "SO") // SO ordertypes are special.
            {
                rsp = await VismaNetApiHelper.Get<SalesOrder>(entityNumber, ApiControllerUri, Authorization);
            }
            else
            {
                rsp = await VismaNetApiHelper.Get<SalesOrder>(entityNumber, ApiControllerUri, Authorization, $"{orderType}/{entityNumber}");
            }
            rsp.InternalPrepareForUpdate();
            return rsp;
        }
        public async Task AddAttachment(SalesOrder salesOrder, byte[] data, string filename)
        {
            await VismaNetApiHelper.AddAttachment(Authorization, ApiControllerUri, $"orderType/{salesOrder.orderType}/{salesOrder.orderNo}", data, filename);
        }

        public async Task AddAttachment(SalesOrder salesOrder, int lineNumber, byte[] data, string filename)
        {
            await VismaNetApiHelper.AddAttachment(Authorization, ApiControllerUri, $"orderType/{salesOrder.orderType}/{salesOrder.orderNo}/{lineNumber}", data, filename);
        }
    }
}