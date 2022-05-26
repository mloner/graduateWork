using System.Threading;

namespace ReportingDB
{
    public interface ICalcellationTokenProvider
    {
        CancellationToken CancellationToken { get; }
    }
}