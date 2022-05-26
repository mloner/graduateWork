using System.Collections.Generic;

namespace ReportingDB.DataBaseModels
{
    public partial class ReportType
    {
        public ReportType()
        {
            ReportTypesWithTemplates = new HashSet<ReportTypesWithTemplate>();
            Sections = new HashSet<Section>();
        }

        public int Id { get; set; }
        public int TypeNum { get; set; }
        public string Name { get; set; }
        public int FormatId { get; set; }
        public string OutputFormat { get; set; }

        public virtual ICollection<ReportTypesWithTemplate> ReportTypesWithTemplates { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
