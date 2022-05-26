using SectionModels.Pdf.SectionModels.SimulationReports.DataModels;

namespace SectionModels.Pdf.SectionModels.SimulationReports.AdviceP1Inv.NL;

public class AdviceP1InvNL_ExecSumSecModel : PdfSectionModel
{
    public AdviceP1InvNL_ExecSumSecModel()
    {
        Subtype = (int)PdfSectionEnum.AdviceP1InvNL_ExecSum;

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