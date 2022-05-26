using System.Globalization;
using ChartGenerator.HighCharts;
using ChartGeneratorModels;
using ChartGeneratorModels.ChartData;
using ChartGeneratorModels.ChartData.CommonChartData;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using Highsoft.Web.Mvc.Charts;
using Microsoft.Extensions.DependencyInjection;

namespace ChartGenerator.Tests;

public class Sandbox
{
    private IChartGenerator _chartGenerator;
    private CsvReader _csvReader;
    
    public void Run()
    {
        Init();
        Main();
    }

    private void Init()
    {
        var services = new ServiceCollection();
        services.AddScoped<IChartGenerator, ChartGenerator>();
        services.AddScoped<ChartGenerator>();
        services.AddScoped<IHighchartsClient, HighchartsClient>();
        services.AddScoped<HighchartsClient>();
        var serviceProvider = services.BuildServiceProvider();
        _chartGenerator = serviceProvider.GetService<IChartGenerator>();
        
        _chartGenerator.Init(new ChartGeneratorSettings
        {
            ChartFolder = "Charts",
            GlobalSettings = new Global(){},
            LangSettings = new Lang(){DecimalPoint = ",", ThousandsSep = " "},
            Font = FontEnum.Averta
        });
        _csvReader = new CsvReader();
    }

    private void Main()
    {
        PeakShavingMonthMultiChart();
    }

    private void PeakShavingMonthMultiChart()
    {
        var ResultGrid1 = _csvReader.GetData(@"C:\r\Reporting Framework\ChartGenerator.Tests\Files\result_smart_grid_3898_battery_2_degradation_False_DAM_True_NM_False.csv");
        var ResultGrid2 = _csvReader.GetData(@"C:\r\Reporting Framework\ChartGenerator.Tests\Files\result_smart_grid_3898_battery_3_degradation_False_DAM_True_NM_False.csv");
        var yMaxes = new List<double?>
        {
            new List<double>()
            {
                (ResultGrid1.GroupBy(x => new
                    {
                        DateTime.Parse(x["time"].ToString(), CultureInfo.InvariantCulture).Year,
                        DateTime.Parse(x["time"].ToString(), CultureInfo.InvariantCulture).Month
                    })
                    .First()
                    .Select(x => double.Parse(x["grid.consumption_power"].ToString(), CultureInfo.InvariantCulture)).Max() / 1000),
                (ResultGrid2.GroupBy(x => new
                    {
                        DateTime.Parse(x["time"].ToString(), CultureInfo.InvariantCulture).Year,
                        DateTime.Parse(x["time"].ToString(), CultureInfo.InvariantCulture).Month
                    })
                    .First()
                    .Select(x => double.Parse(x["grid.consumption_power"].ToString(), CultureInfo.InvariantCulture)).Max() / 1000),
            }.Max() * 1.35
        };
        var link = _chartGenerator.CreateChart(new ChartRequestData()
        {
            ChartType = ChartEnum.PeakShavMonthlyMultiComp,
            ChartData = new PeakShavingMonthMultiChartData()
            {
                Series1 = ResultGrid1
                    .GroupBy(x => new
                    {
                        DateTime.Parse(x["time"].ToString(), CultureInfo.InvariantCulture).Year,
                        DateTime.Parse(x["time"].ToString(), CultureInfo.InvariantCulture).Month
                    })
                    .First()
                    .Select(x => new DateTimeSeries()
                    {
                        DateTime = DateTime.Parse(x["time"].ToString(), CultureInfo.InvariantCulture),
                        Value = double.Parse(x["grid.consumption_power"].ToString(), CultureInfo.InvariantCulture) == null ? 0
                            : double.Parse(x["grid.consumption_power"].ToString(), CultureInfo.InvariantCulture) / 1000
                    }).ToList(),
                Series2 = ResultGrid2
                    .GroupBy(x => new
                    {
                        DateTime.Parse(x["time"].ToString(), CultureInfo.InvariantCulture).Year,
                        DateTime.Parse(x["time"].ToString(), CultureInfo.InvariantCulture).Month
                    })
                    .First()
                    .Select(x => new DateTimeSeries()
                    {
                        DateTime = DateTime.Parse(x["time"].ToString(), CultureInfo.InvariantCulture),
                        Value = double.Parse(x["grid.consumption_power"].ToString(), CultureInfo.InvariantCulture) == null ? 0
                            : (double.Parse(x["grid.consumption_power"].ToString(), CultureInfo.InvariantCulture)) / 1000
                    }).ToList(),
            },
            ChartSettings = new PeakShavingMonthMultiChartSettings()
            {
                YMaxes = yMaxes,
                CustomParameters = new Dictionary<string, string>()
                {
                    {"Series1", "NoBattery"},
                    {"Series2", "SimpleBattery"}
                },
                Language = ChartLanguage.Dutch
            }
        });
        
        Console.WriteLine(link);
    }
    
}