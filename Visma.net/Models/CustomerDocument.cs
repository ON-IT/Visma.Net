using System;
using ONIT.VismaNetApi.Models.CustomDto;

namespace ONIT.VismaNetApi.Models
{
   public class CustomerDocument
    {
        public Account account { get; set; }
        public Subaccount subaccount { get; set; }
        public CondensedBranch branch { get; set; }
        public DateTime documentDueDate { get; set; }
        public Customer customer { get; set; }
        public string documentType { get; set; }
        public string referenceNumber { get; set; }
        public string postPeriod { get; set; }
        public string financialPeriod { get; set; }
        public DateTime documentDate { get; set; }
        public string status { get; set; }
        public string currencyId { get; set; }
        public decimal amount { get; set; }
        public decimal amountInCurrency { get; set; }
        public decimal balance { get; set; }
        public decimal balanceInCurrency { get; set; }
        public decimal cashDiscount { get; set; }
        public decimal cashDiscountInCurrency { get; set; }
        public string invoiceText { get; set; }
        public DateTime lastModifiedDateTime { get; set; }
        public DateTime createdDateTime { get; set; }
        public string note { get; set; }
        public decimal vatTotal { get; set; }
        public decimal vatTotalInCurrency { get; set; }
        public Location location { get; set; }
    }
    
   
    public class CondensedBranch
    {
        public string number { get; set; }
        public string name { get; set; }
    }
    
}