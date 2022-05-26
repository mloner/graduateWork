using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using IdentityServer.Integration.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using ReportingFramweork.WebApp.Backend;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilog();
var logger = builder.CreateStartupLogger();


try
{
    builder.Services.AddControllers();
    builder.Services.AddCors();
    builder.Services.AddEcoscadaSso("reporting", builder.Configuration["Sso:SsoUrl"]);
    builder.Services.AddHttpContextAccessor();

    builder.Services
        .RegisterDatabase(builder.Configuration["ConnectionStrings:RFDatabase"])
        .RegisterRepositories()
        .RegisterApplicationControllers()
        .RegisterServices()
        .RegisterDomainEvents();

    ServicePointManager.ServerCertificateValidationCallback =
        delegate(object sender, X509Certificate certificate, X509Chain chain,
            SslPolicyErrors sslPolicyErrors) { return true; };
            
            
    builder.Services.Configure<KestrelServerOptions>(options =>
    {
        options.Limits.MaxRequestBodySize = int.MaxValue; 
    });
            
    builder.Services.Configure<FormOptions>(x =>
    {
        x.ValueLengthLimit = int.MaxValue;
        x.MultipartBodyLengthLimit = int.MaxValue;
        x.MultipartHeadersLengthLimit = int.MaxValue;
    });
    
    


    var app = builder.Build();


    app.UseCors(options =>
        options
            .WithOrigins(builder.Configuration["Web:Url"])
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
    );
    
    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    

    app.Run();
}
catch (Exception e)
{
    logger.LogCritical($"Message: {e.Message}\nStackTrace: {e.StackTrace}");
}