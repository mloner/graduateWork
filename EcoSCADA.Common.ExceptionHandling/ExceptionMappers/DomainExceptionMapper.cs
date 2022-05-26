using System;
using System.Collections.Generic;
using EcoSCADA.Common.ExceptionHandling.Abstraction.Exceptions;
using EcoSCADA.Common.ExceptionHandling.Configuration;
using EcoSCADA.Common.ExceptionHandling.Models;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace EcoSCADA.Common.ExceptionHandling.ExceptionMappers
{
    internal class DomainExceptionMapper
    {
        private readonly ExceptionHandlingConfiguration _exceptionHandlingConfiguration;
        private readonly ILogger<DomainExceptionMapper> _logger;

        public DomainExceptionMapper(
            ExceptionHandlingConfiguration exceptionHandlingConfiguration, 
            ILogger<DomainExceptionMapper> logger)
        {
            _exceptionHandlingConfiguration = exceptionHandlingConfiguration;
            _logger = logger;
        }

        internal ExceptionResponse SetDomainExceptionResponse(DomainException ex, ProblemDetailsExtensions extensions)
        {
            var type = ex.GetType();
            var code = type.Name.Underscore().Replace("_exception", string.Empty);
            
            var response = new ExceptionResponse()
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Status = StatusCodes.Status400BadRequest,
                Detail = ex.Message,
                Title = code,
                Instance = extensions.Instance,
                StackTrace = _exceptionHandlingConfiguration.IsDevelopment ? ex.ToString() : null,
                Errors = ex.Errors,
                Extensions =
                {
                    new KeyValuePair<string, object>("ConnectionId", extensions.ConnectionId),
                    new KeyValuePair<string, object>("TraceId", extensions.TraceId), 
                    
                }
            };
            
            LogContext.PushProperty("TraceId", extensions.TraceId);
            _logger.LogInformation(ex,ex.Message);

            return response;
        }
    }
}