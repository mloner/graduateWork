using System;
using System.Linq;
using EcoSCADA.Common.ExceptionHandling;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ReportingFramework.WebApi.Application.Host;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilog();
var logger = builder.CreateStartupLogger();


try
{
    builder.Services.AddControllers();
    builder.Services.RegisterApplicationControllers();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddCorsCustom(builder.Configuration);
    
    builder.Services.AddRouting();
    
    builder.Services.AddErrorHandling(builder.Configuration);
    
    builder.Services.AddSwaggerGenCustom();
    
    builder.Services.RegisterDatabases(builder.Configuration);
    builder.Services.RegisterRepositories();
    
    builder.Services.RegisterServices();
    
    


    var app = builder.Build();

    app.UseErrorHandling();
    
    app.UseSwagger();
    app.UseSwaggerUI();
    
    app.UseHttpsRedirection();
    
    app.UseRouting();
    app.MapControllers();
    

    app.Run();
}
catch (Exception e)
{
    logger.LogCritical($"Message: {e.Message}\nStackTrace: {e.StackTrace}");
}
