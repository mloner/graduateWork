namespace SectionModels.ReportObjects.Tables;

public class Table : ReportObject
{
    public Table()
    {
        Type = (int) ReportObjectTypeEnum.Table;
        Subtype = (int) TableTypeEnum.Default;
        Data = new List<Dictionary<string, string>>();
    }
    
    public List<Dictionary<string, string>> Data { get; set; }
}