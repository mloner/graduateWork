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
    public class PeakShavAvgDayChart : Chart
    {
        public new PeakShavAvgDayChartData _data { get; set; }
        public new PeakShavAvgDayChartSettings _settings { get; set; }
        
        public PeakShavAvgDayChart(ChartData data, ChartSettings settings)
            : base()
        {
            ChartName = ChartEnum.PeakShavAvgDay.ToStr();
            _data = data is PeakShavAvgDayChartData chartData ?  chartData
                : throw new Exception($"Can not get chart data {ChartName}");
            _settings = settings is PeakShavAvgDayChartSettings chartSettings ? chartSettings
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
                        //best peak
                        new YAxisPlotLines()
                        {
                            Color = Color.FromArgb(0, 31, 78).ToRgbaString(),
                            Width = 2,
                            Value = _data.PeakBest,
                            DashStyle = YAxisPlotLinesDashStyle.LongDash,
                            ZIndex = 4
                        },
                        //tariff peak
                        new YAxisPlotLines()
                        {
                            Color = Color.FromArgb(245, 159, 167).ToRgbaString(),
                            Width = 2,
                            Value = _data.PeakTariff,
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
                            //Text = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "RefPeak")} {{y:,.1f}} kW",
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
                                    _settings.DefaultStartDate.Day, _data.ValuesBest.Skip((int)(_data.ValuesBest.Count * (2.0/3)))
                                        .First().Key, 0, 0) - _settings.DefaultStartDate).TotalMilliseconds,
                                Y = _data.PeakBest,
                                XAxisNumber = 0,
                                YAxisNumber = 0
                            },
                            //Text = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "BestPeak")} " +
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
                //tariff peak
                new Annotations()
                {
                    Labels = new List<AnnotationsLabels>()
                    {
                        new AnnotationsLabels()
                        {
                            Point = new AnnotationsLabelsPoint()
                            {
                                X = (long)(new DateTime(_settings.DefaultStartDate.Year, _settings.DefaultStartDate.Month,
                                    _settings.DefaultStartDate.Day, _data.ValuesRef.Skip(0)
                                        .First().Key, 0, 0) - _settings.DefaultStartDate).TotalMilliseconds,
                                Y = _data.PeakTariff,
                                XAxisNumber = 0,
                                YAxisNumber = 0
                            },
                            //Text = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "TariffPeak")} {{y:,.1f}} kW",
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
            
            //best
            options.Series.Add(new LineSeries()
            {
                //Name = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "SeriesBest")}",
                Data = _data.ValuesBest.Select(x => new LineSeriesData()
                {
                    X = (long)(new DateTime(_settings.DefaultStartDate.Year, _settings.DefaultStartDate.Month,
                        _settings.DefaultStartDate.Day, x.Key, 0, 0) - _settings.DefaultStartDate).TotalMilliseconds,
                    Y = x.Value
                }).ToList(),
                YAxisNumber = 0,
                XAxisNumber = 0,
                Color = _settings.Colors["SeriesBest"].ToRgbaString()
            });
            
            //lines
            //ref peak
            options.Series.Add(new LineSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "RefPeak"),
                Color = _settings.Colors["SeriesRef"].ToRgbaString(),
                Marker = new LineSeriesMarker()
                {
                    Enabled = false
                },
                DashStyle = LineSeriesDashStyle.ShortDash
            });
            
            //best peak
            options.Series.Add(new LineSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "BestPeak"),
                Color = _settings.Colors["SeriesBest"].ToRgbaString(),
                Marker = new LineSeriesMarker()
                {
                    Enabled = false
                },
                DashStyle = LineSeriesDashStyle.ShortDash
            });
            
            //tariff peak
            options.Series.Add(new LineSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "TariffPeak"),
                Color = _settings.Colors["SeriesTariff"].ToRgbaString(),
                Marker = new LineSeriesMarker()
                {
                    Enabled = false
                },
                DashStyle = LineSeriesDashStyle.ShortDash
            });
            

        }
    }

}