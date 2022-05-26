using ReportingFramework.WebApp.Dtos.DBDtos;

namespace ReportingFramework.WebApp.Dtos.Repositories;

public interface ITemplateEditorRepository
{
    Task<TemplateEditorDto?> GetTemplateEditorByUsername(string username);
    Task<TemplateEditorDto> UpdateTemplate(int id, TemplateEditorDto templateEditorDto);
}