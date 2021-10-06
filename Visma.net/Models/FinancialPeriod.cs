using System;
using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models
{
    public class FinancialPeriod : DtoProviderBase
    {
        public int year
        {
            get { return Get<int>(); }
            set { Set(value); }
        }

        public string period
        {
            get { return Get<string>(); }
            set { Set(value); }
        }
        public DateTime startDate
        {
            get { return Get<DateTime>(); }
            set { Set(value); }
        }
        public DateTime endDate
        {
            get { return Get<DateTime>(); }
            set { Set(value); }
        }
        public string description
        {
            get { return Get<string>(); }
            set { Set(value); }
        }
        public bool active
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }
        public bool closedInSupplierLedger
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }
        public bool closedInCustomerLedger
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }
        public bool closedInInventoryManagement
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }
        public bool closedInGeneralLedger
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }
        public bool closedInCashManagement
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }
        public bool closedInFixedAssets
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }
    }
}