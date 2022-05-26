using CugReportsMSClient;
using ReportConfigurationMS.DataBase.Repositories;
using ReportConfigurationMS.Domain;
using SenderClient;
using Worker;

ILoggerProvider? loggerProvider;
ILogger? logger = null;
try
{
    IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureLogging((context, builder) =>
        {
            builder.AddSerilog(context.Configuration);
            loggerProvider = builder.Services.First(x => x.ServiceType == typeof(ILoggerProvider)).ImplementationInstance as ILoggerProvider;
            logger = loggerProvider!.CreateLogger("StartupLogger");
        })
        .ConfigureServices((context, services) =>
        {
            services.RegisterDatabases(context.Configuration);
            services.AddTransient<IReportConfigurationRepository, ReportConfigurationRepository>();
            services.AddScoped<ISenderClient, SenderClient.SenderClient>();
            services.AddTransient<ICugReportsMSClient, CugReportsMSClient.CugReportsMSClient>();
            services.AddHostedService<Worker.Worker>();
        })
        .Build();
    
    await host.RunAsync();
}
catch (Exception e)
{
    logger!.LogCritical($"{e.Message}\n{e.StackTrace}");
}
