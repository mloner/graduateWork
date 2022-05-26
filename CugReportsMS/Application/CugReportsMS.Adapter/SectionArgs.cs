using System.Collections.Generic;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;

namespace ReportingFramework
{
    public class SectionArgs
    {
        public Dictionary<string, object> ReportCommonData { get; set; }
        public ReportAdapterParameters ReportAdapterParameters { get; set; }
        public CsvReader CsvReader { get; set; }
    }
}