using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class CreditNote : InvoiceBase
    {
        /// <summary>
        /// Create a new credit note without auto numbering
        /// </summary>
        /// <param name="referenceNumber"></param>
        public CreditNote(string referenceNumber)
        {
            this.referenceNumber = referenceNumber;
        }

        public CreditNote()
        {
            IgnoreProperties.Add(nameof(this.referenceNumber));
        }

        internal override void PrepareForUpdate()
        {
            foreach (var invoiceLine in invoiceLines)
            {
                invoiceLine.operation = ApiOperation.Update;
            }
        }
    } 
}