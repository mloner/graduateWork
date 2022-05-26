

using ReportingFramework.Common;
using ReportingFramework.Dto;

namespace Project1
{
    public static class ReportFormatSectionHelperHelper
    {
        public static ReportFormatSectionHelper GetReportFormatSectionHelper(int reportFormat)
        {
            switch ((ReportFormatEnum)reportFormat)
            {
                case ReportFormatEnum.Pdf:
                    throw new Exception();
                case ReportFormatEnum.Excel:
                    return new ExcelReportFormatSectionHelper();
            }
        }
    }
}