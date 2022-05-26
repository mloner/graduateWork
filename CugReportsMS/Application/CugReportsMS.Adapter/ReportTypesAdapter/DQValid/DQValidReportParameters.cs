namespace ReportingFramework.ReportTypesAdapter.DQValid
{
    public class DQValidReportParameters : CugReportMicroservice.Dtos.ReportingAdapterDataModels.ReportParameters
    {
        public new DQValidReportCustomParameters CustomParameters { get; set; }
    }
}