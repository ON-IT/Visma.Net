using System;
using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class SupplierPOBalance : DtoProviderBase
    {
        public Supplier supplier { get; set; }
        public decimal totalPOOnHoldOrderTotal { get; set; }
        public decimal totalPOOnHoldLineTotal { get; set; }
        public decimal totalOpenPOOrderTotal { get; set; }
        public decimal totalOpenPOLineTotal { get; set; }
        public decimal totalClosedPOOrderTotal { get; set; }
        public decimal totalClosedPOLineTotal { get; set; }
        public DateTime? lastModifiedDateTime { get; set; }
    }


    public class CustomerBalance
    {
        public Customer customer { get; set; }
        public decimal balance { get; set; }
        public decimal totalOrder { get; set; }
        public decimal totalLoan { get; set; }
        public decimal totalSalePeriod { get; set; }
        public decimal totalSaleYear { get; set; }
        public decimal totalDiscountPeriod { get; set; }
        public decimal totalDiscountYear { get; set; }
        public DateTime lastModified { get; set; }
    }

 }
