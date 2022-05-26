namespace GeneratorDataBase.Repositories
{
    public class EfRepository
    {
        protected readonly IReportGeneratorDbContext Context;
        protected readonly CancellationToken CancellationToken;
        
        public EfRepository(IReportGeneratorDbContext context, ICalcellationTokenProvider cancellationTokenProvider)
        {
            Context = context;
            CancellationToken = cancellationTokenProvider.CancellationToken;
        }
        
        
    }
}