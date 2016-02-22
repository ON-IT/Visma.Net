using System.Collections.Generic;

namespace ONIT.VismaNetApi.Interfaces
{
    public interface IProvideDto
    {
        Dictionary<string, object> ToDto();
    }
}