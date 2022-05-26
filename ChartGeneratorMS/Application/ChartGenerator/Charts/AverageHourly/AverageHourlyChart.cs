using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using ChartGeneratorModels.ChartData;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using ChartGenerator.Extensions;
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

namespace ChartGenerator.Charts.AverageHourly
{
    public class AverageHourlyChart : Chart
    {
        private readonly AverageHourlyChartData _data;
        private new AverageHourlyChartSettings _settings
        {
            get => base._settings as AverageHourlyChartSettings;
            set => base._settings = value;
        }

        public AverageHourlyChart(ChartData data, ChartSettings settings)
        {
            ChartName = ChartEnum.AverageHourly.ToStr();
            _data = data is AverageHourlyChartData chartData ?  chartData
                : throw new Exception($"Can not get chart data {ChartName}");
            _settings = settings is AverageHourlyChartSettings chartSettings ? chartSettings
                : throw new Exception($"Can not get chart settings {ChartName}");
            ResourceManagers.Add(Resource.ResourceManager);
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
                        Text = GetTranslationString("Hours"),
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
                //demand, pv
                new YAxis()
                {
                    Title = new YAxisTitle()
                    {
                        Text = ""
                    },
                    GridLineWidth = 0,
                    Labels = new YAxisLabels()
                    {
                        Format = "{value} kW"
                    },
                    Min = 0,
                    //Max = _settings.YMaxes[0]
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
                        Format = "{value} €/kWh",
                        Style = new PropertyCollection()
                        {
                            //{"color", _settings.Colors["Dam"].ToRgbaString()}
                        }
                    },
                    Opposite = true,
                    Min = 0,
                    //Max = _settings.YMaxes[1]
                },
                //battery energy
                new YAxis()
                {
                    Title = new YAxisTitle()
                    {
                        Text = ""
                    },
                    GridLineWidth = 0,
                    Labels = new YAxisLabels()
                    {
                        Format = "{value} kWh",
                        Style = new PropertyCollection()
                        {
                           // {"color", _settings.Colors["BatteryEnergy"].ToRgbaString()}
                        }
                    },
                    //Max = _settings.YMaxes[2]
                }
            };

            options.PlotOptions = new PlotOptions()
            {
                Series = new PlotOptionsSeries()
                {
                    Marker = new PlotOptionsSeriesMarker()
                    {
                        Enabled = false
                    }
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
            
            //demand
            options.Series.Add(new LineSeries()
            {
                Name = $"Demand, kW",
                Data = _data.Demand.Select(x => new LineSeriesData()
                {
                    X = (long)(new DateTime(_settings.DefaultStartDate.Year, _settings.DefaultStartDate.Month,
                        _settings.DefaultStartDate.Day, x.Key, 0, 0) - _settings.DefaultStartDate).TotalMilliseconds,
                    Y = x.Value
                }).ToList(),
                YAxisNumber = 0,
                XAxisNumber = 0,
                //Color = _settings.Colors["Demand"].ToRgbaString()
            });
            
            //pv
            options.Series.Add(new LineSeries()
            {
                Name = $"PV, kW",
                Data = _data.Pv.Select(x => new LineSeriesData()
                {
                    X = (long)(new DateTime(_settings.DefaultStartDate.Year, _settings.DefaultStartDate.Month,
                        _settings.DefaultStartDate.Day, x.Key, 0, 0) - _settings.DefaultStartDate).TotalMilliseconds,
                    Y = x.Value
                }).ToList(),
                YAxisNumber = 0,
                XAxisNumber = 0,
                //Color = _settings.Colors["Pv"].ToRgbaString()
            });
            
            //batteryEnergy
            options.Series.Add(new LineSeries()
            {
                Name = $"Battery energy, kWh",
                Data = _data.BatteryEnergy.Select(x => new LineSeriesData()
                {
                    X = (long)(new DateTime(_settings.DefaultStartDate.Year, _settings.DefaultStartDate.Month,
                        _settings.DefaultStartDate.Day, x.Key, 0, 0) - _settings.DefaultStartDate).TotalMilliseconds,
                    Y = x.Value
                }).ToList(),
                YAxisNumber = 2,
                XAxisNumber = 0,
               //Color = _settings.Colors["BatteryEnergy"].ToRgbaString()
            });
            
            //dam
            options.Series.Add(new LineSeries()
            {
                Name = $"DAM, €/kWh",
                Data = _data.Dam.Select(x => new LineSeriesData()
                {
                    X = (long)(new DateTime(_settings.DefaultStartDate.Year,
                        _settings.DefaultStartDate.Month,
                        _settings.DefaultStartDate.Day, x.Key, 0, 0)
                               - _settings.DefaultStartDate).TotalMilliseconds,
                    Y = x.Value
                }).ToList(),
                YAxisNumber = 1,
                XAxisNumber = 0,
                //Color = _settings.Colors["Dam"].ToRgbaString()
            });
            
            // //dam buy
            // options.Series.Add(new LineSeries()
            // {
            //     //Name = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "DamBuyPrice")}, €/kWh",
            //     Data = _data.DamBuy.Select(x => new LineSeriesData()
            //     {
            //         X = (long)(new DateTime(_settings.DefaultStartDate.Year,
            //                        _settings.DefaultStartDate.Month,
            //                        _settings.DefaultStartDate.Day, x.Key, 0, 0)
            //                    - _settings.DefaultStartDate).TotalMilliseconds,
            //         Y = x.Value
            //     }).ToList(),
            //     YAxisNumber = 1,
            //     XAxisNumber = 0,
            //     Color = _settings.Colors["DamBuy"].ToRgbaString(),
            //     DashStyle = LineSeriesDashStyle.Dot
            // });
            //
            // //dam sell
            // options.Series.Add(new LineSeries()
            // {
            //     //Name = $"{_settings.GetTranslationString(ChartSettings.TranslScope.Chart, "DamSellPrice")}, €/kWh",
            //     Data = _data.DamSell.Select(x => new LineSeriesData()
            //     {
            //         X = (long)(new DateTime(_settings.DefaultStartDate.Year,
            //                        _settings.DefaultStartDate.Month,
            //                        _settings.DefaultStartDate.Day, x.Key, 0, 0)
            //                    - _settings.DefaultStartDate).TotalMilliseconds,
            //         Y = x.Value
            //     }).ToList(),
            //     YAxisNumber = 1,
            //     XAxisNumber = 0,
            //     Color = _settings.Colors["DamSell"].ToRgbaString(),
            //     DashStyle = LineSeriesDashStyle.Dot
            // });

        }
    }
}