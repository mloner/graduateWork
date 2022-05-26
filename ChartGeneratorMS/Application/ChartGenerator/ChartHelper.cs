using System;
using ChartGenerator.Charts.AverageHourly;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using ChartGenerator.Charts;
using ChartGenerator.Charts.HourlyDamBattery;
using ChartGenerator.Charts.PeakShav;
using ChartGenerator.Charts.PeakShavingMonthMulti;
using ChartGenerator.Charts.PieChart;

namespace ChartGenerator
{
    public static class ChartHelper
    {
        public static Chart GetChart(ChartEnum chartEnum, ChartData chartData,
            ChartSettings chartSettings)
        {
            switch (chartEnum)
            {
                case ChartEnum.SensitivityMatrix:
                    return new SensitivityMatrixChart(chartData, chartSettings);
                case ChartEnum.PeakShavMonth:
                    return new PeakShavMonthChart(chartData, chartSettings);
                case ChartEnum.DistributionHourly:
                    return new DistributionHourlyChart(chartData, chartSettings);
                case ChartEnum.AverageHourly:
                    return new AverageHourlyChart(chartData, chartSettings);
                case ChartEnum.AverageHourlyDam:
                    return new AverageHourlyDamChart(chartData, chartSettings);
                case ChartEnum.CumCashflow:
                    return new CumCashflowChart(chartData, chartSettings);
                case ChartEnum.ElBillStructure:
                    return new ElBillStructureChart(chartData, chartSettings);
                case ChartEnum.PeakShavMonthly:
                    return new PeakShavMonthlyChart(chartData, chartSettings);
                case ChartEnum.PeakShavAvgDay:
                    return new PeakShavAvgDayChart(chartData, chartSettings);
                case ChartEnum.NetMet:
                    return new NetMetChart(chartData, chartSettings);
                case ChartEnum.BatterySubsidy:
                    return new BatterySubsidyChart(chartData, chartSettings);
                case ChartEnum.PriceAndSpreadYearlyGrow:
                    return new PriceAndSpreadYearlyGrowChart(chartData, chartSettings);
                case ChartEnum.PieChart:
                    return new PieChart(chartData, chartSettings);
                case ChartEnum.PeakShavAvgDayMultuComp:
                    return new PeakShavAvgDayMultiCompChart(chartData, chartSettings);
                case ChartEnum.PerfExplWeek:
                    return new PerfExplWeek(chartData, chartSettings);
                case ChartEnum.PeakShavMonthlyMultiComp:
                    return new PeakShavingMonthMultiChart(chartData, chartSettings);
                case ChartEnum.HourlyDamBattery:
                    return new HourlyDamBattery(chartData, chartSettings);
                default:
                    throw new Exception("\nGenerateChart\n");
            }
        }
    }
}