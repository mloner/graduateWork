namespace ReportConfigurationMS.DataBase.Models
{
    public partial class TReportsSchedule
    {
        public int ReportsScheduleId { get; set; }
        public int? ReportsRequestId { get; set; }
        public int? Granularity { get; set; }
        public int? PeriodInDays { get; set; }
        public int? ReportFrequencyId { get; set; }
        public DateTime NextReportSendDate { get; set; }
        public DateTime? GenerationTimestamp { get; set; }

        public virtual TReportsRequest ReportsRequest { get; set; }
    }
}
