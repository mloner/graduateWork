using Newtonsoft.Json;
using ReportingFramework.Dto;

namespace ReportingFramework.Common.TemplateLoader
{
    public class ExcelTemplateLoader : ITemplateLoader
    {
        public ITemplate LoadTemplate(string templateJson)
        {
            return JsonConvert.DeserializeObject<ExcelTemplate>(templateJson, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
        }
    }
}