using ChartGeneratorModels;

namespace SectionModels.Pdf.SectionModels.AlgoCompReport;

public class AlgoComp_PeakShavCompSectionModel : PdfSectionModel
{
    public RefCase RefCase { get; set; }
    public BestCase BestCase { get; set; }
    
    public AlgoComp_PeakShavCompSectionModel()
    {
        Subtype = (int)PdfSectionEnum.AlgoComp_PeakShavComp;
    }
}

public class RefCase
{
    public ChartRequestDataBase Chart { get; set; }
    public double Peak { get; set; }
    public DateTime PeakDateTimeStart { get; set; }
    public DateTime PeakDateTimeEnd { get; set; }
    public int TimeGate { get; set; }
    public double CapTariff { get; set; }
}

public class BestCase
{
    public ChartRequestDataBase Chart { get; set; }
    public double Peak { get; set; }
    public double CapTariff { get; set; }
}