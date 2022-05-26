using Microsoft.EntityFrameworkCore;
using ReportConfigurationMS.DataBase.Models;

namespace ReportConfigurationMS.DataBase;

public interface IReportConfigurationDbContext
{
    DbSet<TReportsRequest> TReportsRequests { get; set; }
    DbSet<TReportsSchedule> TReportsSchedules { get; set; }
}