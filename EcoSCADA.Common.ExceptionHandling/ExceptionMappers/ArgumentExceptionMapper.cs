using System;
using System.Collections.Generic;
using EcoSCADA.Common.ExceptionHandling.Configuration;
using EcoSCADA.Common.ExceptionHandling.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace EcoSCADA.Common.ExceptionHandling.ExceptionMappers
{
    public class ArgumentExceptionMapper
    {
        private readonly ExceptionHandlingConfiguration _exceptionHandlingConfiguration;
        private readonly ILogger<ArgumentExceptionMapper> _logger;

        public ArgumentExceptionMapper(
            ExceptionHandlingConfiguration exceptionHandlingConfiguration, 
            ILogger<ArgumentExceptionMapper> logger
            )
        {
            _exceptionHandlingConfiguration = exceptionHandlingConfiguration;
            _logger = logger;
        }

        internal ExceptionResponse SetArgumentExceptionResponse(ArgumentException ex, ProblemDetailsExtensions extensions)
        {
            const string code = "Invalid argument found";
            var response = new ExceptionResponse()
            {
                Status = StatusCodes.Status400BadRequest,
                Detail = ex.Message,
                Title = code,
                Instance = extensions.Instance,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                StackTrace = _exceptionHandlingConfiguration.IsDevelopment ? ex.ToString() : null,
                Extensions =
                {
                    new KeyValuePair<string, object>("ConnectionId", extensions.ConnectionId),
                    new KeyValuePair<string, object>("TraceId", extensions.TraceId)
                }
            };
            
            LogContext.PushProperty("TraceId", extensions.TraceId);
            _logger.LogInformation(ex,ex.Message);

            return response;
        }
    }
}