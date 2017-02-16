using ONIT.VismaNetApi.Interfaces;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class IdName : IBecomeDto
    {
        public IdName()
        {
            
        }

        public IdName(string id)
        {
            this.id = id;
        }

        public string id { get; set; }
        public string name { get; set; }

        public static implicit operator IdName(string id)
        {
            return new IdName(id);
        }

        public DtoValue ToDto()
        {
            return new DtoValue(id);
        }
    }
}
