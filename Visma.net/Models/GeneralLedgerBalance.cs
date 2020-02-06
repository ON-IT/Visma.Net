using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONIT.VismaNetApi.Models
{
    public class GeneralLedgerBalance : DtoProviderBase, IProvideIdentificator
    {
        /*
        {
    "branch": {
      "number": "string",
      "name": "string"
    },
    "ledger": {
      "id": "string",
      "description": "string"
    },
    "balanceType": "Actual",
    "financialPeriod": "string",
    "account": {
      "type": "Asset",
      "externalCode1": "string",
      "externalCode2": "string",
      "externalCode1Info": {
        "number": "string",
        "description": "string"
      },
      "externalCode2Info": {
        "number": "string",
        "description": "string"
      },
      "glConsolAccountCD": "string",
      "number": "string",
      "description": "string"
    },
    "subaccountId": "string",
    "subAccountCd": "string",
    "currencyId": "string",
    "periodToDateDebit": 0,
    "periodToDateCredit": 0,
    "beginningBalance": 0,
    "yearToDateBalance": 0,
    "periodToDateDebitInCurrency": 0,
    "periodToDateCreditInCurrency": 0,
    "beginningBalanceInCurrency": 0,
    "yearToDateBalanceInCurrency": 0,
    "yearClosed": true,
    "extras": {
      "additionalProp1": {},
      "additionalProp2": {},
      "additionalProp3": {}
    },
    "errorInfo": "string",
    "metadata": {
      "totalCount": 0
    }
  }
        */
        public NumberName branch
        {
            get => Get<NumberName>();
            set => Set(value);
        }
        public DescriptionId ledger
        {
            get => Get<DescriptionId>();
            set => Set(value);
        }
        public string balanceType
        {
            get => Get<string>();
            set => Set(value);
        }
        public string financialPeriod
        {
            get => Get<string>();
            set => Set(value);
        }
        public Account account
        {
            get => Get<Account>();
            set => Set(value);
        }

        public string subaccountId
        {
            get => Get<string>();
            set => Set(value);
        }
        public string subAccountCd
        {
            get => Get<string>();
            set => Set(value);
        }
        public string currencyId
        {
            get => Get<string>();
            set => Set(value);
        }
        public decimal periodToDateDebit
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal periodToDateCredit
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal beginningBalance
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal yearToDateBalance
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal periodToDateDebitInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal periodToDateCreditInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public decimal beginningBalanceInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }

        public decimal yearToDateBalanceInCurrency
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public bool yearClosed
        {
            get => Get<bool>();
            set => Set(value);
        }

        [JsonProperty]
        public JObject extras { get; private set; }

        public string GetIdentificator()
        {
            return financialPeriod.ToString();
        }
    }
}
