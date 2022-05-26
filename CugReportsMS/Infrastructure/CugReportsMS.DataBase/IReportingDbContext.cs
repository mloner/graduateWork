using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ReportingDB.DataBaseModels;

namespace ReportingDB
{
    public interface IReportingDbContext : IDisposable
    {
        DbSet<Report> Reports { get; set; }
        DbSet<ReportType> ReportTypes { get; set; }
        DbSet<ReportTypesWithTemplate> ReportTypesWithTemplates { get; set; }
        DbSet<Section> Sections { get; set; }
       
       int SaveChanges();
       Task<int> SaveChangesAsync(CancellationToken cancellationToken = default (CancellationToken));
       DatabaseFacade Database { get; }
       EntityEntry Entry(object entity);
    }
}