using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using Microsoft.Extensions.Logging;

namespace ReportingFramework.ReportTypesAdapter.SimulationReports.AdviceP1Report
{
    public abstract class AdviceP1ReportAdapter : SimulationReportAdapter
    {
        protected new AdviceP1CsvReader CsvReader
        {
            get => base.CsvReader as AdviceP1CsvReader;
            set => base.CsvReader = value;
        }
        protected new AdviceP1ReportParameters ReportParameters { get; set; }

        
        public AdviceP1ReportAdapter(
            ReportAdapterParameters reportAdapterParameters,
            IReportRepository reportRepository,
            ILogger<ReportAdapter.ReportAdapter> logger)
            : base(
                reportAdapterParameters,
                reportRepository, logger)
        {
            CsvReader = new AdviceP1CsvReader();
            ReportParameters = (AdviceP1ReportParameters)reportAdapterParameters.ReportParameters;
        }
        
    }
}