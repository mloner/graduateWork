using Microsoft.EntityFrameworkCore;
using ReportConfigurationMS.DataBase;

namespace Worker;

public static class StartupExtensions
{
    public static IServiceCollection RegisterDatabases(this IServiceCollection @this, IConfiguration configuration)
    {
        @this.AddDbContext<ReportConfigurationDbContext>(options => options.UseSqlServer(
            configuration["ConnectionStrings:EcoSCADA_Demo"]));

        return @this;
    }
}