using ChartGeneratorModels.ChartGeneratorModels;
using Newtonsoft.Json;

namespace ChartGeneratorModels.ChartSettings
{
    public static class ReportChartSettingsHelper
    {
        public static global::ChartGeneratorModels.ChartSettings.ChartSettings GetChartSettings(ChartEnum chartEnum, string settingsJsonString)
        {
            switch (chartEnum)
            {
                case ChartEnum.PeakShavMonth:
                    return JsonConvert.DeserializeObject<PeakShavingMonthChartSettings>(settingsJsonString);
                case ChartEnum.DistributionHourly:
                    return JsonConvert.DeserializeObject<DistributionHourlyChartSettings>(settingsJsonString);
                 case ChartEnum.AverageHourly:
                     return JsonConvert.DeserializeObject<AverageHourlyChartSettings>(settingsJsonString);
                case ChartEnum.AverageHourlyDam:
                    return JsonConvert.DeserializeObject<AverageHourlyDamChartSettings>(settingsJsonString);
                case ChartEnum.CumCashflow:
                    return JsonConvert.DeserializeObject<CumCashflowChartSettings>(settingsJsonString);
                case ChartEnum.SensitivityMatrix:
                    return JsonConvert.DeserializeObject<SensitivityMatrixChartSettings>(settingsJsonString);
                case ChartEnum.ElBillStructure:
                    return JsonConvert.DeserializeObject<ElBillStructureChartSettings>(settingsJsonString);
                case ChartEnum.PeakShavMonthly:
                    return JsonConvert.DeserializeObject<PeakShavMonthlyChartSettings>(settingsJsonString);
                case ChartEnum.PeakShavAvgDay:
                    return JsonConvert.DeserializeObject<PeakShavAvgDayChartSettings>(settingsJsonString);
                case ChartEnum.NetMet:
                    return JsonConvert.DeserializeObject<NetMetChartSettings>(settingsJsonString);
                case ChartEnum.BatterySubsidy:
                    return JsonConvert.DeserializeObject<BatterySubsidyChartSettings>(settingsJsonString);
                case ChartEnum.PriceAndSpreadYearlyGrow:
                    return JsonConvert.DeserializeObject<PriceAndSpreadYearlyGrowChartSettings>(settingsJsonString);
                case ChartEnum.PieChart:
                    return JsonConvert.DeserializeObject<PieChartSettings>(settingsJsonString);
                case ChartEnum.PeakShavAvgDayMultuComp:
                    return JsonConvert.DeserializeObject<PeakShavAvgDayMultiCompChartSettings>(settingsJsonString);
                case ChartEnum.PerfExplWeek:
                    return JsonConvert.DeserializeObject<PerfExplWeekChartSettings>(settingsJsonString);
                default:
                    throw new Exception("ReportChartSettingsHelper");
            }
        }
    }
}