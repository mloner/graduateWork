using System.Text.Json;
using ReportingFramework.Dto;

namespace ReportGenerator.Host;

public class ReportGeneratorHostedService : IReportGeneratorHostedService
{
    private readonly ILogger _logger;
    private readonly IServiceProvider _serviceProvider;

    public ReportGeneratorHostedService(ILogger<ReportGeneratorHostedService> logger, IServiceProvider serviceProvider)
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

    public async Task CreateReportAsync(JsonElement reportModelJson, Guid reportGuid)
    {
        var scope = _serviceProvider.CreateScope();
        var xService = scope.ServiceProvider.GetService<IReportingGenerator>();
        await xService.GenerateAsync(reportModelJson, reportGuid);
    }
    
    public async Task<CustomFile> GetReportWithDataAsync(Guid reportGuid)
    {
        var scope = _serviceProvider.CreateScope();
        var xService = scope.ServiceProvider.GetService<IReportingGenerator>();
        var res = await xService.GetReportWithDataAsync(reportGuid);
        return res;
    }
}