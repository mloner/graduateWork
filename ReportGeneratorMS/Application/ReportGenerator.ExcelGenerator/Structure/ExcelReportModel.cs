using ReportingFramework.Common.TemplateLoader;
using ReportingFramework.Dto;

namespace ExcelGenerator.Structure
{
    public class ExcelReportModel : ReportModelExtended
    { 
        public new ExcelTemplate Template { get; set; }
    }
}