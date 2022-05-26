using System.Collections.Generic;

namespace ReportingFramework.Dto
{
    public interface ITemplate
    { 
        GlobalSettings.GlobalSettings GlobalSettings { get; set; }
        List<Style> Styles { get; set; }
        Dictionary<int, int> SectionToTemplateRelations { get; set; }

        //ITemplate Init(ReportDto reportDto, ReportPaths paths);
    }
}