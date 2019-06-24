namespace ONIT.VismaNetApi.Models
{
    public class CustomerVatZone : DescriptiveDto
    {
        public string defaultVatCategory { get; set; }

        public NumberDescription defaultTaxCategory { get; set; }
    }
}