using System;
using Highsoft.Web.Mvc.Charts;
using NUnit.Framework;

namespace ReportGeneratorTests.ChartTests
{
    public class ChartTests
    {
        private string _rootPath;
        private string _reportTestsPath;
        private string _testDataPath;
        ChartGenerator.ChartGenerator _chartGenerator;
        
        [SetUp]
        public void Setup()
        {
            _rootPath = AppDomain.CurrentDomain.BaseDirectory;
            _reportTestsPath = $"{_rootPath}ReportTests/PdfReportTests";
            _testDataPath = $"{_reportTestsPath}/TestData";
            // _chartGenerator = new global::ChartGenerator.ChartGenerator(
            //     new ChartGeneratorSettings()
            // {
            //     ChartFolder = $"{_rootPath}/Charts",
            //     Font = FontEnum.Averta,
            //     GlobalSettings = new Global(),
            //     LangSettings = new Lang(){DecimalPoint = ",", ThousandsSep = " "}
            // });
        }


        // [Test]
        // public void PeakShaving_ChartTest()
        // {
        //     var csvReader = new AlgoCompJabbaCsvReader();
        //     var gridPowerData = csvReader.GetGridPowerDataModels($"{_testDataPath}/GridPowerTestData.csv");
        //     
        //     var res = _chartGenerator.CreateChart(
        //         ChartEnum.PeakShavMonth,
        //         new PeakShavingMonthChartData()
        //         {
        //             GridPower =
        //                 gridPowerData
        //                 .GroupBy(x => new
        //                 {
        //                     x.DateTime.Year, x.DateTime.Month
        //                 })
        //                 .First()
        //                 .Select(x => new DateTimeSeries()
        //                 {
        //                     DateTime = x.DateTime,
        //                     Value = x.Value.Value / 1000
        //                 }).ToList()
        //         },
        //         new PeakShavingMonthChartSettings()
        //         {
        //             Color = Color.FromArgb(143, 180, 119),
        //             YMaxes = new List<double?>()
        //             {
        //                 gridPowerData.Select(x => x.Value).Max().Value / 1000
        //             },
        //             TranslationStringsChartWithTag = new Dictionary<string, string>()
        //             {
        //                 {"GridPower", "Net aankoop"},
        //                 {"MonthPeak", "Gemiddelde maandpiek"}
        //             }
        //         },
        //         "");
        // }

            [Test]
        public void Test()
        {

            // var dsf = _chartGenerator.CreateChart(ChartEnum.Test,
            //     new TestChartData()
            // {
            //     Values = Enumerable.Repeat(12.0, 3000).ToList()
            // },
            //     new TestChartSettings()
            // {
            //     
            // });
        }
    }
}