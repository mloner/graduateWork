using SectionModels.Pdf.SectionModels.SimulationReports.DataModels;

namespace SectionModels.Pdf.SectionModels.SimulationReports.AdviceP1.NL;

public class AdviceP1NL_ExecSumSecModel : PdfSectionModel
{
    public AdviceP1NL_ExecSumSecModel()
    {
        Subtype = (int)PdfSectionEnum.AdviceP1NL_ExecSum;

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