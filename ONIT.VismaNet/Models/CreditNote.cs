using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class CreditNote : InvoiceBase
    {
        internal override void PrepareForUpdate()
        {
            foreach (var invoiceLine in invoiceLines)
            {
                invoiceLine.operation = ApiOperation.Update;
            }
        }
    } 
}