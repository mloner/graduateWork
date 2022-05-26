using System;
using System.Collections.Generic;
using System.Linq;
using ReportingFramework.ReportTypesAdapter.AlgoComp;
using ReportingFramework.ReportTypesAdapter.AlgoComp.DataModels;
using SectionModels;
using SectionModels.Pdf.SectionModels.AlgoCompReport;

namespace ReportingFramework.SectionAdapter.AlgoCompReport
{
    public class AlgoComp_ExecSumSecAdap : PdfSectionAdapter
    {
        public new AlgoComp_ExecSumSectionModel SectionModelModel { get; set; }
        public new AlgoCompReportParameters ReportParameters
        {
            get => ReportAdapterParameters.ReportParameters as AlgoCompReportParameters;
            set => ReportAdapterParameters.ReportParameters = value;
        }

        private List<GridPowerDataModel> _refData;
        private List<GridPowerDataModel> _bestData;

        private double _capTarRef;
        private double _capTarBest;

        public AlgoComp_ExecSumSecAdap()
        {
            SectionModelModel = new AlgoComp_ExecSumSectionModel();
        }
        
        public override void LoadData()
        {
            _refData = ((List<GridPowerDataModel>) CommonData["GridDataRef"]);
            _bestData = ((List<GridPowerDataModel>) CommonData["GridDataBest"]);
            var capTarPeak = 2.5;
            var capTar = 4.0;
            
            //captar ref
            _capTarRef = Math.Round(_refData.GroupBy(x => new { x.DateTime.Year, x.DateTime.Month })
                .First().Max(x => x.Value / 1000).Value, 1) - capTarPeak;
            _capTarRef = _capTarRef < 0 ? 0 : _capTarRef * capTar;
            
            //carpar best
            _capTarBest = Math.Round(_bestData.GroupBy(x => new { x.DateTime.Year, x.DateTime.Month })
                .First().Max(x => x.Value / 1000).Value, 1) - capTarPeak;
            _capTarBest = _capTarBest < 0 ? 0 : _capTarBest * capTar;
        }

        
        public override SectionModel CreateSectionModel()
        {
            SectionModelModel.BasicInfo = new BasicInfo
            {
                BuildingName = ReportParameters.CustomParameters.BuildingName,
                Email = ReportParameters.CustomParameters.Email,
                ReportDate = DateTime.Now,
                SimulationPeriodStart = _bestData.First().DateTime,
                SimulationPeriodEnd = _bestData.Last().DateTime,
                SimulatedDaysNumer = (int)Math.Round((_bestData.Last().DateTime - _bestData.First().DateTime).TotalDays),
                BatteryModel = ReportParameters.CustomParameters.BatteryModel,
                BatteryCapacity = ReportParameters.CustomParameters.BatteryCapacity
            };
            SectionModelModel.Savings = Math.Round(_capTarRef, 1) - Math.Round(_capTarBest, 1);

            return SectionModelModel;
        }
    }
}