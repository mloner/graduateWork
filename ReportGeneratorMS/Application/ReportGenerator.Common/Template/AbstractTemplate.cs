using System.Collections.Generic;
using ReportingFramework.Dto;
using ReportingFramework.Dto.GlobalSettings;

namespace ReportingFramework.Common.Template
{
    public abstract class AbstractTemplate : ITemplate
    {
        public GlobalSettings GlobalSettings { get; set; }
        public List<Dto.Style> Styles { get; set; }
        public Dictionary<int, int> SectionToTemplateRelations { get; set; }

        //public abstract ITemplate Init(ReportDto reportDto, ReportPaths paths);
    }
}