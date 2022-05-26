using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ChartGenerator.Extensions;
using ChartGeneratorModels.ChartData;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using Highsoft.Web.Mvc.Charts;
using ChartType = Highsoft.Web.Mvc.Charts.ChartType;
using Legend = Highsoft.Web.Mvc.Charts.Legend;
using LegendAlign = Highsoft.Web.Mvc.Charts.LegendAlign;
using LegendLayout = Highsoft.Web.Mvc.Charts.LegendLayout;
using LegendVerticalAlign = Highsoft.Web.Mvc.Charts.LegendVerticalAlign;
using PlotOptions = Highsoft.Web.Mvc.Charts.PlotOptions;
using PlotOptionsSeries = Highsoft.Web.Mvc.Charts.PlotOptionsSeries;
using PlotOptionsSeriesMarker = Highsoft.Web.Mvc.Charts.PlotOptionsSeriesMarker;
using Series = Highsoft.Web.Mvc.Charts.Series;
using XAxis = Highsoft.Web.Mvc.Charts.XAxis;
using XAxisLabels = Highsoft.Web.Mvc.Charts.XAxisLabels;
using XAxisLabelsAlign = Highsoft.Web.Mvc.Charts.XAxisLabelsAlign;
using YAxis = Highsoft.Web.Mvc.Charts.YAxis;
using YAxisLabels = Highsoft.Web.Mvc.Charts.YAxisLabels;
using YAxisTitle = Highsoft.Web.Mvc.Charts.YAxisTitle;

namespace ChartGenerator.Charts
{
    public class AverageHourlyDamChart : Chart
    {
        private new readonly AverageHourlyDamChartData _data;
        private new readonly AverageHourlyDamChartSettings _settings;
        
        public AverageHourlyDamChart(ChartData data, ChartSettings settings)
            : base()
        {
            ChartName = ChartEnum.AverageHourlyDam.ToStr();
            _data = data is AverageHourlyDamChartData chartData ?  chartData
                : throw new Exception($"Can not get chart data {ChartName}");
            _settings = settings is AverageHourlyDamChartSettings chartSettings ? chartSettings
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
                        ////Text = _settings.GetTranslationString(ChartSettings.TranslScope.Global, "Hours"),
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
                        Format = "{value} €/kWh"
                    },
                    Max = _settings.YMaxes[0]
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
                    Step = PlotOptionsSeriesStep.Left
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
            
            //alldays
            options.Series.Add(new LineSeries()
            {
                ////Name = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "AllDays")}",
                Data = _data.AllDays.Select(x => new LineSeriesData()
                {
                    X = (long)(new DateTime(_settings.DefaultStartDate.Year, _settings.DefaultStartDate.Month,
                        _settings.DefaultStartDate.Day, x.Key, 0, 0) - _settings.DefaultStartDate).TotalMilliseconds,
                    Y = x.Value
                }).ToList(),
                Color = _settings.Colors["AllDays"].ToRgbaString(),
            });
            
            //working days
            options.Series.Add(new LineSeries()
            {
               // //Name = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "WorkingDays")}",
                Data = _data.WorkingDays.Select(x => new LineSeriesData()
                {
                    X = (long)(new DateTime(_settings.DefaultStartDate.Year, _settings.DefaultStartDate.Month,
                        _settings.DefaultStartDate.Day, x.Key, 0, 0) - _settings.DefaultStartDate).TotalMilliseconds,
                    Y = x.Value
                }).ToList(),
                Color = _settings.Colors["WorkingDays"].ToRgbaString()
            });
            
            //weekends
            options.Series.Add(new LineSeries()
            {
               // //Name = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "Weekends")}",
                Data = _data.Weekends.Select(x => new LineSeriesData()
                {
                    X = (long)(new DateTime(_settings.DefaultStartDate.Year, _settings.DefaultStartDate.Month,
                        _settings.DefaultStartDate.Day, x.Key, 0, 0) - _settings.DefaultStartDate).TotalMilliseconds,
                    Y = x.Value
                }).ToList(),
                Color = _settings.Colors["Weekends"].ToRgbaString()
            });
            
        }
    }
}