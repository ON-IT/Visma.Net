using ONIT.VismaNetApi.Lib;
using System.Collections.Generic;

namespace ONIT.VismaNetApi.Models
{
    public class ProjectTransaction : DtoPaginatedProviderBase, IProvideIdentificator
    {
        public string refNbr { get { return Get<string>(); } set { Set(value); } }
        public string description { get { return Get<string>(); } set { Set(value); } }
        public string module { get { return Get<string>(); } set { Set(value); } }
        public string status { get { return Get<string>(); } set { Set(value); } }
        public List<ProjectTransactionLine> lines
        {
            get { return Get(defaultValue: new List<ProjectTransactionLine>()); }
            private set { Set(value); }
        }

        public string GetIdentificator()
        {
            return this.refNbr;
        }
        public void Add(ProjectTransactionLine line)
        {
            lines.Add(line);
        }
    }
}
