using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using Microsoft.Extensions.Logging;

namespace ReportingFramework.ReportTypesAdapter.SimulationReports.AdviceP1InvReport
{
    public abstract class AdviceP1InvReportAdapter : SimulationReportAdapter
    {
        protected new AdviceP1InvCsvReader CsvReader
        {
            get => base.CsvReader as AdviceP1InvCsvReader;
            set => base.CsvReader = value;
        }
        protected new AdviceP1InvReportParameters ReportParameters { get; set; }

        
        public AdviceP1InvReportAdapter(
            ReportAdapterParameters reportAdapterParameters,
            IReportRepository reportRepository,
            ILogger<ReportAdapter.ReportAdapter> logger)
            : base(
                reportAdapterParameters,
                reportRepository, logger)
        {
            CsvReader = new AdviceP1InvCsvReader();
            ReportParameters = (AdviceP1InvReportParameters)reportAdapterParameters.ReportParameters;
        }
        
    }
}