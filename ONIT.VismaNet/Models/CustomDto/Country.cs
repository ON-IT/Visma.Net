namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class Country : DescriptiveDto
    {
        public Country(string countryId) : base(countryId)
        {
            
        }

        public Country()
        {
            
        }

        public static implicit operator Country(string id)
        {
            return new Country(id);
        }
    }

    public class State : DescriptiveDto
    {
        public State(string stateId) : base(stateId)
        {
            
        }

        public State()
        {
            
        }

        public static implicit operator State(string id)
        {
            return new State(id);
        }
    }
}