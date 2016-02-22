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
        //public readonly QueryableVismaNetCustomerData<Customer> Customers;

        //public readonly QueryableVismaNetInvoiceData<Invoice> Invoices;

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

        private readonly VismaNetAuthorization auth;


        /// <summary>
        ///     Creates a connection to the Visma.Net API. If token is provided, email and password should not be.
        /// </summary>
        /// <param name="companyId">company context ID</param>
        /// <param name="token">the predefined token from Visma.Net. If you don't have this, use email and password.</param>
        /// <param name="email">Visma.Net e-mail</param>
        /// <param name="password">Visma.Net password</param>
        public VismaNet(int companyId, string token = null, string email = null, string password = null)
        {
            if (string.IsNullOrEmpty(token) && (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)))
                throw new InvalidArgumentsException("If Token is not provided, email and password must be.");

            auth = new VismaNetAuthorization
            {
                Token = token,
                CompanyId = companyId
            };
            if (string.IsNullOrEmpty(token))
            {
                auth.Token = Task.Run(async () => await VismaNetApiHelper.GetToken(email, password)).Result;
            }
            //Customers = new QueryableVismaNetCustomerData<Customer>(auth);
            //Invoices = new QueryableVismaNetInvoiceData<Invoice>(auth);
            Customers = new CustomerData(auth);
            CustomerInvoices = new CustomerInvoiceData(auth);
            Suppliers = new SupplierData(auth);
            SupplierInvoices = new SupplierInvoiceData(auth);
            CashSales = new CashSaleData(auth);
            CustomerDocuments = new CustomerDocumentData(auth);
            Dimensions = new DimensionData(auth);
            Inventory = new InventoryData(auth);
            JournalTransactions = new JournalTransactionData(auth);
            Accounts = new FinAccountData(auth);
            Employee = new EmployeeData(auth);
            CreditMemo = new CreditMemoData(auth);
            Shipments = new ShipmentData(auth);
            Contacts = new ContactData(auth);
        }

        public static string Version { get; private set; }

        static VismaNet()
        {
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public async Task<bool> TestConnectionAsyncTask()
        {
            return await VismaNetApiHelper.TestConnection(auth);
        }

        public bool TestConnection()
        {
            try
            {
                return Task.Run(async () => await VismaNetApiHelper.TestConnection(auth)).Result;
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

        public static string GetToken(string email, string password)
        {
            try
            {
                return Task.Run(async () => await VismaNetApiHelper.GetToken(email, password)).Result;
            }
            catch (AggregateException e)
            {
                VismaNetExceptionHandler.HandleException(e);
                return null;
            }
        }
    }
}