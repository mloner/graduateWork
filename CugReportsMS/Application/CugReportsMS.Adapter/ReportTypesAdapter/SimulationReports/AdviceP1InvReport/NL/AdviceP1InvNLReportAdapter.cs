using System.Collections.Generic;
using System.Globalization;
using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using Microsoft.Extensions.Logging;
using SectionModels.Pdf;

namespace ReportingFramework.ReportTypesAdapter.SimulationReports.AdviceP1InvReport.NL
{
    public class AdviceP1InvNLReportAdapter : AdviceP1InvReportAdapter
    {
        public AdviceP1InvNLReportAdapter(
            ReportAdapterParameters reportAdapterParameters,
            IReportRepository reportRepository,
            ILogger<ReportAdapter.ReportAdapter> logger)
            : base(reportAdapterParameters, reportRepository, logger)
        {
            PdfSections = new List<PdfSectionEnum>()
            {
                PdfSectionEnum.AdviceP1InvNL_Title,
                PdfSectionEnum.AdviceP1InvNL_ExecSum,
                PdfSectionEnum.AdviceP1InvNL_Analysis
            };
        }
        
        public override void GetGridResultDataForCases()
        {
            ResultGridRef = CsvReader.GetGridResults(
                $"{ReportAdapterParameters.ReportDataFolderPath}/" +
                $"results/" +
                $"result" +
                $"_{ResultRef.Algo}" +
                $"_grid_{ResultRef.GridId.ToString()}" +
                $"_battery_{ResultRef.BatteryId.ToString(CultureInfo.InvariantCulture).Replace(",", ".")}" +
                $"_degradation_{false.ToString().FirstCharToUpper()}" +
                $"_DAM_{ResultRef.IsDam.ToString().FirstCharToUpper()}" +
                $"_NM_{true.ToString().FirstCharToUpper()}" +
                $".csv");
            ReportCommonData.Add("ResultGridRef", ResultGridRef);
            
            ResultGridSmartAlgo = CsvReader.GetGridResults(
                $"{ReportAdapterParameters.ReportDataFolderPath}/" +
                $"results/" +
                $"result" +
                $"_{ResultSmartAlgo.Algo}" +
                $"_grid_{ResultSmartAlgo.GridId.ToString()}" +
                $"_battery_{ResultSmartAlgo.BatteryId.ToString(CultureInfo.InvariantCulture).Replace(",", ".")}" +
                $"_degradation_{false.ToString().FirstCharToUpper()}" +
                $"_DAM_{ResultSmartAlgo.IsDam.ToString().FirstCharToUpper()}" +
                $"_NM_{true.ToString().FirstCharToUpper()}" +
                $".csv");
            ReportCommonData.Add("ResultGridSmartAlgo", ResultGridSmartAlgo);
            
            ResultGridSimpleAlgo = CsvReader.GetGridResults(
                $"{ReportAdapterParameters.ReportDataFolderPath}/" +
                $"results/" +
                $"result" +
                $"_{ResultSimpleAlgo.Algo}" +
                $"_grid_{ResultSimpleAlgo.GridId.ToString()}" +
                $"_battery_{ResultSimpleAlgo.BatteryId.ToString(CultureInfo.InvariantCulture).Replace(",", ".")}" +
                $"_degradation_{false.ToString().FirstCharToUpper()}" +
                $"_DAM_{ResultSimpleAlgo.IsDam.ToString().FirstCharToUpper()}" +
                $"_NM_{true.ToString().FirstCharToUpper()}" +
                $".csv");
            ReportCommonData.Add("ResultGridSimpleAlgo", ResultGridSimpleAlgo);
            
            ResultGridBest = CsvReader.GetGridResults(
                $"{ReportAdapterParameters.ReportDataFolderPath}/" +
                $"results/" +
                $"result" +
                $"_{ResultBest.Algo}" +
                $"_grid_{ResultBest.GridId.ToString()}" +
                $"_battery_{ResultBest.BatteryId.ToString(CultureInfo.InvariantCulture).Replace(",", ".")}" +
                $"_degradation_{false.ToString().FirstCharToUpper()}" +
                $"_DAM_{ResultBest.IsDam.ToString().FirstCharToUpper()}" +
                $"_NM_{true.ToString().FirstCharToUpper()}" +
                $".csv");
            ReportCommonData.Add("ResultGridBest", ResultGridBest);
        }
    }
}