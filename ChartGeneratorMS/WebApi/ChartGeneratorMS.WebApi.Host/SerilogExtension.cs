using Serilog;

namespace ChartGenerator.Host;

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
}