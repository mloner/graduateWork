namespace ReportConfigurationMS.DataBase.Models
{
    public partial class TReportsRequest
    {
        public TReportsRequest()
        {
            TReportsSchedules = new HashSet<TReportsSchedule>();
        }

        public int Id { get; set; }
        public int ReportType { get; set; }
        public string EmailList { get; set; }
        public DateTime RequestTimestamp { get; set; }
        public DateTime? GenerationTimestamp { get; set; }
        public int UserId { get; set; }
        public DateTime? ReportDateFrom { get; set; }
        public DateTime? ReportDateTo { get; set; }
        public Guid? CugGuid { get; set; }
        public Guid? BuildingGuid { get; set; }
        public Guid UserGuid { get; set; }
        public string AdditionalData { get; set; }
        public string? Name { get; set; }
        public bool IsProductionRequest { get; set; }
        public string RequestCulture { get; set; }

        public virtual ICollection<TReportsSchedule> TReportsSchedules { get; set; }
    }
}
