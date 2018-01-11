using ONIT.VismaNetApi.Lib;
using ONIT.VismaNetApi.Models.CustomDto;
using System.Collections.Generic;
using System.Linq;

namespace ONIT.VismaNetApi.Models
{
    public class Subaccount : DtoProviderBase, IProvideIdentificator
    {
        public string GetIdentificator()
        {
            return subaccountId.ToString();
        }
        public string description {
            get { return Get<string>(); }
            set { Set(value); }
        }
        public int subaccountId {
            get { return Get<int>(); }
            set { Set(value); }
        }
        public int id { get; set; }
        public string lastModifiedDateTime { get; set; }
        public List<Segment> segments { get; set; }

        public string this[int segmentId]
        {
            get
            {
                if (segments == null || segments.Count == 0 || segments.All(x => x.segmentId != segmentId))
                    return string.Empty;
                var firstOrDefault = segments.FirstOrDefault(x => x.segmentId == segmentId);
                if (firstOrDefault != null)
                    return firstOrDefault.segmentValue;
                return string.Empty;
            }
            set
            {
                if (segments == null)
                    segments = new List<Segment>();
                var firstOrDefault = segments.FirstOrDefault(x => x.segmentId == segmentId);
                if (firstOrDefault != null)
                {
                    firstOrDefault.segmentValue = value;
                }
                else
                {
                    segments.Add(new Segment() { segmentId = segmentId, segmentValue = value });
                }
            }
        }
        public string subaccountCd {
            get { return Get<string>(); }
            set { Set(value); }
        }
        public bool active {
            get { return Get<bool>(); }
            set { Set(value); }
        }
    }
}
