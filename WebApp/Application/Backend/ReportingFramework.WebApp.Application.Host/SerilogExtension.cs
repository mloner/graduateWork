using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace ReportingFramweork.WebApp.Backend;

public static class SerilogExtension
{
    public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder)
    {
        var serilogFileConfigIndex = builder.Configuration
            .GetSection("Serilog")
            .GetSection("WriteTo")
            .GetChildren()
            .ToList()
            .FindIndex(x => x.GetSection("Name").Value == "File");
        builder.Configuration[$"Serilog:WriteTo:{serilogFileConfigIndex}:Args:path"] =
            $"{AppDomain.CurrentDomain.BaseDirectory}" +
            $"{builder.Configuration[$"Serilog:WriteTo:{serilogFileConfigIndex}:Args:path"]}";
            
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();
        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);

        return builder;
    }

    public static ILogger CreateStartupLogger(this WebApplicationBuilder builder)
    {
        var loggerProvider = builder.Logging.Services.First(x => x.ServiceType == typeof(ILoggerProvider))
            .ImplementationInstance as ILoggerProvider;
        var logger = loggerProvider.CreateLogger("StartupLogger");

        return logger;
    }
}