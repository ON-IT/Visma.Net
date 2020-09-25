using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class JournalTransaction : DtoPaginatedProviderBase, IProvideIdentificator
    {
        [JsonProperty]
        public List<Attachment> attachments { get; private set; }

        public bool? autoReversing
        {
            get => Get<bool?>();
            set => Set(value);
        }

        public string batchNumber
        {
            get => Get<string>();
            set => Set(value);
        }

        public string branch
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public decimal controlTotal
        {
            get; //  => Get<decimal>();
            private set; //  => Set(value);
        }

        public decimal controlTotalInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public bool? createVatTransaction
        {
            get => Get<bool?>();
            set => Set(value);
        }

        [JsonProperty]
        public decimal creditTotal
        {
            get; //  => Get<decimal>();
            private set; //  => Set(value);
        }

        [JsonProperty]
        public decimal creditTotalInCurrency
        {
            get; //  => Get<decimal>();
            private set; //  => Set(value);
        }

        public string currencyId
        {
            get => Get<string>("currencyId");
            set => Set(value);
        }

        [JsonProperty]
        public decimal debitTotal
        {
            get; //  => Get<decimal>();
            private set; //  => Set(value);
        }

        [JsonProperty]
        public decimal debitTotalInCurrency
        {
            get; //  => Get<decimal>();
            private set; //  => Set(value);
        }

        public string description
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public string errorInfo { get; private set; }

        [JsonProperty]
        public decimal exchangeRate
        {
            get => Get<decimal>();
            set => Set(value);
        }

        [JsonProperty]
        public JObject extras { get; private set; }

        public string financialPeriod
        {
            get => Get<string>();
            set => Set(value);
        }

        public bool? hold
        {
            get => Get<bool?>();
            set => Set(value);
        }

        public List<JournalTransactionLine> journalTransactionLines
        {
            get => Get(defaultValue: new List<JournalTransactionLine>());
            set => Set(value);
        }

        [JsonProperty]
        public DateTime? lastModifiedDateTime
        {
            get; //  => Get<DateTime?>();
            private set; //  => Set(value);
        }

        public string ledger
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public string ledgerDescription
        {
            get; // => Get<string>();
            private set; // => Set(value);
        }

        [JsonProperty]
        public JournalTransactionModule? module
        {
            get; // => Get<JournalTransactionModule?>();
            private set; // => Set(value);
        }

        [JsonProperty]
        public string originalBatchNumber
        {
            get; //  => Get<string>();
            private set; //  => Set(value);
        }

        public string postPeriod
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public bool? reversingEntry
        {
            get; //  => Get<bool?>();
            private set; //  => Set(value);
        }

        public bool? skipVatAmountValidation
        {
            get => Get<bool?>();
            set => Set(value);
        }

        [JsonProperty]
        public JournalTransactionStatus? status
        {
            get; //  => Get<JournalTransactionStatus?>();
            private set; //  => Set(value);
        }

        public string transactionCode
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public string transactionCodeDescription
        {
            get; //  => Get<string>();
            private set; //  => Set(value);
        }

        public DateTime? transactionDate
        {
            get => Get<DateTime?>();
            set => Set(value);
        }

        public string GetIdentificator()
        {
            return batchNumber;
        }

        public void Add(JournalTransactionLine line)
        {
            line.lineNumber = 1;
            if (journalTransactionLines.Count > 0)
                line.lineNumber = Math.Max(journalTransactionLines.Count + 1,
                    journalTransactionLines.Max(x => x.lineNumber) + 1);
            journalTransactionLines.Add(line);
        }

        internal override int GetSubCount()
        {
            return journalTransactionLines.Count;
        }

        internal override void PrepareForUpdate()
        {
            foreach (var transactionLine in journalTransactionLines)
            {
                transactionLine.operation = ApiOperation.Update;
            }
        } 
    }

    public enum JournalTransactionModule
    {
        ModuleGL = 1,
        ModuleAP = 2,
        ModuleAR = 3,
        ModuleCA = 4,
        ModuleCM = 5,
        ModuleIN = 6,
        ModuleSO = 7,
        ModulePO = 8,
        ModuleDR = 9,
        ModuleFA = 10,
        ModuleEP = 11,
        ModulePM = 12,
        ModuleTX = 13,
        ModuleCR = 14
    }

    public enum JournalTransactionStatus
    {
        Hold = 1,
        Balanced = 2,
        Unposted = 3,
        Posted = 4,
        Completed = 5,
        Voided = 6,
        Released = 7,
        PartiallyReleased = 8,
        Scheduled = 9
    }
}