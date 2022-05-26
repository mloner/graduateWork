namespace ReportingFramework.WebApp.Database
{
    public interface ICalcellationTokenProvider
    {
        CancellationToken CancellationToken { get; }
    }
}