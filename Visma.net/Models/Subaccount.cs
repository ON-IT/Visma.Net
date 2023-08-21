﻿using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;

namespace ONIT.VismaNetApi.Models
{
    public class Subaccount : DtoPaginatedProviderBase, IProvideIdentificator
    {
        private List<Segment> _segments;

        public string subaccountNumber { get => Get<string>(); set => Set(value); }

        [JsonProperty]
        public string description { get => Get<string>(); set => Set(value); }

        [JsonProperty]
        public int id { get; private set; }

        [JsonProperty]

        public JObject extras { get; private set; }

        [JsonProperty]
        public string errorInfo { get; private set; }

        public string this[int segmentId]
        {
            get
            {
                if (segments == null || segments.Count == 0 || segments.All(x => x.segmentId != segmentId))
                    return string.Empty;
                var firstOrDefault = segments.FirstOrDefault(x => x.segmentId == segmentId);
                if (firstOrDefault != null)
                    return firstOrDefault.segmentValue;
                return string.Empty;
            }
            set
            {
                var firstOrDefault = segments.FirstOrDefault(x => x.segmentId == segmentId);
                if (firstOrDefault != null)
                {
                    firstOrDefault.segmentValue = value;
                }
                else
                {
                    segments.Add(new Segment {segmentId = segmentId, segmentValue = value});
                }
            }
        }

        [JsonProperty]
        public string lastModifiedDateTime { get; private set; }

        [JsonProperty]
        public List<Segment> segments
        {
            get => _segments ?? (_segments = new List<Segment>());
            private set => _segments = value;
        }

       /* public string subaccountCd
        {
            get => Get<string>();
            set => Set(value);
        }*/

        public int subaccountId
        {
            get => Get<int>();
            set => Set(value);
        }

        public bool active
        {
            get => Get<bool>();
            set => Set(value);
        }

        public string GetIdentificator()
        {
            return subaccountId.ToString();
        }
    }
}