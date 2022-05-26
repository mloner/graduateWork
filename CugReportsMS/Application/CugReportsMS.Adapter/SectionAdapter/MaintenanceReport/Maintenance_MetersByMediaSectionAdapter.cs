using System.Collections.Generic;
using System.Linq;
using CugReportMicroservice.Dtos.ExcelSectionData.MaintenanceReport.Dto;
using SectionModels;
using SectionModels.Excel.SectionModels.Maintenance;
using SectionModels.ReportObjects.Tables;

namespace ReportingFramework.SectionAdapter.MaintenanceReport
{
    public class Maintenance_MetersByMediaSectionAdapter : ExcelSectionAdapter
    {
        public new Maintenance_MetersByMediaSectionModel SectionModelModel { get; set; }
        public Maintenance_MetersByMediaSectionAdapter()
        {
            SectionModelModel = new Maintenance_MetersByMediaSectionModel();
        }
        
        public override SectionModel CreateSectionModel()
        {
            SectionModelModel.CustomParameters = new Dictionary<string, string>()
            {
                { "CugName", CommonData["CugName"].ToString() }
            };
            SectionModelModel.MetersByMediaTable = new MetersByMediaTable()
            {
                Data = ((CugMetersDto) CommonData["MetersData"])
                    .MetersValues
                    .GroupBy(x => new
                    {
                        x.BuildingName,
                        x.Medium
                    })
                    .OrderBy(x => x.Key.BuildingName)
                    .ThenBy(x => x.Key.Medium)
                    .Select(x => new MetersByMediaTable.MetersByMediaSectionTableDataItem
                    {
                        BuildingName = x.Key.BuildingName,
                        Medium = x.Key.Medium,
                        Sum = x.ToList().Count.ToString(),
                    }).ToList()
            };
            
            
            return SectionModelModel;
        }
    }
}