using ONIT.VismaNetApi.Interfaces;

namespace ONIT.VismaNetApi.Models
{
    public class Owner : IBecomeDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public DtoValue ToDto()
        {
            return new DtoValue(id);
        }
    }
}