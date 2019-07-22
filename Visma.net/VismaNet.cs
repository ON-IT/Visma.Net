using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Dynamic;
using ONIT.VismaNetApi.Exceptions;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Lib.Data;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi
{
    [ComVisible(true)]
    public class VismaNet : VismaNetDynamicHandler
    {
        public readonly CashSaleData CashSale;
        public readonly CustomerDocumentData CustomerDocument;
        public readonly CustomerInvoiceData CustomerInvoice;
        public readonly CustomerData Customer;
        public readonly DimensionData Dimension;
        public readonly SupplierInvoiceData SupplierInvoice;
        public readonly SupplierData Supplier;
        public readonly InventoryData Inventory;
        public readonly FinAccountData Account;
        public readonly EmployeeData Employee;
        public readonly CreditNoteData CreditNote;
        public readonly ShipmentData Shipment;
        public readonly ContactData Contact;
        public readonly ProjectData Project;
        public readonly SalesOrderData SalesOrder;
        public readonly JournalTransactionData JournalTransaction;
        public readonly PaymentData Payment;
        public readonly BranchData Branch;
        public readonly WarehouseData Warehouse;
        public readonly LocationData Location;
        public readonly SubaccountData Subaccount;

        public readonly CustomerPaymentData CustomerPayment;

        /// <summary>
        ///     Creates a connection using token.
        /// </summary>
        /// <param name="companyId">Company context</param>
        /// <param name="token">The predefined token from Visma.net</param>
        /// <param name="branchId">Branch ID to work with in the Visma.net Company (optional)</param>
        public VismaNet(int companyId, string token, int branchId = 0)
        {
            if (string.IsNullOrEmpty(token))
                throw new InvalidArgumentsException("Token is missing");

            Auth = new VismaNetAuthorization
            {
                Token = token,
                CompanyId = companyId,
                BranchId = branchId
            };
            Customer = new CustomerData(Auth);
            CustomerInvoice = new CustomerInvoiceData(Auth);
            Supplier = new SupplierData(Auth);
            SupplierInvoice = new SupplierInvoiceData(Auth);
            CashSale = new CashSaleData(Auth);
            CustomerDocument = new CustomerDocumentData(Auth);
            Dimension = new DimensionData(Auth);
            Inventory = new InventoryData(Auth);
            JournalTransaction = new JournalTransactionData(Auth);
            Account = new FinAccountData(Auth);
            Employee = new EmployeeData(Auth);
            CreditNote = new CreditNoteData(Auth);
            Shipment = new ShipmentData(Auth);
            Contact = new ContactData(Auth);
            Project = new ProjectData(Auth);
            SalesOrder = new SalesOrderData(Auth);
            Payment = new PaymentData(Auth);
            Branch = new BranchData(Auth);
            Warehouse = new WarehouseData(Auth);
            Location = new LocationData(Auth);
            Subaccount = new SubaccountData(Auth);
            CustomerPayment = new CustomerPaymentData(Auth);
            Dynamic = new VismaNetDynamicEndpoint(null, Auth);
            Resources = new VismaNetDynamicEndpoint(null, Auth, true);
        }

        /// <summary>
        /// Returns a dynamic Visma.net client allowing you do access all Visma.net endpoints dynamically
        /// </summary>
        /// <see cref="https://integration.visma.net/API-index/"/>
        public readonly dynamic Dynamic;

        /// <summary>
        /// Returns a dynamic Visma.net client allowing you do access all Visma.net resource endpoints dynamically
        /// </summary>
        /// <see cref="https://integration.visma.net/API-index/"/>
        public readonly dynamic Resources;

        public static string Version { get; private set; }
        /// <summary>
        /// Provide a name for your application. This will make it easier for Visma to identify your integration in their logs.
        /// </summary>
        public static string ApplicationName { get; set; }
        static VismaNet()
        {
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public async Task<TestConnectionResponse> TestConnection()
        {
            return await VismaNetApiHelper.TestConnection(Auth);
        }
        
        /// <summary>
        /// Get a new token from Visma.net
        /// </summary>
        /// <param name="username">User name</param>
        /// <param name="password">Password</param>
        /// <param name="clientId">System Client Id (Provided to you by Visma)</param>
        /// <param name="secret">System Client Secret (Provided to you by Visma)</param>
        /// <returns></returns>
        public static async Task<string> GetToken(string username, string password, string clientId, string secret)
        {
            return await VismaNetApiHelper.GetToken(username, password, clientId, secret);
        }

        public static string GetOAuthUrl(string client_id, string callback, string state = null)
        {
            if(string.IsNullOrEmpty(client_id))
                throw new ArgumentException(nameof(client_id));
            if(string.IsNullOrEmpty(callback))
                throw new ArgumentException(nameof(callback));
            return
                $"{VismaNetApiHelper.BaseApiUrl}{VismaNetControllers.OAuthAuthorize}?response_type=code&client_id={client_id}&scope=financialstasks&redirect_uri={Uri.EscapeDataString(callback)}&state={(state ?? Guid.NewGuid().ToString())}";
        }

        public static async Task<string> GetTokenUsingOAuth(string client_id, string client_secret, string code, string redirect_uri)
        {
            return await VismaNetApiHelper.GetTokenOAuth(client_id, client_secret, code, redirect_uri);
        }
        public static async Task<List<CompanyContext>> GetContextsForToken(string token)
        {
            return await VismaNetApiHelper.GetContextsForToken(token);
        }

		public async Task<Stream> GetAttachment(string attachmentId)
		{
			return await VismaNetApiHelper.GetAttachment(Auth, attachmentId);
		}
    }
}