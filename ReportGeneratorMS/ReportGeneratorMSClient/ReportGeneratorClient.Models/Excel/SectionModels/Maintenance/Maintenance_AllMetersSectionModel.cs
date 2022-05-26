using SectionModels.ReportObjects.Tables;

namespace SectionModels.Excel.SectionModels.Maintenance;

public class Maintenance_AllMetersSectionModel : ExcelSectionModel
{
    public Maintenance_AllMetersSectionModel()
    {
        Subtype = (int) ExcelSectionEnum.Maintenance_AllMeters;
    }
    
    public MetersTable MetersTable { get; set; }
}