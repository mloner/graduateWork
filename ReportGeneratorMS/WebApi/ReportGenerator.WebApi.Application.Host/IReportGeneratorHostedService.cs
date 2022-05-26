using System.Text.Json;
using ReportingFramework.Dto;

namespace ReportGenerator.Host;

public interface IReportGeneratorHostedService : IHostedService
{
    Task CreateReportAsync(JsonElement reportModelJson, Guid reportGuid);
    
    Task<CustomFile> GetReportWithDataAsync(Guid reportGuid);
}