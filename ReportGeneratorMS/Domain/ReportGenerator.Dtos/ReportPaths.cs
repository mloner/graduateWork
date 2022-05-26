namespace ReportingFramework.Dto
{
    public class ReportPaths
    {
        // global
        public string Root { get; set; }
        public string Data { get; set; }
        public string Tasks { get; set; }
        public string CommonResources { get; set; }
        public string CommonResourcesImages { get; set; }
        public string CommonResourcesLogos { get; set; }
        public string CommonTextResourceNameSpace { get; set; }
        public string TextResourceNameSpaceTemplate { get; set; }
        public string CompaniesImages { get; set; }
        public string ExcelTemplates { get; set; }
        public string SectionResourcesNamespace { get; set; }

        // company
        public string CompanyImages { get; set; }
        public string CompanyBackgrounds { get; set; }
        public string CompanyIcons { get; set; }
        
        // report
        public string ReportDataFolder { get; set; }
        public string ReportCharts { get; set; }
        public string OutputFolder { get; set; }
        
        // each section
        public string SectionResources { get; set; }
        public string SectionImages { get; set; }
        public string SectionIcons { get; set; }
        public string SectionTextResourceNamespace { get; set; }
    }
}