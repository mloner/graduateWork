using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ChartGenerator.Extensions;
using ChartGeneratorModels.ChartData;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using Highsoft.Web.Mvc.Charts;

namespace ChartGenerator.Charts
{
    public class BatterySubsidyChart : Chart
    {
        private new readonly BatterySubsidyChartData _data;
        private new readonly BatterySubsidyChartSettings _settings;
        
        public BatterySubsidyChart(ChartData data, ChartSettings settings)
            : base()
        {
            ChartName = ChartEnum.BatterySubsidy.ToStr();
            _data = data is BatterySubsidyChartData chartData ?  chartData
                : throw new Exception($"Can not get chart data {ChartName}");
            _settings = settings is BatterySubsidyChartSettings chartSettings ? chartSettings
                : throw new Exception($"Can not get chart settings {ChartName}");
            
        }

        public override void Generate()
        {
            var options = CreateHighchartsOptions();

            options.Chart.Type = ChartType.Column;

            options.XAxis = new List<XAxis>()
            {
                new XAxis()
                {
                    Title = new XAxisTitle()
                    {
                        Text = ""
                    },
                    Categories = _data.Categories,
                    GridLineWidth = 0
                },
            };

            options.YAxis = new List<YAxis>()
            {
                new YAxis()
                {
                    Title = new YAxisTitle()
                    {
                        //Text = _settings.GetTranslationString(ChartSettings.TranslScope.Chart,
                            //"BatteryPriceWithSubsidy"),
                    },
                    GridLineWidth = 0,
                    Labels = new YAxisLabels()
                    {
                        Format = "€ {value:,.0f}"
                    },
                    PlotLines = new List<YAxisPlotLines>()
                    {
                        new YAxisPlotLines()
                        {
                            Color = Color.Gray.ToRgbaString(),
                            Width = 1,
                            Value = _data.BatteryPrice
                        }
                    }
                }
            };

            options.PlotOptions = new PlotOptions()
            {
                Column = new PlotOptionsColumn()
                {
                    DataLabels = new PlotOptionsColumnDataLabels()
                    {
                        Style = new Hashtable()
                        {
                            {"color", Color.Black.ToRgbaString()},
                            {"fontSize", 10},
                            {"textOutline", "0px"},
                        }
                    },
                    PointWidth = 70
                }
            };

            options.Legend = new Legend()
            {
                Enabled = false,
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
                                X = 0,
                                Y = _data.BatteryPrice,
                                XAxisNumber = 0,
                                YAxisNumber = 0
                            },
                            //Text = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "BatteryPrice")} " +
                                   //$"€ {{y:,.0f}}",
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
                }
            };

            options.Series = new List<Series>();
            
            options.Series.Add(new ColumnSeries()
            {
                Name = "",
                Data = _data.Values.Select(x => new ColumnSeriesData()
                {
                    Y = x
                }).ToList(),
                ShowInLegend = false,
                DataLabels = new ColumnSeriesDataLabels()
                {
                    Enabled = true,
                    Format = "€ {point.y:,.0f}"
                }
            });
            
            
            
        }
    }
}