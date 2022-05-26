using System;
using ExcelGenerator;
using Microsoft.Extensions.DependencyInjection;
using ReportingFramework;
using ReportingFramework.Dto;
using SectionModels;

namespace ReportGenerator
{
    public static class ReportGeneratorHelper
    {
        public static IReportGenerator GetReportGenerator(ReportFormatEnum reportFormatEnum, IServiceProvider serviceProvider)
        {
            
            switch (reportFormatEnum)
            {
                case ReportFormatEnum.Excel:
                    return ActivatorUtilities.CreateInstance<ExcelReportGenerator>(serviceProvider);
                case ReportFormatEnum.Pdf:
                    return ActivatorUtilities.CreateInstance<PdfReportGenerator>(serviceProvider);
                default:
                    throw new Exception();
            }
        }
    }
}