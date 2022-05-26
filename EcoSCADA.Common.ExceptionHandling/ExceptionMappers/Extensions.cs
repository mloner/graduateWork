using Microsoft.Extensions.DependencyInjection;

namespace EcoSCADA.Common.ExceptionHandling.ExceptionMappers
{
    internal static class Extensions
    {
        internal static IServiceCollection AddErrorMappers(this IServiceCollection services)
        {
            services
                .AddSingleton<DomainExceptionMapper>()
                .AddSingleton<UnhandledExceptionMapper>()
                .AddSingleton<NotFoundExceptionMapper>()
                .AddSingleton<UnprocessableEntityExceptionMapper>()
                .AddSingleton<ArgumentExceptionMapper>()
                .AddSingleton<ArgumentNullExceptionMapper>()
                .AddSingleton<AggregateExceptionMapper>()
                .AddSingleton<TimeoutRejectedExceptionMapper>()
                .AddSingleton<HttpRequestExceptionMapper>();

            return services;
        }
    }
}