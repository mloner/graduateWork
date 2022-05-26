using Newtonsoft.Json;

namespace CugReportMicroservice.Dtos.ReportingAdapterDataModels
{
    public class ReportParameters
    {
        [JsonProperty("ReportType")]
        public int Type { get; set; }
        //public double Version { get; set; }
        public int Template { get; set; }
        public int Language { get; set; }
        public string? DataFolder { get; set; }
        public CustomParameters CustomParameters { get; set; }
    }
}