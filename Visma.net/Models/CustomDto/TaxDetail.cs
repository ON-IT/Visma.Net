namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class TaxDetail
    {
        public decimal taxableAmount { get; set; }
        public decimal vatAmount { get; set; }
        public string taxId { get; set; }
        public decimal taxRate { get; set; }
    }
}