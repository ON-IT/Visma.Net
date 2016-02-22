using ONIT.VismaNetApi.Models;

namespace ONIT.VismaNetApi.Lib.Data
{
    public abstract class BaseDataClass
    {
        protected string ApiControllerUri { get; set; }
        protected VismaNetAuthorization Authorization { get; set; }

        
        internal BaseDataClass(VismaNetAuthorization auth)
        {
            Authorization = auth;
        }
    }
}