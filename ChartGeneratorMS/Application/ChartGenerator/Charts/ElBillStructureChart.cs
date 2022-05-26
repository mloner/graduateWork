using System;
using System.Collections;
using System.Linq;
using ChartGenerator.Extensions;
using ChartGeneratorModels.ChartData;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using Highsoft.Web.Mvc.Charts;


namespace ChartGenerator.Charts
{
    public class ElBillStructureChart : Chart
    {
        private new readonly ElBillStructureChartData _data;
        private new readonly ElBillStructureChartSettings _settings;
        
        public ElBillStructureChart(ChartData data, ChartSettings settings)
            : base()
        {
            ChartName = ChartEnum.ElBillStructure.ToStr();
            _data = data is ElBillStructureChartData chartData ?  chartData
                : throw new Exception($"Can not get chart data {ChartName}");
            _settings = settings is ElBillStructureChartSettings chartSettings ? chartSettings
                : throw new Exception($"Can not get chart settings {ChartName}");
        }

        public override void Generate()
        {
            var options = CreateHighchartsOptions();

            options.Chart.Type = ChartType.Pie;

            options.Legend = new Legend()
            {
                Enabled = false
            };

            options.PlotOptions = new PlotOptions()
            {
                Series = new PlotOptionsSeries()
                {
                    DataLabels = new PlotOptionsSeriesDataLabels()
                    {
                        Style = new Hashtable()
                        {
                            {"fontSize", 14},
                            {"width", 90},
                            {"textOutline", "0px"},
                        },
                        
                    }
                }
            };
            
            //series
            var seriesData = _data.Values.Select(x => new PieSeriesData()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, x.Key),
                Y = x.Value
            }).ToList();
            
            options.Series.Add(new PieSeries()
            {
                Size = "70%",
                InnerSize = "50%",
                DataLabels = new PieSeriesDataLabels()
                {
                    CustomFields = new Hashtable()
                    {
                        {"enabled", "true"},
                        {"format", "{point.name}"},
                        {"distance", "10"},
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
                Data = seriesData
            });
            
            options.Series.Add(new PieSeries()
            {
                Size = "70%",
                InnerSize = "50%",
                DataLabels = new PieSeriesDataLabels()
                {
                    CustomFields = new Hashtable()
                    {
                        {"enabled", "true"},
                        {"format", "{point.percentage:,.1f}%"},
                        {"distance", "-30"},
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
                Data = seriesData
            });
            
            
            
        }
    }
}