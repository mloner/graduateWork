using SectionModels;

namespace GeneratorDBDtos.DBDTOs.Report;

public class CreateReportDto
{
    public string Parameters { get; set; }
    public ReportStatus StatusId { get; set; }
    public string Link { get; set; }
}