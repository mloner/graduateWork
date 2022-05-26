using GeneratorDataBase.DataBaseModels;
using Microsoft.EntityFrameworkCore;

namespace GeneratorDataBase
{
    public partial class ReportGeneratorDBContext : DbContext, IReportGeneratorDbContext
    {
        public ReportGeneratorDBContext()
        {
        }

        public ReportGeneratorDBContext(DbContextOptions<ReportGeneratorDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<TemplateComponent> TemplateComponents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Parameters)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.GlobalSettings)
                    .WithMany(p => p.TemplateGlobalSettings)
                    .HasForeignKey(d => d.GlobalSettingsId)
                    .HasConstraintName("FK_Templates_TemplateComponents");

                entity.HasOne(d => d.SectionToTemplateRelations)
                    .WithMany(p => p.TemplateSectionToTemplateRelations)
                    .HasForeignKey(d => d.SectionToTemplateRelationsId)
                    .HasConstraintName("FK_Templates_TemplateComponents1");

                entity.HasOne(d => d.SectionTypeTemplates)
                    .WithMany(p => p.TemplateSectionTypeTemplates)
                    .HasForeignKey(d => d.SectionTypeTemplatesId)
                    .HasConstraintName("FK_Templates_TemplateComponents2");

                entity.HasOne(d => d.Styles)
                    .WithMany(p => p.TemplateStyles)
                    .HasForeignKey(d => d.StylesId)
                    .HasConstraintName("FK_Templates_TemplateComponents3");
            });

            modelBuilder.Entity<TemplateComponent>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
