namespace SectionModels.Pdf.SectionModels;

public class TitleSectionModel : PdfSectionModel
{
    public DateTime ReportDate { get; set; }
    public string CustomerName { get; set; }
    public TitleSectionModel()
    {
    }
}