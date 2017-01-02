namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class Segment
    {
        public int segmentId { get; set; } = 1; // since version 6.01 this should by default 1, instead of 0
        public string segmentDescription { get; set; }
        public string segmentValue { get; set; }
        public string segmentValueDescription { get; set; }
    }
}