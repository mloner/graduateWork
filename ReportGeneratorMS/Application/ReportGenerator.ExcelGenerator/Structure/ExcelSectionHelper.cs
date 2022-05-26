using System;
using ExcelGenerator.Structure.Sections.DQValid;
using ExcelGenerator.Structure.Sections.Maintenance;
using SectionModels.Excel;

namespace ExcelGenerator.Structure
{
    public static class ExcelSectionHelper
    {
        public static ExcelReportSection GetSection(int sectionType)
        {
            switch ((ExcelSectionEnum)sectionType)
            {
                //Maintenance
                case ExcelSectionEnum.Maintenance_AllMeters:
                    return new Maintenance_AllMetersSection();
                case ExcelSectionEnum.Maintenance_CugGapsInputs:
                    return new Maintenance_CugGapsInputErrorsSection();
                case ExcelSectionEnum.Maintenance_MetersByMedia:
                    return new Maintenance_MetersByMediaSection();
                
                //DQValid
                case ExcelSectionEnum.DQValid_Overview:
                    return new DQValid_OverviewSection();
                case ExcelSectionEnum.DQValid_DataFromFuture:
                    return new DQValid_DataFromFutureSection();
                case ExcelSectionEnum.DQValid_Gaps:
                    return new DQValid_GapsSection();
                case ExcelSectionEnum.DQValid_Outliers:
                    return new DQValid_OutliersSection();
                case ExcelSectionEnum.DQValid_Anomalies:
                    return new DQValid_AnomaliesSection();
                case ExcelSectionEnum.DQValid_InputType:
                    return new DQValid_InputTypeSection();
                case ExcelSectionEnum.DQValid_InputProfile:
                    return new DQValid_InputProfileSection();
                
                // case ExcelSectionEnum.AllCugsSummary:
                //     return new AllCugsSummarySectionHelper();
                // case ExcelSectionEnum.CugReport:
                //     return new CugReportSectionHelper();
                default:
                    throw new Exception("GetSection");
            }
        }
    }
}