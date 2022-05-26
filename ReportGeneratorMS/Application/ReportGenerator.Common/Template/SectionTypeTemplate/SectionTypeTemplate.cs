using ReportingFramework.Dto;

namespace ReportingFramework.Common.Template.SectionTypeTemplate
{
    public class SectionTypeTemplate
    {
        public PdfSectionStyleEnum Name { get; set; }
        public Margins Margins { get; set; }
        public string BackgroundImage { get; set; }
        public Header Header { get; set; }
        public Footer Footer { get; set; }
        public Title Title { get; set; }
    }
}