namespace ChartGenerator.Host.ControllerLogger;

public interface IControllerLogger
{
    void Log(HttpContext httpContext, string message);
}