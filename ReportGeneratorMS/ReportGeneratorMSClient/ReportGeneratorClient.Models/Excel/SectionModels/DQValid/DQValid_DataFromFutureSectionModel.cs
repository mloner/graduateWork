namespace SectionModels.Excel.SectionModels.DQValid;

public class DQValid_DataFromFutureSectionModel : ExcelSectionModel
{
    public List<Dictionary<string, string>> Data { get; set; }
    public DQValid_DataFromFutureSectionModel()
    {
        Subtype = (int) ExcelSectionEnum.DQValid_DataFromFuture;
        Data = new List<Dictionary<string, string>>();
    }
}