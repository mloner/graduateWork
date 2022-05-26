namespace ReportingFramework.Structure.Sections.CumCashflow.BatSim.Default
{
    public class CumCashflowSecBatSimDefaultV0_9 : CumCashflowBatSimSec
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
            // desc1Par.Text = ResHelper.GetResVal(_sectionResName, desc1Name, _ci);
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
            //         {"CompanyName", _template.GlobalSettings.CompanyName}
            //     });
            // AddParagraph(desc2Par);
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
            // chartName = $"{SubsectionTypeEnum.Chart.Desc()}_CumCashflow";
            // chart = (Chart)GetReportObj(_sectionData, chartName);
            // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // chart.Title = ResHelper.GetResVal(_sectionResName, $"{chartName}_Title", _ci);
            // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // AddImage(
            //     section: _pdfSection,
            //     imgPath: chartPath,
            //     imgTitle: chart.Title,
            //     imgWidthCm: GetSectionWidthCm(),
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles,
            //     figureNum: _secParams.ReportSettings.AddFigure);
            //
            // #endregion
        }

        public override void GenerateContent()
        {
            throw new System.NotImplementedException();
        }
    }
}