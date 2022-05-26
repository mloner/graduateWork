using System.ComponentModel;

namespace ReportingFramework.Dto
{
    public enum PdfSectionStyleEnum
    {
        [Description("TitlePage")]
        TitlePage = 0,
        
        [Description("Default")]
        Default = 1,
        
        [Description("Appendix")]
        Appendix = 2,
        
        [Description("Subsection")]
        Subsection = 3
    }
}