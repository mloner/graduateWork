using System.Threading.Tasks;

namespace ChartGenerator.HighCharts
{
    public interface IHighchartsClient
    {
        Task<string> GetChartImageLinkFromOptions(string options, string globalOptions);
    }
}