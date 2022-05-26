using System.Collections.Generic;
using System.Linq;
using CugReportMicroservice.Dtos.ExcelSectionData.MultiCugReportEnergyManagementReport.Dto;
using SectionModels;
using SectionModels.Excel.SectionModels.MCEM.AllCugsSummary;
using SectionModels.ReportObjects.Tables;

namespace ReportingFramework.SectionAdapter.MCEMReport.AllCugsSummary
{
    public class AllCugsSummarySectionAdapterV0_1 : AllCugsSummarySectionAdapter
    {
        public new AllCugsSummarySectionModelV0_1 SectionModelModel { get; set; }
        public AllCugsSummarySectionAdapterV0_1()
        {
            SectionModelModel = new AllCugsSummarySectionModelV0_1();
        }

        public override SectionModel CreateSectionModel()
        {
            SectionModelModel.CustomParameters = new Dictionary<string, string>()
            {
                {"SheetName", "Quares"},
                {"RefYear",  CommonData["RefYear"].ToString()},
                {"CurYear",  CommonData["CurYear"].ToString()}
            };
            SectionModelModel.AllCugsSummaryTable = new AllCugsSummaryTable()
            {
                Data = ((List<BuildingDataDto>)CommonData["MetersData"])
                    .GroupBy(x => x.CugName)
                    .Select(x => new AllCugsSummaryTable.CugsSummarySectionTableDataItem
                    {
                        CugName = x.Key,
                        Surface = x.Sum(y => y.Surface),
                        ElectricityCurrentYear =  x.Sum(y => y.ElectricityCurrentYear),
                        ElectricityRefYear =  x.Sum(y => y.ElectricityRefYear),
                        ElectricityKpi =  x.Sum(y => y.ElectricityCurrentYear / y.Surface),
                        GasCurrentYear = x.Sum(y => y.GasCurrentYear),
                        GasRefYear = x.Sum(y => y.GasRefYear),
                        GasKpi =  x.Sum(y => y.GasCurrentYear / y.Surface),
                        SolarCurrentYear = x.Sum(y => y.SolarCurrentYear),
                        SolarRefYear = x.Sum(y => y.SolarRefYear),
                        SolarKpi = x.Sum(y => y.SolarCurrentYear / y.Surface),
                    }).ToList()
            };

            return SectionModelModel;
        }
    }
    
}