using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class Packaging : DtoProviderBase
    {
        public decimal baseItemWeight { get; set; }
        public string weightUOM { get; set; }
        public decimal baseItemVolume { get; set; }
        public string volumeUOM { get; set; }

    }
}