using ReportingFramework.WebApp.Database.DataBaseModels;
using ReportingFramework.WebApp.Dtos.DBDtos;

namespace ReportingFramework.WebApp.Database.Extensions;

public static class TemplateEditorExtension
{
    public static TemplateEditorDto ToDtoModel(this TemplateEditor model)
    {
        return new TemplateEditorDto
        {
            Id = model.Id,
            EcoscadaUsername = model.EcoscadaUsername,
            Link = model.Link,
            Token = model.Token
        };
    }
    
    public static TemplateEditor ToDtoModel(this TemplateEditorDto model)
    {
        return new TemplateEditor
        {
            EcoscadaUsername = model.EcoscadaUsername,
            Link = model.Link
        };
    }
}