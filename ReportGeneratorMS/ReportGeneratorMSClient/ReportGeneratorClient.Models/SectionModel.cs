namespace SectionModels;

public class SectionModel
{
    public int Type {get; init; }
    public int Subtype {get; init; }
    public Dictionary<string, string> CustomParameters { get; set; }
}