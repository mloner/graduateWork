using ChartGeneratorClient;
using SectionModels;

namespace ReportingFramework.Dto
{
    public class ReportModelExtended : ReportModel
    {
        public ITemplate Template { get; set; }
        public ReportPaths Paths { get; set; }
        public INumberFormatter NumberFormatter { get; set; }
        public IChartGeneratorClient ChartGeneratorClient { get; set; }
    }
}