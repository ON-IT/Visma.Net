using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    /*    
    public class CustomerDocument
    {
        public Customer customer { get; set; }
        public string referenceNumber { get; set; }
        public string postPeriod { get; set; }
        public DateTime? documentDate { get; set; }
        public DateTime? documentDueDate { get; set; }
        public CustomerDocumentStatus status { get; set; }
        public string documentCurrency { get; set; }
        public double amount { get; set; }
        public double amountInCurrency { get; set; }
        public double balance { get; set; }
        public double balanceInCurrency { get; set; }
        public double cashDiscount { get; set; }
        public double cashDiscountInCurrency { get; set; }
        public string paymentMethod { get; set; }
        public string customerRefNumber { get; set; }
        public string description { get; set; }
        public DateTime lastModifiedDate { get; set; }
        public DateTime createdDate { get; set; }
    }*/

    public class CustomerDocument
    {
        public Account account { get; set; }
        public Subaccount subaccount { get; set; }
        public Branch branch { get; set; }
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
    
    public class Subaccount
    {
        public string description { get; set; }
        public int id { get; set; }
        public DateTime lastModifiedDateTime { get; set; }
        public Segment[] segments { get; set; }
    }
    public class Branch
    {
        public string number { get; set; }
        public string name { get; set; }
    }
    
}