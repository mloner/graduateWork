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
    public class PeakShavMonthlyChart : Chart
    {
        public new PeakShavMonthlyChartData _data { get; set; }
        public new PeakShavMonthlyChartSettings _settings { get; set; }
        public PeakShavMonthlyChart(ChartData data, ChartSettings settings)
            : base()
        {
            ChartName = ChartEnum.PeakShavMonthly.ToStr();
            _data = data is PeakShavMonthlyChartData chartData ?  chartData
                : throw new Exception($"Can not get chart data {ChartName}");
            _settings = settings is PeakShavMonthlyChartSettings chartSettings ? chartSettings
                : throw new Exception($"Can not get chart settings {ChartName}");
        }

        public override void Generate()
        {
            var options = CreateHighchartsOptions();

            #region Years xAxis

            var yearsCat = _data.Categories.Select(x => x.Year.ToString()).ToList();

            int j = 0;
            for (int i = 0; i < yearsCat.Count; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                if (yearsCat[i] == yearsCat[j])
                {
                    yearsCat[i] = "";
                }
                else
                {
                    j = i;
                }
            }

            #endregion
            
            options.XAxis = new List<XAxis>()
            {
                new XAxis()
                {
                    // Categories = _data.Categories.Select(x =>
                    //     _settings.GetTranslationString(
                    //         ChartSettings.TranslScope.Global, $"{x.ToString("MMMM")}_short")).ToList(),
                    GridLineWidth = 0
                },
                //years
                new XAxis()
                {
                    Categories = yearsCat,
                    Labels = new XAxisLabels()
                    {
                        Format = ""
                    },
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
                        Format = "{value:,.0f} kW"
                    },
                    GridLineWidth = 0,
                    PlotLines = new List<YAxisPlotLines>()
                    {
                        //ref peak
                        new YAxisPlotLines()
                        {
                            Color = _settings.Colors["SeriesRef"].ToRgbaString(),
                            Width = 2,
                            Value = _data.PeakRef,
                            DashStyle = YAxisPlotLinesDashStyle.LongDash,
                            ZIndex = 4
                        },
                        //best peak
                        new YAxisPlotLines()
                        {
                            Color = _settings.Colors["SeriesBest"].ToRgbaString(),
                            Width = 2,
                            Value = _data.PeakBest,
                            DashStyle = YAxisPlotLinesDashStyle.LongDash,
                            ZIndex = 4
                        },
                        //tariff peak
                        new YAxisPlotLines()
                        {
                            Color = _settings.Colors["SeriesTariff"].ToRgbaString(),
                            Width = 2,
                            Value = _data.PeakTariff,
                            DashStyle = YAxisPlotLinesDashStyle.LongDash,
                            ZIndex = 4
                        },
                    },
                    Max = _settings.YMaxes[0]
                }
            };

            options.PlotOptions = new PlotOptions()
            {
                Series = new PlotOptionsSeries()
                {
                    DataLabels = new PlotOptionsSeriesDataLabels()
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
                                X = _data.Categories.Count * (1.0/3),
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
                                X = _data.Categories.Count * (2.0/3),
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
                                X = 1,
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
                BackgroundColor = Color.FromArgb(200, 255, 255, 255).ToRgbaString(),
            };

            options.Series = new List<Series>();

            //ref
            options.Series.Add(new ColumnSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "SeriesRef"),
                Data = _data.ValuesRef.Select(x => new ColumnSeriesData()
                {
                    Y = x
                }).ToList(),
                Color = _settings.Colors["SeriesRef"].ToRgbaString(),
            });
            
            //best
            options.Series.Add(new ColumnSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "SeriesBest"),
                Data = _data.ValuesBest.Select(x => new ColumnSeriesData()
                {
                    Y = x
                }).ToList(),
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
            
            //dummy series for years xAxis
            options.Series.Add(new LineSeries()
            {
                Name = " ",
                Data = Enumerable.Repeat(0.0, _data.Categories.Count).Select(x => new LineSeriesData()
                {
                    Y = x
                }).ToList(),
                XAxisNumber = 1,
                ShowInLegend = false,
                LineWidth = 0,
                Marker = new LineSeriesMarker()
                {
                    Enabled = false
                }
            });

        }
    }
}