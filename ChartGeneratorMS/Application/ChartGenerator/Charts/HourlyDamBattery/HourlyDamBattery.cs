using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ChartGenerator.Extensions;
using ChartGeneratorModels.ChartData;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using Highsoft.Web.Mvc.Charts;

namespace ChartGenerator.Charts.HourlyDamBattery;

public class HourlyDamBattery : Chart
{
    private readonly HourlyDamBatteryChartData _data;
    private new HourlyDamBatteryChartSettings _settings
    {
        get => base._settings as HourlyDamBatteryChartSettings;
        set => base._settings = value;
    }

    public HourlyDamBattery(ChartData data, ChartSettings settings)
    {
        ChartName = ChartEnum.HourlyDamBattery.ToStr();
        _data = data is HourlyDamBatteryChartData chartData ?  chartData
            : throw new Exception($"Can not get chart data {ChartName}");
        _settings = settings is HourlyDamBatteryChartSettings chartSettings ? chartSettings
            : throw new Exception($"Can not get chart settings {ChartName}");
        ResourceManagers.Add(Resource.ResourceManager);
    }
    
    public override void Generate()
        {
            var options = CreateHighchartsOptions();

            options.Chart.Type = ChartType.Line;

            options.XAxis = new List<XAxis>()
            {
                new XAxis()
                {
                    Type = "datetime",
                    Min = 0,
                    Max = 86400000, // 24 hours in milliseconds
                    Title = new XAxisTitle()
                    {
                        Text = GetTranslationString("Hours"),
                        Margin = 20
                    },
                    Labels = new XAxisLabels()
                    {
                        Format = "{value:%k}",
                        Step = 1,
                        Rotation = 0,
                        Align = XAxisLabelsAlign.Center
                    },
                    ShowLastLabel = false,
                    StartOnTick = true,
                    TickInterval = 3600000,
                    TickLength = 5,
                    GridLineWidth = 0
                },
            };

            options.YAxis = new List<YAxis>()
            {
                //dam
                new YAxis()
                {
                    Title = new YAxisTitle()
                    {
                        Text = ""
                    },
                    GridLineWidth = 0,
                    Labels = new YAxisLabels()
                    {
                        Format = "{value} €/kWh",
                    },
                    Min = 0,
                },
                //battery power
                new YAxis()
                {
                    Title = new YAxisTitle()
                    {
                        Text = ""
                    },
                    GridLineWidth = 0,
                    Labels = new YAxisLabels()
                    {
                        Format = "{value} W",
                    },
                    Opposite = true,
                    PlotLines = new List<YAxisPlotLines>()
                    {
                        new YAxisPlotLines()
                        {
                            Value = 0,
                            Color = Color.Black.ToRgbaString(),
                            ZIndex = 4
                        },
                    }
                }
            };

            options.PlotOptions = new PlotOptions()
            {
                Series = new PlotOptionsSeries()
                {
                    Marker = new PlotOptionsSeriesMarker()
                    {
                        Enabled = false
                    }
                }
            };

            options.Legend = new Legend()
            {
                Enabled = true,
                Layout = LegendLayout.Vertical,
                Align = LegendAlign.Right,
                VerticalAlign = LegendVerticalAlign.Top,
                Floating = true,
                BorderWidth = 1,
                BorderRadius = 4,
                BorderColor = Color.FromArgb(197, 197, 197).ToRgbaString(),
                BackgroundColor = "rgba(255,255,255,0.6)"
            };

            options.Series = new List<Series>();
            
            //dam
            options.Series.Add(new AreaSeries()
            {
                Name = GetTranslationString("EnergyPrice"),
                Data = _data.Dam.Select(x => new AreaSeriesData()
                {
                    X = (long)(new DateTime(_settings.DefaultStartDate.Year,
                                   _settings.DefaultStartDate.Month,
                                   _settings.DefaultStartDate.Day, x.Key, 0, 0)
                               - _settings.DefaultStartDate).TotalMilliseconds,
                    Y = x.Value
                }).ToList(),
                YAxisNumber = 0,
                LineWidth = 0,
                Marker = new AreaSeriesMarker()
                {
                    Enabled = true,
                    Radius = 2,
                    FillColor = Color.FromArgb(252,205,3).ToRgbaString(),
                    LineColor = Color.FromArgb(252,205,3).ToRgbaString()
                },
                Color = Color.FromArgb(252,205,3).ToRgbaString(),
                FillColor = Color.FromArgb(244,236,198).ToRgbaString()
                //Color = _settings.Colors["Dam"].ToRgbaString()
            });
            
            //battery power charging
            options.Series.Add(new LineSeries()
            {
                Name = GetTranslationString("Charging"),
                Data = _data.BatteryPower.Select(x => new LineSeriesData()
                {
                    X = (long)(new DateTime(_settings.DefaultStartDate.Year, _settings.DefaultStartDate.Month,
                        _settings.DefaultStartDate.Day, x.Key, 0, 0) - _settings.DefaultStartDate).TotalMilliseconds,
                    Y = x.Value
                }).ToList(),
                YAxisNumber = 1,
                XAxisNumber = 0,
                Color = Color.FromArgb(108,216,170).ToRgbaString(),
                NegativeColor = Color.FromArgb(231,159,147).ToRgbaString(),
            });
            
            //battery power discharging
            options.Series.Add(new LineSeries()
            {
                Name = GetTranslationString("Discharging"),
                YAxisNumber = 1,
                XAxisNumber = 0,
                Color = Color.FromArgb(231,159,147).ToRgbaString(),
            });

            
            
        }
}