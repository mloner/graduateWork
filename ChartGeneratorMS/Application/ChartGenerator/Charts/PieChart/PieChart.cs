using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using ChartGenerator.Extensions;
using ChartGeneratorModels.ChartData;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using Highsoft.Web.Mvc.Charts;


namespace ChartGenerator.Charts.PieChart
{
    public class PieChart : Chart
    {
        private readonly PieChartData _data;
        private new PieChartSettings _settings
        {
            get => base._settings as PieChartSettings;
            set => base._settings = value;
        }

        public PieChart(ChartData data, ChartSettings settings)
        {
            ChartName = ChartEnum.PieChart.ToStr();
            _data = data is PieChartData chartData
                ? chartData
                : throw new Exception($"Can not get chart data {ChartName}");
            _settings = settings is PieChartSettings chartSettings
                ? chartSettings
                : throw new Exception($"Can not get chart settings {ChartName}");
            ResourceManagers.Add(Resource.ResourceManager);
        }
        
        public override void Generate()
        {
            var options = CreateHighchartsOptions();

            options.Chart.Type = ChartType.Pie;
            options.Chart.Margin = new[] { 20, 0.0, 0.0, 0.0 };

            options.PlotOptions = new PlotOptions()
            {
                Series = new PlotOptionsSeries()
                {
                    DataLabels = new PlotOptionsSeriesDataLabels()
                    {
                        Style = new Hashtable()
                        {
                            {"fontSize", 30},
                            {"textOutline", "0px"},
                        }
                    }
                }
            };

            options.Legend = new Highsoft.Web.Mvc.Charts.Legend()
            {
                Enabled = true,
                Layout = Highsoft.Web.Mvc.Charts.LegendLayout.Vertical,
                Align = Highsoft.Web.Mvc.Charts.LegendAlign.Right,
                VerticalAlign = Highsoft.Web.Mvc.Charts.LegendVerticalAlign.Top,
                Floating = true,
                BorderWidth = 1,
                BorderRadius = 4,
                BorderColor = Color.FromArgb(197, 197, 197).ToRgbaString(),
                BackgroundColor = "rgba(255,255,255,0.6)",
                ItemStyle = new Hashtable()
                {
                    {"fontSize", "20px"}
                }
            };
            
            //series
            // var seriesData = _data.Values.Select(x => new PieSeriesData()
            // {
            //     //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, x.Key),
            //     Y = x.Value
            // }).ToList();
            var seriesData = new List<PieSeriesData>();
            seriesData.Add(new PieSeriesData()
            {
                Name = GetTranslationString("SelfConsumption"),
                Y = _data.Values["SelfCons"]
            });
            seriesData.Add(new PieSeriesData()
            {
                Name = GetTranslationString("Production"),
                Y = _data.Values["Prod"]
            });
            
            
            
            
            options.Series.Add(new PieSeries()
            {
                Size = "100%",
                DataLabels = new PieSeriesDataLabels()
                {
                    CustomFields = new Hashtable()
                    {
                        {"enabled", "true"},
                        {"format", "{point.percentage:,.0f}%"},
                        {"distance", "-50"},
                        {"textOverflow", "clip"},
                        {"overflowWrap", "break-word"},
                        {"wordWrap", "break-word"},
                        {"crop", "false"},
                    },
                },
                CustomFields = new Hashtable()
                {
                    {"padding", "0"},
                },
                Data = seriesData,
                ShowInLegend = true
            });
            
        }
    }
}