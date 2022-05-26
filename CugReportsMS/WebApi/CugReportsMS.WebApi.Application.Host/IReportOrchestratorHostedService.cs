using System;
using System.Text.Json;
using System.Threading.Tasks;
using CugReportMicroservice.Dtos;
using Microsoft.Extensions.Hosting;

namespace ReportingFramework.WebApi.Application.Host
{
    public interface IReportOrchestratorHostedService : IHostedService
    {
        Task<Guid> CreateReportAsync(JsonElement reportParameters);
        Task<CustomFile> DownloadReportAsync(Guid reportGuid);
        Task<CustomFile> DownloadRawReportDataAsync(Guid reportGuid);
        Task<CustomFile> DownloadRawReportWithDataAsync(Guid reportGuid);
    }
}