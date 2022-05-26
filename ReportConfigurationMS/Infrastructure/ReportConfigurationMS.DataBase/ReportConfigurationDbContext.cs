using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ReportConfigurationMS.DataBase.Models;

namespace ReportConfigurationMS.DataBase;

public partial class ReportConfigurationDbContext : DbContext, IReportConfigurationDbContext
{
    public ReportConfigurationDbContext()
    { }

    public ReportConfigurationDbContext(DbContextOptions<ReportConfigurationDbContext> options)
        : base(options)
    { }


    public virtual DbSet<TReportsRequest> TReportsRequests { get; set; }
    public virtual DbSet<TReportsSchedule> TReportsSchedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TReportsRequest>(entity =>
        {
            entity.ToTable("T_Reports_Requests");

            entity.Property(e => e.EmailList).IsRequired();

            entity.Property(e => e.GenerationTimestamp).HasColumnType("datetime");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.Property(e => e.ReportDateFrom).HasColumnType("datetime");

            entity.Property(e => e.ReportDateTo).HasColumnType("datetime");

            entity.Property(e => e.RequestCulture)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.Property(e => e.RequestTimestamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TReportsSchedule>(entity =>
        {
            entity.HasKey(e => e.ReportsScheduleId)
                .HasName("PK__T_Report__7AB8451B75D9E524");

            entity.ToTable("T_Reports_Schedule");

            entity.Property(e => e.ReportsScheduleId).HasColumnName("Reports_ScheduleID");

            entity.Property(e => e.GenerationTimestamp).HasColumnType("datetime");

            entity.Property(e => e.NextReportSendDate).HasColumnType("datetime");

            entity.Property(e => e.ReportFrequencyId).HasColumnName("ReportFrequencyID");

            entity.Property(e => e.ReportsRequestId).HasColumnName("Reports_RequestID");

            entity.HasOne(d => d.ReportsRequest)
                .WithMany(p => p.TReportsSchedules)
                .HasForeignKey(d => d.ReportsRequestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_Reports_Requests");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}