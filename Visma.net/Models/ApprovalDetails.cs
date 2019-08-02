using ONIT.VismaNetApi.Lib;

namespace ONIT.VismaNetApi.Models
{
    public class ApprovalDetails : DtoProviderBase, IProvideCustomDto
    {
        public string attachmentID { get => Get<string>(); set => Set(value); }
        public string comment { get => Get<string>(); set => Set(value); }

        public object ToDto()
        {
            return base.ToDto();
        }
    }
}