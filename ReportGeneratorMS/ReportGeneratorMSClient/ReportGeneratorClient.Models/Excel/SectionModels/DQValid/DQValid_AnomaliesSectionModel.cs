namespace SectionModels.Excel.SectionModels.DQValid;

public class DQValid_AnomaliesSectionModel : ExcelSectionModel
{
    public List<Dictionary<string, string>> Data { get; set; }
    public DQValid_AnomaliesSectionModel()
    {
        Subtype = (int) ExcelSectionEnum.DQValid_Anomalies;
        Data = new List<Dictionary<string, string>>();
    }
}