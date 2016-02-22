using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ONIT.VismaNetApi.Exceptions;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Lib.Data;
using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi
{
    [ComVisible(true)]
    public class VismaNet
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
        public readonly CreditMemoData CreditMemo;
        public readonly ShipmentData Shipments;
        public readonly ContactData Contacts;


        public readonly JournalTransactionData JournalTransactions;

        private readonly VismaNetAuthorization _auth;

        /// <summary>
        /// Create a new connection using e-mail and password
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public VismaNet(int companyId, string email, string password) : this(companyId, GetTokenAsyncTask(email, password).GetAwaiter().GetResult())
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                throw new InvalidArgumentsException("Both email and password must be provided");
        }

        /// <summary>
        ///     Creates a connection using token.
        /// </summary>
        /// <param name="companyId">Company context</param>
        /// <param name="token">The predefined token from Visma.net</param>
        public VismaNet(int companyId, string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new InvalidArgumentsException("Token is missing");

            _auth = new VismaNetAuthorization
            {
                Token = token,
                CompanyId = companyId
            };
            
            Customers = new CustomerData(_auth);
            CustomerInvoices = new CustomerInvoiceData(_auth);
            Suppliers = new SupplierData(_auth);
            SupplierInvoices = new SupplierInvoiceData(_auth);
            CashSales = new CashSaleData(_auth);
            CustomerDocuments = new CustomerDocumentData(_auth);
            Dimensions = new DimensionData(_auth);
            Inventory = new InventoryData(_auth);
            JournalTransactions = new JournalTransactionData(_auth);
            Accounts = new FinAccountData(_auth);
            Employee = new EmployeeData(_auth);
            CreditMemo = new CreditMemoData(_auth);
            Shipments = new ShipmentData(_auth);
            Contacts = new ContactData(_auth);
        }

        public static string Version { get; private set; }

        static VismaNet()
        {
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public async Task<bool> TestConnectionAsyncTask()
        {
            return await VismaNetApiHelper.TestConnection(_auth);
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

        public static async Task<string> GetTokenAsyncTask(string email, string password)
        {
            return await VismaNetApiHelper.GetToken(email, password);
        }

        public static async Task<List<CompanyContext>> GetContextsForToken(string token)
        {
            return await VismaNetApiHelper.GetContextsForToken(token);
        }
    }
}