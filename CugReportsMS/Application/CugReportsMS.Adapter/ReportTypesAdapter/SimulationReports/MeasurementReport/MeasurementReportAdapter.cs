using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using Microsoft.Extensions.Logging;

namespace ReportingFramework.ReportTypesAdapter.SimulationReports.MeasurementReport
{
    public abstract class MeasurementReportAdapter : SimulationReportAdapter
    {
        protected new MeasurementCsvReader CsvReader
        {
            get => base.CsvReader as MeasurementCsvReader;
            set => base.CsvReader = value;
        }
        protected new MeasurementReportParameters ReportParameters { get; set; }

        
        public MeasurementReportAdapter(
            ReportAdapterParameters reportAdapterParameters,
            IReportRepository reportRepository,
            ILogger<ReportAdapter.ReportAdapter> logger)
            : base(
                reportAdapterParameters,
                reportRepository, logger)
        {
            CsvReader = new MeasurementCsvReader();
            ReportParameters = (MeasurementReportParameters)reportAdapterParameters.ReportParameters;
        }
        
    }
}