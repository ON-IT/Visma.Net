using System.Collections.Generic;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models;
using ONIT.VismaNetApi.Models.CustomDto;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class SupplierData : BasePaginatedCrudDataClass<Supplier>
    {
        internal SupplierData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.Suppliers;
        }

        public async Task<List<SupplierPOBalance>> GetBalanceForAll()
        {
            return
                await
                    VismaNetApiHelper.Get<List<SupplierPOBalance>>("pobalance", VismaNetControllers.Suppliers,
                        Authorization);
        }

        public async Task<SupplierPOBalance> GetBalanceFor(string supplierNumber)
        {
            return
                await
                    VismaNetApiHelper.Get<SupplierPOBalance>(
                        string.Format("{0}/pobalance", supplierNumber),
                        VismaNetControllers.Suppliers,
                        Authorization);
        }
    }
}