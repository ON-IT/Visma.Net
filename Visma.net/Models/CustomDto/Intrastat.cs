using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class Intrastat : DtoProviderBase

    {
        public string cN8 { get; set; }
        public string countryOfOrigin { get; set; }
        public string supplementaryMeasureUnit { get; set; }

    }
}