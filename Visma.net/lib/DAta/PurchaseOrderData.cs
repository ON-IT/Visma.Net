﻿using ONIT.VismaNetApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class PurchaseOrderData : BasePaginatedCrudDataClass<PurchaseOrder>
    {
        public PurchaseOrderData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.PurchaseOrder;
        }

        public override async Task Update(PurchaseOrder entity)
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

        public override async Task<PurchaseOrder> Add(PurchaseOrder entity)
        {
          PurchaseOrder rsp;
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

        public async Task<PurchaseOrder> Get(string entityNumber, string orderType = null)
        {
          PurchaseOrder rsp;
            if (orderType == null || orderType == "SO") // SO ordertypes are special.
            {
                rsp = await VismaNetApiHelper.Get<PurchaseOrder>(entityNumber, ApiControllerUri, Authorization);
            }
            else
            {
                rsp = await VismaNetApiHelper.Get<PurchaseOrder>(entityNumber, ApiControllerUri, Authorization, $"{orderType}/{entityNumber}");
            }
            rsp.InternalPrepareForUpdate();
            return rsp;
        }
        public async Task AddAttachment(PurchaseOrder PurchaseOrder, byte[] data, string filename)
        {
            await VismaNetApiHelper.AddAttachment(Authorization, ApiControllerUri, $"orderType/{PurchaseOrder.orderType}/{PurchaseOrder.orderNbr}", data, filename);
        }

        public async Task AddAttachment(PurchaseOrder PurchaseOrder, int lineNumber, byte[] data, string filename)
        {
            await VismaNetApiHelper.AddAttachment(Authorization, ApiControllerUri, $"orderType/{PurchaseOrder.orderType}/{PurchaseOrder.orderNbr}/{lineNumber}", data, filename);
        }

        public async Task<CreateShipmentActionResult> CreateShipment(string entityNumber, CreateShipment cs)
        {
            return await VismaNetApiHelper.CreateShipmentAction(Authorization, ApiControllerUri, entityNumber, "createShipment", cs);
        }
    }
}