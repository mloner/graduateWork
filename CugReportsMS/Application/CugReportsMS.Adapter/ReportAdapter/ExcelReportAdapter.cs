using System;
using System.Collections.Generic;
using ChartGeneratorModels;
using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using Microsoft.Extensions.Logging;
using ReportingFramework.SectionAdapter;
using SectionModels;
using SectionModels.Excel;

namespace ReportingFramework.ReportAdapter
{
    public abstract class ExcelReportAdapter : ReportAdapter
    {
        public new ExcelReportModel ReportModel { get; set; }
        public List<ExcelSectionEnum> ExcelSections { get; set; }
        public ExcelReportAdapter(ReportAdapterParameters reportAdapterParameters, IReportRepository reportRepository,
            ILogger<ReportAdapter>  logger)
            : base(reportAdapterParameters, reportRepository, logger)
        {
            ReportModel = new ExcelReportModel()
            {
                Sections = new List<SectionModel>()
            };
        }

        protected override void InitCommonReportData()
        {
            
        }
        
        protected override ReportModel InitReportStructure()
        {
            var sectionAdapterHelper = new SectionAdapterHelper();
            
            foreach (var sectionEnum in ExcelSections)
            {
                try
                {
                    var sectionAdapter = sectionAdapterHelper.GetSectionAdapter(
                        ReportFormatEnum.Excel,
                        (int)sectionEnum);

                    sectionAdapter.Init(new SectionArgs
                    {
                        ReportCommonData = ReportCommonData,
                        ReportAdapterParameters = ReportAdapterParameters,
                        CsvReader = CsvReader
                    });
                    sectionAdapter.LoadData();
                    var section = sectionAdapter.CreateSectionModel();


                    ReportModel.Sections.Add(section);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Section: " + sectionEnum.Desc());
                    throw;
                }
            }


            return ReportModel;
        }
    }
}