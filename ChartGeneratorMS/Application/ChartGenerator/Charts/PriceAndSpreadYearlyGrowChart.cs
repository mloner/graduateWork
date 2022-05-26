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
    public class PriceAndSpreadYearlyGrowChart : Chart
    {
        private new readonly PriceAndSpreadYearlyGrowChartData _data;
        private new readonly PriceAndSpreadYearlyGrowChartSettings _settings;
        
        public PriceAndSpreadYearlyGrowChart(ChartData data, ChartSettings settings)
            : base()
        {
            ChartName = ChartEnum.PriceAndSpreadYearlyGrow.ToStr();
            _data = data is PriceAndSpreadYearlyGrowChartData chartData ?  chartData
                : throw new Exception($"Can not get chart data {ChartName}");
            _settings = settings is PriceAndSpreadYearlyGrowChartSettings chartSettings ? chartSettings
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
                    Categories = _data.Years.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToList(),
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
                        Format = "{value} €/kWh"
                    },
                    Max = _settings.YMaxes[0],
                    GridLineWidth = 0
                }
            };

            options.PlotOptions = new PlotOptions()
            {
                Series = new PlotOptionsSeries()
                {
                    Marker = new PlotOptionsSeriesMarker()
                    {
                        Enabled = false
                    },
                }
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
            
            //all days
            options.Series.Add(new LineSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "AllDays"),
                Data = _data.AllDays.Select(x => new LineSeriesData()
                {
                    Y = x
                }).ToList(),
                Color = _settings.Colors["AllDays"].ToRgbaString(),
            });
            
            //working days
            options.Series.Add(new LineSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "WorkingDays"),
                Data = _data.WorkingDays.Select(x => new LineSeriesData()
                {
                    Y = x
                }).ToList(),
                Color = _settings.Colors["WorkingDays"].ToRgbaString(),
            });
            
            //weekends
            options.Series.Add(new LineSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "Weekends"),
                Data = _data.Weekends.Select(x => new LineSeriesData()
                {
                    Y = x
                }).ToList(),
                Color = _settings.Colors["Weekends"].ToRgbaString(),
            });
            
            //all days spread
            options.Series.Add(new LineSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "AllDaysSpread"),
                Data = _data.AllDaysSpread.Select(x => new LineSeriesData()
                {
                    Y = x
                }).ToList(),
               // Color = _settings.Colors["AllDays"].ToRgbaString(),
            });
            
            //working days spread
            options.Series.Add(new LineSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "WorkingDaysSpread"),
                Data = _data.WorkingDaysSpread.Select(x => new LineSeriesData()
                {
                    Y = x
                }).ToList(),
                //Color = _settings.Colors["WorkingDays"].ToRgbaString(),
            });
            
            //weekends spread
            options.Series.Add(new LineSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "WeekendsSpread"),
                Data = _data.WeekendsSpread.Select(x => new LineSeriesData()
                {
                    Y = x
                }).ToList(),
                //Color = _settings.Colors["Weekends"].ToRgbaString(),
            });
            
            
        }
    }
}