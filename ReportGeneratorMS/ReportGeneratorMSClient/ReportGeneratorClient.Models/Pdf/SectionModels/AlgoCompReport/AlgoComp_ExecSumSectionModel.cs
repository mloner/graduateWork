namespace SectionModels.Pdf.SectionModels.AlgoCompReport;

public class AlgoComp_ExecSumSectionModel : PdfSectionModel
{
    public BasicInfo BasicInfo { get; set; }
    public double Savings { get; set; }
    public AlgoComp_ExecSumSectionModel()
    { 
        Subtype = (int)PdfSectionEnum.AlgoComp_ExecSum;
    }
}

public class BasicInfo
{
    public string BuildingName { get; set; }
    public string Email { get; set; }
    public DateTime ReportDate { get; set; }
    public DateTime SimulationPeriodStart { get; set; }
    public DateTime SimulationPeriodEnd { get; set; }
    public int SimulatedDaysNumer { get; set; }
    public string BatteryModel { get; set; }
    public double BatteryCapacity { get; set; }
}