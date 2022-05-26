namespace ChartGeneratorModels.ChartData;

public class HourlyDamBatteryChartData : global::ChartGeneratorModels.ChartGeneratorModels.ChartData
{
    public Dictionary<int, double> Dam { get; set; }
    public Dictionary<int, double> BatteryPower { get; set; }
}