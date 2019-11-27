using System;
using System.Collections.Generic;
using System.Text;

namespace ONIT.VismaNetApi.Models.Enums
{
    public enum TransferOrderType
    {
        Undefined = 0,
        CreditNote = 1,
        DebitNote = 3,
        Invoice = 4,
        QuoteOrder = 5,
        RMAOrder = 6,
        SalesOrder = 7,
        StandardOrder = 8,
        TransferOrder = 9
    }
}
