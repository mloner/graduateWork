namespace ReportingFramework.Dto.GlobalSettings
{
    public class GlobalSettings
    {
        public string DecimalSeparator { get; set; }
        public string ThousandsSeparator { get; set; }
        public ReportVariables Variables { get; set; }
        public string Language { get; set; }
        //public ChartGeneratorSettings ChartGeneratorSettings { get; set; }
        public string DateFormat { get; set; }
        public string TimeFormat { get; set; }
        public string CompanyName { get; set; }
        public string Logo { get; set; }
    }
}