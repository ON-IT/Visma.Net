using System;
using System.Collections.Generic;
using ONIT.VismaNetApi.Interfaces;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{

    public class InventoryAdjustment : DtoProviderBase, IProvideIdentificator
    {
        public int totalCost { get { return Get<int>(); } set { Set(value); } }
        public int controlCost { get { return Get<int>(); } set { Set(value); } }
        
        public List<Adjustmentline> adjusmentLines
        {
            get { return Get(defaultValue: new List<Adjustmentline>()); }
            private set { Set(value); }
        }

        public string referenceNumber { get { return Get<string>(); } set { Set(value); } }
        public string status { get { return Get<string>(); } set { Set(value); } }
        public bool hold { get { return Get<bool>(); } set { Set(value); } }
        public DateTime date { get { return Get<DateTime>(); } set { Set(value); } }
        public string postPeriod { get { return Get<string>(); } set { Set(value); } }
        public string externalReference { get { return Get<string>(); } set { Set(value); } }
        public string description { get { return Get<string>(); } set { Set(value); } }
        public int totalQuantity { get { return Get<int>(); } set { Set(value); } }
        public int controlQuantity { get { return Get<int>(); } set { Set(value); } }
        public string batchNumber { get { return Get<string>(); } set { Set(value); } }
        public DateTime lastModifiedDateTime { get { return Get<DateTime>(); } set { Set(value); } }

        public List<Attachment> attachments
        {
            get { return Get(defaultValue: new List<Attachment>()); } 
            private set { Set(value);}
        }

        public string GetIdentificator()
        {
            return referenceNumber;
        }
    }

    public class Adjustmentline : DtoProviderBase
    {
        public ApiOperation operation
        {
            get { return Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value; }
            set { Set(new NotDto<ApiOperation>(value)); }
        }
        public Warehouse warehouse { get { return Get<Warehouse>(); } set { Set(value); } }
        public int unitCost { get { return Get<int>(); } set { Set(value); } }
        public int extCost { get { return Get<int>(); } set { Set(value); } }
        public string receiptNumber { get { return Get<string>(); } set { Set(value); } }
        public int lineNumber { get { return Get<int>(); } set { Set(value); } }
        public Inventoryitem inventoryItem { get { return Get<Inventoryitem>("inventoryNumber"); } set { Set(value, "inventoryNumber"); } }
        public Location location { get { return Get<Location>(); } set { Set(value); } }
        public int quantity { get { return Get<int>(); } set { Set(value); } }
        public string uom { get { return Get<string>(); } set { Set(value); } }
        public DescriptiveDto reasonCode { get { return Get<DescriptiveDto>(); } set { Set(value); } }
        public string description { get { return Get<string>(); } set { Set(value); } }

        public List<Attachment> attachments
        {
            get { return Get(defaultValue: new List<Attachment>()); }
            set { Set(value); }
        }
    }

   
    public class Inventoryitem  : IBecomeDto
    {
        public string number { get; set; }
        public string description { get; set; }
        public DtoValue ToDto()
        {
            return new DtoValue(number);
        }
    }

    public class Attachment
    {
        public string name { get; set; }
        public string id { get; set; }
        public int revision { get; set; }
    }
}
