using EcoSCADA.Common.ExceptionHandling.Abstraction;
using EcoSCADA.Common.ExceptionHandling.Configuration;
using EcoSCADA.Common.ExceptionHandling.ExceptionMappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EcoSCADA.Common.ExceptionHandling
{
    public static class Extensions
    {
        public static IServiceCollection AddErrorHandling(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetOptions<ExceptionHandlingConfiguration>("exceptionHandling");
            
            services
                .AddSingleton(options)
                .AddErrorMappers()
                .AddSingleton<ErrorHandlerMiddleware>()
                .AddSingleton<IExceptionToResponseMapper, ExceptionToResponseMapper>();
            
            return services;
        }

        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
            return app;
        }
    }
}