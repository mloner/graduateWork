using ChartGeneratorModels;

namespace SectionModels.Pdf.SectionModels.SimulationReports.AdviceP1.BE;

public class AdviceP1BE_AnalysisSecModel : PdfSectionModel
{
    public PeakShav PeakShav { get; set; }
    public ElectMark ElectMark { get; set; }
    public double AvgBuyPrice { get; set; }
    public double AvgSellPrice { get; set; }
    public AdviceP1BE_AnalysisSecModel()
    {
        Subtype = (int) PdfSectionEnum.AdviceP1BE_Analysis;

        PeakShav = new PeakShav();
        ElectMark = new ElectMark();
    }
    
}

    
public class PeakShav
{
    public ChartRequestDataBase NoBatteryChart { get; set; }
    public ChartRequestDataBase SmartBatteryChart { get; set; }
}
    
public class ElectMark
{
    public ChartRequestDataBase Chart { get; set; }
}