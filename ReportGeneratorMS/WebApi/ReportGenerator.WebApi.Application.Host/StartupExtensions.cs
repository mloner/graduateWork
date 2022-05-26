using ChartGeneratorClient;
using GeneratorDataBase;
using GeneratorDataBase.Repositories;
using Microsoft.EntityFrameworkCore;
using PdfReportTemplaterClient;
using ReportGenerator.Host.ControllerLogger;
using ReportingFramework.Dto;


namespace ReportGenerator.Host
{
    public static class StartupExtensions
    {
        readonly static string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public static IServiceCollection RegisterApplicationControllers(this IServiceCollection @this)
        {
            //@this.AddScoped<ReportGenerateController, ReportGenerateController>();
            return @this;
        }

        public static IServiceCollection RegisterDatabases(this IServiceCollection @this, IConfiguration configuration)
        {
            @this.AddDbContext<ReportGeneratorDBContext>(options => options.UseSqlServer(
                configuration["ConnectionStrings:ReportGenerator"]));

            return @this;
        }
        
        public static IServiceCollection RegisterServices(this IServiceCollection @this)
        {
            @this.AddScoped<IReportingGenerator, ReportGenerator>();
            @this.AddScoped<ReportGenerator>();
            @this.AddSingleton<ReportGeneratorHostedService>();
            @this.AddSingleton<IReportGeneratorHostedService, ReportGeneratorHostedService>(
                serviceProvider => serviceProvider.GetService<ReportGeneratorHostedService>());
            @this.AddScoped<IChartGeneratorClient, ChartGeneratorClient.ChartGeneratorClient>();
            @this.AddScoped<IPdfReportTemplaterClient, PdfReportTemplaterClient.PdfReportTemplaterClient>();
            @this.AddScoped<IControllerLogger, ControllerLogger.ControllerLogger>();
            
            return @this;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection @this)
        {
            @this.AddScoped<ICalcellationTokenProvider, HttpContextCancellationTokenProvider>();
            @this.AddScoped<IReportGeneratorDbContext, ReportGeneratorDBContext>();
            
            @this.AddScoped<IReportGeneratorRepository, ReportGeneratorRepository>();

            return @this;

        }

        public static IServiceCollection AddCustomCors(this IServiceCollection @this, IConfiguration configuration)
        {
            @this.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder
                            .WithOrigins(configuration.GetSection("Web:AllowedHosts")
                                .Get<List<string>>().Aggregate((x, y) => $"{x};{y}"))
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