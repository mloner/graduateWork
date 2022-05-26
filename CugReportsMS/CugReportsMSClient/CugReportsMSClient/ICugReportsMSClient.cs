using CugReportsMSClient.Dtos;

namespace CugReportsMSClient;

public interface ICugReportsMSClient
{
    void Init(CugReportsMSSettings settings);
    Task<Guid> CreateReportAsync(ReportParameters reportParameters);
    Task<CustomFile> DownloadReportAsync(Guid reportGuid);
}