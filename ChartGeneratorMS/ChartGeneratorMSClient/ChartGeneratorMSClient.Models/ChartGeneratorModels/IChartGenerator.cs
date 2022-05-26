using System.Text.Json;

namespace ChartGeneratorModels.ChartGeneratorModels
{
    public interface IChartGenerator
    {
        void Init(ChartGeneratorSettings settings);
        Task<string> CreateChart(ChartRequestData chartRequestData);
        Task<string> CreateChart(JsonElement chartRequestDataJson);
    }
}