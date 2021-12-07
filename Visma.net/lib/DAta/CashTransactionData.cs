using ONIT.VismaNetApi.Models;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{

  public class CashTransactionData : BasePaginatedCrudDataClass<CashTransaction>
  {
    internal CashTransactionData(VismaNetAuthorization auth) : base(auth)
    {
      ApiControllerUri = VismaNetControllers.CashTransaction;
    }

    protected CashTransactionData() : base(null)
    {
      ApiControllerUri = VismaNetControllers.CashTransaction;
    }

    public async Task<VismaActionResult> Release(CashTransaction payment)
    {
      return await VismaNetApiHelper.Action(Authorization, ApiControllerUri, payment.GetIdentificator(), "release", new { type = new DtoValue(payment.refNbr) });
    }

    public async Task<VismaActionResult> Void(CashTransaction payment)
    {
      return await VismaNetApiHelper.Action(Authorization, ApiControllerUri, payment.GetIdentificator(), "void", new { type = new DtoValue(payment.refNbr) });
    }
  }
}
