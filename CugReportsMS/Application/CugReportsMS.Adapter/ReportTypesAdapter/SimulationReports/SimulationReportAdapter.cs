using System.Collections.Generic;
using System.IO;
using System.Linq;
using ApiService.MetadataMicroservice;
using ApiService.MetadataMicroservice.JsonMoedls;
using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using Microsoft.Extensions.Logging;
using ReportingFramework.ReportAdapter;
using ReportingFramework.ReportTypesAdapter.SimulationReports.DataModels;

namespace ReportingFramework.ReportTypesAdapter.SimulationReports
{
    public abstract class SimulationReportAdapter : PdfReportAdapter
    {
        protected new SimulationCsvReader CsvReader
        {
            get => base.CsvReader as SimulationCsvReader;
            set => base.CsvReader = value;
        }
        protected new ReportParameters ReportParameters { get; set; }

        #region Shared variables

        protected List<SimulationResultModel> Results;
        protected SimulationResultModel ResultRef;
        protected SimulationResultModel ResultSmartAlgo;
        protected SimulationResultModel ResultSimpleAlgo;
        protected SimulationResultModel ResultBest;
        
        protected List<SimulationResultGridModel> ResultGridRef;
        protected List<SimulationResultGridModel> ResultGridSmartAlgo;
        protected List<SimulationResultGridModel> ResultGridSimpleAlgo;
        protected List<SimulationResultGridModel> ResultGridBest;
        
        public List<ComponentWithParametersWithValues> Batteries;

        #endregion
        
        public SimulationReportAdapter(
            ReportAdapterParameters reportAdapterParameters,
            IReportRepository reportRepository,
            ILogger<ReportAdapter.ReportAdapter> logger)
            : base(
                reportAdapterParameters,
                reportRepository, logger)
        {
            CsvReader = new SimulationCsvReader();
            ReportParameters = reportAdapterParameters.ReportParameters;
        }

        protected override void InitCommonReportData()
        {
            GetparamsJson();
            GetResults();
            ChooseCases();
            GetResultGridData();
            GetBatteries();
            GetCustomerData();
        }
        
        public void GetResults()
        {
            Results = CsvReader.GetResults($"{ReportAdapterParameters.ReportDataFolderPath}/results/results.csv");
            ReportCommonData.Add("Results", Results);
        }
        
        public void ChooseCases()
        {
            //ref
            ResultRef = Results.First();
            ReportCommonData.Add("ResultRef", ResultRef);
            
            //smart algo
            ResultSmartAlgo =
                Results.Where(x =>
                        x.BatteryId != 0
                        && x.Algo == "smart_ps"
                        && x.IsDam == true)
                    .OrderByDescending(x => x.Npv)
                    .First();
            ReportCommonData.Add("ResultSmartAlgo", ResultSmartAlgo);
            
            //simple algo
            ResultSimpleAlgo =
                Results.First(x => 
                    x.BatteryId == ResultSmartAlgo.BatteryId
                    && x.Algo == "dumb"
                    && x.IsDam == false);
            ReportCommonData.Add("ResultSimpleAlgo", ResultSimpleAlgo);

            //best
            ResultBest = new List<SimulationResultModel>()
            {
                ResultSmartAlgo,
                ResultSimpleAlgo
            }.OrderByDescending(x => x.Npv).First();
            ReportCommonData.Add("ResultBest", ResultBest);
        }

        public void GetResultGridData()
        {
            GetGridResultDataForCases();
            GetGridResultWithDam();
        }

        public void GetGridResultWithDam()
        {
            DirectoryInfo d = new DirectoryInfo(ReportAdapterParameters.ReportDataFolderPath + "/results");
            FileInfo[] files = d.GetFiles("*.csv");
            var fileName = files.ToList().First(x => x.Name.Contains("DAM_True")).Name;

            var gridResultWithDam = CsvReader.GetGridResults(
                $"{ReportAdapterParameters.ReportDataFolderPath}/" +
                $"results/" + fileName);
            ReportCommonData.Add("ResultGridWithDam", gridResultWithDam);
        }

        public abstract void GetGridResultDataForCases();
        
        public void GetBatteries()
        {
            var batteryIds = Results.Select(x => x.BatteryId).Distinct().Where(x => x != 0).ToList();
            Batteries = new List<ComponentWithParametersWithValues>();
            foreach (var batteryId in batteryIds)
            {
                var batteryComponent = MetadataMicroserviceClient.GetComponentsByParameterIdAndValue(
                    (int)BatteryComponentParameterEnum.OldId,
                    batteryId.ToString()).Result.First();
                
                Batteries.Add(MetadataMicroserviceClient
                    .GetComponentWithParametersWithValueByComponentId(batteryComponent.ComponentId).Result);
            }
            ReportCommonData.Add("Batteries", Batteries);
        }
    }
}