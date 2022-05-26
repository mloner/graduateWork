using Microsoft.AspNetCore.Http;

namespace ReportingFramework.WebApi.Application.Host.ControllerLogger;

public interface IControllerLogger
{
    void Log(HttpContext httpContext, string message);
}