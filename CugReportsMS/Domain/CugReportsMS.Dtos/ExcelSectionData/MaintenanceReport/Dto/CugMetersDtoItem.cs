namespace CugReportMicroservice.Dtos.ExcelSectionData.MaintenanceReport.Dto
{
    public class CugMetersDtoItem
    {
        public string BuildingName { get; set; }
        public string AimrId { get; set; }
        public string AimrName { get; set; }
        public string AimrType { get; set; }
        public string InputId { get; set; }
        public string Medium { get; set; }
        public string InputName { get; set; }
        public string LastValueTimeStamp { get; set; }
        public string LastValue { get; set; }
        public string GateTime { get; set; }
        public string Description { get; set; }
    }
}