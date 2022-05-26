namespace CugReportMicroservice.Dtos.ExcelSectionData.MaintenanceReport.Dto
{
    public class CugMetersDto
    {
        public string CugName { get; set; }
        public List<CugMetersDtoItem> MetersValues { get; set; }
    }
}