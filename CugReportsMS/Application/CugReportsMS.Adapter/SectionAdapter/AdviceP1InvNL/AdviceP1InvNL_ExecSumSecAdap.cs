﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ApiService.MetadataMicroservice.JsonMoedls;
using ReportingFramework.DataModels.CustomerData;
using ReportingFramework.ReportTypesAdapter.SimulationReports.DataModels;
using SectionModels;
using SectionModels.Pdf.SectionModels.SimulationReports.AdviceP1Inv.NL;
using SectionModels.Pdf.SectionModels.SimulationReports.DataModels;

namespace ReportingFramework.SectionAdapter.AdviceP1InvNL
{
    public class AdviceP1InvNL_ExecSumSecAdap : PdfSectionAdapter
    {
        protected new AdviceP1InvNL_ExecSumSecModel SectionModel
        {
            get => base.SectionModel as AdviceP1InvNL_ExecSumSecModel;
            set => base.SectionModel = value;
        }

        public AdviceP1InvNL_ExecSumSecAdap()
        {
            SectionModel = new AdviceP1InvNL_ExecSumSecModel();
        }
        
        public CustomerData CustomerData;
        protected List<SimulationResultModel> Results;
        protected List<SimulationResultGridModel> ResultGridRef;
        protected List<SimulationResultGridModel> ResultGridSmartAlgo;
        protected SimulationResultModel ResultRef;
        protected SimulationResultModel ResultBest;
        protected SimulationResultModel ResultSmartAlgo;
        protected List<ComponentWithParametersWithValues> Batteries;
        
        public override void LoadData()
        {
            base.LoadData();
            CustomerData = (CustomerData)CommonData["CustomerData"];
            Results = (List<SimulationResultModel>)CommonData["Results"];
            ResultRef = (SimulationResultModel)CommonData["ResultRef"];
            ResultBest = (SimulationResultModel)CommonData["ResultBest"];
            ResultGridRef = (List<SimulationResultGridModel>)CommonData["ResultGridRef"];
            Batteries = (List<ComponentWithParametersWithValues>)CommonData["Batteries"];
        }
        
        
        

        public override SectionModel CreateSectionModel()
        {
            SectionModel.Location = new Location()
            {
                City = "Antwerpen",
                BuildingName = CustomerData.CustomerMetadata_.Task.Cug.Building.BuildingName
            };

            SectionModel.Measurements = new Measurements
            {
                FirstMeasurementDate = ResultGridRef.First().DateTime,
                MeasurementCount = ResultGridRef.Count,
                Consumption = ResultRef.ConsumptionEnergy,
                Production = ResultRef.ProductionEnergy,
                Injection = ResultRef.InjectedEnergy
            };

            var npvRef = Results.First().Npv;
            var monthCount = ResultGridRef.GroupBy(x => x.DateTime.Month).Count();
            SectionModel.DecisionTable = new DecisionTable()
            {
                Items = Results
                    .Select(x => x.BatteryId).Distinct().Where(x => x != 0)
                    .Select(x => new DecisionTableItem()
                    {
                        BatteryCapacity = double.Parse(GetBattery(x).ComponentParameters.Single(x => x.ComponentParameterId == (int)BatteryComponentParameterEnum.CapacityTotal).Value, CultureInfo.InvariantCulture),
                        BatteryPower = double.Parse(GetBattery(x).ComponentParameters.Single(x => x.ComponentParameterId == (int)BatteryComponentParameterEnum.Power).Value, CultureInfo.InvariantCulture),
                        SimpleBattery = (Results.First(y =>
                            y.BatteryId == x
                            && y.Algo == "dumb"
                            && y.IsDam == false).Npv - npvRef) / monthCount,
                        IsSimpleBatteryBest = Results.First(y =>
                            y.BatteryId == x
                            && y.Algo == "dumb"
                            && y.IsDam == false).CaseId == ResultBest.CaseId,
                        SmartBattery = (Results.First(y =>
                            y.BatteryId == x
                            && y.Algo == "smart_ps"
                            && y.IsDam == true).Npv - npvRef) / monthCount,
                        IsSmartBatteryBest = Results.First(y =>
                            y.BatteryId == x
                            && y.Algo == "smart_ps"
                            && y.IsDam == true).CaseId == ResultBest.CaseId,
                    }).ToList()
            };
            
            
            return SectionModel;
        }
        
        public ComponentWithParametersWithValues GetBattery(int batteryId)
        {
            return Batteries.Single(
                y => y.ComponentParameters.Single(
                    z => z.ComponentParameterId == (int)BatteryComponentParameterEnum.OldId).Value == batteryId.ToString());
        }
    }
}