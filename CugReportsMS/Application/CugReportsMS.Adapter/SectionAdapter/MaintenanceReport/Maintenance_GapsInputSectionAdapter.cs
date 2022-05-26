using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.ExcelSectionData.MaintenanceReport.Dto;
using ReportingFramework.ReportTypesAdapter.Maintenance;
using SectionModels;
using SectionModels.Excel.SectionModels.Maintenance;
using SectionModels.ReportObjects.Tables;

namespace ReportingFramework.SectionAdapter.MaintenanceReport
{
    public class Maintenance_GapsInputSectionAdapter : ExcelSectionAdapter
    {
        public new Maintenance_GapsInputsSectionModel SectionModelModel { get; set; }
        public Maintenance_GapsInputSectionAdapter()
        {
            SectionModelModel = new Maintenance_GapsInputsSectionModel();
        }
        
        public override SectionModel CreateSectionModel()
        {
            var reportParameters = (MaintenanceReportParameters)ReportAdapterParameters.ReportParameters;
            var nowDateTime = DateTime.Now;

            SectionModelModel.CustomParameters = new Dictionary<string, string>()
            {
                { "CugName", CommonData["CugName"].ToString() }
            };
            SectionModelModel.CugGapsInputsTable = new CugGapsInputsTable()
            {
                Data = ((CugMetersDto)CommonData["MetersData"])
                    .MetersValues
                    .Where(x => IsGap(DateTime.Parse(x.LastValueTimeStamp, CultureInfo.InvariantCulture),
                        nowDateTime, reportParameters.CustomParameters.MinGapPeriod))
                    .Select(x => new CugGapsInputsTable.CugGapsInputsTableDataItem()
                    {
                        BuildingName = x.BuildingName,
                        AimrId = x.AimrId,
                        AimrName = x.AimrName,
                        AimrType = x.AimrType,
                        InputId = x.InputId,
                        Medium = x.Medium,
                        InputName = x.InputName,
                        LastValueTimestamp = x.LastValueTimeStamp,
                        LastValue = x.LastValue,
                        GateTime = x.GateTime,
                        Description = x.Description,
                    }).ToList()
            };

            
            return SectionModelModel;
        }

        private bool IsGap(DateTime lastDateTime, DateTime nowDateTime, GapPeriod gapPeriod)
        {
            var valueInMinutes = PeriodTypeExtension.PeriodToMinutes(gapPeriod.GapValue, gapPeriod.PeriodType);
            var minGapDateTime = nowDateTime.AddMinutes(-valueInMinutes);
            
            return lastDateTime < minGapDateTime;
        }
    }
}