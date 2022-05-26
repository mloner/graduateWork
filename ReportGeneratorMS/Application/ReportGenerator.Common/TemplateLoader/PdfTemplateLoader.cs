using Newtonsoft.Json;
using ReportingFramework.Dto;

namespace ReportingFramework.Common.TemplateLoader
{
    public class PdfTemplateLoader : ITemplateLoader
    {
        public ITemplate LoadTemplate(string templateJson)
        {
            return JsonConvert.DeserializeObject<PdfTemplate>(templateJson, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
        }
    }
}