using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ApiService.EcoScadaMicroservice;
using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.ExcelSectionData.MaintenanceReport.Dto;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using Microsoft.Extensions.Logging;
using ReportingFramework.ReportAdapter;
using ReportingFramework.SectionAdapter;
using SectionModels;
using SectionModels.Excel;

namespace ReportingFramework.ReportTypesAdapter.Maintenance
{
    public class MaintenanceReportAdapter : ExcelReportAdapter
    {
        public new MaintenanceCsvReader CsvReader;
        public new MaintenanceReportParameters ReportParameters;
        public MaintenanceReportAdapter(
            ReportAdapterParameters reportAdapterParameters,
            IReportRepository reportRepository,
            ILogger<ReportAdapter.ReportAdapter> logger)
            : base(reportAdapterParameters, reportRepository, logger)
        {
            ReportParameters = (MaintenanceReportParameters)reportAdapterParameters.ReportParameters;
            ExcelSections = new List<ExcelSectionEnum>()
            {
                ExcelSectionEnum.Maintenance_CugGapsInputs,
                ExcelSectionEnum.Maintenance_AllMeters,
                ExcelSectionEnum.Maintenance_MetersByMedia
            };
        }

        protected override void InitCommonReportData()
        {
            //get aimr type names
            var aimrTypes = EcoScadaMicroserviceClient.GetAimrTypes().Result;
            
            foreach (var cugParam in ReportParameters.CustomParameters.Cugs)
            {
                var cugResultData = new Dictionary<string, object>();
                
                var cug = EcoScadaMicroserviceClient.GetCugByGuid(Guid.Parse(cugParam.CugGuid)).Result;
                cugResultData.Add("CugName", cug.Name);
                
                var cugMetersDto = new CugMetersDto()
                {
                    CugName = cug.Name,
                    MetersValues = new List<CugMetersDtoItem>()
                };
                
                foreach (var cugParamInputGuid in cugParam.InputGuids)
                {
                    try
                    {
                        //get input details
                        var input = EcoScadaMicroserviceClient.GetInputByGuid(Guid.Parse(cugParamInputGuid)).Result;
                        //get aimr by input
                        var aimr = EcoScadaMicroserviceClient.GetAimrByGuid(Guid.Parse(input.AimrGuid)).Result;
                        //get building by aimr
                        var building = EcoScadaMicroserviceClient.GetBuildingByGuid(Guid.Parse(aimr.BuildingGuid)).Result;
                        //get input last value
                        var lastValue = EcoScadaMicroserviceClient.GetInputLastValue(input.Guid).Result;
                    
                        cugMetersDto.MetersValues.Add(new CugMetersDtoItem
                        {
                            BuildingName = building.Name,
                            AimrId = aimr.Id.ToString(),
                            AimrName = aimr.Name,
                            AimrType = aimrTypes.FirstOrDefault(x => x.Id == aimr.AimrTypeId)?.Name,
                            InputId = input.Id,
                            InputName = input.Name,
                            Medium = input.Medium.Name,
                            LastValueTimeStamp = lastValue?.DateTime.ToString(CultureInfo.InvariantCulture),
                            LastValue = lastValue?.Value.ToString(),
                            GateTime = input.GateTime.Name,
                            Description = input.Description?.ToString()
                        });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Maintenance report. Input {cugParamInputGuid} skipped.");
                    }
                }

                cugResultData.Add("MetersData", cugMetersDto);
                
                ReportCommonData.Add(cug.Guid.ToString(), cugResultData);
            }
        }

        protected override ReportModel InitReportStructure()
        {
            var sectionAdapterHelper = new SectionAdapterHelper();
            // for each cug create sheets
            foreach (var cugGuid in ReportParameters.CustomParameters.Cugs)
            {
                foreach (var sectionEnum in ExcelSections)
                {
                    var sectionAdapter = sectionAdapterHelper.GetSectionAdapter(
                        ReportFormatEnum.Excel,
                        (int)sectionEnum);
                    sectionAdapter.Init(new SectionArgs
                    {
                        ReportCommonData = (Dictionary<string, object>)ReportCommonData[cugGuid.CugGuid],
                        ReportAdapterParameters = ReportAdapterParameters,
                        CsvReader = CsvReader
                    });
                    var section = sectionAdapter.CreateSectionModel();
                    
                    ReportModel.Sections.Add(section);
                }

            }

            return ReportModel;
        }
    }
}















