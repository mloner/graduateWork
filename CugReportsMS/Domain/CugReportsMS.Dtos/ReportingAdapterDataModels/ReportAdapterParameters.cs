namespace CugReportMicroservice.Dtos.ReportingAdapterDataModels
{
    public class ReportAdapterParameters
    {
        public int ReportId { get; set; }
        public ReportParameters ReportParameters { get; set; }
        public string ReportDataFolderPath { get; set; }
    }
}