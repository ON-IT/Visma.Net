using System.Collections.Generic;
using System.Linq;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class Subaccount : IProvideCustomDto
    {
        public string description { get; set; }
        public int id { get; set; }
        public string lastModifiedDateTime { get; set; }
        public List<Segment> segments { get; set; }

        public bool HasSegments
        {
            get { return segments != null && segments.Count > 0; }
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
                if (segments == null)
                    segments = new List<Segment>();
                var firstOrDefault = segments.FirstOrDefault(x => x.segmentId == segmentId);
                if (firstOrDefault != null)
                {
                    firstOrDefault.segmentValue = value;
                }
                else
                {
                    segments.Add(new Segment() {segmentId = segmentId, segmentValue = value});
                }
            }
        }

        public object ToDto()
        {
            return segments.Select(x => new {x.segmentId, x.segmentValue});
        }
    }
}