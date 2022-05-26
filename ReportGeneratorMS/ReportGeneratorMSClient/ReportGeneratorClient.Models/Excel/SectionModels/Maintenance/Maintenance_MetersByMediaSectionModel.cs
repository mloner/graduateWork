using SectionModels.ReportObjects.Tables;

namespace SectionModels.Excel.SectionModels.Maintenance;

public class Maintenance_MetersByMediaSectionModel : ExcelSectionModel
{
    public MetersByMediaTable MetersByMediaTable { get; set; }
    public Maintenance_MetersByMediaSectionModel()
    {
        Subtype = (int) ExcelSectionEnum.Maintenance_MetersByMedia;
    }
}