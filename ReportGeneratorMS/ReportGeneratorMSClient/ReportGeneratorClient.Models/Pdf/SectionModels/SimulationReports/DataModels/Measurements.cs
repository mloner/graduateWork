namespace SectionModels.Pdf.SectionModels.SimulationReports.DataModels;

public class Measurements
{
    public DateTime FirstMeasurementDate { get; set; }
    public int MeasurementCount { get; set; }
    public double Consumption { get; set; }
    public double Production { get; set; }
    public double Injection { get; set; }
}