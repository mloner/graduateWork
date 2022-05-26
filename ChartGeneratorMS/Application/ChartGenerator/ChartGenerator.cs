using System;
using System.Text.Json;
using System.Threading.Tasks;
using ChartGeneratorModels;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using ChartGenerator.HighCharts;
using Highsoft.Web.Mvc.Charts;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace ChartGenerator
{
    public class ChartGenerator : IChartGenerator
    {
        private readonly IHighchartsClient _highchartsClient;
        private readonly ILogger<ChartGenerator> _logger;

        private Guid _chartGuid;
        
        private Global GlobalSettings { get; set; }
        private Lang LangSettings { get; set; }
        private FontEnum Font { get; set; }
        private string ChartFolder { get; set; }

        public ChartGenerator(IHighchartsClient highchartsClient,
            ILogger<ChartGenerator> logger)
        {
            _highchartsClient = highchartsClient;
            _logger = logger;
        }

        public void Init(ChartGeneratorSettings settings)
        {
            LangSettings = settings.LangSettings;
            GlobalSettings = settings.GlobalSettings;
            Font = (int)settings.Font == 0 ? FontEnum.Averta : settings.Font;
            ChartFolder = settings.ChartFolder;
        }
        public async Task<string> CreateChart(ChartRequestData chartRequestData)
        {
            return await CreateChart(chartRequestData.ChartType, chartRequestData.ChartData, chartRequestData.ChartSettings);
        }

        public async Task<string> CreateChart(JsonElement chartRequestDataJson)
        {
            var jo = JObject.Parse(chartRequestDataJson.ToString());
            if (jo["ChartType"] == null || jo["ChartData"] == null || jo["ChartSettings"] == null)
            {
                throw new Exception("ChartType or ChartData or ChartSettings is null");
            }
            
            var chartEnum = (ChartEnum)int.Parse(jo["ChartType"].ToString());
            var chartData = ChartDataHelper.GetChartData(chartEnum, jo["ChartData"].ToString());
            var chartSettings = ChartSettingsHelper.GetChartSettings(chartEnum, jo["ChartSettings"].ToString());
            _chartGuid = Guid.NewGuid();

            try
            {
                return await CreateChart(new ChartRequestData
                {
                    ChartType = chartEnum,
                    ChartData = chartData,
                    ChartSettings = chartSettings,
                });
            }
            catch (Exception e)
            {
                _logger.LogCritical($"[ChartGuid: {_chartGuid}]\n" +
                                    $"CreateChart failed:\n" +
                                    $"Message: {e.Message}\n" +
                                    $"StackTrace: {e.StackTrace}");
                
                throw new Exception("Inner exception");
            }
            
        }

        public async Task<string> CreateChart(
            ChartEnum chartType,
            ChartData chartData,
            ChartSettings chartSettings)
        {
            var chart = ChartHelper.GetChart(chartType, chartData, chartSettings);
            chart.Generate();
            
            chart.SetChartJson();
            chart.SetChartFont(Font);
            
            var globalOptions = new HighsoftNamespace().GetGlobalSettings(GlobalSettings, LangSettings);
            var response = await _highchartsClient.GetChartImageLinkFromOptions(chart.Json, globalOptions);

            return response;
        }
    }
}