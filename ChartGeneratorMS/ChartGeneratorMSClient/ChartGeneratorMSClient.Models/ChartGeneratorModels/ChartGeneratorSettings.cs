using Highsoft.Web.Mvc.Charts;

namespace ChartGeneratorModels.ChartGeneratorModels
{
    public class ChartGeneratorSettings
    {
        public string ChartFolder { get; set; }
        public Global GlobalSettings { get; set; }
        public Lang LangSettings { get; set; }
        public FontEnum Font { get; set; }
    }
}