using ONIT.VismaNetApi.Interfaces;

namespace ONIT.VismaNetApi.Models
{
    public class NumberName : IBecomeDto
    {
        public string number { get; set; }
        public string name { get; set; }

        public DtoValue ToDto()
        {
            return new DtoValue(number);
        }
    }
}