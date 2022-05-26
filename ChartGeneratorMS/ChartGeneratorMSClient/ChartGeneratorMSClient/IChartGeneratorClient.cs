using ChartGeneratorModels;

namespace ChartGeneratorClient;

public interface IChartGeneratorClient
{
    void Init(ChartGeneratorSettings settings);
    Task<string> CreateChartAsync(ChartRequestData chartRequestData);
}