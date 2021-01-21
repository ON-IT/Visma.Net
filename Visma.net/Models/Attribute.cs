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
    public class Attribute : DtoPaginatedProviderBase, IProvideIdentificator
    {
        public Attribute(string attributeID)
        {
            this.attributeID = attributeID;
        }
        public string attributeID
        {
            get => Get<string>();
            set => Set(value);
        }
        public string description
        {
            get => Get<string>();
            set => Set(value);
        }
        public string controlType
        {
            get => Get<string>();
            set => Set(value);
        }
        public bool Internal
        {
            get => Get<bool>();
            set => Set(value);
        }
        public string entryMask
        {
            get => Get<string>();
            set => Set(value);
        }
        public string regExp
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty] public DateTime createdDateTime { get; private set; }
        [JsonProperty] public DateTime lastModifiedDateTime { get; private set; }

        [JsonProperty] public string errorInfo { get; private set; }

        [JsonProperty]
        public List<AttributeDetails> details
        {
            get => Get(defaultValue: new List<AttributeDetails>());
            private set => Set(value);
        }

        public string GetIdentificator()
        {
            return attributeID;
        }

        internal override void PrepareForUpdate()
        {
            foreach (var detail in details)
            {
                detail.operation = ApiOperation.Update;
            }

            IgnoreProperties.Add(nameof(attributeID));
        }
    }
}