using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using SectionModels;

namespace CugReportMicroservice.Dtos
{
    public interface IReportingAssembler
    {
        Task InitReportStructure(ReportModel reportModel, ReportParameters reportParameters, int reportId);
    }
}