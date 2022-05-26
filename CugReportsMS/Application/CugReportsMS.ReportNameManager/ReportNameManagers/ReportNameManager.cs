namespace ReportNameManager.ReportNameManagers;

public class ReportNameManager
{
    public virtual string CreateReportName(ReportNameManagerParameters parameters)
    {
        var reportName =
            $"{parameters.ReportDto.TypeWithTemplateDto.Name}" +
            $"_{parameters.ReportDto.Id}" +
            $"_{DateTime.Now:yyyy_MM_dd}";

        return reportName;
    }
}