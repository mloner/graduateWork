using System;
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
    public class PerfExplWeek : Chart
    {
        private new readonly PerfExplWeekChartData _data;
        private new readonly PerfExplWeekChartSettings _settings;
        
        public PerfExplWeek(ChartData data, ChartSettings settings)
            : base()
        {
            ChartName = ChartEnum.PerfExplWeek.ToStr();
            _data = data is PerfExplWeekChartData chartData ?  chartData
                : throw new Exception($"Can not get chart data {ChartName}");
            _settings = settings is PerfExplWeekChartSettings chartSettings ? chartSettings
                : throw new Exception($"Can not get chart settings {ChartName}");
        }

        public override void Generate()
        {
            var options = CreateHighchartsOptions();

            options.Chart.WidthNumber = 1000;
            
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
            
            options.XAxis = new List<XAxis>()
            {
                new XAxis()
                {
                    Type = "datetime",
                    Title = new XAxisTitle()
                    {
                        Text = ""
                    },
                    Labels = new XAxisLabels()
                    {
                        Format = "{value:%d-%m-%Y}",
                        Step = 2
                    },
                    // ShowLastLabel = false,
                    // StartOnTick = true,
                    //TickInterval = 24 * 4, 
                    TickLength = 10,
                    TickWidth = 3,
                    GridLineWidth = 0
                },
            };
            
            options.YAxis = new List<YAxis>()
            {
                //main
                new YAxis()
                {
                    Title = new YAxisTitle()
                    {
                        Text = ""
                    },
                    GridLineWidth = 0,
                    Labels = new YAxisLabels()
                    {
                        Format = "{value:,.0f} kWh"
                    },
                    Min = 0,
                    Max = _settings.YMaxes[0]
                },
                //dam
                new YAxis()
                {
                    Title = new YAxisTitle()
                    {
                        Text = ""
                    },
                    GridLineWidth = 0,
                    Labels = new YAxisLabels()
                    {
                        Format = "{value:,.2f} €/kWh"
                    },
                    Min = 0,
                    Max = _settings.YMaxes[1],
                    Opposite = true
                },
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
            
            options.Series = new List<Series>();
            
            //Demand
            options.Series.Add(new LineSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "Demand"),
                Data = _data.Demand.Select(x => new LineSeriesData()
                {
                    X = (long)(x.Key - _settings.DefaultStartDate).TotalMilliseconds,
                    Y = x.Value
                }).ToList(),
                Color = _settings.Colors["Demand"].ToRgbaString(),
            });
            
            //Pv
            options.Series.Add(new LineSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "Pv"),
                Data = _data.Pv.Select(x => new LineSeriesData()
                {
                    X = (long)(x.Key - _settings.DefaultStartDate).TotalMilliseconds,
                    Y = x.Value
                }).ToList(),
                Color = _settings.Colors["Pv"].ToRgbaString(),
            });
            
            //Battery
            options.Series.Add(new LineSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "Battery"),
                Data = _data.Battery.Select(x => new LineSeriesData()
                {
                    X = (long)(x.Key - _settings.DefaultStartDate).TotalMilliseconds,
                    Y = x.Value
                }).ToList(),
                Color = _settings.Colors["Battery"].ToRgbaString(),
            });
            
            //Dam
            options.Series.Add(new LineSeries()
            {
                //Name = _settings.GetTranslationString(ChartSettings.TranslScope.Chart, "Dam"),
                Data = _data.Dam.Select(x => new LineSeriesData()
                {
                    X = (long)(x.Key - _settings.DefaultStartDate).TotalMilliseconds,
                    Y = x.Value
                }).ToList(),
                Color = _settings.Colors["Dam"].ToRgbaString(),
                YAxisNumber = 1
            });
            
        }
    }
}