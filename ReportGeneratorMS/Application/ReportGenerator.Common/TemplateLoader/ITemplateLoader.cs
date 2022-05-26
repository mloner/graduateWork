using ReportingFramework.Dto;

namespace ReportingFramework.Common.TemplateLoader
{
    public interface ITemplateLoader
    {
        ITemplate LoadTemplate(string templateJson);
    }
}