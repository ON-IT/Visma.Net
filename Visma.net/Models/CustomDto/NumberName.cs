using Newtonsoft.Json;
using ONIT.VismaNetApi.Interfaces;

namespace ONIT.VismaNetApi.Models
{
    public class NumberName : IBecomeDto
    {
        public NumberName()
        {
            
        }

        public NumberName(string number)
        {
            this.number = number;
        }
        public string number { get; set; }
        public string name { get; set; }

        public static implicit operator NumberName(string number)
        {
            return new NumberName(number);
        }

        public override string ToString()
        {
            if(!string.IsNullOrEmpty(name))
                return $"{number} [{name}]";
            return number;
        }

        public DtoValue ToDto()
        {
            return new DtoValue(number);
        }
    }

    public class NumberDescription : IBecomeDto
    {
        public NumberDescription()
        {

        }

        public NumberDescription(string number)
        {
            this.number = number;
        }
        public string number { get; set; }
        
        [JsonProperty]
        public string description { get; private set; }

        public static implicit operator NumberDescription(string number)
        {
            return new NumberDescription(number);
        }

        public DtoValue ToDto()
        {
            return new DtoValue(number);
        }
    }
}