using System.Collections.Generic;
using ReportingFramework.Common.Template;
using ReportingFramework.Common.Template.SectionTypeTemplate;

namespace ReportingFramework.Common.TemplateLoader
{
    public class PdfTemplate : AbstractTemplate
    {
        public List<SectionTypeTemplate> SectionTypeTemplates { get; set; }
        // public override ITemplate Init(ReportDto reportDto, ReportPaths paths)
        // {
        //     return this;
        // }
    }
}