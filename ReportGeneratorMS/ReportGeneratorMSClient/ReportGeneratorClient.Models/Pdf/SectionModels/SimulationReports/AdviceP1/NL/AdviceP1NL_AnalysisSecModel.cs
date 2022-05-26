using ChartGeneratorModels;

namespace SectionModels.Pdf.SectionModels.SimulationReports.AdviceP1.NL;

public class AdviceP1NL_AnalysisSecModel : PdfSectionModel
{
    public ElectMark ElectMark { get; set; }
    public double AvgBuyPrice { get; set; }
    public double AvgSellPrice { get; set; }
    public AdviceP1NL_AnalysisSecModel()
    {
        Subtype = (int) PdfSectionEnum.AdviceP1NL_Analysis;

        ElectMark = new ElectMark();
    }
    
}

    
public class ElectMark
{
    public ChartRequestDataBase Chart { get; set; }
}