using ReportingFramework.ReportTypesAdapter.MCEM.CustomParameters;

namespace ReportingFramework.ReportTypesAdapter.MCEM.ReportParameters
{
    public class MCEMReportParametersV0_1 : MCEMReportParameters
    {
        public new MCEMReportCustomParametersV0_1 CustomParameters { get; set; }
    }
}