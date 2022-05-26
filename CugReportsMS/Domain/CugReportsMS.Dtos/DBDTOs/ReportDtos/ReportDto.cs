namespace CugReportMicroservice.Dtos.DBDTOs.ReportDtos
{
    public class ReportDto : CreateReportDto
    {
        public int Id { get; set; }
        public Guid? ReportGuidInGenerator { get; set; }
        public ReportTypeWithTemplateDto TypeWithTemplateDto { get; set; }
    }
}