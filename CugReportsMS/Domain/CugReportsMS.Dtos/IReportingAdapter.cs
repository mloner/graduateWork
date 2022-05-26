using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using SectionModels;

namespace CugReportMicroservice.Dtos
{
    public interface IReportingAdapter
    {
        void Init(ReportParameters reportParameters);
        Task<ReportModel> CreateReportModel(int reportFormatId, string reportDataFolderPath, int reportId);
    }
}