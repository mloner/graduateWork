using SectionModels.Pdf.SectionModels.SimulationReports.DataModels;

namespace SectionModels.Pdf.SectionModels.SimulationReports.Savings.BE;

public class SavingsBE_ExecSumSecModel : PdfSectionModel
{
    public SavingsBE_ExecSumSecModel()
    {
        Subtype = (int)PdfSectionEnum.SavingsBE_ExecSum;

        Location = new Location();
        Measurements = new Measurements();
        DecisionTable = new DecisionTable()
        {
            Items = new List<DecisionTableItem>()
        };
    }
    
    public Location Location { get; set; }
    public Measurements Measurements { get; set; }
    public DecisionTable DecisionTable { get; set; }
}