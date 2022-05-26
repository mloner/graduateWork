namespace SectionModels.Excel.SectionModels.DQValid;

public class DQValid_InputTypeSectionModel : ExcelSectionModel
{
    public List<Dictionary<string, string>> Data { get; set; }
    public DQValid_InputTypeSectionModel()
    {
        Subtype = (int) ExcelSectionEnum.DQValid_InputType;
        Data = new List<Dictionary<string, string>>();
    }
    
}