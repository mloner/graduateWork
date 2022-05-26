using System;

namespace ReportingDB.DataBaseModels
{
    public partial class Report
    {
        public int Id { get; set; }
        public int TypeWithTemplateId { get; set; }
        public string Parameters { get; set; }
        public Guid? ReportGuidInGenerator { get; set; }

        public virtual ReportTypesWithTemplate TypeWithTemplate { get; set; }
    }
}
