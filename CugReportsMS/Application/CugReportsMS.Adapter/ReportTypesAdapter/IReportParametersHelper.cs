using CugReportMicroservice.Dtos.ReportingAdapterDataModels;

namespace ReportingFramework.ReportTypesAdapter
{
    public interface IReportParametersHelper
    {
        ReportParameters GetReportParameters(double reportVersion, string reportParametersJson);
    }
}