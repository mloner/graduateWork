namespace SectionModels.Excel.SectionModels.DQValid;

public class DQValid_OutliersSectionModel : ExcelSectionModel
{
    public List<Dictionary<string, string>> Data { get; set; }
    public DQValid_OutliersSectionModel()
    {
        Subtype = (int) ExcelSectionEnum.DQValid_Outliers;
        Data = new List<Dictionary<string, string>>();
    }
    
}