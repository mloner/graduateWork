using System;
using System.Collections.Generic;
using System.Net.Http;
using EcoSCADA.Common.ExceptionHandling.Configuration;
using EcoSCADA.Common.ExceptionHandling.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace EcoSCADA.Common.ExceptionHandling.ExceptionMappers
{
    public class HttpRequestExceptionMapper
    {
        private readonly ExceptionHandlingConfiguration _exceptionHandlingConfiguration;
        private readonly ILogger<HttpRequestExceptionMapper> _logger;

        public HttpRequestExceptionMapper(
            ExceptionHandlingConfiguration exceptionHandlingConfiguration, 
            ILogger<HttpRequestExceptionMapper> logger
        )
        {
            _exceptionHandlingConfiguration = exceptionHandlingConfiguration;
            _logger = logger;
        }

        internal ExceptionResponse SetHttpRequestExceptionResponse(HttpRequestException ex, ProblemDetailsExtensions extensions)
        {
            const string code = "One of services is unavailable";
            var response = new ExceptionResponse()
            {
                Status = StatusCodes.Status503ServiceUnavailable,
                Detail = "code",
                Title = "Service Unavailable",
                Instance = extensions.Instance,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.4",
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