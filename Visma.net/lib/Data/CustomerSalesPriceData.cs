using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class CustomerSalesPriceData : BasePaginatedCollectionDataClass<CustomerSalesPrice>
    {
        public CustomerSalesPriceData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.CustomerSalesPrices;
        }
    }
}
