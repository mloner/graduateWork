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
    public class UnprocessableEntityExceptionMapper
    {
        private readonly ExceptionHandlingConfiguration _exceptionHandlingConfiguration;
        private readonly ILogger<UnprocessableEntityExceptionMapper> _logger;

        public UnprocessableEntityExceptionMapper(ExceptionHandlingConfiguration exceptionHandlingConfiguration, ILogger<UnprocessableEntityExceptionMapper> logger)
        {
            _exceptionHandlingConfiguration = exceptionHandlingConfiguration;
            _logger = logger;
        }

        internal ExceptionResponse SetUnprocessableEntityExceptionResponse(UnprocessableEntityException ex, ProblemDetailsExtensions extensions)
        {
            var type = ex.GetType();
            var code = type.Name.Underscore().Replace("_exception", string.Empty);
            var response = new ExceptionResponse()
            {
                Status = StatusCodes.Status422UnprocessableEntity,
                Detail = ex.Message,
                Title = code,
                Instance = extensions.Instance,
                Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/422",
                StackTrace = _exceptionHandlingConfiguration.IsDevelopment ? ex.StackTrace : null,
                Extensions =
                {
                    new KeyValuePair<string, object>("ConnectionId", extensions.ConnectionId),
                    new KeyValuePair<string, object>("TraceId", extensions.TraceId)
                }
            };
            
            LogContext.PushProperty("TraceId", extensions.TraceId);
            _logger.LogWarning(ex,ex.Message);
            
            return response;
        }
    }
}