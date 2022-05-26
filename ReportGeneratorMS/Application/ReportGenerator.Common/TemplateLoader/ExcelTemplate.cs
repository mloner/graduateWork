using System.Collections.Generic;
using ReportingFramework.Common.Template;
using ReportingFramework.Dto;

namespace ReportingFramework.Common.TemplateLoader
{
    public class ExcelTemplate : AbstractTemplate
    {
        public Dictionary<string, string> TemplateFilePaths { get; set; }
        public new List<Style> Styles { get; set; }
        // public override ITemplate Init(ReportDto reportDto, ReportPaths paths)
        // {
        //     var reportName = reportDto.ReportType.TypeName;
        //     TemplateFilePaths = TemplateFilePaths
        //         .ToDictionary(
        //             x => x.Key,
        //             x => $"{paths.ExcelTemplates}/{reportName}/{x.Value}");
        //
        //     return this;
        // }
    }
}