namespace ONIT.VismaNetApi.Models
{
    public class DtoValue
    {
        public object Value { get; set; }

        public DtoValue()
        {
        }

        public DtoValue(object value)
        {
            Value = value;
        }
    }
}