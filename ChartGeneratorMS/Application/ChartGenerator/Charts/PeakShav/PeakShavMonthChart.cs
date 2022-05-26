using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using ChartGenerator.Extensions;
using ChartGeneratorModels.ChartData;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using Highsoft.Web.Mvc.Charts;


namespace ChartGenerator.Charts.PeakShav
{
    public class PeakShavMonthChart : Chart
    {
        private PeakShavingMonthChartData _data;
        private PeakShavingMonthChartSettings _settings;
        
        public PeakShavMonthChart(ChartData data, ChartSettings settings)
            : base()
        {
            ChartName = ChartEnum.PeakShavMonth.ToStr();
            _data = data is PeakShavingMonthChartData chartData ?  chartData
                : throw new Exception($"Can not get chart data {ChartName}");
            _settings = settings is PeakShavingMonthChartSettings chartSettings ? chartSettings
                : throw new Exception($"Can not get chart settings {ChartName}");
        }
        
        public override void Generate()
        {
            _data.GridPower = _data.GridPower.Select(x =>
            {
                x.Value = Math.Round(x.Value, 4);
                return x;
            }).ToList();
            
            
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
                BorderColor = _settings.Color.ToRgbaString(),
                Title = new LegendTitle()
                {
                    Text = "",
                    Style = new PropertyCollection()
                    {
                        {"color", _settings.Color.ToRgbaString()}
                    }
                },
                ItemStyle = new PropertyCollection()
                {
                    {"color", _settings.Color.ToRgbaString()}
                },
                BackgroundColor = "rgba(255,255,255,0.6)"
            };
            options.XAxis = new List<XAxis>()
            {
                new XAxis()
                {
                    Type = "datetime",
                    StartOnTick = false,
                    EndOnTick = false,
                    Min = ((DateTimeOffset)_data.GridPower.First().DateTime).ToUnixTimeSeconds() * 1000,
                    Max = ((DateTimeOffset)_data.GridPower.Last().DateTime).ToUnixTimeSeconds() * 1000,
                    Labels = new XAxisLabels()
                    {
                        Style = new PropertyCollection()
                        {
                            {"color", _settings.Color.ToRgbaString()}
                        },
                        Format = "{value:%e}"
                    },
                    Title = new XAxisTitle()
                    {
                        Text = _data.GridPower.First().DateTime.ToString("MMM, yyyy", CultureInfo.InvariantCulture),
                        Margin = 20,
                        Style = new PropertyCollection()
                        {
                            {"color", _settings.Color.ToRgbaString()}
                        }
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
                        Style = new PropertyCollection()
                        {
                            { "color", _settings.Color.ToRgbaString() }
                        }
                    },
                    Min = _data.GridPower.Select(x => x.Value).Min() < 0 ? 0 : _data.GridPower.Select(x => x.Value).Min(),
                    GridLineWidth = 0,
                    Max = _settings.YMaxes[0],
                    PlotLines = new List<YAxisPlotLines>()
                    {
                        new YAxisPlotLines()
                        {
                            Value = _data.GridPower.Select(x => x.Value).Max(),
                            Color = _settings.Color.ToRgbaString(),
                            DashStyle = YAxisPlotLinesDashStyle.LongDash
                        }
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
                new Annotations()
                {
                    Labels = new List<AnnotationsLabels>()
                    {
                        new AnnotationsLabels()
                        {
                            Point = new AnnotationsLabelsPoint()
                            {
                                X = ((DateTimeOffset)_data.GridPower[_data.GridPower.Count/2].DateTime).ToUnixTimeSeconds() * 1000,
                                Y = _data.GridPower.Select(x => x.Value).Max() + _settings.YMaxes[0] * 0.01,
                                XAxisNumber = 0,
                                YAxisNumber = 0
                            },
                            Text = $"Gemiddelde maandpiek {Math.Round(_data.GridPower.Select(x => x.Value).Max(), 1)} kW",
                            Shape = "rect",
                            BackgroundColor = _settings.Color.ToRgbaString(),
                            BorderColor = _settings.Color.ToRgbaString(),
                        }
                    },
                    LabelOptions = new AnnotationsLabelOptions()
                    {
                        X = 0,
                        Y = 0
                    }
                }
            };

            options.Series = new List<Series>();
            
            //grid power
            int i = 0;
            var gridPowerSeries = new LineSeries()
            {
                Name = $"Net aankoop",
                Data = _data.GridPower.Select(x => new LineSeriesData()
                {
                    X = ((DateTimeOffset)x.DateTime).ToUnixTimeSeconds() * 1000,
                    Y = x.Value,
                }).ToList(),
                Color = _settings.Color.ToRgbaString(),
                Marker = new LineSeriesMarker()
                {
                    Enabled = false
                },
                XAxisNumber = 0
            };
            options.Series.Add(gridPowerSeries);

            
            
        }
    }
}