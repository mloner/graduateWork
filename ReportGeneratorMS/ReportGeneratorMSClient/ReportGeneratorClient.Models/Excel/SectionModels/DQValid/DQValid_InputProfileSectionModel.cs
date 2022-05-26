namespace SectionModels.Excel.SectionModels.DQValid;

public class DQValid_InputProfileSectionModel : ExcelSectionModel
{
    public List<Dictionary<string, string>> Data { get; set; }
    public DQValid_InputProfileSectionModel()
    {
        Subtype = (int) ExcelSectionEnum.DQValid_InputProfile;
        Data = new List<Dictionary<string, string>>();
    }
    
}