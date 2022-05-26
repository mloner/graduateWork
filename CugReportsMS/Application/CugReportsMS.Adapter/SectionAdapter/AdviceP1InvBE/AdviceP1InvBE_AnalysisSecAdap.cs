﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ChartGeneratorModels;
using ChartGeneratorModels.ChartData;
using ChartGeneratorModels.ChartData.CommonChartData;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using ReportingFramework.ReportTypesAdapter.SimulationReports.DataModels;
using SectionModels;
using SectionModels.Pdf.SectionModels.SimulationReports.AdviceP1Inv.BE;

namespace ReportingFramework.SectionAdapter.AdviceP1InvBE
{
    public class AdviceP1InvBE_AnalysisSecAdap : PdfSectionAdapter
    {
        protected new AdviceP1InvBE_AnalysisSecModel SectionModel
        {
            get => base.SectionModel as AdviceP1InvBE_AnalysisSecModel;
            set => base.SectionModel = value;
        }

        public AdviceP1InvBE_AnalysisSecAdap()
        {
            SectionModel = new AdviceP1InvBE_AnalysisSecModel();
        }
        
        protected SimulationResultModel ResultRef;
        protected SimulationResultModel ResultBest;
        protected SimulationResultModel ResultSmartAlgo;
        protected List<SimulationResultGridModel> ResultGridRef;
        protected List<SimulationResultGridModel> ResultGridSimpleAlgo;
        protected List<SimulationResultGridModel> ResultGridSmartAlgo;
        protected List<SimulationResultGridModel> ResultGridWithDam;

        public override void LoadData()
        {
            base.LoadData();
            ResultRef = (SimulationResultModel)CommonData["ResultRef"];
            ResultBest = (SimulationResultModel)CommonData["ResultBest"];
            ResultSmartAlgo = (SimulationResultModel)CommonData["ResultSmartAlgo"];
            ResultGridRef = (List<SimulationResultGridModel>)CommonData["ResultGridRef"];
            ResultGridSimpleAlgo = (List<SimulationResultGridModel>)CommonData["ResultGridSimpleAlgo"];
            ResultGridSmartAlgo = (List<SimulationResultGridModel>)CommonData["ResultGridSmartAlgo"];
            ResultGridWithDam = (List<SimulationResultGridModel>)CommonData["ResultGridWithDam"];
        }
        
        

        public override SectionModel CreateSectionModel()
        {
            AddSelfConsCharts();
            AddPeakShavCharts();
            AddElectMarkCharts();
            
            return SectionModel;
        }
        

        private void AddSelfConsCharts()
        {
            SectionModel.SelfCons = new SelfCons()
            {
                NoBatteryChart = new ChartRequestData
                {
                    ChartType = ChartEnum.PieChart,
                    ChartData = new PieChartData()
                    {
                        Values = new Dictionary<string, double>()
                        {
                            {"Prod", 100 - ResultRef.Csr},
                            {"SelfCons", ResultRef.Csr}
                        }
                    },
                    ChartSettings = new PieChartSettings()
                    {
                        Colors = new Dictionary<string, Color>()
                        {
                            {"Prod", Color.FromArgb(84, 211, 157)},
                            {"SelfCons", Color.FromArgb(0, 31, 78)}
                        }
                    }
                },
                SmartBatteryChart = new ChartRequestData
                {
                    ChartType = ChartEnum.PieChart,
                    ChartData = new PieChartData()
                    {
                        Values = new Dictionary<string, double>()
                        {
                            {"Prod", 100 - ResultSmartAlgo.Csr},
                            {"SelfCons", ResultSmartAlgo.Csr}
                        }
                    },
                    ChartSettings = new PieChartSettings()
                    {
                        Colors = new Dictionary<string, Color>()
                        {
                            {"Prod", Color.FromArgb(84, 211, 157)},
                            {"SelfCons", Color.FromArgb(0, 31, 78)}
                        }
                    }
                }
            };
        }
        private void AddPeakShavCharts()
        {
            var yMaxes = new List<double?>
            {
                new List<double>()
                {
                    (ResultGridRef.GroupBy(x => new
                        {
                            x.DateTime.Year, x.DateTime.Month
                        })
                        .First()
                        .Select(x => x.GridConsumptionPower).Max().Value / 1000),
                    (ResultGridSmartAlgo.GroupBy(x => new
                        {
                            x.DateTime.Year, x.DateTime.Month
                        })
                        .First()
                        .Select(x => x.GridConsumptionPower).Max().Value / 1000),
                }.Max() * 1.35
            };
            SectionModel.PeakShav = new PeakShav()
            {
                NoBatteryChart = new ChartRequestData
                {
                    ChartType = ChartEnum.PeakShavMonthlyMultiComp,
                    ChartData = new PeakShavingMonthMultiChartData()
                    {
                        Series1 = ResultGridRef.
                            GroupBy(x => new
                            {
                                x.DateTime.Year, x.DateTime.Month
                            })
                            .First()
                            .Select(x => new DateTimeSeries()
                            {
                                DateTime = x.DateTime,
                                Value = x.GridConsumptionPower == null ? 0 : x.GridConsumptionPower.Value / 1000
                            }).ToList(),
                        Series2 = ResultGridSimpleAlgo.
                            GroupBy(x => new
                            {
                                x.DateTime.Year, x.DateTime.Month
                            })
                            .First()
                            .Select(x => new DateTimeSeries()
                            {
                                DateTime = x.DateTime,
                                Value = x.GridConsumptionPower == null ? 0 : x.GridConsumptionPower.Value / 1000
                            }).ToList(),
                    },
                    ChartSettings = new PieChartSettings()
                    {
                        YMaxes = yMaxes,
                        CustomParameters = new Dictionary<string, string>()
                        {
                            {"Series1", "NoBattery"},
                            {"Series2", "SimpleBattery"}
                        }
                    }
                },
                SmartBatteryChart = new ChartRequestData
                {
                    ChartType = ChartEnum.PeakShavMonthlyMultiComp,
                    ChartData = new PeakShavingMonthMultiChartData()
                    {
                        Series1 = ResultGridRef.
                            GroupBy(x => new
                            {
                                x.DateTime.Year, x.DateTime.Month
                            })
                            .First()
                            .Select(x => new DateTimeSeries()
                            {
                                DateTime = x.DateTime,
                                Value = x.GridConsumptionPower == null ? 0 : x.GridConsumptionPower.Value / 1000
                            }).ToList(),
                        Series2 = ResultGridSmartAlgo.
                            GroupBy(x => new
                            {
                                x.DateTime.Year, x.DateTime.Month
                            })
                            .First()
                            .Select(x => new DateTimeSeries()
                            {
                                DateTime = x.DateTime,
                                Value = x.GridConsumptionPower == null ? 0 : x.GridConsumptionPower.Value / 1000
                            }).ToList(),
                    },
                    ChartSettings = new PieChartSettings()
                    {
                        YMaxes = yMaxes,
                        CustomParameters = new Dictionary<string, string>()
                        {
                            {"Series1", "NoBattery"},
                            {"Series2", "SmartBattery"}
                        }
                    }
                }
            };
        }

        private void AddElectMarkCharts()
        {
            SectionModel.AvgBuyPrice = Math.Abs(ResultBest.BuyPrice);
            SectionModel.AvgSellPrice = Math.Abs(ResultBest.SellPrice);
            var damPriceDay = ResultGridWithDam
                .GroupBy(x => x.DateTime.Day)
                .First()
                .GroupBy(x => x.DateTime.Hour)
                .ToDictionary(
                    g => g.Key,
                    g => g.Average(x => x.GridConsumptionPrice.Value));
            
            var batteryPowerDay = ResultGridSmartAlgo
                .GroupBy(x => x.DateTime.Day)
                .First()
                .GroupBy(x => x.DateTime.Hour)
                .ToDictionary(
                    g => g.Key,
                    g => g.Average(x => x.BatteryPower.Value));
            
            
            SectionModel.ElectMark = new ElectMark()
            {
                Chart = new ChartRequestData
                {
                    ChartType = ChartEnum.HourlyDamBattery,
                    ChartData = new HourlyDamBatteryChartData()
                    {
                        Dam = damPriceDay,
                        BatteryPower = batteryPowerDay,
                    },
                    ChartSettings = new HourlyDamBatteryChartSettings()
                }
            };
        }
    }
}