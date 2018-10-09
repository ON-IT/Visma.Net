using System;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class PaymentLine : DtoProviderBase
    {
        public PaymentLine()
        {
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }

        public decimal amountPaid
        {
            get => Get<decimal>();
            set => Set(value);
        }

        [JsonProperty] public decimal balance { get; private set; }

        public decimal balanceWriteOff
        {
            get => Get<decimal>();
            set => Set(value);
        }

        [JsonProperty] public decimal cashDiscountBalance { get; private set; }

        [JsonProperty] public DateTime cashDiscountDate { get; private set; }

        public decimal cashDiscountTaken
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public decimal crossRate
        {
            get => Get<decimal>();
            set => Set(value);
        }

        [JsonProperty]
        public string postPeriod { get; private set; }
        [JsonProperty] public string customerOrder
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public string currency
        {
            get;
            private set;
        }

        [JsonProperty]
        public DateTime date
        {
            get;// => Get<DateTime>();
            private set;// => Set(value);
        }

        [JsonProperty]
        public string description
        {
            get;// => Get<string>();
            private set;// => Set(value);
        }

        public string documentType
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty] public DateTime dueDate { get; private set; }

        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }

        public string refNbr
        {
            get => Get<string>();
            set => Set(value);
        }

        public DescriptiveDto writeOffReasonCode
        {
            get => Get<DescriptiveDto>();
            set => Set(value);
        }
    }
}