namespace ReportingFramework.Structure.Sections.SenMark.BatSim.Default
{
    public class SenMarkSecBatSimDefaultV0_9 : SenMarkBatSimSec
    {
        public override void InitSectionModel(string sectionModelJson)
        {
            throw new System.NotImplementedException();
        }

        public override void Generate()
        {
            // #region Desc 1
            //
            // var desc1Name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Desc_1";
            // var desc1Par = (ReportParagraph)GetReportObj(_sectionData, desc1Name);
            // desc1Par.Text = ResHelper.GetResVal(_sectionResName, desc1Name, _ci)
            //     .ReplaceVals(new Dictionary<string, string>()
            //     {
            //         { "ElectricityRateAvgIncrease", _numFmtr.Format(desc1Par.Parameters.First(x => x.Key == "ElectricityRateAvgIncrease").Value.ToString()) },
            //         { "Year", desc1Par.Parameters.First(x => x.Key == "Year").Value.ToString() },
            //     });
            // AddParagraph(desc1Par);
            //
            // #endregion
            //
            // AddSpace(0.3);
            //
            // #region Desc 2
            //
            // var desc2Name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Desc_2";
            // var desc2Par = (ReportParagraph)GetReportObj(_sectionData, desc2Name);
            // desc2Par.Text = ResHelper.GetResVal(_sectionResName, desc2Name, _ci)
            //     .ReplaceVals(new Dictionary<string, string>()
            //     {
            //         { "Years", desc2Par.Parameters.First(x => x.Key == "Years").Value.ToString() },
            //         { "PriceIncreasePercent", _numFmtr.Format(desc2Par.Parameters.First(x => x.Key == "PriceIncreasePercent").Value.ToString()) },
            //
            //     });
            // AddParagraph(desc2Par);
            //
            // #endregion
            //
            // AddSpace(0.3);
            //
            // #region Desc 3
            //
            // var desc3Name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Desc_3";
            // var desc3Par = (ReportParagraph)GetReportObj(_sectionData, desc3Name);
            // desc3Par.Text = ResHelper.GetResVal(_sectionResName, desc3Name, _ci)
            //     .ReplaceVals(new Dictionary<string, string>()
            //     {
            //         { "Years", desc3Par.Parameters.First(x => x.Key == "Years").Value.ToString() },
            //         { "ElectricityPriceEncrease", _numFmtr.Format(desc3Par.Parameters.First(x => x.Key == "ElectricityPriceEncrease").Value.ToString()) },
            //         { "FeedInEncrease", _numFmtr.Format(desc3Par.Parameters.First(x => x.Key == "FeedInEncrease").Value.ToString()) },
            //
            //     });
            // AddParagraph(desc3Par);
            //
            // #endregion
            //
            // AddSpace(0.3);
            //
            // #region Chart
            //
            // string chartName;
            // Chart chart;
            // string chartPath;
            //
            // // chartName = $"{SubsectionTypeEnum.Chart.Desc()}_SensitivityMatrix";
            // // chart = (Chart)GetReportObj(_sectionData, chartName);
            // // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // // chart.Title = ResHelper.GetResVal(_sectionResName, $"{chartName}_Title", _ci);
            // // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // // AddImage(
            // //     section: _pdfSection,
            // //     imgPath: chartPath,
            // //     imgTitle: chart.Title,
            // //     imgWidthCm: new Unit(10, UnitType.Centimeter).Centimeter,
            // //     globalSettings: _template.GlobalSettings,
            // //     styles: _styles,
            // //     figureNum: _secParams.ReportSettings.AddFigure);
            //
            // #endregion
        }

        public override void GenerateContent()
        {
            throw new System.NotImplementedException();
        }
    }
}