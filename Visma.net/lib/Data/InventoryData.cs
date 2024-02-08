using ONIT.VismaNetApi.Models;
using ONIT.VismaNetApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
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

        public async Task<List<ItemClass>> GetAllItemClasses()
        {
            return await VismaNetApiHelper.GetAllItemClasses(Authorization);
        }

        public async Task<string> AddAttachmentToInventory(string inventoryNumber, byte[] byteArray, string fileName)
        {
            if (byteArray == default(byte[]))
                throw new ArgumentNullException(nameof(byteArray), "ByteArray is missing");
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(Path.GetExtension(fileName)))
                throw new ArgumentNullException(nameof(fileName), "File name must be provided and have an extention");
            return await VismaNetApiHelper.AddAttachmentToInventory(Authorization, inventoryNumber, byteArray, fileName);
        }

        public async Task<string> AddAttachmentToInventory(string inventoryNumber, Stream stream, string fileName)
        {
            if (stream == default(Stream))
                throw new ArgumentNullException(nameof(stream), "Stream is missing");
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(Path.GetExtension(fileName)))
                throw new ArgumentNullException(nameof(fileName), "File name must be provided and have an extention");

            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return await VismaNetApiHelper.AddAttachmentToInventory(Authorization, inventoryNumber, stream, fileName);
            }
        }
    }
}