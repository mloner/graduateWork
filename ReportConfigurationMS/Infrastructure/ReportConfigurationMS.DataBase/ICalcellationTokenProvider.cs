namespace ReportConfigurationMS.DataBase
{
    public interface ICalcellationTokenProvider
    {
        CancellationToken CancellationToken { get; }
    }
}