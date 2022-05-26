namespace SectionModels.Pdf.SectionModels.SimulationReports.DataModels;

public class DecisionTable
{
    public List<DecisionTableItem> Items { get; set; }
}

public class DecisionTableItem
{
    public double BatteryPower { get; set; }
    public double BatteryCapacity { get; set; }
    
    public double SimpleBattery { get; set; }
    public bool IsSimpleBatteryBest { get; set; }
    
    public double SmartBattery { get; set; }
    public bool IsSmartBatteryBest { get; set; }
}