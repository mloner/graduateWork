using System;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using Newtonsoft.Json;
using ChartSettings = ChartGeneratorModels.ChartSettings.ChartSettings;

namespace ChartGenerator;

public static class ChartSettingsHelper
{
    public static ChartSettings GetChartSettings(ChartEnum chartEnum, string chartSettings)
    {
        switch (chartEnum)
        {
            case ChartEnum.AverageHourly:
                return JsonConvert.DeserializeObject<AverageHourlyChartSettings>(chartSettings);
            case ChartEnum.PeakShavMonth:
                return JsonConvert.DeserializeObject<PeakShavingMonthChartSettings>(chartSettings);
            case ChartEnum.PieChart:
                return JsonConvert.DeserializeObject<PieChartSettings>(chartSettings);
            case ChartEnum.PeakShavMonthlyMultiComp:
                return JsonConvert.DeserializeObject<PeakShavingMonthMultiChartSettings>(chartSettings);
            case ChartEnum.HourlyDamBattery:
                return JsonConvert.DeserializeObject<HourlyDamBatteryChartSettings>(chartSettings);
            default:
                throw new Exception();
        }
    }
}