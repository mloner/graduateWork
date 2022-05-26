using System.Collections.Generic;

namespace ReportingFramework.Dto
{
    public class SectionData
    {
        public string Title { get; set; }
        public List<IReportObject> ReportObjects { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }
}