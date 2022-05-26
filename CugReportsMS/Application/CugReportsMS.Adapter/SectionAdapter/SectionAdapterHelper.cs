using System;
using ReportingFramework.SectionAdapter.AdviceP1BE;
using ReportingFramework.SectionAdapter.AdviceP1InvBE;
using ReportingFramework.SectionAdapter.AdviceP1InvNL;
using ReportingFramework.SectionAdapter.AdviceP1NL;
using ReportingFramework.SectionAdapter.AlgoCompReport;
using ReportingFramework.SectionAdapter.DQValid;
using ReportingFramework.SectionAdapter.MaintenanceReport;
using ReportingFramework.SectionAdapter.MCEMReport.AllCugsSummary;
using ReportingFramework.SectionAdapter.MCEMReport.CugReportSectionAdapter;
using ReportingFramework.SectionAdapter.MeasurementBE;
using ReportingFramework.SectionAdapter.MeasurementNL;
using ReportingFramework.SectionAdapter.SavingsBE;
using ReportingFramework.SectionAdapter.SavingsNL;
using SectionModels;
using SectionModels.Excel;
using SectionModels.Pdf;

namespace ReportingFramework.SectionAdapter
{
    public class SectionAdapterHelper
    {
        public SectionAdapter GetSectionAdapter(ReportFormatEnum reportFormatEnum, int sectionTypeNum)
        {
            ISectionAdapterWithVersionHelper sectionAdapterWithVersionHelper;
            try
            {
                switch (reportFormatEnum)
                {
                    case ReportFormatEnum.Excel:
                        switch ((ExcelSectionEnum)sectionTypeNum)
                        {
                            //excel Maintenance report
                            case ExcelSectionEnum.Maintenance_CugGapsInputs:
                                return new Maintenance_GapsInputSectionAdapter();
                            case ExcelSectionEnum.Maintenance_AllMeters:
                                return new Maintenance_AllMetersSectionAdapter();
                            case ExcelSectionEnum.Maintenance_MetersByMedia:
                                return new Maintenance_MetersByMediaSectionAdapter();

                            //excel Multicug report
                            case ExcelSectionEnum.MCEM_AllCugsSummary:
                                sectionAdapterWithVersionHelper = new AllCugsSummarySectionAdapterHelper();
                                break;
                            case ExcelSectionEnum.MCEM_CugReport:
                                sectionAdapterWithVersionHelper = new CugReportSectionAdapterHelper();
                                break;
                            
                            
                            // //Cug savings report
                            // case ExcelSectionNameEnum.CugSavingsSheet_CugSavings:
                            //     sectionAdapterWithVersionHelper = new CugSavingsSectionAdapterHelper();
                            //     break;
                            //
                            // case ExcelSectionNameEnum.DataSheet_CugSavings:
                            //     sectionAdapterWithVersionHelper = new CugSavingsDataSheetSectionAdapterHelper();
                            //     break;
                            //
                            //DQValid report
                            case ExcelSectionEnum.DQValid_Overview:
                                return new DQValid_OverviewSectionAdapter();
                            case ExcelSectionEnum.DQValid_DataFromFuture:
                                 return new DQValid_DataFromFutureSectionAdapter();
                            case ExcelSectionEnum.DQValid_Gaps:
                                 return new DQValid_GapsSectionAdapter();
                            case ExcelSectionEnum.DQValid_Outliers:
                                 return new DQValid_OutliersSectionAdapter();
                            case ExcelSectionEnum.DQValid_Anomalies:
                                return new DQValid_AnomaliesSectionAdapter();
                            case ExcelSectionEnum.DQValid_InputType:
                                return new DQValid_InputTypeSectionAdapter();
                            case ExcelSectionEnum.DQValid_InputProfile:
                                return new DQValid_InputProfileSectionAdapter();

                            default:
                                throw new Exception();
                        }

                        break;
                    case ReportFormatEnum.Pdf:
                        switch ((PdfSectionEnum)sectionTypeNum)
                        {
                            // case PdfSectionEnum.Measurement_Title:
                            //     return new TitleSecAdap();
                            
                            // algo comp
                            case PdfSectionEnum.AlgoComp_ExecSum:
                                return new AlgoComp_ExecSumSecAdap();
                            case PdfSectionEnum.AlgoComp_PeakShavComp:
                                return new AlgoComp_PeakShavCompSecAdap();
                            
                            // measurement report
                            // BE
                            case PdfSectionEnum.MeasurementBE_Title:
                                return new MeasurementBE_TitleSecAdap();
                            case PdfSectionEnum.MeasurementBE_ExecSum:
                                return new MeasurementBE_ExecSumSecAdap();
                            case PdfSectionEnum.MeasurementBE_Analysis:
                                return new MeasurementBE_AnalysisSecAdap();
                            // NL
                            case PdfSectionEnum.MeasurementNL_Title:
                                return new MeasurementNL_TitleSecAdap();
                            case PdfSectionEnum.MeasurementNL_ExecSum:
                                return new MeasurementNL_ExecSumSecAdap();
                            case PdfSectionEnum.MeasurementNL_Analysis:
                                return new MeasurementNL_AnalysisSecAdap();

                            // savings report
                            // BE
                            case PdfSectionEnum.SavingsBE_Title:
                                return new SavingsBE_TitleSecAdap();
                            case PdfSectionEnum.SavingsBE_ExecSum:
                                return new SavingsBE_ExecSumSecAdap();
                            case PdfSectionEnum.SavingsBE_Analysis:
                                return new SavingsBE_AnalysisSecAdap();
                            // NL
                            case PdfSectionEnum.SavingsNL_Title:
                                return new SavingsNL_TitleSecAdap();
                            case PdfSectionEnum.SavingsNL_ExecSum:
                                return new SavingsNL_ExecSumSecAdap();
                            case PdfSectionEnum.SavingsNL_Analysis:
                                return new SavingsNL_AnalysisSecAdap();
                            
                            // adviceP1 report
                            // BE
                            case PdfSectionEnum.AdviceP1BE_Title:
                                return new AdviceP1BE_TitleSecAdap();
                            case PdfSectionEnum.AdviceP1BE_ExecSum:
                                return new AdviceP1BE_ExecSumSecAdap();
                            case PdfSectionEnum.AdviceP1BE_Analysis:
                                return new AdviceP1BE_AnalysisSecAdap();
                            // NL
                            case PdfSectionEnum.AdviceP1NL_Title:
                                return new AdviceP1NL_TitleSecAdap();
                            case PdfSectionEnum.AdviceP1NL_ExecSum:
                                return new AdviceP1NL_ExecSumSecAdap();
                            case PdfSectionEnum.AdviceP1NL_Analysis:
                                return new AdviceP1NL_AnalysisSecAdap();
                            
                            // adviceP1Inv report
                            // BE
                            case PdfSectionEnum.AdviceP1InvBE_Title:
                                return new AdviceP1InvBE_TitleSecAdap();
                            case PdfSectionEnum.AdviceP1InvBE_ExecSum:
                                return new AdviceP1InvBE_ExecSumSecAdap();
                            case PdfSectionEnum.AdviceP1InvBE_Analysis:
                                return new AdviceP1InvBE_AnalysisSecAdap();
                            // NL
                            case PdfSectionEnum.AdviceP1InvNL_Title:
                                return new AdviceP1InvNL_TitleSecAdap();
                            case PdfSectionEnum.AdviceP1InvNL_ExecSum:
                                return new AdviceP1InvNL_ExecSumSecAdap();
                            case PdfSectionEnum.AdviceP1InvNL_Analysis:
                                return new AdviceP1InvNL_AnalysisSecAdap();
                            
                            default:
                                throw new Exception();
                        }

                        break;
                    default:
                        throw new Exception("SectionAdapterHelper");
                }
            }
            catch (Exception e)
            {
                throw new Exception("SectionAdapterHelper");
            }
            throw new Exception("SectionAdapterHelper");
            // return sectionAdapterWithVersionHelper.GetSectionAdapter(sectionVersion);
        }
    }
}