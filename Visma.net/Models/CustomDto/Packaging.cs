using ONIT.VismaNetApi.Interfaces;
using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class Packaging : DtoProviderBase, IProvideCustomDto
    {
        public decimal baseItemWeight
        {
            get => Get<decimal>("baseItemWeight");
            set => Set(value);
        }
        public string weightUOM
        {
            get => Get<string>();
            set => Set(value?.Trim());
        }
        public decimal baseItemVolume
        {
            get => Get<decimal>();
            set => Set(value);
        }
        public string volumeUOM
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