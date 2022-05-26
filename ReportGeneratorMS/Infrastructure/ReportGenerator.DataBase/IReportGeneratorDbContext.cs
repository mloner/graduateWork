using GeneratorDataBase.DataBaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GeneratorDataBase;

public interface IReportGeneratorDbContext
{
    DbSet<Report> Reports { get; set; }
    DbSet<Template> Templates { get; set; }
    DbSet<TemplateComponent> TemplateComponents { get; set; }
       
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default (CancellationToken));
    DatabaseFacade Database { get; }
    EntityEntry Entry(object entity);
}