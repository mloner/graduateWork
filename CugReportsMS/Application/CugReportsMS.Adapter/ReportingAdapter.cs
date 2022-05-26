using System;
using System.Threading.Tasks;
using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using Microsoft.Extensions.Logging;
using SectionModels;

namespace ReportingFramework
{
    public class ReportingAdapter : IReportingAdapter
    {
        private readonly IReportRepository _reportRepository;
        private readonly ILogger<ReportingAdapter> _logger;
        private readonly IServiceProvider _serviceProvider;
        
        private ReportParameters _reportParameters;
        private string _loggerPrefix;
        

        public ReportingAdapter(
            ILogger<ReportingAdapter> logger,
            IReportRepository reportRepository,
            IServiceProvider serviceProvider)
        {
            _loggerPrefix = "Adapter";
            _logger = logger;
            _reportRepository = reportRepository;
            _serviceProvider = serviceProvider;
        }

        public void Init(ReportParameters reportParameters)
        {
            _reportParameters = reportParameters;
        }

        public async Task<ReportModel> CreateReportModel(int reportFormatId, string reportDataFolderPath, int reportId)
        {
            //get report adapter
            var reportAdapter = ReportAdapterHelper.GetReportAdapter(
                reportFormatId,
                new ReportAdapterParameters
                {
                    ReportParameters = _reportParameters,
                    ReportDataFolderPath = reportDataFolderPath
                },
                await _reportRepository.GetReportTypeNumByReportTypeWithTemplateId(_reportParameters.Type),
                _serviceProvider);
            var reportModel = reportAdapter.CreateReportStructure();

            return reportModel;
        }
    }
}