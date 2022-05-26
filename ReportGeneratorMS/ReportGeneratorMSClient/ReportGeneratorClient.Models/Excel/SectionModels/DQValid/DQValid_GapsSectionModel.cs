namespace SectionModels.Excel.SectionModels.DQValid;

public class DQValid_GapsSectionModel : ExcelSectionModel
{
    public List<Dictionary<string, string>> Data { get; set; }
    public DQValid_GapsSectionModel()
    {
        Subtype = (int) ExcelSectionEnum.DQValid_Gaps;
        Data = new List<Dictionary<string, string>>();
    }
    
}