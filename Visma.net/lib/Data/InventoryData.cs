using ONIT.VismaNetApi.Models;
using ONIT.VismaNetApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class InventoryData : BasePaginatedCrudDataClass<Inventory>
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

        /// <summary>
        ///     Retrieves all entities with availability updated since given datetime from Visma.Net.
        /// </summary>
        /// <returns>List of all entities</returns>
        public async Task<List<Inventory>> GetAllAvailabilityUpdatedSince(DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
            {
                return await All();
            }
            else
            {
                return await Find(new NameValueCollection
                    {
                        {"availabilityLastModifiedDateTime", dateTime.ToString(VismaNetApiHelper.VismaNetDateTimeFormat)},
                        {"availabilityLastModifiedDateTimeCondition", ">"}
                    });
            }
        }
    }
}