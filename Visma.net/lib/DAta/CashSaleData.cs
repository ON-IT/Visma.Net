using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class CashSaleData : BasePaginatedCrudDataClass<CashSale>
    {
        internal CashSaleData(VismaNetAuthorization auth)
            : base(auth)
		{
		    ApiControllerUri = VismaNetControllers.CashSale;
		}
    }
}
