using System;
using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models
{
    public class FinAccount : DtoProviderBase
    {
        public int accountID
        {
            get { return Get<int>(); }
            set { Set(value); }
        }

        public string accountCD
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string accountClass
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string type
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public bool active
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public string description
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public bool useDefaultSub
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public string postOption
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string currency
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public string taxCategory
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public bool cashAccount
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public DateTime lastModifiedDateTime
        {
            get { return Get<DateTime>(); }
            set { Set(value); }
        }
    }
}