using System;
using System.Collections.Generic;
using System.Linq;
using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using Microsoft.Extensions.Logging;
using ReportingFramework.ReportAdapter;
using SectionModels.Pdf;

namespace ReportingFramework.ReportTypesAdapter.AlgoComp
{
    public class AlgoCompReportAdapter : PdfReportAdapter
    {
        public new AlgoCompReportParameters ReportParameters; 
        
        public AlgoCompReportAdapter
            (ReportAdapterParameters reportAdapterParameters,
                IReportRepository reportRepository,
                ILogger<ReportAdapter.ReportAdapter> logger)
            : base(reportAdapterParameters, reportRepository, logger)
        {
            CsvReader = new AlgoCompJabbaCsvReader();
            ReportParameters = (AlgoCompReportParameters)reportAdapterParameters.ReportParameters;

            PdfSections = new List<PdfSectionEnum>()
            {
                PdfSectionEnum.AlgoComp_ExecSum,
                PdfSectionEnum.AlgoComp_PeakShavComp
            };
        }

        protected override void InitCommonReportData()
        {
            try
            {
                var csvRd = (AlgoCompJabbaCsvReader)CsvReader;

                //results
                var results = csvRd.GetResultsFromCsv($"{ReportAdapterParameters.ReportDataFolderPath}/results/results.csv");
                ReportCommonData.Add("Results", results);
                ReportCommonData.Add("ResultRef", results.First());
                var resultBest = results.OrderByDescending(x => x.Npv).First();
                ReportCommonData.Add("ResultBest", resultBest);

                //grid data
                ReportCommonData.Add("GridDataRef", csvRd.GetRefData($"{ReportAdapterParameters.ReportDataFolderPath}/data.csv"));
                ReportCommonData.Add("GridDataBest",
                    csvRd.GetGridPowerDataModels(
                        $"{ReportAdapterParameters.ReportDataFolderPath}\\results\\" +
                        $"result_{resultBest.Algo}" +
                        $"_grid_{resultBest.GridId}" +
                        $"_battery_{resultBest.BatteryId}" +
                        $"_degradation_False" +
                        $"_DAM_{resultBest.IsDynamicTariff.ToString().FirstCharToUpper()}" +
                        $"_NM_False" +
                        $".csv"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}