using System;

namespace ONIT.VismaNetApi.Models.Dimensions
{
    public class DimensionSegment
    {
        public int segmentId { get; set; }
        public string description { get; set; }
        public int length { get; set; }
        public string timeStamp { get; set; }
        public DateTime lastModified { get; set; }
        public bool validate { get; set; }
        public DimensionSegmentValue[] segmentValues { get; set; }
    }
}