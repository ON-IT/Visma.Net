namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class PoAddress : Address
    {
        public bool overrideAddress
        {
            get => Get<bool>();
            set => Set(value);
        }
    }
}