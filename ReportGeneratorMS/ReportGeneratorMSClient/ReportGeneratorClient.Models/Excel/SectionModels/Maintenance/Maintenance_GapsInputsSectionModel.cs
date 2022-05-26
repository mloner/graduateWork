using SectionModels.ReportObjects.Tables;

namespace SectionModels.Excel.SectionModels.Maintenance;

public class Maintenance_GapsInputsSectionModel : ExcelSectionModel
{
    public CugGapsInputsTable CugGapsInputsTable { get; set; }
    public Maintenance_GapsInputsSectionModel()
    {
        Subtype = (int) ExcelSectionEnum.Maintenance_CugGapsInputs;
    }
}