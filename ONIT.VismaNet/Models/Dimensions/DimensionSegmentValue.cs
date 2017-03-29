using System;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models.Dimensions
{
    public class DimensionSegmentValue : DtoProviderBase
    {
        public DimensionSegmentValue()
        {
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }
        public ApiOperation operation
        {
            get { return Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value; }
            set { Set(new NotDto<ApiOperation>(value)); }
        }

        public string value
        {
            get { return valueId; }
            set { valueId = value; }
        }

        [JsonProperty]
        private string valueId { get; set; }

        public string description
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public bool active
        {
            get { return Get<bool>(); }
            set { Set(value); }
        }

        public string timeStamp { get; set; }
        public DateTime lastModified { get; set; }
    }
}