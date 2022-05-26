using System.Net;
using System.Text;
using CugReportsMSClient.Dtos;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;

namespace CugReportsMSClient;

public class CugReportsMSClient : ICugReportsMSClient
{
    private CugReportsMSSettings _settings;
    private readonly IConfiguration _configuration;
    private readonly ILogger<CugReportsMSClient> _logger;
 
    public CugReportsMSClient(
        IConfiguration configuration,
        ILogger<CugReportsMSClient> logger)
    {
        _configuration = configuration;
        _logger = logger;
        _settings = new CugReportsMSSettings()
        {
            ServerAddress = _configuration
                .GetSection("Api")
                .GetSection("Microservices")
                .GetSection("CugReportsMS")
                .GetSection("Url")
                .Value,
            ApiKey = _configuration
                .GetSection("Api")
                .GetSection("Microservices")
                .GetSection("CugReportsMS")
                .GetSection("ApiKey")
                .Value
        };
    }
    public void Init(CugReportsMSSettings settings)
    {
        _settings = settings;
    }
    
    
    public async Task<Guid> CreateReportAsync(ReportParameters reportParameters)
    {
        var url = new Url(_settings.ServerAddress)
            .AppendPathSegments(
                "reports");
        var policy = BuildRetryPolicy();
        var response = await policy.ExecuteAsync(() => url
                .PostJsonAsync(reportParameters))
            .ReceiveString();
        return Guid.Parse(response);
    }
    public async Task<CustomFile> DownloadReportAsync(Guid reportGuid)
    {
        var url = new Url(_settings.ServerAddress)
            .AppendPathSegments(
                "reports",
                "download")
            .SetQueryParam("reportGuid", reportGuid);
        var policy = BuildRetryPolicy();
        var response = await policy.ExecuteAsync(() => url
            .GetAsync());

        var contentDispositionString = response.Headers.FirstOrDefault(x => x.Name == "Content-Disposition").Value;
        var contentDisposition = contentDispositionString.Split(";").Select(x => x.Trim()).ToList();
        var fullFileName = contentDisposition.First(x => x.StartsWith("filename=")).Split("=").Last();
        var fileName = fullFileName.Split(".").First();
        var fileType = fullFileName.Split(".").Skip(1).First();
        return new CustomFile
        {
            Bytes = await response.GetBytesAsync(),
            ContentType = fileType,
            FileName = fileName
        };
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