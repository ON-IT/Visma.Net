using System;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class DirectDebitLine : DtoProviderBase
    {
        public DirectDebitLine()
        {
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }

        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }

        public string id
        {
            get => Get<NotDto<string>>()?.Value;
            set => Set(new NotDto<string>(value));
        }

        public string mandateId
        {
            get => Get<string>();
            set => Set(value);
        }

        public string mandateDescription
        {
            get => Get<string>();
            set => Set(value);
        }

        public DateTime dateOfSignature
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        public bool isDefault
        {
            get => Get<bool>();
            set => Set(value);
        }

        public bool oneTime
        {
            get => Get<bool>();
            set => Set(value);
        }

        public string bic
        {
            get => Get<string>();
            set => Set(value);
        }

        public string iban
        {
            get => Get<string>();
            set => Set(value);
        }

        public DateTime lastCollectionDate
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        public decimal maxAmount
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public DateTime expirationDate
        {
            get => Get<DateTime>();
            set => Set(value);
        }
    }
}