using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class Country : IdName
    {
        public Country(string countryId) : base(countryId)
        {
            
        }

        public Country()
        {
            
        }

        [JsonProperty]
        public JObject extras { get; private set; }

        [JsonProperty]
        public string errorInfo { get; private set; }
        
        [JsonProperty]
        public Metadata metadata { get; private set; }

        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(name) ? id : $"{id} - {name}";
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