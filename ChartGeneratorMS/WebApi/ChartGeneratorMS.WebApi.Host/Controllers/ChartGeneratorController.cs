using System.Text.Json;
using ChartGenerator.Host.ControllerLogger;
using ChartGeneratorModels.ChartGeneratorModels;
using Highsoft.Web.Mvc.Charts;
using Microsoft.AspNetCore.Mvc;

namespace ChartGenerator.Host.Controllers;

[Route("charts")]
//[Authorize]
[ApiController]
public class ChartGeneratorController : ControllerBase
{
    private IChartGenerator _chartGenerator;
    private readonly IControllerLogger _controllerLogger;

    public ChartGeneratorController(IChartGenerator chartGenerator,
        IControllerLogger controllerLogger)
    {
        _chartGenerator = chartGenerator;
        _chartGenerator.Init(new ChartGeneratorSettings
        {
            ChartFolder = "Charts",
            GlobalSettings = new Global(){},
            LangSettings = new Lang()
            {
                DecimalPoint = ",",
                ThousandsSep = " "
            },
            Font = FontEnum.Averta
        });

        _controllerLogger = controllerLogger;
    }
    
    [HttpPost("chart")]
    public async Task<string> GenerateChart([FromBody] JsonElement chartDataJson)
    {
        _controllerLogger.Log(HttpContext, $"ChartData: {chartDataJson}");
        
        var chartUrl = await _chartGenerator.CreateChart(chartDataJson);

        return chartUrl;
    } 
}