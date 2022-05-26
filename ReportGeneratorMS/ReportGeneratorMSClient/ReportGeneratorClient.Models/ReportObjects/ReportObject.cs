namespace SectionModels.ReportObjects;

public abstract class ReportObject
{
    public ReportObject()
    {
        Parameters = new Dictionary<string, string>();
    }
    public int Type { get; init; }
    public int Subtype { get; init; }
    public Dictionary<string, string> Parameters { get; set; }
}