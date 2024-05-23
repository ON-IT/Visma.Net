using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class Intrastat : DtoProviderBase, IProvideCustomDto

    {
        public string cN8
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }
        public string countryOfOrigin
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }
        public string supplementaryMeasureUnit
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }
        public object ToDto()
        {
            return base.ToDto();
        }
    }
}