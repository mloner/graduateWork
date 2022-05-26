using Newtonsoft.Json.Linq;

namespace CugReportsMSClient.Dtos;

public class ReportParameters
{
    public int ReportType { get; set; }
    public JObject CustomParameters { get; set; }
}