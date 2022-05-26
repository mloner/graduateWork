using System;
using SectionModels;

namespace ReportingFramework.Common.TemplateLoader
{
    public static class TemplateLoaderHelper
    {
        public static ITemplateLoader GetTemplateLoader(ReportFormatEnum reportFormat)
        {
            switch (reportFormat)
            {
                case ReportFormatEnum.Pdf:
                    return new PdfTemplateLoader();
                case ReportFormatEnum.Excel:
                    return new ExcelTemplateLoader();
                default:
                    throw new Exception();
            }
        }
    }
}