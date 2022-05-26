namespace ReportingDB.DataBaseModels
{
    public partial class Section
    {
        public int Id { get; set; }
        public int ReportTypeId { get; set; }
        public int SectionNum { get; set; }
        public string Name { get; set; }
        public int? OrderNum { get; set; }
        public bool Enabled { get; set; }

        public virtual ReportType ReportType { get; set; }
    }
}
