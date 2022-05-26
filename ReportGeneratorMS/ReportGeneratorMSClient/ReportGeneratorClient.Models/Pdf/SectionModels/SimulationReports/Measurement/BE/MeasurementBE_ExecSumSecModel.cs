using SectionModels.Pdf.SectionModels.SimulationReports.DataModels;

namespace SectionModels.Pdf.SectionModels.SimulationReports.Measurement.BE;

public class MeasurementBE_ExecSumSecModel : PdfSectionModel
{
    public MeasurementBE_ExecSumSecModel()
    {
        Subtype = (int)PdfSectionEnum.MeasurementBE_ExecSum;

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