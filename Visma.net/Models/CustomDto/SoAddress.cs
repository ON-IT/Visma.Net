namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class SoAddress : Address
    {
        public bool overrideAddress
        {
            get => Get<bool>();
            set => Set(value);
        }
    }
}