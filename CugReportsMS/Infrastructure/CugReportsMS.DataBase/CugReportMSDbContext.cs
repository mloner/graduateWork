using Microsoft.EntityFrameworkCore;
using ReportingDB.DataBaseModels;

#nullable disable

namespace ReportingDB
{
    public partial class CugReportMSDbContext : DbContext, IReportingDbContext
    {
        public CugReportMSDbContext()
        {
        }

        public CugReportMSDbContext(DbContextOptions<CugReportMSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportType> ReportTypes { get; set; }
        public virtual DbSet<ReportTypesWithTemplate> ReportTypesWithTemplates { get; set; }
        public virtual DbSet<Section> Sections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.Parameters).HasColumnType("text");

                entity.HasOne(d => d.TypeWithTemplate)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.TypeWithTemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reports_ReportTypesWithTemplate");
            });

            modelBuilder.Entity<ReportType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OutputFormat)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReportTypesWithTemplate>(entity =>
            {
                entity.ToTable("ReportTypesWithTemplate");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TemplateId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ReportType)
                    .WithMany(p => p.ReportTypesWithTemplates)
                    .HasForeignKey(d => d.ReportTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_TypesWithTemplate_T_Types");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ReportType)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.ReportTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Sections_T_Types");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
