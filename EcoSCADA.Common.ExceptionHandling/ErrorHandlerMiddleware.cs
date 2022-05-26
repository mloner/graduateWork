using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EcoSCADA.Common.ExceptionHandling.Abstraction;
using EcoSCADA.Common.ExceptionHandling.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace EcoSCADA.Common.ExceptionHandling
{
    internal class ErrorHandlerMiddleware :IMiddleware
    {
        private const string ProblemDetailsContentType = "application/problem+json";
        private readonly IExceptionToResponseMapper _exceptionToResponseMapper;
        private readonly JsonSerializerSettings _serializerSettings;
        public ErrorHandlerMiddleware(IExceptionToResponseMapper mapper)
        {
            _exceptionToResponseMapper = mapper;
            _serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }
        
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await HandleErrorAsync(context, exception);
            }
        }
        
        private async Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            try
            {
                var metadata = new ProblemDetailsExtensions()
                {
                    ConnectionId = context?.Connection?.Id ?? Guid.Empty.ToString(),
                    TraceId = Activity.Current?.RootId ?? Guid.Empty.ToString(),
                    Instance = context?.Request?.Path ?? default
                };
            
                var errorResponse = _exceptionToResponseMapper.Map(exception, metadata);
                context.Response.StatusCode = errorResponse?.Status ?? StatusCodes.Status500InternalServerError;
                if (errorResponse is null) return;

                var json = JsonConvert.SerializeObject(errorResponse, _serializerSettings);
                context.Response.ContentType = ProblemDetailsContentType;
                
                await context.Response.WriteAsync(json, Encoding.UTF8, CancellationToken.None);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await context.Response.WriteAsync("There was an error.", Encoding.UTF8, CancellationToken.None);
            }
        
        }
    }
}