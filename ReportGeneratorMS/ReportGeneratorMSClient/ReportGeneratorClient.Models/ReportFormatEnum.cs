using System.ComponentModel;

namespace SectionModels
{
    public enum ReportFormatEnum
    {
        [Description("Pdf")]
        Pdf = 1,
        
        [Description("Excel")]
        Excel = 2
    }
}