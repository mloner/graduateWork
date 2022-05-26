using Microsoft.EntityFrameworkCore;
using PdfReportTemplaterClient;
using ReportingFramework.WebApp.Database;
using ReportingFramework.WebApp.Database.Repositories;
using ReportingFramework.WebApp.Dtos.Repositories;

namespace ReportingFramweork.WebApp.Backend
{
    public static class StartupExtensions
    {
        public static IServiceCollection RegisterApplicationControllers(this IServiceCollection @this)
        {
            return @this;
        }
        
        public static IServiceCollection RegisterServices(this IServiceCollection @this)
        {
            @this.AddScoped<IPdfReportTemplaterClient, PdfReportTemplaterClient.PdfReportTemplaterClient>();
            return @this;
        }
        
        public static IServiceCollection RegisterDatabase(this IServiceCollection @this, string connectionString)
        {
            @this.AddDbContext<TemplateEditorDbContext>(options => options.UseSqlServer(connectionString));

            return @this;
        }
        
        public static IServiceCollection RegisterRepositories(this IServiceCollection @this)
        {
            @this.AddScoped<ITemplateEditorDbContext, TemplateEditorDbContext>();
            @this.AddScoped<ICalcellationTokenProvider, HttpContextCancellationTokenProvider>();
            
            @this.AddScoped<ITemplateEditorRepository, TemplateEditorRepository>();
            // @this.AddScoped<IRuleRepository, RuleRepository>();
            // @this.AddScoped<IConfigurationRepository, ConfigurationRepository>();

            return @this;
        }
        
        public static IServiceCollection RegisterHealthChecks(this IServiceCollection services, string databaseConnectionString)
        {
           

            return services;
        }
        
        public static IServiceCollection RegisterDomainEvents(this IServiceCollection @this)
        {
            return @this;
        }
    }
}