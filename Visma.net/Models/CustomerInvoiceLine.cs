using System;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class CustomerInvoiceLine : DtoProviderBase
    {
        public CustomerInvoiceLine()
        {
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
            DtoFields.Add("lineNumber", new DtoValue(0));
            DtoFields.Add("quantity", new DtoValue(1));
        }
        
        public ApiOperation operation
        {
            get { return Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value; }
            set { Set(new NotDto<ApiOperation>(value)); }
        }

        public int lineNumber
        {
            get { return Get<int>(); }
            set { Set(value); }
        }

        /// <summary>
        ///     Also known as article number
        /// </summary>
        public string inventoryNumber
        {
            get { return Get<string>(); }
            set
            {
                if (value != null)
                    Set(value.Trim());
            }
        }

        /// <summary>
        ///     Orderline description (aka. name)
        /// </summary>
        public string description
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        /// <summary>
        ///     Number of articles
        /// </summary>
        public decimal quantity
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal unitPriceInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal manualAmountInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public VatCode vatCode
        {
            get { return Get<VatCode>(defaultValue: new VatCode(), key: "vatCodeId"); }
            set { Set(value, "vatCodeId"); }
        }

        public string uOM
        {
            get { return Get(defaultValue:""); }
            set { Set(value); }
        }

        public decimal discountPercent
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal discountAmountInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public bool manualDiscount
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public ONIT.VismaNetApi.Models.CustomDto.Subaccount subaccount
        {
            get { return Get(defaultValue: new ONIT.VismaNetApi.Models.CustomDto.Subaccount()); }
            set { Set(value); }
        }

        public string salesperson
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public DateTime? termStartDate
        {
            get { return Get<DateTime?>(); }
            set { Set(value);}
        }

        public DateTime? termEndDate
        {
            get { return Get<DateTime?>(); }
            set { Set(value); }
        }

        public int deferralSchedule
        {
            get { return Get<int>(); }
            set { Set(value); }
        }

        public string deferralCode
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string discountCode
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        #region read only

        /// <summary>
        ///     Price pr. unit. To set unit price, use unitPriceInCurrency.
        /// </summary>
        [JsonProperty]
        public decimal unitPrice
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal manualAmount
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        /// <summary>
        ///     Order line total price
        /// </summary>
        [JsonProperty]
        public decimal amount
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal amountInCurrency
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public Account account
        {
            get { return Get(defaultValue: new Account(), key: "accountNumber"); }
            set { Set(value, "accountNumber"); }
        }

        [JsonProperty]
        public decimal discountAmount
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        #endregion
    }
}