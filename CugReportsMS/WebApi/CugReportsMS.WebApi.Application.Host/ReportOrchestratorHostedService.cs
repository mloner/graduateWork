using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CugReportMicroservice.Dtos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ReportingOrchestrator;

namespace ReportingFramework.WebApi.Application.Host
{
    public class ReportOrchestratorHostedService : IReportOrchestratorHostedService
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;

        public ReportOrchestratorHostedService(ILogger<ReportOrchestratorHostedService> logger, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
        }

        public async Task<Guid> CreateReportAsync(JsonElement reportParameters)
        {
            var scope = _serviceProvider.CreateScope();
            var xService = scope.ServiceProvider.GetService<Orchestrator>();
            var reportGuid = await xService.CreateReportAsync(reportParameters);
            return reportGuid;
        }
        
        public async Task<CustomFile> DownloadReportAsync(Guid reportGuid)
        {
            var scope = _serviceProvider.CreateScope();
            var xService = scope.ServiceProvider.GetService<Orchestrator>();
            var fileStreamRes = await xService.DownloadReportAsync(reportGuid);
            return fileStreamRes;
        }
        
        public async Task<CustomFile> DownloadRawReportDataAsync(Guid reportGuid)
        {
            var scope = _serviceProvider.CreateScope();
            var xService = scope.ServiceProvider.GetService<Orchestrator>();
            var fileStreamRes = await xService.DownloadRawReportDataAsync(reportGuid);
            return fileStreamRes;
        }
        
        public async Task<CustomFile> DownloadRawReportWithDataAsync(Guid reportGuid)
        {
            var scope = _serviceProvider.CreateScope();
            var xService = scope.ServiceProvider.GetService<Orchestrator>();
            var fileStreamRes = await xService.DownloadRawReportWithDataAsync(reportGuid);
            return fileStreamRes;
        }
    }
}