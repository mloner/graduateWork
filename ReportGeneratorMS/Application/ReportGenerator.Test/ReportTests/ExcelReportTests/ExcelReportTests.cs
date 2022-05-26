using System;
using System.Collections.Generic;
using System.IO;
using Highsoft.Web.Mvc.Charts;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ReportGeneratorTests.ReportTests.ExcelReportTests
{
    public class ExcelReportTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ExcelReportTest_Ileco_FromClass()
        {
            // const string companyName = "Ileco";
            // string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            // string excelTemplatesFolder = $"{rootPath}ExcelTemplates";
            //
            // var reportType = ExcelReportTypeEnum.MaintenanceReport;
            // var reportStructure = new ExcelReportModel()
            // {
            //     ReportType = reportType,
            //     ReportName = $"{companyName}_{reportType.Desc()}_{DateTime.Now.ToString("yyyy-MM-dd")}",
            //     OutputFolder = $"{rootPath}\\Reports\\{companyName}\\{DateTime.Now.ToString("yyyy-MM-dd")}",
            //     Template = new ExcelTemplate()
            //     {
            //         TemplateFilePaths = new Dictionary<string, string>()
            //         {
            //             {
            //                 "Main",
            //                 $"{excelTemplatesFolder}\\{reportType.Desc()}\\Template_{reportType.Desc()}.xlsx"
            //             },
            //             {
            //                 "CugGapsInputErrors",
            //                 $"{excelTemplatesFolder}\\{reportType.Desc()}\\Template_{reportType.Desc()}_GapsInputsReport.xlsx"
            //             }
            //         },
            //         GlobalSettings = new GlobalSettings()
            //         {
            //             DecimalSeparator = ",",
            //             ThousandsSeparator = " ",
            //             ChartGeneratorSettings = new ChartGeneratorSettings()
            //             {
            //                 Font = FontEnum.Averta,
            //                 ChartFolder = $"{rootPath}\\Charts",
            //                 GlobalSettings = new Global(),
            //                 LangSettings = new Lang(){ThousandsSep = " ", DecimalPoint = ","}
            //             }
            //         }
            //     },
            //     Sections = new List<ISection>()
            //     {
            //         new ExcelSection()
            //         {
            //             Name = ExcelSectionNameEnum.CugGapsInputErrors,
            //             Data = new SectionData()
            //             {
            //                 Parameters = new Dictionary<string, string>()
            //                 {
            //                     {"CugName", "Cordium"}
            //                 },
            //                 ReportObjects = new List<IReportObject>()
            //                 {
            //                     new CugGapsInputErrorsTable()
            //                     {
            //                         Name = "TableData",
            //                         TableData = new List<CugGapsInputErrorsSectionTableDataItem>()
            //                         {
            //                             new CugGapsInputErrorsSectionTableDataItem()
            //                             {
            //                                 BuildingName = "Cordium Staging",
            //                                 AimrId = "39686",
            //                                 AimrName = "ADS01:NAE02",
            //                                 AimrType = "Virtual",
            //                                 InputId = "118944",
            //                                 Medium = "test",
            //                                 InputName = "Fase 3 - WW__PROD.Alarm ketels",
            //                                 LastValueTimestamp = "12/11/2020 8:03:00 PM",
            //                                 LastValue = "1",
            //                                 GateTime = "15 min.",
            //                                 Description = "ADS01:NAE02/FCB.002AFEC009.SW01.SW01_AVAIBLE.Present Value no-units Other "
            //                             },
            //                             new CugGapsInputErrorsSectionTableDataItem()
            //                             {
            //                                 BuildingName = "Cordium Staging",
            //                                 AimrId = "39686",
            //                                 AimrName = "ADS01:NAE02",
            //                                 AimrType = "Virtual",
            //                                 InputId = "118944",
            //                                 Medium = "test",
            //                                 InputName = "Fase 3 - WW__PROD.Alarm ketels",
            //                                 LastValueTimestamp = "12/11/2020 8:03:00 PM",
            //                                 LastValue = "1",
            //                                 GateTime = "15 min.",
            //                                 Description = "ADS01:NAE02/FCB.002AFEC009.SW01.SW01_AVAIBLE.Present Value no-units Other "
            //                             },
            //                             new CugGapsInputErrorsSectionTableDataItem()
            //                             {
            //                                 BuildingName = "Cordium Staging 22",
            //                                 AimrId = "39634534586",
            //                                 AimrName = "ADS01:NAE02",
            //                                 AimrType = "123",
            //                                 InputId = "118944",
            //                                 Medium = "test",
            //                                 InputName = "Fase 3 - WW__PROD.Alarm ketels",
            //                                 LastValueTimestamp = "12/11/2020 8:03:00 PM",
            //                                 LastValue = "1",
            //                                 GateTime = "15 min.",
            //                                 Description = "ADS01:NAE02/FCB.002AFEC00975675676ts Other "
            //                             }
            //                         }
            //                     }
            //                 }
            //             }
            //         },
            //     }
            //};
            
            //serialize report structure to json string
            // string reportStructureJson =  JsonConvert.SerializeObject(reportStructure,
            //     new JsonSerializerSettings()
            //     {
            //         TypeNameHandling = TypeNameHandling.Auto
            //     });
            //
            // File.WriteAllText($"{rootPath}ReportTests\\ExcelReportTests\\TestData\\ExcelTemplates\\Excel_Maintenance.json",
            //     reportStructureJson);

            // var report = new ExcelReportGenerator(reportStructureJson);
            // report.Generate();
            //// report.Open();
        }
        
        
        [Test]
        public void ExcelReportTest_Ileco_FromJson()
        {
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            
            var reportStructureJson = File.ReadAllText(
                $"{rootPath}ReportTests\\ExcelReportTests\\TestData\\ExcelTemplates\\Excel_Maintenance_1.json");
            
            
            // var report = new ExcelReportGenerator(reportStructureJson);
            // report.Generate();
            // report.Open();
        }
    }
}