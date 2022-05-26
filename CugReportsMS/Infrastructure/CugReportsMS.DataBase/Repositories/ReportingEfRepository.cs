using System.Threading;

namespace ReportingDB.Repositories
{
    public class ReportingEfRepository
    {
        protected readonly IReportingDbContext Context;
        protected readonly CancellationToken CancellationToken;
        
        public ReportingEfRepository(IReportingDbContext context, ICalcellationTokenProvider cancellationTokenProvider)
        {
            Context = context;
            CancellationToken = cancellationTokenProvider.CancellationToken;
        }
        
        
    }
}