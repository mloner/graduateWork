namespace GeneratorDBDtos.DBDTOs;

public class TemplateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? GlobalSettingsId { get; set; }
    public string? GlobalSettings { get; set; }
    
    public int? StylesId { get; set; }
    public string? Styles { get; set; }
    
    public int? SectionToTemplateRelationsId { get; set; }
    public string? SectionToTemplateRelations { get; set; }
    
    public int? SectionTypeTemplatesId { get; set; }
    public string? SectionTypeTemplates { get; set; }
    
    public string? TemplateFull { get; set; }
}