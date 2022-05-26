using System.Net;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using SectionModels;

namespace ReportGeneratorClient;

public class ReportGeneratorClient : IReportGeneratorClient
{
    private ReportGeneratorSettings _settings;
    private readonly IConfiguration _configuration;
    private readonly ILogger<ReportGeneratorClient> _logger;

    public ReportGeneratorClient(
        IConfiguration configuration,
        ILogger<ReportGeneratorClient> logger)
    {
        _configuration = configuration;
        _logger = logger;
        _settings = new ReportGeneratorSettings()
        {
            ServerAddress = _configuration
                .GetSection("Api")
                .GetSection("Microservices")
                .GetSection("ReportGenerator")
                .GetSection("Url")
                .Value,
            ApiKey = _configuration
                .GetSection("Api")
                .GetSection("Microservices")
                .GetSection("ReportGenerator")
                .GetSection("ApiKey")
                .Value
        };
    }
    public void Init(ReportGeneratorSettings settings)
    {
        _settings = settings;
    }


    public async Task<Guid> CreateReportAsync(ReportModel reportModel)
    {
        var url = new Url(_settings.ServerAddress)
            .AppendPathSegments(
                "reports",
                "report");
        var policy = BuildRetryPolicy();
        var response = await policy.ExecuteAsync(() => url
                .PostJsonAsync(reportModel))
            .ReceiveString();
        return Guid.Parse(response);
    }
    public async Task<ReportStatus> GetReportStatus(Guid reportGuid)
    {
        var url = new Url(_settings.ServerAddress)
            .AppendPathSegments(
                "reports",
                "status")
            .SetQueryParam("reportGuid", reportGuid);
        var policy = BuildRetryPolicy();
        var response = await policy.ExecuteAsync(() => url
                .GetStringAsync());
        return (ReportStatus)int.Parse(response);
    }
    public async Task<Stream> DownloadReportAsync(Guid reportGuid)
    {
        var url = new Url(_settings.ServerAddress)
            .AppendPathSegments(
                "reports",
                "download")
            .SetQueryParam("reportGuid", reportGuid);
        var policy = BuildRetryPolicy();
        var response = await policy.ExecuteAsync(() => url
            .GetStreamAsync());

        return response;
    }
    public async Task<Stream> DownloadReportWithDataAsync(Guid reportGuid)
    {
        var url = new Url(_settings.ServerAddress)
            .AppendPathSegments(
                "reports",
                "download",
                "reportwithdata")
            .SetQueryParam("reportGuid", reportGuid);
        var policy = BuildRetryPolicy();
        var response = await policy.ExecuteAsync(() => url
            .GetStreamAsync());
        return response;
    }


    private AsyncRetryPolicy BuildRetryPolicy()
    {
        var retryPolicy = Policy
            .Handle<FlurlHttpException>(IsTransientError)
            .WaitAndRetryAsync(3, retryAttempt =>
            {
                var nextAttemptIn = TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
                _logger.LogWarning($"PdfGeneratopAPI. Retry attempt {retryAttempt} to make request. Next try on {nextAttemptIn.TotalSeconds} seconds.");
                return nextAttemptIn;
            });

        return retryPolicy;
    }
    private bool IsTransientError(FlurlHttpException exception)
    {
        int[] httpStatusCodesWorthRetrying =
        {
            (int)HttpStatusCode.RequestTimeout, // 408
            (int)HttpStatusCode.BadGateway, // 502
            (int)HttpStatusCode.ServiceUnavailable, // 503
            (int)HttpStatusCode.GatewayTimeout // 504
        };

        return exception.StatusCode.HasValue && httpStatusCodesWorthRetrying.Contains(exception.StatusCode.Value);
    }
}