using System.Collections.Generic;
using System.Linq;
using CugReportMicroservice.Dtos.ExcelSectionData.MaintenanceReport.Dto;
using SectionModels;
using SectionModels.Excel.SectionModels.Maintenance;
using SectionModels.ReportObjects.Tables;

namespace ReportingFramework.SectionAdapter.MaintenanceReport
{
    public class Maintenance_AllMetersSectionAdapter : ExcelSectionAdapter
    {
        public new Maintenance_AllMetersSectionModel SectionModelModel { get; set; }

        public Maintenance_AllMetersSectionAdapter()
        {
            SectionModelModel = new Maintenance_AllMetersSectionModel();
        }
        public override SectionModel CreateSectionModel()
        {
            SectionModelModel.CustomParameters = new Dictionary<string, string>()
            {
                {"CugName", CommonData["CugName"].ToString()}
            };
            SectionModelModel.MetersTable = new MetersTable()
            {
                Data = ((CugMetersDto) CommonData["MetersData"])
                    .MetersValues
                    .Select(x => new MetersTable.MetersTableDataItem
                    {
                        BuildingName = x.BuildingName,
                        AimrId = x.AimrId,
                        InputId = x.InputId,
                        Medium = x.Medium,
                        InputName = x.InputName,
                        LastValueTimeStamp = x.LastValueTimeStamp,
                        LastValue = x.LastValue,
                    }).ToList()
                    
            };

            return SectionModelModel;
        }
    }
}