using ChartGeneratorModels;

namespace SectionModels.Pdf.SectionModels.SimulationReports.Measurement.NL;

public class MeasurementNL_AnalysisSecModel : PdfSectionModel
{
    public SelfCons SelfCons { get; set; }
    public ElectMark ElectMark { get; set; }
    public double AvgBuyPrice { get; set; }
    public double AvgSellPrice { get; set; }
    public MeasurementNL_AnalysisSecModel()
    {
        Subtype = (int) PdfSectionEnum.MeasurementNL_Analysis;

        SelfCons = new SelfCons();
        ElectMark = new ElectMark();
    }
    
}

public class SelfCons
{
    public ChartRequestDataBase NoBatteryChart { get; set; }
    public ChartRequestDataBase SmartBatteryChart { get; set; }
}

public class ElectMark
{
    public ChartRequestDataBase Chart { get; set; }
}