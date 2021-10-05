using System;
using System.Collections.Generic;
using System.Text;

namespace ONIT.VismaNetApi.Models.Enums
{
    public enum PurchaseReceiptLineType
    {
        Undefined = 0,
        GoodsForInventory = 1,
        GoodsForSalesOrder = 2,
        GoodsForReplenishment = 3,
        GoodsForDropShip = 4,
        NonStockForDropShip = 5,
        NonStockForSalesOrder = 6,
        NonStock = 7,
        Service = 8,
        Freight = 9,
        Description = 10
    }
}
