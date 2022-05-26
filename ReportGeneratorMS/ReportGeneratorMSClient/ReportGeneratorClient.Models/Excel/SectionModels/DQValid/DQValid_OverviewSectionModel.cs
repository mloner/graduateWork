namespace SectionModels.Excel.SectionModels.DQValid;

public class DQValid_OverviewSectionModel : ExcelSectionModel
{
    public List<Dictionary<string, string>> Data { get; set; }
    public DQValid_OverviewSectionModel()
    {
        Subtype = (int) ExcelSectionEnum.DQValid_Overview;
        Data = new List<Dictionary<string, string>>();
    }
}