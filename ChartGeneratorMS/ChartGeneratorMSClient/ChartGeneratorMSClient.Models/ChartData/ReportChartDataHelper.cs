using ChartGeneratorModels.ChartGeneratorModels;

namespace ChartGeneratorModels.ChartData
{
    public static class ReportChartDataHelper
    {
        public static global::ChartGeneratorModels.ChartGeneratorModels.ChartData GetChartData(ChartEnum chartEnum)
        {
            switch (chartEnum)
            {
                case ChartEnum.PeakShavMonth:
                    return new PeakShavingMonthChartData();
                case ChartEnum.DistributionHourly:
                    return new DistributionHourlyChartData();
                 case ChartEnum.AverageHourly:
                     return new AverageHourlyChartData();
                case ChartEnum.AverageHourlyDam:
                    return new AverageHourlyDamChartData();
                case ChartEnum.CumCashflow:
                    return new CumCashflowChartData();
                case ChartEnum.SensitivityMatrix:
                    return new SensitivityMatrixChartData();
                case ChartEnum.ElBillStructure:
                    return new ElBillStructureChartData();
                case ChartEnum.PeakShavMonthly:
                    return new PeakShavMonthlyChartData();
                case ChartEnum.PeakShavAvgDay:
                    return new PeakShavAvgDayChartData();
                case ChartEnum.NetMet:
                    return new NetMetChartData();
                case ChartEnum.BatterySubsidy:
                    return new BatterySubsidyChartData();
                case ChartEnum.PriceAndSpreadYearlyGrow:
                    return new PriceAndSpreadYearlyGrowChartData();
                case ChartEnum.PieChart:
                    return new PieChartData();
                case ChartEnum.PeakShavAvgDayMultuComp:
                    return new PeakShavAvgDayMultiCompChartData();
                case ChartEnum.PerfExplWeek:
                    return new PerfExplWeekChartData();
                default:
                    throw new Exception("GetChartData");
            }
        }
    }
}