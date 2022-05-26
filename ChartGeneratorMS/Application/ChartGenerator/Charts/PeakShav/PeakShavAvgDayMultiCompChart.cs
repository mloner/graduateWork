using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ChartGenerator.Extensions;
using ChartGeneratorModels.ChartData;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using Highsoft.Web.Mvc.Charts;


namespace ChartGenerator.Charts.PeakShav
{
    public class PeakShavAvgDayMultiCompChart : Chart
    {
        public new PeakShavAvgDayMultiCompChartData _data { get; set; }
        public new PeakShavAvgDayMultiCompChartSettings _settings { get; set; }
        
        public PeakShavAvgDayMultiCompChart(ChartData data, ChartSettings settings)
            : base()
        {
            ChartName = ChartEnum.PeakShavAvgDayMultuComp.ToStr();
            _data = data is PeakShavAvgDayMultiCompChartData chartData ?  chartData
                : throw new Exception($"Can not get chart data {ChartName}");
            _settings = settings is PeakShavAvgDayMultiCompChartSettings chartSettings ? chartSettings
                : throw new Exception($"Can not get chart settings {ChartName}");
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
                        //Text = _settings.GetTranslationString(ChartSettings.TranslScope.Global, "Hours"),
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
                new YAxis()
                {
                    Title = new YAxisTitle()
                    {
                        Text = ""
                    },
                    GridLineWidth = 0,
                    Labels = new YAxisLabels()
                    {
                        Format = "{value:,.0f} kW"
                    },
                    Min = 0,
                    Max = _settings.YMaxes[0],
                    PlotLines = new List<YAxisPlotLines>()
                    {
                        //ref peak
                        new YAxisPlotLines()
                        {
                            Color = Color.FromArgb(84, 211, 157).ToRgbaString(),
                            Width = 2,
                            Value = _data.PeakRef,
                            DashStyle = YAxisPlotLinesDashStyle.LongDash,
                            ZIndex = 4
                        },
                        //alt peak
                        new YAxisPlotLines()
                        {
                            Color = Color.FromArgb(84, 211, 157).ToRgbaString(),
                            Width = 2,
                            Value = _data.PeakAlt,
                            DashStyle = YAxisPlotLinesDashStyle.LongDash,
                            ZIndex = 4
                        },
                        //best peak
                        new YAxisPlotLines()
                        {
                            Color = Color.FromArgb(0, 31, 78).ToRgbaString(),
                            Width = 2,
                            Value = _data.PeakMain,
                            DashStyle = YAxisPlotLinesDashStyle.LongDash,
                            ZIndex = 4
                        },
                    },
                },
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
            
            options.Annotations = new List<Annotations>()
            {
                //ref peak
                new Annotations()
                {
                    Labels = new List<AnnotationsLabels>()
                    {
                        new AnnotationsLabels()
                        {
                            Point = new AnnotationsLabelsPoint()
                            {
                                X = (long)(new DateTime(_settings.DefaultStartDate.Year, _settings.DefaultStartDate.Month,
                                    _settings.DefaultStartDate.Day, _data.ValuesRef.Skip((int)(_data.ValuesRef.Count * (1.0/3)))
                                        .First().Key, 0, 0) - _settings.DefaultStartDate).TotalMilliseconds,
                                Y = _data.PeakRef,
                                XAxisNumber = 0,
                                YAxisNumber = 0
                            },
                            //Text = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "PeakRef")} {{y:,.1f}} kW",
                            Shape = "rect",
                            BackgroundColor = Color.FromArgb(128,0,0,0).ToRgbaString(),
                            BorderColor = Color.FromArgb(0,0,0,0).ToRgbaString()
                        }
                    },
                    LabelOptions = new AnnotationsLabelOptions()
                    {
                        X = 0,
                        Y = 0,
                        AllowOverlap = true
                    }
                },
                //alt peak
                new Annotations()
                {
                    Labels = new List<AnnotationsLabels>()
                    {
                        new AnnotationsLabels()
                        {
                            Point = new AnnotationsLabelsPoint()
                            {
                                X = (long)(new DateTime(_settings.DefaultStartDate.Year, _settings.DefaultStartDate.Month,
                                    _settings.DefaultStartDate.Day, _data.ValuesAlt.Skip((int)(_data.ValuesAlt.Count * (2.0/3)))
                                        .First().Key, 0, 0) - _settings.DefaultStartDate).TotalMilliseconds,
                                Y = _data.PeakAlt,
                                XAxisNumber = 0,
                                YAxisNumber = 0
                            },
                            //Text = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "PeakAlt")} {{y:,.1f}} kW",
                            Shape = "rect",
                            BackgroundColor = Color.FromArgb(128,0,0,0).ToRgbaString(),
                            BorderColor = Color.FromArgb(0,0,0,0).ToRgbaString()
                        }
                    },
                    LabelOptions = new AnnotationsLabelOptions()
                    {
                        X = 0,
                        Y = 0,
                        AllowOverlap = true
                    }
                },
                //best peak
                new Annotations()
                {
                    Labels = new List<AnnotationsLabels>()
                    {
                        new AnnotationsLabels()
                        {
                            Point = new AnnotationsLabelsPoint()
                            {
                                X = (long)(new DateTime(_settings.DefaultStartDate.Year, _settings.DefaultStartDate.Month,
                                    _settings.DefaultStartDate.Day, _data.ValuesMain.Last().Key, 0, 0) - _settings.DefaultStartDate).TotalMilliseconds,
                                Y = _data.PeakMain,
                                XAxisNumber = 0,
                                YAxisNumber = 0
                            },
                            //Text = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "PeakMain")} " +
                                   //$"{{y:,.1f}} kW",
                            Shape = "rect",
                            BackgroundColor = Color.FromArgb(128,0,0,0).ToRgbaString(),
                            BorderColor = Color.FromArgb(0,0,0,0).ToRgbaString()
                        }
                    },
                    LabelOptions = new AnnotationsLabelOptions()
                    {
                        X = 0,
                        Y = 0,
                        AllowOverlap = true
                    }
                },
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
            
            //ref
            options.Series.Add(new LineSeries()
            {
                //Name = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "SeriesRef")}",
                Data = _data.ValuesRef.Select(x => new LineSeriesData()
                {
                    X = (long)(new DateTime(_settings.DefaultStartDate.Year, _settings.DefaultStartDate.Month,
                        _settings.DefaultStartDate.Day, x.Key, 0, 0) - _settings.DefaultStartDate).TotalMilliseconds,
                    Y = x.Value
                }).ToList(),
                YAxisNumber = 0,
                XAxisNumber = 0,
                Color = _settings.Colors["SeriesRef"].ToRgbaString()
            });
            //alt
            options.Series.Add(new LineSeries()
            {
                //Name = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "SeriesAlt")}",
                Data = _data.ValuesAlt.Select(x => new LineSeriesData()
                {
                    X = (long)(new DateTime(_settings.DefaultStartDate.Year, _settings.DefaultStartDate.Month,
                        _settings.DefaultStartDate.Day, x.Key, 0, 0) - _settings.DefaultStartDate).TotalMilliseconds,
                    Y = x.Value
                }).ToList(),
                YAxisNumber = 0,
                XAxisNumber = 0,
                Color = _settings.Colors["SeriesAlt"].ToRgbaString()
            });
            //main
            options.Series.Add(new LineSeries()
            {
                //Name = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "SeriesMain")}",
                Data = _data.ValuesMain.Select(x => new LineSeriesData()
                {
                    X = (long)(new DateTime(_settings.DefaultStartDate.Year, _settings.DefaultStartDate.Month,
                        _settings.DefaultStartDate.Day, x.Key, 0, 0) - _settings.DefaultStartDate).TotalMilliseconds,
                    Y = x.Value
                }).ToList(),
                YAxisNumber = 0,
                XAxisNumber = 0,
                Color = _settings.Colors["SeriesMain"].ToRgbaString()
            });
            
            //lines
            //ref peak
            options.Series.Add(new LineSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "PeakRef"),
                Color = _settings.Colors["SeriesRef"].ToRgbaString(),
                Marker = new LineSeriesMarker()
                {
                    Enabled = false
                },
                DashStyle = LineSeriesDashStyle.ShortDash
            });
            //alt peak
            options.Series.Add(new LineSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "PeakAlt"),
                Color = _settings.Colors["SeriesAlt"].ToRgbaString(),
                Marker = new LineSeriesMarker()
                {
                    Enabled = false
                },
                DashStyle = LineSeriesDashStyle.ShortDash
            });
            //main peak
            options.Series.Add(new LineSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "PeakMain"),
                Color = _settings.Colors["SeriesMain"].ToRgbaString(),
                Marker = new LineSeriesMarker()
                {
                    Enabled = false
                },
                DashStyle = LineSeriesDashStyle.ShortDash
            });


        }
    }

}