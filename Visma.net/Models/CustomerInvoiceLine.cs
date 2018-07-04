using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class CustomerInvoiceLine : DtoProviderBase
    {
        private List<Attachment> _attachments;

        public CustomerInvoiceLine()
        {
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
            DtoFields.Add("lineNumber", new DtoValue(0));
            DtoFields.Add("quantity", new DtoValue(1));
        }

        [JsonProperty]
        public Account account
        {
            get => Get(defaultValue: new Account(), key: "accountNumber");
            set => Set(value, "accountNumber");
        }

        /// <summary>
        ///     Order line total price
        /// </summary>
        [JsonProperty]
        public decimal amount
        {
            get; // { return Get<decimal>(); }
            private set; // { Set(value); }
        }

        [JsonProperty]
        public decimal amountInCurrency
        {
            get; // { return Get<decimal>(); }
            private set; // { Set(value); }
        }

        [JsonProperty]
        public List<Attachment> attachments
        {
            get => _attachments ?? (_attachments = new List<Attachment>());
            private set => _attachments = value;
        }

        public NumberName branchNumber
        {
            get => Get<NumberName>();
            set => Set(value);
        }


        [JsonProperty] public decimal deductableAmount { get; private set; }

        public string deferralCode
        {
            get => Get<string>();
            set => Set(value);
        }

        public int deferralSchedule
        {
            get => Get<int>();
            set => Set(value);
        }

        /// <summary>
        ///     Orderline description (aka. name)
        /// </summary>
        public string description
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public decimal discountAmount
        {
            get; //{ return Get<decimal>(); }
            private set; // { Set(value); }
        }

        public decimal discountAmountInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public string discountCode
        {
            get => Get<string>();
            set => Set(value);
        }

        public decimal discountPercent
        {
            get => Get<decimal>();
            set => Set(value);
        }


        /// <summary>
        ///     Also known as article number
        /// </summary>
        public string inventoryNumber
        {
            get => Get<string>();
            set
            {
                if (value != null)
                    Set(value.Trim());
            }
        }

        public bool isRotRutDeductible
        {
            get => Get<bool>("domesticServicesDeductible");
            set => Set(value, "domesticServicesDeductible");
        }

        public string itemType
        {
            get => Get<string>();
            set => Set(value);
        }

        public int lineNumber
        {
            get => Get<int>();
            set => Set(value);
        }

        [JsonProperty]
        public decimal manualAmount
        {
            get; // { return Get<decimal>(); }
            private set; // { Set(value); }
        }

        public decimal manualAmountInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public bool manualDiscount
        {
            get => Get<bool>();
            set => Set(value);
        }

        public string note
        {
            get => Get<string>();
            set => Set(value);
        }

        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }

        public DescriptiveDto projectTask
        {
            get => Get<DescriptiveDto>("taskId");
            set => Set(value, "taskId");
        }

        /// <summary>
        ///     Number of articles
        /// </summary>
        public decimal quantity
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public string salesperson
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty] public DescriptiveDto seller { get; private set; }

        public CustomDto.Subaccount subaccount
        {
            get => Get(defaultValue: new CustomDto.Subaccount());
            set => Set(value);
        }

        public DateTime? termEndDate
        {
            get => Get<DateTime?>();
            set => Set(value);
        }

        public DateTime? termStartDate
        {
            get => Get<DateTime?>();
            set => Set(value);
        }

        public TypeOfWork typeOfWork
        {
            get => Get<TypeOfWork>();
            set => Set(value);
        }

        /// <summary>
        ///     Price pr. unit. To set unit price, use unitPriceInCurrency.
        /// </summary>
        [JsonProperty]
        public decimal unitPrice
        {
            get; // { return Get<decimal>(); }
            private set; // { Set(value); }
        }

        public decimal unitPriceInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public string uOM
        {
            get => Get(defaultValue: "");
            set => Set(value);
        }

        public VatCode vatCode
        {
            get => Get(defaultValue: new VatCode(), key: "vatCodeId");
            set => Set(value, "vatCodeId");
        }

        public override Dictionary<string, object> ToDto(bool delta = false)
        {
            if (operation == ApiOperation.Delete)
            {
                return Data
                    .Where(x => x.Key == "lineNumber" || x.Key == "operation")
                    .ToDictionary(x => x.Key, x => CreateDto(x.Value, x.Key));
            }
            else
            {
                return base.ToDto(delta);
            }
        }
    }
}