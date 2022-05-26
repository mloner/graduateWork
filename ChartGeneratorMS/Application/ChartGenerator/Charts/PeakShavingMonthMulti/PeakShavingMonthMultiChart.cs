using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using ChartGenerator.Extensions;
using ChartGeneratorModels.ChartData;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using Highsoft.Web.Mvc.Charts;

namespace ChartGenerator.Charts.PeakShavingMonthMulti;

public class PeakShavingMonthMultiChart : Chart
{
    private readonly PeakShavingMonthMultiChartData _data;
    private new PeakShavingMonthMultiChartSettings _settings
    {
        get => base._settings as PeakShavingMonthMultiChartSettings;
        set => base._settings = value;
    }
    
    public PeakShavingMonthMultiChart(ChartData data, ChartSettings settings)
        : base()
    {
        ChartName = ChartEnum.PeakShavMonthlyMultiComp.ToStr();
        _data = data is PeakShavingMonthMultiChartData chartData ?  chartData
            : throw new Exception($"Can not get chart data {ChartName}");
        _settings = settings is PeakShavingMonthMultiChartSettings chartSettings ? chartSettings
            : throw new Exception($"Can not get chart settings {ChartName}");
        ResourceManagers.Add(Resource.ResourceManager);
    }
    
    public override void Generate()
    {
       double fontSize = 18;
        var options = CreateHighchartsOptions();

        options.Chart.Type = ChartType.Line;

        options.Title = new Title()
        {
            Text = ""
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
            BackgroundColor = "rgba(255,255,255,0.6)",
            ItemStyle = new Hashtable()
            {
                {"fontSize", $"{fontSize}px"}
            }
        };
        options.XAxis = new List<XAxis>()
        {
            new XAxis()
            {
                Type = "datetime",
                StartOnTick = false,
                EndOnTick = false,
                Min = ((DateTimeOffset)_data.Series1.First().DateTime).ToUnixTimeSeconds() * 1000,
                Max = ((DateTimeOffset)_data.Series2.Last().DateTime).ToUnixTimeSeconds() * 1000,
                Labels = new XAxisLabels()
                {
                    Format = "{value:%e}"
                },
                Title = new XAxisTitle()
                {
                    Text = _data.Series1.First().DateTime.ToString("MMM yyyy", new CultureInfo(_settings.Language.Desc())),
                    Margin = 20,
                },
                GridLineWidth = 0,
                TickInterval = 4*24,
                LineColor = "lightGray",
                TickColor = "lightGray",
                TickWidth = 0.5
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
                    Format = "{value} kW",
                },
                Min = 0,
                GridLineWidth = 0,
                Max = _settings.YMaxes[0],
                PlotLines = new List<YAxisPlotLines>()
                {
                    new YAxisPlotLines()
                    {
                        Value = _data.Series1.Select(y => y.Value).Max(),
                        DashStyle = YAxisPlotLinesDashStyle.LongDash
                    },
                    new YAxisPlotLines()
                    {
                        Value = _data.Series2.Select(y => y.Value).Max(),
                        DashStyle = YAxisPlotLinesDashStyle.LongDash
                    },
                }
            }
        };
        options.PlotOptions = new PlotOptions()
        {
            Series = new PlotOptionsSeries()
            {
                DataLabels = new PlotOptionsSeriesDataLabels()
                {
                    Enabled = false
                },
                TurboThreshold = 10000
            }
        };
        options.Annotations = new List<Annotations>()
        {
            // series 1
            new Annotations()
            {
                Labels = new List<AnnotationsLabels>()
                {
                    new AnnotationsLabels()
                    {
                        Point = new AnnotationsLabelsPoint()
                        {
                            X = ((DateTimeOffset)_data.Series1.First().DateTime).ToUnixTimeSeconds() * 1000,
                            Y = _data.Series1.Select(x => x.Value).Max() + _settings.YMaxes[0] * 0.01,
                            XAxisNumber = 0,
                            YAxisNumber = 0
                        },
                        Text = $"{GetTranslationString($"MonthPeak{_settings.CustomParameters["Series1"]}")}" +
                               $" {Math.Round(_data.Series1.Select(x => x.Value).Max(), 1)} kW",
                        Shape = "rect",
                        BackgroundColor = Color.FromArgb(128,0,0,0).ToRgbaString(),
                        BorderColor = Color.FromArgb(0,0,0,0).ToRgbaString(),
                        Style = new Hashtable()
                        {
                            {"fontSize", $"{fontSize}px"}
                        }
                    }
                },
                LabelOptions = new AnnotationsLabelOptions()
                {
                    X = 0,
                    Y = 0
                }
            },
            // series 2
            new Annotations()
            {
                Labels = new List<AnnotationsLabels>()
                {
                    new AnnotationsLabels()
                    {
                        Point = new AnnotationsLabelsPoint()
                        {
                            X = ((DateTimeOffset)_data.Series2.First().DateTime).ToUnixTimeSeconds() * 1000,
                            Y = _data.Series2.Select(x => x.Value).Max() + _settings.YMaxes[0] * 0.01,
                            XAxisNumber = 0,
                            YAxisNumber = 0
                        },
                        Text = $"{GetTranslationString($"MonthPeak{_settings.CustomParameters["Series2"]}")}" +
                               $" {Math.Round(_data.Series2.Select(x => x.Value).Max(), 1)} kW",
                        Shape = "rect",
                        BackgroundColor = Color.FromArgb(128,0,0,0).ToRgbaString(),
                        BorderColor = Color.FromArgb(0,0,0,0).ToRgbaString(),
                        Style = new Hashtable()
                        {
                            {"fontSize", $"{fontSize}px"}
                        }
                    }
                },
                LabelOptions = new AnnotationsLabelOptions()
                {
                    X = 0,
                    Y = 0,
                    AllowOverlap = true,
                }
            }
        };

        options.Series = new List<Series>();
        LineSeries series;
        
        // series 1
        series = new LineSeries()
        {
            Name = $"{GetTranslationString($"GridPower{_settings.CustomParameters["Series1"]}")}",
            Data = _data.Series1.Select(x => new LineSeriesData()
            {
                X = ((DateTimeOffset)x.DateTime).ToUnixTimeSeconds() * 1000,
                Y = x.Value,
            }).ToList(),
            Marker = new LineSeriesMarker()
            {
                Enabled = false
            },
            XAxisNumber = 0
        };
        options.Series.Add(series);
        
        // series 2
        series = new LineSeries()
        {
            Name = $"{GetTranslationString($"GridPower{_settings.CustomParameters["Series2"]}")}",
            Data = _data.Series2.Select(x => new LineSeriesData()
            {
                X = ((DateTimeOffset)x.DateTime).ToUnixTimeSeconds() * 1000,
                Y = x.Value,
            }).ToList(),
            Marker = new LineSeriesMarker()
            {
                Enabled = false
            },
            XAxisNumber = 0
        };

        options.Series.Add(series);
    }
}