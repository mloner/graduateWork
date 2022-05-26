using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using Microsoft.Extensions.Logging;
using ReportingFramework.ReportAdapter;
using ReportingFramework.ReportTypesAdapter.MCEM.ReportParameters;

namespace ReportingFramework.ReportTypesAdapter.MCEM.ReportAdapter
{
    public abstract class MCEMReportAdapter : ExcelReportAdapter
    {
        public new MCEMCsvReader CsvReader;
        public new MCEMReportParameters ReportParameters; 
        public MCEMReportAdapter(
            ReportAdapterParameters reportAdapterParameters,
            IReportRepository reportRepository,
            ILogger<ReportingFramework.ReportAdapter.ReportAdapter> logger)
            : base(reportAdapterParameters, reportRepository, logger)
        {
            CsvReader = new MCEMCsvReader();
            ReportParameters = (MCEMReportParameters)reportAdapterParameters.ReportParameters;
        }
    }
}