using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ReportingFramework.WebApi.Application.Host.ControllerLogger;

public class ControllerLogger : IControllerLogger
{
    protected readonly ILogger<ControllerLogger> _logger;

    public ControllerLogger(ILogger<ControllerLogger> logger)
    {
        _logger = logger;
    }
    
    public void Log(HttpContext httpContext, string message)
    {
        _logger.LogDebug("\n" +
                               $"Request: {httpContext.TraceIdentifier}\n" +
                               $"Path: {httpContext.Request.Path}\n" +
                               $"Method: {httpContext.Request.Method}\n" +
                               $"{message}"
        );
    }
}