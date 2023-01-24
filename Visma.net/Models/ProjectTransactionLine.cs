using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;
using System;

namespace ONIT.VismaNetApi.Models
{
    public class ProjectTransactionLine : DtoProviderBase
    {
        public int tranId { get { return Get<int>(); } set { Set(value); } }
        public DateTime date { get { return Get<DateTime>(); } set { Set(value); } }
        public NumberDescription inventoryId { get { return Get<NumberDescription>(); } set { Set(value); } }
        public string uom { get { return Get<string>(); } set { Set(value); } }
        public int quantity { get { return Get<int>(); } set { Set(value); } }
        public int billableQuantity { get { return Get<int>(); } set { Set(value); } }
        public int unitRate { get { return Get<int>(); } set { Set(value); } }
        public int amount { get { return Get<int>(); } set { Set(value); } }
        public bool billable { get { return Get<bool>(); } set { Set(value); } }
        public string financialPeriod { get { return Get<string>(); } set { Set(value); } }
        public string batchNbr { get { return Get<string>(); } set { Set(value); } }
        public bool useBillableQty { get { return Get<bool>(); } set { Set(value); } }
        public DescriptionId project { get { return Get<DescriptionId>(); } set { Set(value); } }
        public DescriptionId projectTask { get { return Get<DescriptionId>(); } set { Set(value); } }
        public NumberDescriptionType debitAccount { get { return Get<NumberDescriptionType>(); } set { Set(value); } }
        public DescriptionId debitSubaccount { get { return Get<DescriptionId>(); } set { Set(value); } }
        public NumberDescriptionType creditAccount { get { return Get<NumberDescriptionType>(); } set { Set(value); } }
        public DescriptionId creditSubaccount { get { return Get<DescriptionId>(); } set { Set(value); } }
        public NumberName branch { get { return Get<NumberName>(); } set { Set(value); } }
        public Employee employee { get { return Get<Employee>(); } set { Set(value); } }
        public NumberName customerVendor { get { return Get<NumberName>(); } set { Set(value); } }
        public NumberName accountGroup { get { return Get<NumberName>(); } set { Set(value); } }
        public IdName location { get { return Get<IdName>(); } set { Set(value); } }
        public string description { get { return Get<string>(); } set { Set(value); } }

        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }

        public bool allocated { get { return Get<bool>(); } private set { Set(value); } }
        public NumberName debitAccountGroup { get { return Get<NumberName>(); } private set { Set(value); } }
        public DateTime endDate { get { return Get<DateTime>(); } private set { Set(value); } }
        public DateTime lastModifiedDateTime { get { return Get<DateTime>(); } private set { Set(value); } }
        public int overtimeMultiplier { get { return Get<int>(); } private set { Set(value); } }
        public bool released { get { return Get<bool>(); } private set { Set(value); } }
        public DateTime startDate { get { return Get<DateTime>(); } private set { Set(value); } }
    }
}
