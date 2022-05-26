using System;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using CugReportMicroservice.Dtos.ReportTypeEnums;
using Microsoft.Extensions.DependencyInjection;
using ReportingFramework.ReportTypesAdapter.AlgoComp;
using ReportingFramework.ReportTypesAdapter.DQValid;
using ReportingFramework.ReportTypesAdapter.Maintenance;
using ReportingFramework.ReportTypesAdapter.SimulationReports.AdviceP1InvReport.BE;
using ReportingFramework.ReportTypesAdapter.SimulationReports.AdviceP1InvReport.NL;
using ReportingFramework.ReportTypesAdapter.SimulationReports.AdviceP1Report.BE;
using ReportingFramework.ReportTypesAdapter.SimulationReports.AdviceP1Report.NL;
using ReportingFramework.ReportTypesAdapter.SimulationReports.MeasurementReport.BE;
using ReportingFramework.ReportTypesAdapter.SimulationReports.SavingsReport.BE;
using ReportingFramework.ReportTypesAdapter.SimulationReports.MeasurementReport.NL;
using ReportingFramework.ReportTypesAdapter.SimulationReports.SavingsReport.NL;
using SectionModels;

namespace ReportingFramework
{
    public static class ReportAdapterHelper
    {
        public static ReportAdapter.ReportAdapter GetReportAdapter(
            int reportFormatId,
            ReportAdapterParameters reportAdapterParameters,
            int reportType,
            IServiceProvider serviceProvider)
        {
            var fmtType = (ReportFormatEnum)reportFormatId;
            switch (fmtType)
            {
                case ReportFormatEnum.Pdf:
                    var pdfReportType = (PdfReportTypeEnum)reportType;
                    switch (pdfReportType)
                    {
                        //Algo comparison
                        case PdfReportTypeEnum.AlgoComp:
                            return ActivatorUtilities.CreateInstance<AlgoCompReportAdapter>(serviceProvider, reportAdapterParameters);
                        //Measurement
                        case PdfReportTypeEnum.Measurement_BE:
                            return ActivatorUtilities.CreateInstance<MeasurementBEReportAdapter>(serviceProvider, reportAdapterParameters);
                        case PdfReportTypeEnum.Measurement_NL:
                            return ActivatorUtilities.CreateInstance<MeasurementNLReportAdapter>(serviceProvider, reportAdapterParameters);
                        //Savings
                        case PdfReportTypeEnum.Savings_BE:
                            return ActivatorUtilities.CreateInstance<SavingsBEReportAdapter>(serviceProvider, reportAdapterParameters);
                        case PdfReportTypeEnum.Savings_NL:
                            return ActivatorUtilities.CreateInstance<SavingsNLReportAdapter>(serviceProvider, reportAdapterParameters);
                        //AdviceP1
                        case PdfReportTypeEnum.AdviceP1_BE:
                            return ActivatorUtilities.CreateInstance<AdviceP1BEReportAdapter>(serviceProvider, reportAdapterParameters);
                        case PdfReportTypeEnum.AdviceP1_NL:
                            return ActivatorUtilities.CreateInstance<AdviceP1NLReportAdapter>(serviceProvider, reportAdapterParameters);
                        //AdviceP1Inv
                        case PdfReportTypeEnum.AdviceP1Inv_BE:
                            return ActivatorUtilities.CreateInstance<AdviceP1InvBEReportAdapter>(serviceProvider, reportAdapterParameters);
                        case PdfReportTypeEnum.AdviceP1Inv_NL:
                            return ActivatorUtilities.CreateInstance<AdviceP1InvNLReportAdapter>(serviceProvider, reportAdapterParameters);
                        
                        // // //Bat sim
                        // // case PdfReportTypeEnum.BatSim_Default_BE:
                        // //     return BatSimDefaultBEReportAdapterHelper.GetReportAdapter(reportAdapterParameters);
                        // // case PdfReportTypeEnum.BatSim_Default_NL:
                        // //     return BatSimDefaultNLReportAdapterHelper.GetReportAdapter(reportAdapterParameters);
                        // // case PdfReportTypeEnum.BatSim_Bliq_BE:
                        // //     return BatSimBliqBEReportAdapterHelper.GetReportAdapter(reportAdapterParameters);
                        // // case PdfReportTypeEnum.BatSim_Bliq_Nl:
                        // //     return BatSimBliqNLReportAdapterHelper.GetReportAdapter(reportAdapterParameters);
                        // case PdfReportTypeEnum.BatSimShort_Default_BE:
                        //     return BatSimShortDefaultBEReportAdapterHelper.GetReportAdapter(reportAdapterParameters, serviceProvider);
                        // // case PdfReportTypeEnum.BatSimShort_Bliq_NL:
                        // //     return BatSimShortBliqNLReportAdapterHelper.GetReportAdapter(reportAdapterParameters);
                        // // //Heating savings
                        // // case PdfReportTypeEnum.HeatSav:
                        // //     return HeatSavReportAdapterHelper.GetReportAdapter(reportAdapterParameters);
                        // case PdfReportTypeEnum.Measurement_Default_BE:
                        //     return MeasurementBEReportAdapterHelper.GetReportAdapter(reportAdapterParameters, serviceProvider);
                        default:
                            throw new Exception("GetReportAdapter FAILED (switch pdfReportType)");
                    }
                case ReportFormatEnum.Excel:
                    var excelReportType = (ExcelReportTypeEnum)reportType;
                    switch (excelReportType)
                    {
                        case ExcelReportTypeEnum.MaintenanceReport:
                            return ActivatorUtilities.CreateInstance<MaintenanceReportAdapter>(serviceProvider, reportAdapterParameters);
                        // case ExcelReportTypeEnum.MCEM:
                        //     return MCEMReportingAdapterHelper.GetReportAdapter(reportAdapterParameters, serviceProvider);
                        // case ExcelReportTypeEnum.CugSavingsReport:
                        //     return CugSavingsReportAdapterHelper.GetReportAdapter(reportAdapterParameters);
                        case ExcelReportTypeEnum.DQValidReport:
                            return ActivatorUtilities.CreateInstance<DQValidReportAdapter>(serviceProvider, reportAdapterParameters);

                        default:
                            throw new Exception("GetReportAdapter FAILED (switch excelReportType)");
                    }
                default:
                    throw new Exception();
            }
        }
    
    }
}