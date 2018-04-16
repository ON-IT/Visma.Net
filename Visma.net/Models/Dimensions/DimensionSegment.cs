using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using ONIT.VismaNetApi.Annotations;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models.Dimensions
{
    public class DimensionSegment : DtoProviderBase, IProvideIdentificator
    {
        public string dimensionId
        {
            get { return Get<NotDto<string>>(defaultValue: new NotDto<string>(string.Empty)).Value; }
            set { Set(new NotDto<string>(value)); }
        }
        public int segmentId { get; set; }

        public string description
        {
            get { return Get<string>(); }
            set { Set(value); }
        }

        public int length { get; set; }
        public string timeStamp { get; set; }
        public DateTime lastModified { get; set; }
        public bool validate { get; set; }

        public List<DimensionSegmentValue> segmentValues
        {
            get { return Get(defaultValue: new List<DimensionSegmentValue>()); }
            set { Set(value); }
        }

        public void Add(string key, string description)
        {
            segmentValues.Add(new DimensionSegmentValue
            {
                active = true,
                value = key,
                description = description
            });
        }

        internal override void PrepareForUpdate()
        {
            foreach (var dimensionSegmentValue in segmentValues)
            {
                dimensionSegmentValue.operation = ApiOperation.Update;
            }
        }

        public string GetIdentificator()
        {
            return segmentId.ToString();
        }
    }
}