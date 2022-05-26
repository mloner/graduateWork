using SectionModels.Pdf.SectionModels.SimulationReports.DataModels;

namespace SectionModels.Pdf.SectionModels.SimulationReports.Measurement.NL;

public class MeasurementNL_ExecSumSecModel : PdfSectionModel
{
    public MeasurementNL_ExecSumSecModel()
    {
        Subtype = (int)PdfSectionEnum.MeasurementNL_ExecSum;

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