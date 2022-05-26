using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ChartGeneratorModels;
using ChartGeneratorModels.ChartData;
using ChartGeneratorModels.ChartData.CommonChartData;
using ChartGeneratorModels.ChartGeneratorModels;
using ChartGeneratorModels.ChartSettings;
using ReportingFramework.ReportTypesAdapter.AlgoComp.DataModels;
using SectionModels;
using SectionModels.Pdf.SectionModels.AlgoCompReport;

namespace ReportingFramework.SectionAdapter.AlgoCompReport
{
    public class AlgoComp_PeakShavCompSecAdap : PdfSectionAdapter
    {
        public new AlgoComp_PeakShavCompSectionModel SectionModelModel { get; set; }

        public List<GridPowerDataModel> _refData;
        public List<GridPowerDataModel> _bestData;
        
        private double _capTarRef;
        private double _capTarBest;
        
        private GridPowerDataModel _peakRef;
        private GridPowerDataModel _peakBest;

        public AlgoComp_PeakShavCompSecAdap()
        {
            SectionModelModel = new AlgoComp_PeakShavCompSectionModel();
        }
        
        public override void LoadData()
        {
            _refData = ((List<GridPowerDataModel>) CommonData["GridDataRef"]);
            _bestData = ((List<GridPowerDataModel>) CommonData["GridDataBest"]);
            var capTarPeak = 2.5;
            var capTar = 4.0;
            
            //captar ref
            _capTarRef = Math.Round(_refData.GroupBy(x => new { x.DateTime.Year, x.DateTime.Month })
                .First().Max(x => x.Value / 1000).Value, 1) - capTarPeak;
            _capTarRef = _capTarRef < 0 ? 0 : _capTarRef * capTar;
            _peakRef = _refData
                .GroupBy(x => new
                {
                    x.DateTime.Year, x.DateTime.Month
                })
                .First()
                .OrderByDescending(x => x.Value).First();
            
            //carpar best
            _capTarBest = Math.Round(_bestData.GroupBy(x => new { x.DateTime.Year, x.DateTime.Month })
                .First().Max(x => x.Value / 1000).Value, 1) - capTarPeak;
            _capTarBest = _capTarBest < 0 ? 0 : _capTarBest * capTar;
            _peakBest = _bestData
                .GroupBy(x => new
                {
                    x.DateTime.Year, x.DateTime.Month
                })
                .First()
                .OrderByDescending(x => x.Value).First();
        }

        
        public override SectionModel CreateSectionModel()
        {
            var yMaxes = new List<double?>
            {
                new List<double>()
                {
                    (_refData.GroupBy(x => new
                        {
                            x.DateTime.Year, x.DateTime.Month
                        })
                        .First()
                        .Select(x => x.Value).Max().Value / 1000),
                    (_bestData.GroupBy(x => new
                        {
                            x.DateTime.Year, x.DateTime.Month
                        })
                        .First()
                        .Select(x => x.Value).Max().Value / 1000),
                }.Max()
            };
            //add space above the chart data for right annotations placement
            yMaxes = yMaxes.Select(y =>
            {
                y += 1;
                return y;
            }).ToList();
            
            SectionModelModel.RefCase = new RefCase
            {
                Chart = new ChartRequestData
                {
                    ChartType = ChartEnum.PeakShavMonth,
                    ChartData = new PeakShavingMonthChartData()
                    {
                        GridPower = _refData
                            .GroupBy(x => new
                            {
                                x.DateTime.Year, x.DateTime.Month
                            })
                            .First()
                            .Select(x => new DateTimeSeries()
                            {
                                DateTime = x.DateTime,
                                Value = x.Value == null ? 0 : x.Value.Value / 1000
                            }).ToList()
                    },
                    ChartSettings = new PeakShavingMonthChartSettings()
                    {
                        Color = Color.FromArgb(143, 180, 119),
                        YMaxes = yMaxes
                    }
                },
                Peak = _peakRef.Value.Value / 1000,
                PeakDateTimeStart = _peakRef.DateTime.AddMinutes(-15),
                PeakDateTimeEnd = _peakRef.DateTime,
                CapTariff = _capTarRef
            };

            SectionModelModel.BestCase = new BestCase
            {
                Chart = new ChartRequestData
                {
                    ChartType = ChartEnum.PeakShavMonth,
                    ChartData = new PeakShavingMonthChartData()
                    {
                        GridPower = _bestData
                            .GroupBy(x => new
                            {
                                x.DateTime.Year, x.DateTime.Month
                            })
                            .First()
                            .Select(x => new DateTimeSeries()
                            {
                                DateTime = x.DateTime,
                                Value = x.Value == null ? 0 : x.Value.Value / 1000
                            }).ToList()
                    },
                    ChartSettings = new PeakShavingMonthChartSettings()
                    {
                        Color = Color.FromArgb(228, 191, 102),
                        YMaxes = yMaxes
                    }
                },
                Peak = _peakBest.Value.Value / 1000,
                CapTariff = _capTarBest
            };

            return SectionModelModel;
        }
    }
}