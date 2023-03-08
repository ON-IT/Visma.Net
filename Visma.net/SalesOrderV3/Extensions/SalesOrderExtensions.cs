using ONIT.VismaNetApi.Models.Enums;
using ONIT.VismaNetApi.SalesOrderV3.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace ONIT.VismaNetApi.SalesOrderV3.Extensions
{


  public static class SalesOrderExtensions
  {
    public static NewSalesOrderCommand toV3SalesOrder(this ONIT.VismaNetApi.Models.SalesOrder v2SalesOrder)
    {
      var v3SalesOrder = new NewSalesOrderCommand();
      if (!string.IsNullOrEmpty(v2SalesOrder.orderNo))
      {
        v3SalesOrder.OrderId = v2SalesOrder.orderNo;
      }
      v3SalesOrder.Customer.Id = v2SalesOrder.customer.number;
      v3SalesOrder.Customer.Order = v2SalesOrder.customerOrder;
      v3SalesOrder.Customer.TermsId = v2SalesOrder.terms?.id;
      if (v2SalesOrder.contactId != 0)
        v3SalesOrder.Customer.ContactId = v2SalesOrder.contactId;
      v3SalesOrder.Customer.LocationId = v2SalesOrder.location?.id;
      v3SalesOrder.Customer.Gln = v2SalesOrder.gln;
      v3SalesOrder.Customer.RefNo = v2SalesOrder.customerRefNo;
      if (v2SalesOrder.soBillingAddress != null && v2SalesOrder.soBillingAddress.overrideAddress)
      {
        v3SalesOrder.Billing = new NewSalesOrderBillingDto();
        v3SalesOrder.Billing.Address = new NewSalesOrderAddressDto();
        v3SalesOrder.Billing.Address.Line1 = v2SalesOrder.soBillingAddress.addressLine1;
        v3SalesOrder.Billing.Address.Line2 = v2SalesOrder.soBillingAddress.addressLine2;
        v3SalesOrder.Billing.Address.Line3 = v2SalesOrder.soBillingAddress.addressLine3;
        v3SalesOrder.Billing.Address.PostalCode = v2SalesOrder.soBillingAddress.postalCode;
        v3SalesOrder.Billing.Address.City = v2SalesOrder.soBillingAddress.city;
        v3SalesOrder.Billing.Address.CountryId = v2SalesOrder.soBillingAddress.country?.id;
        v3SalesOrder.Billing.Address.StateId = v2SalesOrder.soBillingAddress.county?.id;
      }

      if (v2SalesOrder.soShippingAddress != null && v2SalesOrder.soShippingAddress.overrideAddress)
      {
        v3SalesOrder.Shipping = new NewSalesOrderShippingDto();
        v3SalesOrder.Shipping.Address = new NewSalesOrderAddressDto();
        v3SalesOrder.Shipping.Address.Line1 = v2SalesOrder.soShippingAddress.addressLine1;
        v3SalesOrder.Shipping.Address.Line2 = v2SalesOrder.soShippingAddress.addressLine2;
        v3SalesOrder.Shipping.Address.Line3 = v2SalesOrder.soShippingAddress.addressLine3;
        v3SalesOrder.Shipping.Address.PostalCode = v2SalesOrder.soShippingAddress.postalCode;
        v3SalesOrder.Shipping.Address.City = v2SalesOrder.soShippingAddress.city;
        v3SalesOrder.Shipping.Address.CountryId = v2SalesOrder.soShippingAddress.country?.id;
        v3SalesOrder.Shipping.Address.StateId = v2SalesOrder.soShippingAddress.county?.id;
      }

      if (v2SalesOrder.soBillingContact != null && v2SalesOrder.soBillingContact.overrideContact)
      {
        if (v3SalesOrder.Billing == null)
          v3SalesOrder.Billing = new NewSalesOrderBillingDto();
        v3SalesOrder.Billing.Contact = new NewSalesOrderContactDto();
        v3SalesOrder.Billing.Contact.Attention = v2SalesOrder.soBillingContact.attention;
        v3SalesOrder.Billing.Contact.Email = v2SalesOrder.soBillingContact.email;
        v3SalesOrder.Billing.Contact.Name = v2SalesOrder.soBillingContact.name;
        v3SalesOrder.Billing.Contact.Phone1 = v2SalesOrder.soBillingContact.phone1;
      }
      if (v2SalesOrder.soShippingContact != null && v2SalesOrder.soShippingContact.overrideContact)
      {
        if (v3SalesOrder.Shipping == null)
          v3SalesOrder.Shipping = new NewSalesOrderShippingDto();
        v3SalesOrder.Shipping.Contact = new NewSalesOrderContactDto();
        v3SalesOrder.Shipping.Contact.Attention = v2SalesOrder.soShippingContact.attention;
        v3SalesOrder.Shipping.Contact.Email = v2SalesOrder.soShippingContact.email;
        v3SalesOrder.Shipping.Contact.Name = v2SalesOrder.soShippingContact.name;
        v3SalesOrder.Shipping.Contact.Phone1 = v2SalesOrder.soShippingContact.phone1;
      }
      if (v2SalesOrder.cancelBy != default(DateTime))
      {
        v3SalesOrder.CancelBy = v2SalesOrder.cancelBy;
      }
      v3SalesOrder.CurrencyId = v2SalesOrder.currency;
      if (v2SalesOrder.date != default(DateTime))
      {
        v3SalesOrder.Date = v2SalesOrder.date;
      }
      v3SalesOrder.Description = v2SalesOrder.description;
      v3SalesOrder.Note = v2SalesOrder.note;
      v3SalesOrder.OwnerId = v2SalesOrder.owner?.id;

      v3SalesOrder.PaymentSettings = new NewSalesOrderPaymentSettings();
      v3SalesOrder.PaymentSettings.PaymentMethodId = v2SalesOrder.paymentMethod?.id;
      v3SalesOrder.PaymentSettings.CashAccountId = v2SalesOrder.cashAccount;
      v3SalesOrder.PaymentSettings.PaymentReference = v2SalesOrder.paymentRef;

      v3SalesOrder.Print = new SalesOrderPrintDto();
      v3SalesOrder.Print.NoteOnInternalDocuments = v2SalesOrder.printNoteOnInternalDocuments;
      v3SalesOrder.Print.NoteOnExternalDocuments = v2SalesOrder.printNoteOnExternalDocuments;
      v3SalesOrder.Print.DescriptionOnInvoice = v2SalesOrder.printDescriptionOnInvoice;

      if (v2SalesOrder.requestOn != default(DateTime))
        v3SalesOrder.RequestOn = v2SalesOrder.requestOn;

      v3SalesOrder.Shipping = new NewSalesOrderShippingDto();
      v3SalesOrder.Shipping.ShipViaId = v2SalesOrder.shipVia?.id;
      v3SalesOrder.Shipping.PreferredWarehouseId = v2SalesOrder.preferredWarehouse?.id;
      if (v2SalesOrder.schedShipment != default(DateTime))
        v3SalesOrder.Shipping.ScheduledDate = v2SalesOrder.schedShipment;

      v3SalesOrder.Shipping.Insurance = v2SalesOrder.insurance;
      v3SalesOrder.Shipping.ResidentialDelivery = v2SalesOrder.residentialDelivery;
      v3SalesOrder.Shipping.SaturdayDelivery = v2SalesOrder.saturdayDelivery;

      v3SalesOrder.Status = v2SalesOrder.status;

      v3SalesOrder.TaxZoneId = v2SalesOrder.customerVATZone?.id;
      v3SalesOrder.Type = v2SalesOrder.orderType != null ? v2SalesOrder.orderType : "SO";


      v3SalesOrder.OrderLines = new List<NewSalesOrderLineDto>();
      foreach (var l in v2SalesOrder.lines)
      {
        var newline = new NewSalesOrderLineDto();
        newline.Description = l.lineDescription;
        newline.DiscountAmount = l.discountAmount;
        newline.DiscountCode = l.discountCode;
        newline.DiscountPercent = l.discountPercent;
        newline.ExternalLink = l.externalLink;
        newline.HasManualDiscount = l.manualDiscount;
        newline.InventoryId = l.inventory.number;
        newline.Note = l.note;
        newline.Operation = l.salesOrderOperation.ToString();
        if (l.overshipThreshold > 0)
          newline.OvershipThreshold = l.overshipThreshold;
        newline.Quantity = l.quantity;
        newline.ReasonCode = l.reasonCode;
        if (l.requestedOn != default(DateTime))
          newline.RequestDate = l.requestedOn;
        if (l.shipOn != default(DateTime))
          newline.ShipDate = l.shipOn;

        // Todo: Check and fix subaccounts
        foreach (var s in l.subaccount.segments)
        {
          newline.Subaccount.Add(s.segmentId.ToString(), s.segmentValue);
        }

        newline.TaxCategoryId = l.taxCategory;
        if (l.undershipThreshold > 0)
          newline.UndershipThreshold = l.undershipThreshold;
        newline.UnitCost = (double)l.unitCost;
        newline.UnitPrice = l.unitPrice;
        newline.UnitOfMeasure = l.uom;
        newline.WarehouseId = l.warehouse?.id;
        v3SalesOrder.OrderLines.Add(newline);
      }

      return v3SalesOrder;

    }

    public static ONIT.VismaNetApi.Models.SalesOrder fromV3SalesOrder(this ONIT.VismaNetApi.Models.SalesOrder OldV2, SalesOrderDto v3SalesOrder, IEnumerable<SalesOrderLineDto> v3salesOrderLines)
    {
      ONIT.VismaNetApi.Models.SalesOrder v2SalesOrder;
      if (v3SalesOrder.OrderId != null)
      {
        v2SalesOrder = new VismaNetApi.Models.SalesOrder(v3SalesOrder.OrderId, v3SalesOrder.Type);
      }
      else
      {
        v2SalesOrder = new VismaNetApi.Models.SalesOrder();
      }

      v2SalesOrder.customer = v3SalesOrder.Customer.Id;
      v2SalesOrder.customerOrder = v3SalesOrder.Customer.Order;
      v2SalesOrder.terms = v3SalesOrder.FinancialInformation?.Terms?.Id;
      v2SalesOrder.contactId = v2SalesOrder.contactId;
      if (v3SalesOrder.Customer.Location != null)
      {
        v2SalesOrder.location = new VismaNetApi.Models.CustomDto.LocationSummary();
        v2SalesOrder.location.id = v3SalesOrder.Customer.Location.Id;
      }
      v2SalesOrder.gln = v3SalesOrder.Customer.Location?.Gln;
      v2SalesOrder.customerRefNo = v3SalesOrder.Customer.RefNo;
      if (v3SalesOrder.Billing.Address != null)
      {
        v2SalesOrder.soBillingAddress.overrideAddress = v3SalesOrder.Billing.Address.OverridesDefault;
        v2SalesOrder.soBillingAddress.addressLine1 = v3SalesOrder.Billing.Address.Line1;
        v2SalesOrder.soBillingAddress.addressLine2 = v3SalesOrder.Billing.Address.Line2;
        v2SalesOrder.soBillingAddress.addressLine3 = v3SalesOrder.Billing.Address.Line3;
        v2SalesOrder.soBillingAddress.postalCode = v3SalesOrder.Billing.Address.PostalCode;
        v2SalesOrder.soBillingAddress.city = v3SalesOrder.Billing.Address.City;
        v2SalesOrder.soBillingAddress.country = v3SalesOrder.Billing.Address.Country?.Id;
        v2SalesOrder.soBillingAddress.county = v3SalesOrder.Billing.Address.County?.Id;
      }

      if (v3SalesOrder.Shipping.Address != null)
      {
        v2SalesOrder.soShippingAddress.overrideAddress = v3SalesOrder.Shipping.Address.OverridesDefault;
        v2SalesOrder.soShippingAddress.addressLine1 = v3SalesOrder.Shipping.Address.Line1;
        v2SalesOrder.soShippingAddress.addressLine2 = v3SalesOrder.Shipping.Address.Line2;
        v2SalesOrder.soShippingAddress.addressLine3 = v3SalesOrder.Shipping.Address.Line3;
        v2SalesOrder.soShippingAddress.postalCode = v3SalesOrder.Shipping.Address.PostalCode;
        v2SalesOrder.soShippingAddress.city = v3SalesOrder.Shipping.Address.City;
        v2SalesOrder.soShippingAddress.country = v3SalesOrder.Shipping.Address.Country?.Id;
        v2SalesOrder.soShippingAddress.county = v3SalesOrder.Shipping.Address.County?.Id;
      }

      if (v3SalesOrder.Billing.Contact != null)
      {
        v2SalesOrder.soBillingContact.overrideContact = v3SalesOrder.Billing.Contact.OverridesDefault;
        v2SalesOrder.soBillingContact.attention = v3SalesOrder.Billing.Contact.Attention;
        v2SalesOrder.soBillingContact.email = v3SalesOrder.Billing.Contact.Email;
        v2SalesOrder.soBillingContact.name = v3SalesOrder.Billing.Contact.Name;
        v2SalesOrder.soBillingContact.phone1 = v3SalesOrder.Billing.Contact.Phone1;
      }
      if (v3SalesOrder.Shipping.Contact != null)
      {
        v2SalesOrder.soShippingContact.overrideContact = v3SalesOrder.Shipping.Contact.OverridesDefault;
        v2SalesOrder.soShippingContact.attention = v3SalesOrder.Shipping.Contact.Attention;
        v2SalesOrder.soShippingContact.email = v3SalesOrder.Shipping.Contact.Email;
        v2SalesOrder.soShippingContact.name = v3SalesOrder.Shipping.Contact.Name;
        v2SalesOrder.soShippingContact.phone1 = v3SalesOrder.Shipping.Contact.Phone1;
      }
      if (v3SalesOrder.CancelBy != null)
      {
        v2SalesOrder.cancelBy = ((DateTimeOffset)v3SalesOrder.CancelBy).DateTime;
      }
      v2SalesOrder.currency = v3SalesOrder.CurrencyId;
      if (v3SalesOrder.Date != null)
      {
        v2SalesOrder.date = ((DateTimeOffset)v3SalesOrder.Date).DateTime;
      }
      v2SalesOrder.description = v3SalesOrder.Description;
      v2SalesOrder.note = v3SalesOrder.Note;

      if (v3SalesOrder.PaymentSettings != null)
      {

        v2SalesOrder.paymentMethod = v3SalesOrder.PaymentSettings.PaymentMethod.Id;
        v2SalesOrder.cashAccount = v3SalesOrder.PaymentSettings.CashAccountId;
        v2SalesOrder.paymentRef = v3SalesOrder.PaymentSettings.PaymentReference;
      }

      if (v3SalesOrder.Print != null)
      {
        if (v3SalesOrder.Print.NoteOnInternalDocuments != null)
          v2SalesOrder.printNoteOnInternalDocuments = (bool)v3SalesOrder.Print.NoteOnInternalDocuments;
        if (v3SalesOrder.Print.NoteOnExternalDocuments != null)
          v2SalesOrder.printNoteOnExternalDocuments = (bool)v3SalesOrder.Print.NoteOnExternalDocuments;
        if (v3SalesOrder.Print.DescriptionOnInvoice != null)
          v2SalesOrder.printDescriptionOnInvoice = (bool)v3SalesOrder.Print.DescriptionOnInvoice;
      }

      if (v3SalesOrder.RequestOn != null)
        v2SalesOrder.requestOn = ((DateTimeOffset)v3SalesOrder.RequestOn).DateTime;


      if (v3SalesOrder.Shipping != null)
      {
        v2SalesOrder.shipVia = v3SalesOrder.Shipping.ShipVia?.Id;
        v2SalesOrder.preferredWarehouse = v3SalesOrder.Shipping.PreferredWarehouse?.Id;
        if (v3SalesOrder.Shipping.ScheduledDate != null)
          v2SalesOrder.schedShipment = ((DateTimeOffset)v3SalesOrder.Shipping.ScheduledDate).DateTime;

        v2SalesOrder.insurance = v3SalesOrder.Shipping.Insurance;
        v2SalesOrder.residentialDelivery = v3SalesOrder.Shipping.ResidentialDelivery;
        v2SalesOrder.saturdayDelivery = v3SalesOrder.Shipping.SaturdayDelivery;
      }


      v2SalesOrder.customerVATZone = v3SalesOrder.Customer.TaxZone.Id;
      v2SalesOrder.orderType = v3SalesOrder.Type;



      foreach (var l in v3salesOrderLines)
      {
        var newline = new VismaNetApi.Models.SalesOrderLine();
        newline.lineDescription = l.Description;
        if (l.DiscountAmount != null)
          newline.discountAmount = (double)l.DiscountAmount;
        newline.discountCode = l.DiscountCode;
        if (l.DiscountPercent != null)
          newline.discountPercent = (double)l.DiscountPercent;
        newline.externalLink = l.ExternalLink;
        newline.manualDiscount = l.HasManualDiscount;
        newline.inventory = l.Inventory.Id;
        newline.note = l.Note;

        if (!string.IsNullOrEmpty(l.Operation))
          newline.salesOrderOperation = l.Operation;
        if (l.OvershipThreshold != null)
          newline.overshipThreshold = (double)l.OvershipThreshold;
        if (l.Quantity != null)
          newline.quantity = (double)l.Quantity;

        newline.reasonCode = l.ReasonCode;
        if (l.RequestDate != null)
          newline.requestedOn = ((DateTimeOffset)l.RequestDate).DateTime;
        if (l.ShipDate != null)
          newline.shipOn = ((DateTimeOffset)l.ShipDate).DateTime;

        // Todo: Check and fix subaccounts
        //foreach (var s in l.subaccount.segments)
        //{
        //    newline.Subaccount.Add(s.)
        //}
        newline.taxCategory = l.TaxCategoryId;
        if (l.UndershipThreshold != null)
          newline.undershipThreshold = (double)l.UndershipThreshold;
        if (l.UnitCost != null)
          newline.unitCost = (decimal)l.UnitCost;
        if (l.UnitPrice != null)
          newline.unitPrice = (double)l.UnitPrice;

        newline.uom = l.UnitOfMeasure;
        newline.warehouse = l.WarehouseId;
        v2SalesOrder.lines.Add(newline);
      }
      return v2SalesOrder;
    }
  }
}
