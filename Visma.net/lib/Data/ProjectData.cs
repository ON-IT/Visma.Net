using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public class ProjectData : BasePaginatedCrudDataClass<Project>
    {
        internal ProjectData(VismaNetAuthorization auth) : base(auth)
        {
            ApiControllerUri = VismaNetControllers.Project;
        }
    }
}
