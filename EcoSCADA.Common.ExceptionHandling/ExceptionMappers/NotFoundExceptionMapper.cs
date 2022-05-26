using System.Collections.Generic;
using EcoSCADA.Common.ExceptionHandling.Abstraction;
using EcoSCADA.Common.ExceptionHandling.Abstraction.Exceptions;
using EcoSCADA.Common.ExceptionHandling.Configuration;
using EcoSCADA.Common.ExceptionHandling.Models;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace EcoSCADA.Common.ExceptionHandling.ExceptionMappers
{
    public class NotFoundExceptionMapper
    {
        private readonly ExceptionHandlingConfiguration _exceptionHandlingConfiguration;
        private readonly ILogger<NotFoundExceptionMapper> _logger;

        public NotFoundExceptionMapper(ExceptionHandlingConfiguration exceptionHandlingConfiguration, ILogger<NotFoundExceptionMapper> logger)
        {
            _exceptionHandlingConfiguration = exceptionHandlingConfiguration;
            _logger = logger;
        }

        internal ExceptionResponse SetNotFoundExceptionResponse(NotFoundException ex, ProblemDetailsExtensions extensions)
        {
            var type = ex.GetType();
            var code = type.Name.Underscore().Replace("_exception", string.Empty);
            var response = new ExceptionResponse()
            {
                Status = StatusCodes.Status404NotFound,
                Detail = ex.Message,
                Title = code,
                Instance = extensions.Instance,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                StackTrace = _exceptionHandlingConfiguration.IsDevelopment ? ex.ToString() : null,
                Errors = _exceptionHandlingConfiguration.IsDevelopment ? ex.Errors : null,
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