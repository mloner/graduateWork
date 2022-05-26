using System.Collections.Generic;
using System.Linq;
using CugReportMicroservice.Dtos.ExcelSectionData.MultiCugReportEnergyManagementReport.Dto;
using SectionModels;
using SectionModels.Excel.SectionModels.MCEM.CugReport;
using SectionModels.ReportObjects.Tables;

namespace ReportingFramework.SectionAdapter.MCEMReport.CugReportSectionAdapter
{
    public class CugReportSectionAdapterV0_1 : CugReportSectionAdapter
    {
        public new CugReportSectionModelV0_1 SectionModelModel { get; set; }
        public CugReportSectionAdapterV0_1()
        {
            SectionModelModel = new CugReportSectionModelV0_1();
        }

        public override SectionModel CreateSectionModel()
        {
            var metersData = (KeyValuePair<string, List<BuildingDataDto>>)CommonData["MetersData"];
            SectionModelModel.CustomParameters = new Dictionary<string, string>()
            {
                {"SheetName", metersData.Key},
                {"CugName",  metersData.Key.ToString()},
                {"RefYear",  CommonData["RefYear"].ToString()},
                {"CurYear",  CommonData["CurYear"].ToString()}
            };
            SectionModelModel.CugReportTable = new CugReportTable()
            {
                Data = metersData.Value
                    .Select(x => new CugReportTable.CugSectionTableDataItem 
                    {
                        BuildingName = x.BuildingName,
                        BuildingType = x.BuildingType,
                        Surface = x.Surface,
                        ElectricityCurrentYear = x.ElectricityCurrentYear,
                        ElectricityRefYear = x.ElectricityRefYear,
                        ElectricityKpi = x.ElectricityCurrentYear / x.Surface,
                        GasCurrentYear = x.GasCurrentYear,
                        GasRefYear = x.GasRefYear,
                        GasKpi = x.GasCurrentYear / x.Surface,
                        SolarCurrentYear = x.SolarCurrentYear,
                        SolarRefYear = x.SolarRefYear,
                        SolarKpi = x.SolarCurrentYear / x.Surface,
                    }).ToList()
            };
            
            
            return SectionModelModel;
        }
    }
}