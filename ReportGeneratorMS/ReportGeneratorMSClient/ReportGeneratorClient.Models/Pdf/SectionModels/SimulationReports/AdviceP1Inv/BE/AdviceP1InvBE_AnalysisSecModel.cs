﻿using ChartGeneratorModels;

namespace SectionModels.Pdf.SectionModels.SimulationReports.AdviceP1Inv.BE;

public class AdviceP1InvBE_AnalysisSecModel : PdfSectionModel
{
    public SelfCons SelfCons { get; set; }
    public PeakShav PeakShav { get; set; }
    public ElectMark ElectMark { get; set; }
    public double AvgBuyPrice { get; set; }
    public double AvgSellPrice { get; set; }
    public AdviceP1InvBE_AnalysisSecModel()
    {
        Subtype = (int) PdfSectionEnum.AdviceP1InvBE_Analysis;

        SelfCons = new SelfCons();
        PeakShav = new PeakShav();
        ElectMark = new ElectMark();
    }
    
}

public class SelfCons
{
    public ChartRequestDataBase NoBatteryChart { get; set; }
    public ChartRequestDataBase SmartBatteryChart { get; set; }
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