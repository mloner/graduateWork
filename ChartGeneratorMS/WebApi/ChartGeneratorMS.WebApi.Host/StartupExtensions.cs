using ChartGenerator.HighCharts;
using ChartGenerator.Host.ControllerLogger;
using ChartGeneratorModels.ChartGeneratorModels;

namespace ChartGenerator.Host
{
    public static class StartupExtensions
    {
        readonly static string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public static IServiceCollection RegisterApplicationControllers(this IServiceCollection @this)
        {
            return @this;
        }

        public static IServiceCollection RegisterDatabase(this IServiceCollection @this, string connectionString)
        {

            return @this;
        }
        
        public static IServiceCollection RegisterServices(this IServiceCollection @this)
        {
            @this.AddScoped<IChartGenerator, ChartGenerator>();
            @this.AddScoped<IControllerLogger, ControllerLogger.ControllerLogger>();
            @this.AddScoped<IHighchartsClient, HighchartsClient>();

            return @this;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection @this)
        {


            return @this;

        }

        public static IServiceCollection AddCustomCors(this IServiceCollection @this)
        {
            @this.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder
                            .WithOrigins(
                                "https://localhost:5001",
                                "https://localhost:7115")
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });

            return @this;
        }
    }
}