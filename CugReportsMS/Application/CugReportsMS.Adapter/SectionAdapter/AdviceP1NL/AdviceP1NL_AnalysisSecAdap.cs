using System;
using System.Collections.Generic;
using System.Linq;
using ChartGeneratorModels;
using ChartGeneratorModels.ChartData;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using ReportingFramework.ReportTypesAdapter.SimulationReports.DataModels;
using SectionModels;
using SectionModels.Pdf.SectionModels.SimulationReports.AdviceP1.NL;

namespace ReportingFramework.SectionAdapter.AdviceP1NL
{
    public class AdviceP1NL_AnalysisSecAdap : PdfSectionAdapter
    {
        protected new AdviceP1NL_AnalysisSecModel SectionModel
        {
            get => base.SectionModel as AdviceP1NL_AnalysisSecModel;
            set => base.SectionModel = value;
        }

        public AdviceP1NL_AnalysisSecAdap()
        {
            SectionModel = new AdviceP1NL_AnalysisSecModel();
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
            AddElectMarkCharts();
            
            return SectionModel;
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