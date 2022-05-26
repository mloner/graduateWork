using System.Net;
using System.Text;
using Flurl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Flurl.Http;
using PdfReportTemplaterClient.Dtos;
using Polly;
using Polly.Retry;

namespace PdfReportTemplaterClient;

public class PdfReportTemplaterClient : IPdfReportTemplaterClient
{
    private PdfReportTemplaterClientSettings _settings;
    private readonly IConfiguration _configuration;
    private readonly ILogger<PdfReportTemplaterClient> _logger;

    public PdfReportTemplaterClient(
        IConfiguration configuration,
        ILogger<PdfReportTemplaterClient> logger)
    {
        _configuration = configuration;
        _logger = logger;
        _settings = new PdfReportTemplaterClientSettings()
        {
            ServerAddress = _configuration
                .GetSection("Api")
                .GetSection("Microservices")
                .GetSection("PdfReportTemplater")
                .GetSection("Url")
                .Value,
            ApiKey = _configuration
                .GetSection("Api")
                .GetSection("Microservices")
                .GetSection("PdfReportTemplater")
                .GetSection("ApiKey")
                .Value,
        };
    }
    public void Init(PdfReportTemplaterClientSettings settings)
    {
        _settings = settings;
    }

    
    public async Task<string> CreateReportAsync(object data, int templateId)
    {
        var url = new Url(_settings.ServerAddress)
            .AppendPathSegments(
                "templates",
                templateId,
                "output")
            .SetQueryParam("name", "<string>")
            .SetQueryParam("format", "pdf")
            .WithOAuthBearerToken(_settings.ApiKey);
        var policy = BuildRetryPolicy();
        var response = await policy.ExecuteAsync(() => url
                .PostJsonAsync(data))
            .ReceiveJson<MergeTemplateResponse>();
        return response.response;
    }

    public async Task<string> GetEditorLinkAsync(string token)
    {
        var url = new Url(_settings.ServerAddress)
            .AppendPathSegments(
                "templates",
                "0",
                "editor")
            .WithOAuthBearerToken(token);
        var policy = BuildRetryPolicy();
        var response = await policy.ExecuteAsync(() => url
            .GetJsonAsync<EditorResponse>());
        return response.response;
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