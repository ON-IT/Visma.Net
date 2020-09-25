using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using System;

namespace ONIT.VismaNetApi.Models
{
    public class GeneralLedgerTransaction : DtoPaginatedProviderBase, IProvideIdentificator
    {
        public int lineNumber
        {
            get => Get<int>();
            set => Set(value);
        }
        public string module
        {
            get => Get<string>();
            set => Set(value);
        }
        public string batchNumber
        {
            get => Get<string>();
            set => Set(value);
        }
        public DateTime tranDate
        {
            get => Get<DateTime>();
            set => Set(value);
        }
        public string period
        {
            get => Get<string>();
            set => Set(value);
        }
        public string description
        {
            get => Get<string>();
            set => Set(value);
        }
        public string refNumber
        {
            get => Get<string>();
            set => Set(value);
        }
        public Branch branch
        {
            get => Get<Branch>();
            set => Set(value);
        }
        public Account account
        {
            get => Get<Account>();
            set => Set(value);
        }
        public Ledger ledger
        {
            get => Get<Ledger>();
            set => Set(value);
        }

        public string subaccount
        {
            get => Get<string>();
            set => Set(value);
        }
        public string currency
        {
            get => Get<string>();
            set => Set(value);
        }
        public decimal begBalance
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal debitAmount
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal creditAmount
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal endingBalance
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal currBegBalance
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal currDebitAmount
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal currCreditAmount
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public decimal currEndingBalance
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public DateTime lastModifiedDateTime
        {
            get => Get<DateTime>();
            set => Set(value);
        }

        [JsonProperty]
        public JObject extras { get; private set; }

        public string GetIdentificator()
        {
            return lineNumber.ToString();
        }
    }
}
