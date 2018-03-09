using ONIT.VismaNetApi.Models;
using ONIT.VismaNetApi.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class InventoryData : BaseCrudDataClass<Inventory>
    {
        public InventoryData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.Inventory;
        }

        public async Task<List<InventorySummary>> InventorySummary(string entityNumber)
        {
            return await VismaNetApiHelper.FetchInventorySummaryForItem(entityNumber, Authorization);
        }

        public async Task<List<CustomerSalesPrice>> CustomerSalesPrices(string entityNumber, PriceType priceType = PriceType.Undefined)
        {
            return await VismaNetApiHelper.FetchCustomerSalesPricesForItem(entityNumber, Authorization, priceType);
        }
    }
}