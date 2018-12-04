using ONIT.VismaNetApi.Interfaces;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class Baccount : IBecomeDto
    {
        public int internalId { get; set; }
        public string number { get; set; }
        public string name { get; set; }
        public DtoValue ToDto()
        {
            return new DtoValue(number);
        }

        public override string ToString()
        {
            return !string.IsNullOrEmpty(name) ? $"{number} [{name}]" : number;
        }
    }
}