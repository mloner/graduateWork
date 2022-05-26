using System.ComponentModel;

namespace ReportingFramework.Dto
{
    public enum TemplateComponentEnum
    {
        [Description("GlobalSettings")]
        GlobalSettings = 1,
        
        [Description("Styles")]
        Styles = 2,

        [Description("SectionToTemplateRelations")]
        SectionToTemplateRelations = 3,
        
        [Description("SectionTypeTemplates")]
        SectionTypeTemplates = 4,
        
        [Description("TemplateFilePaths")]
        TemplateFilePaths = 5,
    }
}