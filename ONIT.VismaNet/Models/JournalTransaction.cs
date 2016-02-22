using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class JournalTransaction : DtoProviderBase, IHaveNumber, IHaveInternalId
    {
        [JsonProperty]
        public JournalTransactionModule? module
        {
            get { return Get<JournalTransactionModule?>(); }
            private set { Set(value); }
        }

        public string batchNumber
        {
            get { return Get<string>(); }
            set { Set(value); }
        }
        [JsonProperty]
        public JournalTransactionStatus? status
        {
            get { return Get<JournalTransactionStatus?>(); }
            private set { Set(value); }
        }

        public bool? hold
        {
            get { return Get<bool?>(); }
            set { Set(value); }
        }

        public DateTime? transactionDate
        {
            get { return Get<DateTime?>(); }
            set { Set(value); }
        }

        public string postPeriod
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string financialPeriod
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string ledger
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        [JsonProperty]
        public string ledgerDescription
        {
            get { return Get<string>(); }
            private set { Set(value); }
        }

        public string currencyId
        {
            get { return Get<string>("currencyId"); }
            set { Set(value); }
        }

        public bool? autoReversing
        {
            get { return Get<bool?>(); }
            set { Set(value); }
        }

        [JsonProperty]
        public bool? reversingEntry
        {
            get { return Get<bool?>(); }
            private set { Set(value); }
        }

        public string description
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        [JsonProperty]
        public string originalBatchNumber
        {
            get { return Get<string>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal debitTotal
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal debitTotalInCurrency
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal creditTotal
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal creditTotalInCurrency
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        [JsonProperty]
        public decimal controlTotal
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        public decimal controlTotalInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public bool? createVatTransaction
        {
            get { return Get<bool?>(); }
            set { Set(value); }
        }

        public bool? skipVatAmountValidation
        {
            get { return Get<bool?>(); }
            set { Set(value); }
        }

        [JsonProperty]
        public DateTime? lastModifiedDateTime
        {
            get { return Get<DateTime?>(); }
            private set { Set(value); }
        }

        public string transactionCode
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string transactionCodeDescription
        {
            get { return Get<string>(); }
            private set { Set(value); }
        }

        public List<JournalTransactionLine> journalTransactionLines
        {
            get { return Get(defaultValue: new List<JournalTransactionLine>()); }
            set { Set(value); }
        }

        public int internalId
        {
            get
            {
                int o = 0;
                int.TryParse(batchNumber, out o);
                return o;
            }
        }

        public string number
        {
            get { return batchNumber; }
        }

        public void Add(JournalTransactionLine line)
        {
            line.lineNumber = 1;
            if (journalTransactionLines.Count > 0)
                line.lineNumber = Math.Max(journalTransactionLines.Count + 1,
                    journalTransactionLines.Max(x => x.lineNumber) + 1);
            journalTransactionLines.Add(line);
        }
    }

    public class JournalTransactionLine : DtoProviderBase
    {
        public JournalTransactionLine()
        {
            DtoFields.Add("operation", new NotDto<int>(1));
            DtoFields.Add("lineNumber", new DtoValue(0));
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

        public string accountNumber
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        [JsonProperty]
        public string description
        {
            get { return Get<string>(); }
            private set { Set(value); }
        }

        public Subaccount subaccount
        {
            get { return Get(defaultValue: new Subaccount()); }
            set { Set(value); }
        }

        public string referenceNumber
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public decimal debitAmount
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        public decimal debitAmountInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public decimal creditAmount
        {
            get { return Get<decimal>(); }
            private set { Set(value); }
        }

        public decimal creditAmountInCurrency
        {
            get { return Get<decimal>(); }
            set { Set(value); }
        }

        public string transactionDescription
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public VatCode vatCode
        {
            get { return Get<VatCode>("vatCodeId"); }
            set { Set(value); }
        }

        public Vat vat
        {
            get { return Get<Vat>("vatId"); }
            set { Set(value); }
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
        ModuleCR = 14,
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
        Scheduled = 9,
    }
}