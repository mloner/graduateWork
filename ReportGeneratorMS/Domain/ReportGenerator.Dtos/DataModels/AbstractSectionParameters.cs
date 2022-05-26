using ChartGeneratorClient;

namespace ReportingFramework.Dto.DataModels
{
    public abstract class AbstractSectionParameters
    {
        public ITemplate Template;
        public ReportSettings ReportSettings;
        public IChartGeneratorClient ChartGeneratorClient;
        public ResourceParameters ResourceParameters;
        public INumberFormatter NumFmtr;
        public ReportPaths Paths;
    }
}