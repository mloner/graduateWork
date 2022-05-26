using SectionModels;

namespace ReportGeneratorClient;

public interface IReportGeneratorClient
{
    void Init(ReportGeneratorSettings settings);
    Task<Guid> CreateReportAsync(ReportModel reportModel);
    Task<ReportStatus> GetReportStatus(Guid reportGuid);
    Task<Stream> DownloadReportAsync(Guid reportGuid);
    Task<Stream> DownloadReportWithDataAsync(Guid reportGuid);
}