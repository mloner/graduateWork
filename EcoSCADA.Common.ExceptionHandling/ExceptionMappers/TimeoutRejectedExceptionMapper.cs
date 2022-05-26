using System.Collections.Generic;
using EcoSCADA.Common.ExceptionHandling.Abstraction.Exceptions;
using EcoSCADA.Common.ExceptionHandling.Configuration;
using EcoSCADA.Common.ExceptionHandling.Models;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Polly.Timeout;
using Serilog.Context;

namespace EcoSCADA.Common.ExceptionHandling.ExceptionMappers
{
    public class TimeoutRejectedExceptionMapper
    {
        private readonly ExceptionHandlingConfiguration _exceptionHandlingConfiguration;
        private readonly ILogger<TimeoutRejectedExceptionMapper> _logger;

        public TimeoutRejectedExceptionMapper(ExceptionHandlingConfiguration exceptionHandlingConfiguration, ILogger<TimeoutRejectedExceptionMapper> logger)
        {
            _exceptionHandlingConfiguration = exceptionHandlingConfiguration;
            _logger = logger;
        }

        internal ExceptionResponse SetTimeoutRejectedExceptionResponse(TimeoutRejectedException ex, ProblemDetailsExtensions extensions)
        {
            var type = ex.GetType();
            var code = type.Name.Underscore().Replace("_exception", string.Empty);
            
            var response = new ExceptionResponse()
            {
                Status = StatusCodes.Status504GatewayTimeout,
                Detail = "Server didn't response in expected time period.",
                Title = code,
                Instance = extensions.Instance,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.5",
                StackTrace = _exceptionHandlingConfiguration.IsDevelopment ? ex.ToString() : null,
                Extensions =
                {
                    new KeyValuePair<string, object>("ConnectionId", extensions.ConnectionId),
                    new KeyValuePair<string, object>("TraceId", extensions.TraceId)
                }
            };
            
            LogContext.PushProperty("TraceId", extensions.TraceId);
            _logger.LogCritical(ex,ex.Message);

            return response;
        }
    }
}