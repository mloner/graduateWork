#nullable disable

using Microsoft.EntityFrameworkCore;
using ReportingFramework.WebApp.Database.DataBaseModels;

namespace ReportingFramework.WebApp.Database
{
    public partial class TemplateEditorDbContext : DbContext, ITemplateEditorDbContext
    {
        public TemplateEditorDbContext()
        {
        }

        public TemplateEditorDbContext(DbContextOptions<TemplateEditorDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TemplateEditor> TemplateEditors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
