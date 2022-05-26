using System;
using System.Collections.Generic;
using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using Microsoft.Extensions.Logging;
using SectionModels;

namespace ReportingFramework.ReportAdapter
{
    public abstract class ReportAdapter
    {
        protected readonly IReportRepository ReportRepository;
        private readonly ILogger _logger;
        public ReportAdapterParameters ReportAdapterParameters { get; set; }
        public ReportParameters ReportParameters;
        public CsvReader CsvReader;
        
        public Dictionary<string, object> ReportCommonData;
        
        public ReportModel ReportModel { get; set; }
        //public List<SectionDto> SectionDtos { get; set; }

        public ReportAdapter(
            ReportAdapterParameters reportAdapterParameters,
            IReportRepository reportRepository,
            ILogger<ReportAdapter> logger)
        {
            _logger = logger;
            ReportAdapterParameters = reportAdapterParameters;
            ReportRepository = reportRepository;
            ReportParameters = ReportAdapterParameters.ReportParameters;
            ReportCommonData = new Dictionary<string, object>();
            CsvReader = new CsvReader();
            
            // SectionDtos = ReportRepository
            //     .GetSectionsByReportTypeWithTemplateId(ReportAdapterParameters.ReportParameters.Type).Result;
        }

        protected abstract void InitCommonReportData(); //Fill Dictionary<string, object> ReportData
        
        protected abstract ReportModel InitReportStructure(); //Fill AbstractReportStructure ReportStructure
        
        public ReportModel CreateReportStructure()
        {
            try
            {
                InitCommonReportData(); //init data for the curtain type of report
            }
            catch (Exception e)
            {
                _logger.LogCritical($"\n[Orchestrator] [Method InitCommonReportData]:\n" +
                                    $"ReportId: {ReportAdapterParameters.ReportId}\n" +
                                    $"Failed\n" +
                                    $"Message: {e.Message}\n" +
                                    $"StackTrace: {e.StackTrace}");
                throw;
            }

            try
            {
                ReportModel = InitReportStructure();  //get report structure
            }
            catch (Exception e)
            {
                _logger.LogCritical($"\n[Orchestrator] [Method InitReportStructure]:\n" +
                                    $"ReportId: {ReportAdapterParameters.ReportId}\n" +
                                    $"Failed\n" +
                                    $"Message: {e.Message}\n" +
                                    $"StackTrace: {e.StackTrace}");
                throw;
            }

            return ReportModel;
        }
    }
}