using System;
using System.Collections.Generic;
using System.Linq;
using ChartGeneratorModels;
using ChartGeneratorModels.ChartData;
using ChartGeneratorModels.ChartData.CommonChartData;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using ReportingFramework.ReportTypesAdapter.SimulationReports.DataModels;
using SectionModels;
using SectionModels.Pdf.SectionModels.SimulationReports.AdviceP1.BE;

namespace ReportingFramework.SectionAdapter.AdviceP1BE
{
    public class AdviceP1BE_AnalysisSecAdap : PdfSectionAdapter
    {
        protected new AdviceP1BE_AnalysisSecModel SectionModel
        {
            get => base.SectionModel as AdviceP1BE_AnalysisSecModel;
            set => base.SectionModel = value;
        }

        public AdviceP1BE_AnalysisSecAdap()
        {
            SectionModel = new AdviceP1BE_AnalysisSecModel();
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
            AddPeakShavCharts();
            AddElectMarkCharts();
            
            return SectionModel;
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