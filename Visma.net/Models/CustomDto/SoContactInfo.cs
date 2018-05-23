namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class SoContactInfo : ContactInfo
    {
        public bool overrideContact
        {
            get => Get<bool>();
            set => Set(value);
        }
    }
}