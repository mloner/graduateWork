namespace CugReportMicroservice.Dtos.DBDTOs;

public class ReportTypeWithTemplateDto
{
    public int Id { get; set; }
    public int ReportTypeId { get; set; }
    public string Name { get; set; }
    public string TemplateId { get; set; }
    public int? LanguageId { get; set; }
    
    public ReportTypeDto ReportTypeDto { get; set; }
}