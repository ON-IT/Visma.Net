using ONIT.VismaNetApi.Dynamic;
using ONIT.VismaNetApi.Exceptions;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Lib.Data;
using ONIT.VismaNetApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi
{
  [ComVisible(true)]
  public class VismaNet : VismaNetDynamicHandler
  {
    public readonly CashTransactionData CashTransaction;
    public readonly CashSaleData CashSale;
    public readonly CustomerDocumentData CustomerDocument;
    public readonly CustomerInvoiceData CustomerInvoice;

    public readonly CustomerSalesPriceData CustomerSalesPrice;
    public readonly CustomerCreditNoteData CustomerCreditNote;
    public readonly AttributeData Attribute;
    public readonly CustomerData Customer;
    public readonly CurrencyData Currency;
    public readonly DimensionData Dimension;
    public readonly DiscountData Discount;
    public readonly SupplierInvoiceData SupplierInvoice;
    public readonly SupplierData Supplier;
    public readonly InventoryData Inventory;
    public readonly FinAccountData Account;
    public readonly FinancialPeriodData FinancialPeriod;
    public readonly EmployeeData Employee;

    public readonly ShipmentData Shipment;
    public readonly ContactData Contact;
    public readonly ProjectData Project;
    public readonly SalesOrderData SalesOrder;
    public readonly JournalTransactionData JournalTransaction;
    public readonly GeneralLedgerTransactionData GeneralLedgerTransaction;
    public readonly GeneralLedgerBalanceData GeneralLedgerBalance;

    public readonly BranchData Branch;
    public readonly WarehouseData Warehouse;
    public readonly LocationData Location;
    public readonly SubaccountData Subaccount;
    public readonly SupplierDocumentData SupplierDocument;
    public readonly CustomerPaymentData CustomerPayment;
    public readonly InventoryIssueData InventoryIssue;
    public readonly InventoryReceiptData InventoryReceipt;
    public readonly PurchaseReceiptData PurchaseReceipt;
    public readonly PurchaseOrderData PurchaseOrder;

    // Obsolete
    [Obsolete]
    public readonly CreditNoteData CreditNote;
    [Obsolete]
    public readonly PaymentData Payment;

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
      Attribute = new AttributeData(Auth);
      Customer = new CustomerData(Auth);
      Currency = new CurrencyData(Auth);
      CustomerInvoice = new CustomerInvoiceData(Auth);
      Supplier = new SupplierData(Auth);
      SupplierInvoice = new SupplierInvoiceData(Auth);
      CashSale = new CashSaleData(Auth);
      CustomerDocument = new CustomerDocumentData(Auth);
      Dimension = new DimensionData(Auth);
      Discount = new DiscountData(Auth);
      Inventory = new InventoryData(Auth);
      JournalTransaction = new JournalTransactionData(Auth);
      GeneralLedgerTransaction = new GeneralLedgerTransactionData(Auth);
      GeneralLedgerBalance = new GeneralLedgerBalanceData(Auth);
      Account = new FinAccountData(Auth);
      FinancialPeriod = new FinancialPeriodData(Auth);
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
      SupplierDocument = new SupplierDocumentData(Auth);
      InventoryIssue = new InventoryIssueData(Auth);
      InventoryReceipt = new InventoryReceiptData(Auth);
      PurchaseReceipt = new PurchaseReceiptData(Auth);
      CustomerSalesPrice = new CustomerSalesPriceData(Auth);
      CustomerCreditNote = new CustomerCreditNoteData(Auth);
      PurchaseOrder = new PurchaseOrderData(Auth);
      CashTransaction = new CashTransactionData(Auth);
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

    private static int maxConcurrentRequests;
    /// <summary>
    /// Gets or sets the maximum number of concurrent requests sent to the API. Min: 1, Max: 8.
    /// </summary>
    public static int MaxConcurrentRequests
    {
      get
      {
        var requestLimit = maxConcurrentRequests > 0 ? maxConcurrentRequests : 8;
        return requestLimit > 8 ? 8 : requestLimit;
      }

      set => maxConcurrentRequests = value > 0 ? value : maxConcurrentRequests;
    }
    private static int maxRetries;
    /// <summary>
    /// Gets or sets the maximum number of retries sent to the API. Min: 1, Max: 5, Default: 5.
    /// </summary>
    public static int MaxRetries
    {
      get { return maxRetries > 0 ? maxRetries : 5; }
      set => maxRetries = (value > 0 && value < 6) ? value : 5;
    }

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
      if (string.IsNullOrEmpty(client_id))
        throw new ArgumentException(nameof(client_id));
      if (string.IsNullOrEmpty(callback))
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