using System.Net;
using ChartGeneratorModels;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;

namespace ChartGeneratorClient;

public class ChartGeneratorClient : IChartGeneratorClient
{
    private ChartGeneratorSettings _settings;
    private readonly IConfiguration _configuration;
    private readonly ILogger<ChartGeneratorClient> _logger;
 
    public ChartGeneratorClient(
        IConfiguration configuration,
        ILogger<ChartGeneratorClient> logger)
    {
        _configuration = configuration;
        _logger = logger;
        _settings = new ChartGeneratorSettings()
        {
            ServerAddress = _configuration
                .GetSection("Api")
                .GetSection("Microservices")
                .GetSection("ChartGenerator")
                .GetSection("Url")
                .Value,
            ApiKey = _configuration
                .GetSection("Api")
                .GetSection("Microservices")
                .GetSection("ChartGenerator")
                .GetSection("ApiKey")
                .Value
        };
    }
    public void Init(ChartGeneratorSettings settings)
    {
        _settings = settings;
    }
    

    public async Task<string> CreateChartAsync(ChartRequestData chartRequestData)
    {
        var url = new Url(_settings.ServerAddress)
            .AppendPathSegments(
                "charts",
                "chart");
        var policy = BuildRetryPolicy();
        var response = await policy.ExecuteAsync(() => url
                .PostJsonAsync(chartRequestData))
            .ReceiveString();
        
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