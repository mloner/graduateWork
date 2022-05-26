using System.Collections.Generic;
using CugReportMicroservice.Dtos;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using Microsoft.Extensions.Logging;
using ReportingFramework.ReportAdapter;
using SectionModels.Excel;

namespace ReportingFramework.ReportTypesAdapter.DQValid
{
    public class DQValidReportAdapter : ExcelReportAdapter
    {
        public new DQValidReportCsvReader CsvReader;
        public new DQValidReportParameters ReportParameters;
        public DQValidReportAdapter(
            ReportAdapterParameters reportAdapterParameters,
            IReportRepository reportRepository,
            ILogger<ReportAdapter.ReportAdapter>  logger)
            : base(reportAdapterParameters, reportRepository, logger)
        {
            ReportParameters = (DQValidReportParameters)reportAdapterParameters.ReportParameters;

            ExcelSections = new List<ExcelSectionEnum>()
            {
                ExcelSectionEnum.DQValid_Overview,
                ExcelSectionEnum.DQValid_DataFromFuture,
                ExcelSectionEnum.DQValid_Gaps,
                ExcelSectionEnum.DQValid_Outliers,
                ExcelSectionEnum.DQValid_Anomalies,
                ExcelSectionEnum.DQValid_InputType,
                ExcelSectionEnum.DQValid_InputProfile
            };
        }
        
        protected override void InitCommonReportData()
        {
            ReportCommonData.Add("Data", ReportParameters.CustomParameters.Data);
        }
    }
}