using Newtonsoft.Json;
using ONIT.VismaNetApi.Interfaces;

namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class GLAccountDetailsDto : IBecomeDto
    {
        public string description { get; private set; }

        public string number { get; set; }

        public string type { get; private set; }

        public DtoValue ToDto()
        {
            return new DtoValue(number);
        }
    }
}