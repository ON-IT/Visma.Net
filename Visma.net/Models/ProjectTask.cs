using System;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{
    public class ProjectTask : DtoProviderBase
    {
        public ProjectTask()
        {
            DtoFields.Add("operation", new NotDto<ApiOperation>(ApiOperation.Insert));
        }

        public ApiOperation operation
        {
            get { return Get(defaultValue: new NotDto<ApiOperation>(ApiOperation.Insert)).Value; }
            set { Set(new NotDto<ApiOperation>(value)); }
        }

        public string taskId { get { return Get<string>();  } set { Set(value);} }
        public string description { get { return Get<string>(); } set { Set(value); } }
        public DateTime plannedStart { get { return Get<DateTime>(); } set { Set(value); } }
        public DateTime plannedEnd { get { return Get<DateTime>(); } set { Set(value); } }
        public DateTime startDate { get { return Get<DateTime>(); } set { Set(value); } }
        public DescriptiveDto rateTable { get { return Get<DescriptiveDto>(); } set { Set(value); } }

        public string status { get { return Get<string>(); } set { Set(value); } }
    }
}