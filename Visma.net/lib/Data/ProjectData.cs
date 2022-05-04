using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class ProjectData : BaseCrudDataClass<Project>
    {
        internal ProjectData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.Project;
        }
    }
}
