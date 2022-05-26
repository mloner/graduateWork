using System.Collections.Generic;

namespace ReportingDB.DataBaseModels
{
    public partial class ReportTypesWithTemplate
    {
        public ReportTypesWithTemplate()
        {
            Reports = new HashSet<Report>();
        }

        public int Id { get; set; }
        public int ReportTypeId { get; set; }
        public string Name { get; set; }
        public string TemplateId { get; set; }
        public int? LanguageId { get; set; }

        public virtual ReportType ReportType { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
