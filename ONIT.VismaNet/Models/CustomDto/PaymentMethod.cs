namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class PaymentMethod : DescriptiveDto
    {
        public PaymentMethod()
        {
            
        }

        public PaymentMethod(string id)
        {
            this.id = id;
        }

        public static implicit operator PaymentMethod(string id)
        {
            return new PaymentMethod(id);
        }
    }
}