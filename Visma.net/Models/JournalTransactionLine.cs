using System.Collections.Generic;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class JournalTransactionLine : DtoProviderBase
    {
        public JournalTransactionLine()
        {
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
            DtoFields.Add("lineNumber", new DtoValue(0));
        }

        public string accountNumber
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public List<Attachment> attachments { get; private set; }

        public string branch
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public decimal creditAmount { get; private set; }

        public decimal creditAmountInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }

        [JsonProperty]
        public string customerSupplier { get; private set; }

        [JsonProperty]
        public decimal debitAmount
        {
            get; // => Get<decimal>();
            private set; // => Set(value);
        }

        public decimal debitAmountInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }

        [JsonProperty]
        public string description
        {
            get; // => Get<string>();
            private set; // => Set(value);
        }

        public int lineNumber
        {
            get => Get<int>();
            set => Set(value);
        }

        [JsonProperty]
        public JournalTransactionModule module
        {
            get; //=> Get<JournalTransactionModule>();
            private set; // => Set(value);
        }

        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }

        [JsonProperty]
        public DescriptiveDto project { 
            get => Get(defaultValue: new DescriptiveDto());
            set => Set(value);
        }

        [JsonProperty]
        public DescriptiveDto projectTask {
            get => Get(defaultValue: new DescriptiveDto());
            set => Set(value);
        }

        public string referenceNumber
        {
            get => Get<string>();
            set => Set(value);
        }

        public CustomDto.Subaccount subaccount
        {
            get => Get(defaultValue: new CustomDto.Subaccount());
            set => Set(value);
        }

        public string transactionDescription
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public string transactionType { get; private set; }

        public string uom
        {
            get => Get<string>();
            set => Set(value);
        }

        public Vat vat
        {
            get => Get<Vat>("vatId");
            set => Set(value, "vatId");
        }

        public VatCode vatCode
        {
            get => Get<VatCode>("vatCodeId");
            set => Set(value, "vatCodeId");
        }
    }
}