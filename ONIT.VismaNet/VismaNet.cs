using System;
using System.Collections.Generic;
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
        public readonly CashSaleData CashSales;
        public readonly CustomerDocumentData CustomerDocuments;
        public readonly CustomerInvoiceData CustomerInvoices;
        public readonly CustomerData Customers;
        public readonly DimensionData Dimensions;
        public readonly SupplierInvoiceData SupplierInvoices;
        public readonly SupplierData Suppliers;
        public readonly InventoryData Inventory;
        public readonly FinAccountData Accounts;
        public readonly EmployeeData Employee;
        public readonly CreditNoteData CreditNote;
        public readonly ShipmentData Shipments;
        public readonly ContactData Contacts;
        public readonly ProjectData Projects;
        public readonly InventoryAdjustmentData InventoryAdjustment;
        public readonly JournalTransactionData JournalTransactions;

        
        /// <summary>
        ///     Creates a connection using token.
        /// </summary>
        /// <param name="companyId">Company context</param>
        /// <param name="token">The predefined token from Visma.net</param>
        public VismaNet(int companyId, string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new InvalidArgumentsException("Token is missing");

            Auth = new VismaNetAuthorization
            {
                Token = token,
                CompanyId = companyId
            };
            Customers = new CustomerData(Auth);
            CustomerInvoices = new CustomerInvoiceData(Auth);
            Suppliers = new SupplierData(Auth);
            SupplierInvoices = new SupplierInvoiceData(Auth);
            CashSales = new CashSaleData(Auth);
            CustomerDocuments = new CustomerDocumentData(Auth);
            Dimensions = new DimensionData(Auth);
            Inventory = new InventoryData(Auth);
            InventoryAdjustment = new InventoryAdjustmentData(Auth);
            JournalTransactions = new JournalTransactionData(Auth);
            Accounts = new FinAccountData(Auth);
            Employee = new EmployeeData(Auth);
            CreditNote = new CreditNoteData(Auth);
            Shipments = new ShipmentData(Auth);
            Contacts = new ContactData(Auth);
            Projects = new ProjectData(Auth);
        }

        public static string Version { get; private set; }

        static VismaNet()
        {
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public async Task<bool> TestConnectionAsyncTask()
        {
            return await VismaNetApiHelper.TestConnection(Auth);
        }

        public bool TestConnection()
        {
            try
            {
                return TestConnectionAsyncTask().GetAwaiter().GetResult();
            }
            catch (AggregateException e)
            {
                VismaNetExceptionHandler.HandleException(e);
                return false;
            }
        }
        /// <summary>
        /// Get a new token from Visma.net
        /// </summary>
        /// <param name="username">User name</param>
        /// <param name="password">Password</param>
        /// <param name="clientId">System Client Id (Provided to you by Visma)</param>
        /// <param name="secret">System Client Secret (Provided to you by Visma)</param>
        /// <returns></returns>
        public static async Task<string> GetTokenAsyncTask(string username, string password, string clientId, string secret)
        {
            return await VismaNetApiHelper.GetToken(username, password, clientId, secret);
        }

        public static async Task<List<CompanyContext>> GetContextsForToken(string token)
        {
            return await VismaNetApiHelper.GetContextsForToken(token);
        }
    }
}