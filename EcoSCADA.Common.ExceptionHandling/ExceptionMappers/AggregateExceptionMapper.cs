using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EcoSCADA.Common.ExceptionHandling.Abstraction.Exceptions;
using EcoSCADA.Common.ExceptionHandling.Configuration;
using EcoSCADA.Common.ExceptionHandling.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace EcoSCADA.Common.ExceptionHandling.ExceptionMappers
{
    public class AggregateExceptionMapper
    {
        private readonly ExceptionHandlingConfiguration _exceptionHandlingConfiguration;
        private readonly ILogger<AggregateExceptionMapper> _logger;

        public AggregateExceptionMapper(
            ExceptionHandlingConfiguration exceptionHandlingConfiguration,
            ILogger<AggregateExceptionMapper> logger
        )
        {
            _exceptionHandlingConfiguration = exceptionHandlingConfiguration;
            _logger = logger;
        }

        internal ExceptionResponse SetAggregateExceptionResponse(AggregateException ex,
            ProblemDetailsExtensions extensions)
        {
            const string code = "Error";
            const string message = "One or more error occured";

            var errors = ex.InnerExceptions
                .ToDictionary<Exception, string, object>(e => e.GetType().Name, e => e.Message);
            
            var response = new ExceptionResponse()
            {
                Status = StatusCodes.Status400BadRequest,
                Detail = message,
                Title = code,
                Instance = extensions.Instance,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                StackTrace = _exceptionHandlingConfiguration.IsDevelopment ? ex.ToString() : null,
                Errors = _exceptionHandlingConfiguration.IsDevelopment ? errors : null,
                Extensions =
                {
                    new KeyValuePair<string, object>("ConnectionId", extensions.ConnectionId),
                    new KeyValuePair<string, object>("TraceId", extensions.TraceId)
                }
            };

            LogContext.PushProperty("TraceId", extensions.TraceId);
            
            if (InnerExceptionAllowed(ex)) _logger.LogInformation(ex, ex.Message);
            else _logger.LogError(ex.Message);
            
            return response;
        }

        private static bool InnerExceptionAllowed(AggregateException ex)
        {
            var aggregateExceptions = ex.InnerExceptions
                .ToDictionary<Exception, Type, object>(e => e.GetType(), e => e.Message);
            
            IList<Type> allowedExceptions = new List<Type>()
            {
                typeof(DomainException),
                typeof(NotFoundException),
                typeof(ArgumentException),
                typeof(ArgumentNullException),
                typeof(UnprocessableEntityException)
            };

            foreach (var e in aggregateExceptions)
            {
                // Checks for base exception types that are allowed 
                if(allowedExceptions.Any(x => e.Key == x))  continue;
                
                // Checks if exception is of type Domain/NotFound
                var allowed = allowedExceptions.Any(x => e.Key.BaseType == x);

                //If at least one of innerExceptions is false aggregateException should be logged as warning/error
                if (allowed == false) return false;
            }

            return true;
        }
    }
}