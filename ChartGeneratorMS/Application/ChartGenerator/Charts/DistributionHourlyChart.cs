using System;
using System.Collections.Generic;
using System.Linq;
using ChartGenerator.Extensions;
using ChartGeneratorModels.ChartData;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using Highsoft.Web.Mvc.Charts;

namespace ChartGenerator.Charts
{
    public class DistributionHourlyChart : Chart
    {
        private new readonly DistributionHourlyChartData _data;
        private new readonly DistributionHourlyChartSettings _settings;
        
        public DistributionHourlyChart(ChartData data, ChartSettings settings)
            : base()
        {
            ChartName = ChartEnum.DistributionHourly.ToStr();
            _data = data is DistributionHourlyChartData chartData ?  chartData
                : throw new Exception($"Can not get chart data {ChartName}");
            _settings = settings is DistributionHourlyChartSettings chartSettings ? chartSettings
                : throw new Exception($"Can not get chart settings {ChartName}");
        }

        public override void Generate()
        {
            var options = CreateHighchartsOptions();

            options.Chart.Type = ChartType.Heatmap;
            
            options.Title = new Title()
            {
                //Text = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Global, new DateTime(1970, _settings.Month, 1).ToString("MMMM"))} {_settings.Year}"
            };
            options.Legend = new Legend()
            {
                Enabled = false
            };
            options.XAxis = new List<XAxis>()
            {
                new XAxis()
                {
                    Type = "datetime",
                    Title = new XAxisTitle()
                    {
                        //Text = _settings.GetTranslationString(ChartSettings.TranslScope.Global, "Hours"),
                        Margin = 20
                    },
                    Min = 0,
                    Max = 86400000, // 24 hours in milliseconds
                    Labels = new XAxisLabels()
                    {
                        Format = "{value:%H}",
                        Step = 1,
                        Rotation = 0,
                        Align = XAxisLabelsAlign.Center
                    },
                    ShowLastLabel = false,
                    StartOnTick = true,
                    TickInterval = 60 * 60 * 1000, // hour
                    TickLength = 5,
                    GridLineWidth = 0
                }
            };
            options.YAxis = new List<YAxis>()
            {
                new YAxis()
                {
                    Title = new YAxisTitle()
                    {
                        Text = ""
                    },
                    Labels = new YAxisLabels()
                    {
                        Format = "{value:,.1f} kWh"
                    },
                    TickWidth = 1,
                    Min = 0,
                    Max = Math.Round(_settings.YMaxes[0].Value, 1),
                    TickInterval = 0.1,
                    GridLineWidth = 0,
                    Visible = !_settings.isYAxisHidden
                }
            };
            options.ColorAxis = new ColorAxis()
            {
                Labels = new ColorAxisLabels()
                {
                    Format = "{value}"
                },
                Min = 1,
                Stops = new List<Stop>()
                {
                    new Stop()
                    {
                        Position = 0,
                        Color = _settings.Colors.First().Value.ChangeBrightness(0.4f).ToRgbaString()
                    },
                    new Stop()
                    {
                        Position = 0.3,
                        Color = _settings.Colors.First().Value.ChangeBrightness(0.3f).ToRgbaString()
                    },
                    new Stop()
                    {
                        Position = 0.5,
                        Color = _settings.Colors.First().Value.ChangeBrightness(0.2f).ToRgbaString()
                    },
                    new Stop()
                    {
                        Position = 0.7,
                        Color = _settings.Colors.First().Value.ChangeBrightness(0.1f).ToRgbaString()
                    },
                    new Stop()
                    {
                        Position = 0.9,
                        Color = _settings.Colors.First().Value.ToRgbaString()
                    }
                },
                StartOnTick = true,
                EndOnTick = true
            };

            var heatmapData = new List<HeatmapSeriesData>();
            foreach (var item in _data.Values)
            {
                var newXValue = new DateTime(
                    _settings.DefaultStartDate.Year,
                    _settings.DefaultStartDate.Month,
                    _settings.DefaultStartDate.Day,
                    Convert.ToInt32(item.Key.Hours.ToString()),
                    Convert.ToInt32(item.Key.Minutes.ToString()),
                    Convert.ToInt32(item.Key.Seconds.ToString()),
                    Convert.ToInt32(item.Key.Milliseconds.ToString()));
                var totalMilliseconds = (long) ((newXValue - _settings.DefaultStartDate).TotalMilliseconds);
                foreach (var zVal in item.Value)
                {
                    heatmapData.Add(new HeatmapSeriesData()
                    {
                        X = totalMilliseconds,
                        Y = zVal.Key,
                        Value = zVal.Value
                    });
                }
            }
            options.Series = new List<Series>()
            {
                new HeatmapSeries()
                {
                    Colsize = 15 * 60 * 1000, // 15 mins in ms
                    Rowsize = 0.01,
                    BorderWidth = 0,
                    TurboThreshold = 1000000,
                    NullColor = "#ffffff",
                    Data = heatmapData
                }
            };
            
        }
    }
}