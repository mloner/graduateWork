namespace ReportingFramework.Dto
{
    public interface IReportParagraph : IReportObject
    {
        string Title { get; set; }
        string Text { get; set; }
    }
}