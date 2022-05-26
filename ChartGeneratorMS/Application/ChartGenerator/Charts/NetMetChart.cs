using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using ChartGenerator.Extensions;
using ChartGeneratorModels.ChartData;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using Highsoft.Web.Mvc.Charts;


namespace ChartGenerator.Charts
{
    public class NetMetChart : Chart
    {
        private new readonly NetMetChartData _data;
        private new readonly NetMetChartSettings _settings;
        
        public NetMetChart(ChartData data, ChartSettings settings)
            : base()
        {
            ChartName = ChartEnum.NetMet.ToStr();
            _data = data is NetMetChartData chartData ?  chartData
                : throw new Exception($"Can not get chart data {ChartName}");
            _settings = settings is NetMetChartSettings chartSettings ? chartSettings
                : throw new Exception($"Can not get chart settings {ChartName}");
        }

        public override void Generate()
        {
            var options = CreateHighchartsOptions();

            //cumulative sum
            var cumulativeSum = new List<double>();
            for (var i = 0; i < _data.Netted.Count; i++)
            {
                cumulativeSum.Add((cumulativeSum.Count > 0 ? cumulativeSum.Last() : 0) +
                                  _data.Netted[i] + _data.Injected[i] + _data.SelfConsumed[i]);
            }
            
            
            options.Chart.Type = ChartType.Column;
            options.Chart.WidthNumber = 600;

            options.XAxis = new List<XAxis>()
            {
                new XAxis()
                {
                    Categories = _data.Categories.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToList(),
                    
                }
            };

            options.YAxis = new List<YAxis>()
            {
                //netted, injected, selfconsumed
                new YAxis()
                {
                    Title = new YAxisTitle()
                    {
                        Text = ""
                    },
                    Labels = new YAxisLabels()
                    {
                        Format = "€ {value:,.0f}"
                    },
                    Max = _settings.YMaxes[0]
                },
                //production revenue
                new YAxis()
                {
                    Title = new YAxisTitle()
                    {
                        Text = ""
                    },
                    Labels = new YAxisLabels()
                    {
                        Format = "€ {value:,.0f}"
                    },
                    Opposite = true,
                    Max = _settings.YMaxes[1],
                    GridLineWidth = 0
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
                                X = _data.Categories.Count - 1,
                                Y = cumulativeSum.Last(),
                                XAxisNumber = 0,
                                YAxisNumber = 1
                            },
                            //Text = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "ProductionRevenue")} € {{y:,.0f}}",
                            Shape = "rect",
                            BackgroundColor = Color.FromArgb(128,0,0,0).ToRgbaString(),
                            BorderColor = Color.FromArgb(0,0,0,0).ToRgbaString()
                        }
                    },
                    LabelOptions = new AnnotationsLabelOptions()
                    {
                        X = 0,
                        Y = 0
                    }
                }
            };
            //annotations for netmet percent
            var netMetPercList = new List<int>
            {
                100,
                91,
                82,
                73,
                64,
                55,
                46,
                37,
                28
            };
            var columnSum = new List<double>();
            for (var i = 0; i < _data.Netted.Count; i++)
            {
                columnSum.Add(_data.Netted[i] + _data.Injected[i] + _data.SelfConsumed[i]);
            }
            for (var i = 0; i < netMetPercList.Count; i++) {
                options.Annotations.Add(new Annotations()
                {
                    Labels = new List<AnnotationsLabels>()
                    {
                        new AnnotationsLabels()
                        {
                            Point = new AnnotationsLabelsPoint()
                            {
                                X = i,
                                Y = columnSum[i],
                                XAxisNumber = 0,
                                YAxisNumber = 0
                            },
                            Text = $"{netMetPercList[i]}%",
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
                });
            }

            options.PlotOptions = new PlotOptions()
            {
                Column = new PlotOptionsColumn()
                {
                    Stacking = PlotOptionsColumnStacking.Normal
                }
            };

            options.Series = new List<Series>();
            
            //netted
            options.Series.Add(new ColumnSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "Netted"),
                Data = _data.Netted.Select(x => new ColumnSeriesData()
                {
                    Y = x
                }).ToList(),
                YAxisNumber = 0
            });
            //injected
            options.Series.Add(new ColumnSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "Injected"),
                Data = _data.Injected.Select(x => new ColumnSeriesData()
                {
                    Y = x
                }).ToList(),
                YAxisNumber = 0
            });
            //selfConsumed
            options.Series.Add(new ColumnSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "SelfConsumed"),
                Data = _data.SelfConsumed.Select(x => new ColumnSeriesData()
                {
                    Y = x
                }).ToList(),
                YAxisNumber = 0
            });
            //cumulative sum series
            options.Series.Add(new LineSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "CumulativeSum"),
                Data = cumulativeSum.Select(x => new LineSeriesData()
                {
                    Y = x
                }).ToList(),
                YAxisNumber = 1,
                Marker = new LineSeriesMarker()
                {
                    Enabled = false
                }
            });
            
            
        }
    }
}