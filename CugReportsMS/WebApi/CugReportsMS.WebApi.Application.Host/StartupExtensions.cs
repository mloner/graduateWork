using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ChartGeneratorClient;
using CugReportMicroservice.Dtos;
using CugReportsMSClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ReportConfigurationMS.DataBase;
using ReportConfigurationMS.DataBase.Repositories;
using ReportConfigurationMS.Domain;
using ReportGeneratorClient;
using ReportingDB;
using ReportingDB.Repositories;
using ReportingFramework.WebApi.Application.Host.ControllerLogger;
using ReportingFramework.WebApi.Application.Host.Controllers;
using ReportingOrchestrator;
using SenderClient;
using HttpContextCancellationTokenProvider = ReportingDB.HttpContextCancellationTokenProvider;
using ICalcellationTokenProvider = ReportingDB.ICalcellationTokenProvider;


namespace ReportingFramework.WebApi.Application.Host
{
    public static class StartupExtensions
    {
        readonly static string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public static IServiceCollection RegisterApplicationControllers(this IServiceCollection @this)
        {
            @this.AddScoped<ReportsController, ReportsController>();
            return @this;
        }
        
        public static IServiceCollection RegisterDatabases(this IServiceCollection @this, IConfiguration configuration)
        {
            @this.AddDbContext<CugReportMSDbContext>(options => options.UseSqlServer(
                configuration["ConnectionStrings:ReportsMSDB"]));
            @this.AddDbContext<ReportConfigurationDbContext>(options => options.UseSqlServer(
                configuration["ConnectionStrings:EcoSCADA_Demo"]));

            return @this;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection @this)
        {
            @this.AddScoped<IReportingAssembler, ReportAssembler.ReportAssembler>();
            @this.AddScoped<IReportingAdapter, ReportingAdapter>();
            @this.AddScoped<IOrchestrator, Orchestrator>();
            @this.AddScoped<Orchestrator>();
            @this.AddSingleton<ReportOrchestratorHostedService>();
            @this.AddSingleton<IReportOrchestratorHostedService, ReportOrchestratorHostedService>(
                serviceProvider => serviceProvider.GetService<ReportOrchestratorHostedService>());
            @this.AddScoped<IReportGeneratorClient, ReportGeneratorClient.ReportGeneratorClient>();
            @this.AddScoped<IChartGeneratorClient, ChartGeneratorClient.ChartGeneratorClient>();
            @this.AddScoped<IControllerLogger, ControllerLogger.ControllerLogger>();
            @this.AddTransient<ICugReportsMSClient, CugReportsMSClient.CugReportsMSClient>();
            
            //worker
            @this.AddTransient<ISenderClient, SenderClient.SenderClient>();
            @this.AddHostedService<Worker.Worker>();

            return @this;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection @this)
        {
            @this.AddScoped<ICalcellationTokenProvider, HttpContextCancellationTokenProvider>();
            @this.AddScoped<IReportingDbContext, CugReportMSDbContext>();

            @this.AddScoped<IReportRepository, ReportRepository>();
            @this.AddTransient<IReportConfigurationRepository, ReportConfigurationRepository>();
            

            return @this;

        }
        
        public static IServiceCollection AddCorsCustom(this IServiceCollection @this, IConfiguration configuration)
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
        
        public static IServiceCollection AddSwaggerGenCustom(this IServiceCollection @this)
        {
            @this.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "CugReportsMS.WebApi.Application.Host", Version = "v1"});
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return @this;
        }
        
        
    }
}