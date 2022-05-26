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


namespace ChartGenerator.Charts
{
    public class SensitivityMatrixChart : Chart
    {
        private new readonly SensitivityMatrixChartData _data;
        private new readonly SensitivityMatrixChartSettings _settings;

        public SensitivityMatrixChart(ChartData data, ChartSettings settings) : base()
        {
            ChartName = ChartEnum.SensitivityMatrix.ToStr();
            _data = data is SensitivityMatrixChartData chartData ?  chartData
                : throw new Exception($"Can not get chart data {ChartName}");
            _settings = settings is SensitivityMatrixChartSettings chartSettings ? chartSettings
                : throw new Exception($"Can not get chart settings {ChartName}");
        }
        
        public override void Generate()
        {
            var options = CreateHighchartsOptions();
            
            options.Chart.Type = ChartType.Heatmap;
            options.Chart.WidthNumber = 300;
            options.Chart.HeightNumber = 260;
            
            options.Legend = new Legend()
            {
                Enabled = _settings.ShowLegend,
            };
            options.XAxis = new List<XAxis>()
            {
                new XAxis()
                {
                    Categories = _data.XAxis.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToList(),
                    Title = new XAxisTitle()
                    {
                        //Text = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "XAxis")
                    },
                    Labels = new XAxisLabels()
                    {
                        Format = "{value:,.0f}%"
                    },
                    Opposite = true
                }
            };
            var yAxis = _data.YAxis.Select(x => x).ToList().Select(x => x+1).Select(x => x-1);
            options.YAxis = new List<YAxis>()
            {
                new YAxis()
                {
                    Categories = yAxis.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToList(),
                    Title = new YAxisTitle()
                    {
                        //Text = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "YAxis")
                    },
                    Reversed = true,
                    Labels = new YAxisLabels()
                    {
                        Format = "{value:,.0f}%"
                    }
                }
            };
            options.ColorAxis = new ColorAxis()
            {
                Labels = new ColorAxisLabels()
                {
                    Format = "{value:,.0f}"
                },
                Max = _data.Values.Select(xx => xx.Max()).Max(),
                Min = _data.Values.Select(xx => xx.Min()).Min(),
                Stops = new List<Stop>()
                {
                    new Stop()
                    {
                        Position = 0.1,
                        Color = Color.FromArgb(252, 206, 6).ToRgbaString()
                    },
                    new Stop()
                    {
                        Position = 0.9,
                        Color = Color.FromArgb(43, 201, 37).ToRgbaString()
                    },
                }
            };
            
            var dataSeries = new List<HeatmapSeriesData>();
            //generate data triplets
            int x = 0;
            int y = 0;
            foreach (var row in _data.Values.AsEnumerable())
            {
                x = 0;
                foreach (var cell in row.AsEnumerable())
                {
                    var value = Math.Round(cell);
                    dataSeries.Add(new HeatmapSeriesData()
                    {
                        X = x++,
                        Y = y,
                        Value = value
                    });
                }
                y++;
            }
            options.Series = new List<Series>();
            options.Series.Add(new HeatmapSeries()
            {
                DataLabels = new HeatmapSeriesDataLabels()
                {
                    Enabled = true,
                    Inside = true,
                    Style = new Hashtable()
                    {
                        {"textOutline", "0px"}
                    },
                    Format = "{point.value:,.0f}"
                },
                BorderWidth = 0.2,
                Data = dataSeries
            });
            
        }
    }
}