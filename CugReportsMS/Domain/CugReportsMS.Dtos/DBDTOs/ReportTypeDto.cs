namespace CugReportMicroservice.Dtos.DBDTOs
{
    public class ReportTypeDto
    {
        public int Id { get; set; }
        public int TypeNum { get; set; }
        public string Name { get; set; }
        public int FormatId { get; set; }
        public string OutputFormat { get; set; }
    }
}