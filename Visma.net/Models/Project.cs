using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.Enums;

namespace ONIT.VismaNetApi.Models
{

    public class Project : DtoProviderBase, IProvideIdentificator
    {
        public Project()
        {
            IgnoreProperties.Add(nameof(this.projectID));
            IgnoreProperties.Add(nameof(this.internalID));
        }

        public Project(string projectNumber)
        {
            projectID = projectNumber;
            IgnoreProperties.Add(nameof(this.internalID));
        }
        [JsonProperty]
        public double assets { get; private set; }
        [JsonProperty]
        public double liability { get; private set; }
        [JsonProperty]
        public double income { get; private set; }
        [JsonProperty]
        public double expenses { get; private set; }
        public int internalID { get { return Get<int>(); } set { Set(value); } }
        public string projectID { get { return Get<string>(); } set { Set(value); } }
        public CustomerSummary customer { get { return Get<CustomerSummary>(); } set { Set(value); } }
        public bool hold { get { return Get<bool>(); } set { Set(value); } }
        public string status { get { return Get<string>(); } set { Set(value); } }
        public DescriptiveDto template { get { return Get<DescriptiveDto>(); } set { Set(value); } }
        public string description { get { return Get<string>(); } set { Set(value); } }
        public DateTime startDate { get { return Get<DateTime>(); } set { Set(value); } }
        public DateTime endDate { get { return Get<DateTime>(); } set { Set(value); } }

        public ProjectManager projectManager {
            get => Get("projectManger", new ProjectManager()); // Misspelled in Visma API projectManger not projectManager
            set => Set(value, "employeeNumber");
        }

        public bool restrictEmployees { get { return Get<bool>(); } set { Set(value); } }
        public bool restrictEquipment { get { return Get<bool>(); } set { Set(value); } }
        public Visibility visibility { get { return Get(defaultValue:new Visibility()); } set { Set(value); } }
        public CustomDto.SubaccountProject defSub
        {
            get => Get("defSub",defaultValue: new CustomDto.SubaccountProject());
            set => Set(value);
        }
        public string billingPeriod { get { return Get<string>(); } set { Set(value); } }
        //public DescriptiveDto customerLocation { get { return Get<DescriptiveDto>(); } set { Set(value); } }
        public DescriptiveDto allocationRule { get { return Get<DescriptiveDto>(); } set { Set(value); } }
        public DescriptiveDto billingRule { get { return Get<DescriptiveDto>(); } set { Set(value); } }
        public DescriptiveDto rateTable { get { return Get<DescriptiveDto>(); } set { Set(value); } }
        public bool autoAllocate { get { return Get<bool>(); } set { Set(value); } }
        public bool automaticReleaseAr { get { return Get<bool>(); } set { Set(value); } }
        public List<ProjectTask> tasks { get { return Get(defaultValue: new List<ProjectTask>()); } set{Set(value);} }
        public DateTime lastModifiedDateTime { get; set; }
        internal override void PrepareForUpdate()
        {
            foreach (var projectTask in tasks)
            {
                projectTask.operation = ApiOperation.Update;
            }
            base.PrepareForUpdate();
        }

        public string number => projectID;

        //public int internalId => internalID;
        public string GetIdentificator()
        {
            return projectID;
        }
    }
}
