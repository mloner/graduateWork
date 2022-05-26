namespace SectionModels
{
    public class ReportModel
    {
        public ReportFormatEnum ReportFormat { get; set; }
        public string OutputFormat { get; set; }
        public int TemplateId { get; set; }
        public int LanguageId { get; set; }
        public List<SectionModel> Sections { get; set; }
        //public string ReportName { get; set; }
    }
}