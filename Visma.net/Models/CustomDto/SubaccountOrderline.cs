using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class SubaccountOrderLine : IProvideCustomDto
    {
        private List<Segment> _segments;

        [JsonProperty]
        public string description { get; private set; }
        [JsonProperty]
        public string id { get; private set; }
        [JsonProperty]
        public List<Segment> segments
        {
            get => _segments ?? (_segments = new List<Segment>());
            private set => _segments = value;
        }
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