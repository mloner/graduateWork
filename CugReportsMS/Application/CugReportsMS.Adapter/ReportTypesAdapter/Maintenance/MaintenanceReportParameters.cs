namespace ReportingFramework.ReportTypesAdapter.Maintenance
{
    public class MaintenanceReportParameters : CugReportMicroservice.Dtos.ReportingAdapterDataModels.ReportParameters
    {
        public new MaintenanceReportCustomParameters CustomParameters { get; set; }
    }
    
}