using SectionModels.Pdf.SectionModels.SimulationReports.DataModels;

namespace SectionModels.Pdf.SectionModels.SimulationReports.AdviceP1Inv.BE;

public class AdviceP1InvBE_ExecSumSecModel : PdfSectionModel
{
    public AdviceP1InvBE_ExecSumSecModel()
    {
        Subtype = (int)PdfSectionEnum.AdviceP1InvBE_ExecSum;

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