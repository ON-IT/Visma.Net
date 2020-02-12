using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;
using System;

namespace ONIT.VismaNetApi.Models
{
    public class SupplierDocument : DtoPaginatedProviderBase, IProvideIdentificator
    {
        public Account account { get; set; }
        public Subaccount subaccount { get; set; }
        public double amount { get; set; }
        public double amountInCurrency { get; set; }
        public NumberName branch { get; set; }
        public NumberName supplier { get; set; }
        public SupplierDocumentType documentType { get; set; }
        public string referenceNumber { get; set; }
        public string postPeriod { get; set; }
        public string financialPeriod { get; set; }
        public DateTime date { get; set; }
        public DateTime origInvoiceDate { get; set; }
        public DateTime dueDate { get; set; }
        public string approvalStatus { get; set; }
        public string status { get; set; }
        public string currencyId { get; set; }
        public double balance { get; set; }
        public double balanceInCurrency { get; set; }
        public double cashDiscount { get; set; }
        public double cashDiscountInCurrency { get; set; }
        public PaymentMethod paymentMethod { get; set; }
        public string supplierReference { get; set; }
        public string description { get; set; }
        public DateTime createdDateTime { get; set; }
        public DateTime lastModifiedDateTime { get; set; }
        public string note { get; set; }
        public string closedFinancialPeriod { get; set; }
        public IdName location { get; set; }
        public double vatTotal { get; set; }
        public double vatTotalInCurrency { get; set; }
        public NumberName branchNumber { get; set; }
        public DateTime payDate { get; set; }
        public string paymentMessage { get; set; }
        public string errorInfo { get; set; }

        public string GetIdentificator()
        {
            return this.referenceNumber;
        }
    }
}
