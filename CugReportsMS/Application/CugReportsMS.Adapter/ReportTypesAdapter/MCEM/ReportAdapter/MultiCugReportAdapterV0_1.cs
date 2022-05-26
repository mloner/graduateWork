using System.Linq;
using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.ExcelSectionData.MultiCugReportEnergyManagementReport.Dto;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using Microsoft.Extensions.Logging;
using ReportingFramework.ReportTypesAdapter.MCEM.ReportParameters;
using ReportingFramework.SectionAdapter;
using SectionModels;

namespace ReportingFramework.ReportTypesAdapter.MCEM.ReportAdapter
{
    public class MultiCugReportAdapterV0_1 : MCEMReportAdapter
    {
        
        public new MCEMReportParametersV0_1 ReportParameters;
        public MultiCugReportAdapterV0_1(
            ReportAdapterParameters reportAdapterParameters,
            IReportRepository reportRepository,
            ILogger<ReportingFramework.ReportAdapter.ReportAdapter> logger)
            : base(reportAdapterParameters, reportRepository, logger)
        {
            ReportParameters = (MCEMReportParametersV0_1)reportAdapterParameters.ReportParameters;
        }

        protected override void InitCommonReportData()
        {
            ReportCommonData.Add("RefYear", ReportParameters.CustomParameters.RefYear);
            ReportCommonData.Add("CurYear", ReportParameters.CustomParameters.CurYear);
            ReportCommonData.Add("MetersData",
                CsvReader.GetMultiCugDataModels($"{ReportAdapterParameters.ReportDataFolderPath}/MultiCugMetersData.csv")
                    .Select(x => new BuildingDataDto
                    {
                        CugName = x.CugName,
                        BuildingName = x.BuildingName,
                        BuildingType = x.BuildingType,
                        Surface = x.Surface,
                        ElectricityCurrentYear = x.ElectricityCurrentYear,
                        ElectricityRefYear = x.ElectricityRefYear,
                        GasCurrentYear = x.GasCurrentYear,
                        GasRefYear = x.GasRefYear,
                        SolarCurrentYear = x.SolarCurrentYear,
                        SolarRefYear = x.SolarRefYear
                    }).ToList());
        }

        protected override ReportModel InitReportStructure()
        {
            var sectionAdapterHelper = new SectionAdapterHelper();
            SectionAdapter.SectionAdapter sectionAdapter;
            SectionModel sectionModel;


            // #region AllCugsSummary section
            //
            // var sectionDto = SectionDtos.First(x => x.SectionNum == (int)ExcelSectionEnum.AllCugsSummary);
            // sectionAdapter = sectionAdapterHelper.GetSectionAdapter(
            //     ReportFormatEnum.Excel,
            //     sectionDto.SectionNum);
            // sectionAdapter.Init(new SectionArgs
            // {
            //     ReportCommonData = ReportCommonData,
            //     ReportAdapterParameters = ReportAdapterParameters,
            //     CsvReader = CsvReader
            // });
            // sectionModel = sectionAdapter.CreateSectionModel();
            //
            // ReportModel.Sections.Add(sectionModel);
            //
            // #endregion
            //
            //
            // //for each cug create a tab
            // foreach (var keyValuePair in ((List<BuildingDataDto>)ReportCommonData["MetersData"])
            //     .GroupBy(x => x.CugName)
            //     .ToDictionary(
            //         g => g.Key,
            //         g => g.ToList()
            //     ))
            // {
            //     //sectionDto = SectionDtos.First(x => x.SectionNum == (int)ExcelSectionEnum.CugReport);
            //     sectionAdapter = sectionAdapterHelper.GetSectionAdapter(
            //         ReportFormatEnum.Excel,
            //         sectionDto.SectionNum);
            //     sectionAdapter.Init(new SectionArgs
            //     {
            //         ReportCommonData = new Dictionary<string, object>()
            //         {
            //             {"RefYear", ReportCommonData["RefYear"]},
            //             {"CurYear", ReportCommonData["CurYear"]},
            //             {"MetersData", keyValuePair}
            //         },
            //         ReportAdapterParameters = ReportAdapterParameters,
            //         CsvReader = CsvReader
            //     });
            //     sectionModel = sectionAdapter.CreateSectionModel();
            //     ReportModel.Sections.Add(sectionModel);
            // }
            

            return ReportModel;
        }
    }
}