namespace CugReportMicroservice.Dtos.DBDTOs.ReportDtos
{
    public class CreateReportDto
    {
        public int TypeWithTemplateId { get; set; }
        public string Parameters { get; set; }
    }
}