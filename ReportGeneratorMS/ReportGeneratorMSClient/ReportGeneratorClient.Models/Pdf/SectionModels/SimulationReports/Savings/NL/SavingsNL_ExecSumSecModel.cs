using SectionModels.Pdf.SectionModels.SimulationReports.DataModels;

namespace SectionModels.Pdf.SectionModels.SimulationReports.Savings.NL;

public class SavingsNL_ExecSumSecModel : PdfSectionModel
{
    public SavingsNL_ExecSumSecModel()
    {
        Subtype = (int)PdfSectionEnum.SavingsNL_ExecSum;

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