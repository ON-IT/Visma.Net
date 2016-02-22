using System;

namespace ONIT.VismaNetApi.Models.Dimensions
{
    public class DimensionSegmentValue
    {
        public string valueId { get; set; }
        public string description { get; set; }
        public bool active { get; set; }
        public string timeStamp { get; set; }
        public DateTime lastModified { get; set; }
    }
}