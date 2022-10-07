using Newtonsoft.Json;
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

        [JsonProperty]
        public string name { get; private set; }

        public static implicit operator IdName(string id)
        {
            return new IdName(id);
        }

        public DtoValue ToDto()
        {
            return new DtoValue(id);
        }
    }

    public class IdDescription : IBecomeDto
    {
        public IdDescription()
        {

        }

        public IdDescription(string id)
        {
            this.id = id;
        }

        public string id { get; set; }

        [JsonProperty]
        public string descriptuin { get; private set; }

        public static implicit operator IdDescription(string id)
        {
            return new IdDescription(id);
        }

        public DtoValue ToDto()
        {
            return new DtoValue(id);
        }
    }

    public class IdValue : IBecomeDto
    {
        public IdValue()
        {

        }

        public IdValue(string id)
        {
            this.id = id;
        }

        public string id { get; set; }
        public string value { get; set; }

        public static implicit operator IdValue(string id)
        {
            return new IdValue(id);
        }

        public DtoValue ToDto()
        {
            return new DtoValue(id);
        }
    }
}
