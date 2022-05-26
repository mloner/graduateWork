using Microsoft.Extensions.DependencyInjection;

namespace ReportConfigurationMS.DataBase.Repositories
{
    public class EfRepository
    {
        protected readonly IServiceScopeFactory _scopeFactory; 
        
        public EfRepository(
            IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        
        
    }
}