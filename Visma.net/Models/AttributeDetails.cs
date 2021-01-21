using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class AttributeDetails : DtoProviderBase
    {
        public AttributeDetails()
        {
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }
        [JsonIgnore]
        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }

        public string valueId
        {
            get => Get<string>();
            set => Set(value);
        }
        public string description
        {
            get => Get<string>();
            set => Set(value);
        }
        public int sortOrder
        {
            get => Get<int>();
            set => Set(value);
        }
        public bool disabled
        {
            get => Get<bool>();
            set => Set(value);
        }

        [JsonProperty] public string errorInfo { get; private set; }
    }
}