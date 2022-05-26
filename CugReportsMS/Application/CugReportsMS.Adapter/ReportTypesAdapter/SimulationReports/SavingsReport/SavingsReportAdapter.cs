using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using Microsoft.Extensions.Logging;

namespace ReportingFramework.ReportTypesAdapter.SimulationReports.SavingsReport
{
    public abstract class SavingsReportAdapter : SimulationReportAdapter
    {
        protected new SavingsCsvReader CsvReader
        {
            get => base.CsvReader as SavingsCsvReader;
            set => base.CsvReader = value;
        }
        protected new SavingsReportParameters ReportParameters { get; set; }

        
        public SavingsReportAdapter(
            ReportAdapterParameters reportAdapterParameters,
            IReportRepository reportRepository,
            ILogger<ReportAdapter.ReportAdapter> logger)
            : base(
                reportAdapterParameters,
                reportRepository, logger)
        {
            CsvReader = new SavingsCsvReader();
            ReportParameters = (SavingsReportParameters)reportAdapterParameters.ReportParameters;
        }
        
    }
}