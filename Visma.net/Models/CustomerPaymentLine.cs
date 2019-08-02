using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;
using System;

namespace ONIT.VismaNetApi.Models
{
    public class CustomerPaymentLine : DtoProviderBase
    {
        public CustomerPaymentLine()
        {
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }
        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }
        public string documentType { get => Get<string>(); set => Set(value); }
        public string refNbr { get => Get<string>(); set => Set(value); }
        public decimal amountPaid { get => Get<decimal>(); set => Set(value); }
        public decimal cashDiscountTaken { get => Get<decimal>(); set => Set(value); }
        public decimal balanceWriteOff { get => Get<decimal>(); set => Set(value); }
        public DescriptiveDto writeOffReasonCode { get => Get<DescriptiveDto>(); set => Set(value); }
        [JsonProperty]
        public DateTime date { get; private set; }
        [JsonProperty]
        public DateTime dueDate { get; private set; }
        [JsonProperty]
        public DateTime cashDiscountDate { get; private set; }
        [JsonProperty]
        public decimal balance { get; private set; }
        [JsonProperty]
        public decimal cashDiscountBalance { get; private set; }
        [JsonProperty]
        public string description { get; private set; }
        [JsonProperty]
        public string currency { get; private set; }
        [JsonProperty]
        public string postPeriod { get; private set; }
        [JsonProperty]
        public string customerOrder { get; private set; }
        public decimal crossRate { get => Get<decimal>(); set => Set(value); }
    }

}
