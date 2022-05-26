using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using ChartGenerator.Extensions;
using ChartGeneratorModels.ChartData;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using Highsoft.Web.Mvc.Charts;


namespace ChartGenerator.Charts
{
    public class CumCashflowChart : Chart
    {
        private new readonly CumCashflowChartData _data;
        private new readonly CumCashflowChartSettings _settings;
        
        public CumCashflowChart(ChartData data, ChartSettings settings)
            : base()
        {
            ChartName = ChartEnum.CumCashflow.ToStr();
            _data = data is CumCashflowChartData chartData ?  chartData
                : throw new Exception($"Can not get chart data {ChartName}");
            _settings = settings is CumCashflowChartSettings chartSettings ? chartSettings
                : throw new Exception($"Can not get chart settings {ChartName}");
            
        }

        public override void Generate()
        {
            var options = CreateHighchartsOptions();

            options.Chart.Type = ChartType.Waterfall;
            options.Chart.WidthNumber = 700;

            var profitStartYearMarkX = _data.Items.Count - 1;
            if (_data.PaybackPeriod[0] != -1) //if pay off
            {
                profitStartYearMarkX = _data.PaybackPeriod[0] + 1;
                if (profitStartYearMarkX > _data.Items.Count - 1)
                {
                    profitStartYearMarkX = _data.Items.Count - 1;
                }
            }
            
            var earnings = _data.Items.Sum(x => x.Value);
            
            options.XAxis = new List<XAxis>()
            {
                new XAxis()
                {
                    Type = "category",
                    PlotLines = new List<XAxisPlotLines>()
                    {
                        //earnings vertical line
                        new XAxisPlotLines()
                        {
                            Color = Color.FromArgb(203, 224, 235).ToRgbaString(),
                            Width = 2,
                            Value = profitStartYearMarkX,
                            ZIndex = 1
                        }
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
                        Format = "€ {value:,.0f}"
                    },
                    PlotLines = new List<YAxisPlotLines>()
                    {
                        //zero line
                        new YAxisPlotLines()
                        {
                            Color = _settings.Colors["ZeroLine"].ToRgbaString(),
                            Width = 1,
                            Value = 0,
                            ZIndex = 2
                        },
                        //earnings
                        new YAxisPlotLines()
                        {
                            Color = _settings.Colors["Earnings"].ToRgbaString(),
                            Width = 1,
                            Value = earnings,
                            ZIndex = 2
                        }
                    },
                    GridLineWidth = 0
                }
            };

            
            var paybackPeriodWords = _data.PaybackPeriod[0] != -1 ?
                GetPaybackPeriodWord(_data.PaybackPeriod, _settings)
                : new List<string>(){"",""};
            options.Annotations = new List<Annotations>()
            {
                //earnings
                new Annotations()
                {
                    Labels = new List<AnnotationsLabels>()
                    {
                        new AnnotationsLabels()
                        {
                            Point = new AnnotationsLabelsPoint()
                            {
                                X = 0,
                                Y = earnings,
                                XAxisNumber = 0,
                                YAxisNumber = 0,
                            },
                            //Text = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "TotalEarnings")}: € {{y:,.0f}}",
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
                //payback period
                new Annotations()
                {
                    Labels = new List<AnnotationsLabels>()
                    {
                        new AnnotationsLabels()
                        {
                            Point = new AnnotationsLabelsPoint()
                            {
                                X = profitStartYearMarkX,
                                Y = earnings >= 0 ? 0 : earnings,
                                XAxisNumber = 0,
                                YAxisNumber = 0
                            },
                            //Text = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "PaybackPeriod")}<br>{paybackPeriodWords[0]} {paybackPeriodWords[1]}",
                            Shape = "rect",
                            BackgroundColor = Color.FromArgb(128,0,0,0).ToRgbaString(),
                            BorderColor = Color.FromArgb(0,0,0,0).ToRgbaString(),
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

            options.Legend = new Legend()
            {
                Enabled = false
            };

            options.Series = new List<Series>()
            {
                new WaterfallSeries()
                {
                    UpColor = _settings.Colors["UpColor"].ToRgbaString(),
                    Color = _settings.Colors["DownColor"].ToRgbaString(),
                    Data = _data.Items.Select(x => new WaterfallSeriesData()
                    {
                        Name = x.Year.ToString(),
                        Y = x.Value
                    }).ToList(),
                    DataLabels = new WaterfallSeriesDataLabels()
                    {
                        Enabled = true,
                        Format = "{point.y:,.0f}",
                        Style = new PropertyCollection()
                        {
                            {"color", "black"},
                            {"fontSize", "10"},
                            {"textOutline", "0px"}
                        },
                        Inside = false,
                        Align = WaterfallSeriesDataLabelsAlign.Center
                    },
                    PointPadding = 0,
                    DashStyle = WaterfallSeriesDashStyle.Null,
                    BorderWidth = 0.1,
                    BorderColor = Color.Black.ToRgbaString(),
                    LineWidth = 0
                }
            };
            
            
        }
    }
}