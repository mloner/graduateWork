using ChartGeneratorModels.ChartGeneratorModels;

namespace ChartGeneratorModels
{
    public class ChartRequestData : ChartRequestDataBase
    {
        //public string Tag { get; set; }
        public ChartEnum ChartType { get; set; }
        public ChartGeneratorModels.ChartData ChartData { get; set; }
        public ChartSettings.ChartSettings ChartSettings { get; set; }
    }
}