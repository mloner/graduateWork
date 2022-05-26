using System;
using System.Collections.Generic;
using EcoSCADA.Common.ExceptionHandling.Configuration;
using EcoSCADA.Common.ExceptionHandling.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace EcoSCADA.Common.ExceptionHandling.ExceptionMappers
{
    internal class UnhandledExceptionMapper
    {
        private readonly ExceptionHandlingConfiguration _exceptionHandlingConfiguration;
        private readonly ILogger<UnhandledExceptionMapper> _logger;

        public UnhandledExceptionMapper(ExceptionHandlingConfiguration exceptionHandlingConfiguration,
            ILogger<UnhandledExceptionMapper> logger)
        {
            _exceptionHandlingConfiguration = exceptionHandlingConfiguration;
            _logger = logger;
        }

        public ExceptionResponse SetDefaultExceptionResponse(Exception ex, ProblemDetailsExtensions extensions)
        {
      
            var response = new ExceptionResponse()
            {
                Status = StatusCodes.Status500InternalServerError,
                Detail = _exceptionHandlingConfiguration.IsDevelopment ? ex.GetType().Name : "There was an error",
                Title = "Error",
                Instance = extensions.Instance,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                StackTrace = _exceptionHandlingConfiguration.IsDevelopment ? ex.StackTrace : null,
                Extensions =
                {
                    new KeyValuePair<string, object>("ConnectionId", extensions.ConnectionId),
                    new KeyValuePair<string, object>("TraceId", extensions.TraceId),
                }
            };

            LogContext.PushProperty("TraceId", extensions.TraceId);
            _logger.LogError(ex, ex.Message);
            return response;
        }
    }
}