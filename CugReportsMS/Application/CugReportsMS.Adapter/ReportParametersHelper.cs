using System;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using CugReportMicroservice.Dtos.ReportTypeEnums;
using Newtonsoft.Json;
using ReportingFramework.ReportTypesAdapter.AlgoComp;
using ReportingFramework.ReportTypesAdapter.DQValid;
using ReportingFramework.ReportTypesAdapter.Maintenance;
using ReportingFramework.ReportTypesAdapter.SimulationReports.AdviceP1InvReport;
using ReportingFramework.ReportTypesAdapter.SimulationReports.AdviceP1Report;
using ReportingFramework.ReportTypesAdapter.SimulationReports.MeasurementReport;
using ReportingFramework.ReportTypesAdapter.SimulationReports.SavingsReport;
using SectionModels;

namespace ReportingFramework
{
    public static class ReportParametersHelper
    {
        public static ReportParameters GetReportParameters(
            int reportFormatType,
            int reportType,
            string reportParametersJson)
        {
            var fmtType = (ReportFormatEnum)reportFormatType;

            switch (fmtType)
            {
                case ReportFormatEnum.Pdf:
                    var pdfReportType = (PdfReportTypeEnum)reportType;
                    switch (pdfReportType)
                    {
                        //Algo comp
                        case PdfReportTypeEnum.AlgoComp:
                            return JsonConvert.DeserializeObject<AlgoCompReportParameters>(reportParametersJson);
                        
                        //measurement
                        case PdfReportTypeEnum.Measurement_BE:
                            return JsonConvert.DeserializeObject<MeasurementReportParameters>(reportParametersJson);
                        case PdfReportTypeEnum.Measurement_NL:
                            return JsonConvert.DeserializeObject<MeasurementReportParameters>(reportParametersJson);
                        
                        //Savings
                        case PdfReportTypeEnum.Savings_BE:
                            return JsonConvert.DeserializeObject<SavingsReportParameters>(reportParametersJson);
                        case PdfReportTypeEnum.Savings_NL:
                            return JsonConvert.DeserializeObject<SavingsReportParameters>(reportParametersJson);
                        
                        //Advice P1
                        case PdfReportTypeEnum.AdviceP1_BE:
                            return JsonConvert.DeserializeObject<AdviceP1ReportParameters>(reportParametersJson);
                        case PdfReportTypeEnum.AdviceP1_NL:
                            return JsonConvert.DeserializeObject<AdviceP1ReportParameters>(reportParametersJson);
                        
                        //Advice P1 Inv
                        case PdfReportTypeEnum.AdviceP1Inv_BE:
                            return JsonConvert.DeserializeObject<AdviceP1InvReportParameters>(reportParametersJson);
                        case PdfReportTypeEnum.AdviceP1Inv_NL:
                            return JsonConvert.DeserializeObject<AdviceP1InvReportParameters>(reportParametersJson);

                        
                        case PdfReportTypeEnum.BatSimShort_Default_BE:
                            break;
                    }
                    break;
                
                case ReportFormatEnum.Excel:
                    var excelReportType = (ExcelReportTypeEnum)reportType;
                    switch (excelReportType)
                    {
                        case ExcelReportTypeEnum.MaintenanceReport:
                            return JsonConvert.DeserializeObject<MaintenanceReportParameters>(reportParametersJson);
                        case ExcelReportTypeEnum.DQValidReport:
                            return JsonConvert.DeserializeObject<DQValidReportParameters>(reportParametersJson);
                        case ExcelReportTypeEnum.MCEM:
                            break;
                    }
                    break;
            }
 
            throw new Exception("GetReportParameters error");
        }
    }
}