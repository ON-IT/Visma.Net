using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class Subaccount : IProvideCustomDto
    {
        private List<Segment> _segments;

        [JsonProperty]
        public string description { get; private set; }
        [JsonProperty]
        public int id { get; private set; }
        [JsonProperty]
        public int subaccountId { get; private set; }
        [JsonProperty]
        public string lastModifiedDateTime { get; private set; }

        [JsonProperty] public string subaccountNumber { get; private set; }

        [JsonProperty]
        public List<Segment> segments
        {
            get => _segments ?? (_segments = new List<Segment>());
            private set => _segments = value;
        }
        [JsonProperty]
        public string errorInfo { get; private set; }

        [JsonProperty] 
        public JObject extras { get; private set; }

        /// <summary>
        /// Sets a segment (department, project) for an invoice line. Remember that you have to set ALL segments for a line.
        /// </summary>
        /// <param name="segmentId"></param>
        /// <returns></returns>
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

        public object ToDto()
        {
            return segments.Select(x => new {x.segmentId, x.segmentValue});
        }
    }
}