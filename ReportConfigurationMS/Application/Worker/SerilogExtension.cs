using Serilog;

namespace Worker;

public static class SerilogExtension
{
    public static ILoggingBuilder AddSerilog(this ILoggingBuilder loggingBuilder, IConfiguration configuration)
    {
        var serilogFileConfigIndex = configuration
            .GetSection("Serilog")
            .GetSection("WriteTo")
            .GetChildren()
            .ToList()
            .FindIndex(x => x.GetSection("Name").Value == "File");
        configuration[$"Serilog:WriteTo:{serilogFileConfigIndex}:Args:path"] =
            $"{AppDomain.CurrentDomain.BaseDirectory}" +
            $"{configuration[$"Serilog:WriteTo:{serilogFileConfigIndex}:Args:path"]}";
            
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .CreateLogger();
        loggingBuilder.ClearProviders();
        loggingBuilder.AddSerilog(logger);

        return loggingBuilder;
    }
}