namespace ReportingFramework.WebApp.Database.Repositories
{
    public class EFReposotory
    {
        protected readonly ITemplateEditorDbContext Context;
        protected readonly CancellationToken CancellationToken;
        
        public EFReposotory(ITemplateEditorDbContext context, ICalcellationTokenProvider cancellationTokenProvider)
        {
            Context = context;
            CancellationToken = cancellationTokenProvider.CancellationToken;
        }
        
        
    }
}