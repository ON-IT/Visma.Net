namespace ONIT.VismaNetApi.Lib
{
    internal static class VismaNetControllers
    {
        // Security
        public const string UserContexts = "security/api/v1/token/usercontexts";
        public const string Token = "security/api/v2/token";

        // Financials
        public const string SupplierInvoices = "controller/api/v1/supplierinvoice";
        public const string CashSale = "controller/api/v1/cashsale";
        public const string Customers = "controller/api/v1/customer";
        public const string Suppliers = "controller/api/v1/supplier";
        public const string CustomerInvoice = "controller/api/v1/customerinvoice";
        public const string CreditNote = "controller/api/v1/creditnote";
        public const string CustomerDocument = "controller/api/v1/customerdocument";
        public const string Dimensions = "controller/api/v1/dimension";
        public const string Inventory = "controller/api/v1/inventory";
        public const string InventorySummary = "controller/api/v1/inventorysummary";
        public const string JournalTransaction = "controller/api/v1/journaltransaction";
        public const string FinAccount = "controller/api/v1/account";
        public const string Employee = "controller/api/v1/employee";
        public const string Shipments = "controller/api/v1/shipment";
        public const string Contacts = "controller/api/v1/contact";
        public const string Project = "controller/api/v1/project";
        public const string SalesOrder = "controller/api/v1/salesorder";
        public const string Subaccount = "controller/api/v1/subaccount";
        public const string Payment = "controller/api/v1/payment";
        public const string Branch = "controller/api/v1/branch";
		public const string Attachment = "controller/api/v1/attachment";
        public const string Warehouse = "controller/api/v1/warehouse";
        public const string Location = "controller/api/v1/location";

        public const string OAuthAuthorize = "resources/oauth/authorize";
    }
}