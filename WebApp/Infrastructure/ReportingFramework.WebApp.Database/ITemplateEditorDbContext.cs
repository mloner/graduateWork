using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ReportingFramework.WebApp.Database.DataBaseModels;

namespace ReportingFramework.WebApp.Database
{
    public interface ITemplateEditorDbContext : IDisposable
    {
        DbSet<TemplateEditor> TemplateEditors { get; set; }
        
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default (CancellationToken));
        DatabaseFacade Database { get; }
        EntityEntry Entry(object entity);
    }
}