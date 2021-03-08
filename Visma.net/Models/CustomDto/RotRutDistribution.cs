using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    class RotRutDistribution : DtoProviderBase
    {
        public RotRutDistribution()
        {
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }
        [JsonIgnore]
        public ApiOperation operation
        {
            get => Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value;
            set => Set(new NotDto<ApiOperation>(value));
        }
        public int lineNbr
        {
            get => Get<int>();
            set => Set(value);
        }
        public string personalId
        {
            get => Get<string>();
            set => Set(value);
        }

        public double amount
        {
            get => Get<double>();
            set => Set(value);
        }
        public bool extra
        {
            get => Get<bool>();
            set => Set(value);
        }
    }
}
