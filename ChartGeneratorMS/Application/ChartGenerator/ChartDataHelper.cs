using System;
using ChartGeneratorModels.ChartData;
using ChartGeneratorModels.ChartGeneratorModels;
using Newtonsoft.Json;

namespace ChartGenerator;

public static class ChartDataHelper
{
    public static ChartData GetChartData(ChartEnum chartEnum, string chartDataJson)
    {
        switch (chartEnum)
        {
            case ChartEnum.AverageHourly:
                return JsonConvert.DeserializeObject<AverageHourlyChartData>(chartDataJson);
            case ChartEnum.PeakShavMonth:
                return JsonConvert.DeserializeObject<PeakShavingMonthChartData>(chartDataJson);
            case ChartEnum.PieChart:
                return JsonConvert.DeserializeObject<PieChartData>(chartDataJson);
            case ChartEnum.PeakShavMonthlyMultiComp:
                return JsonConvert.DeserializeObject<PeakShavingMonthMultiChartData>(chartDataJson);
            case ChartEnum.HourlyDamBattery:
                return JsonConvert.DeserializeObject<HourlyDamBatteryChartData>(chartDataJson);
            default: throw new Exception();
        }
    }
}