namespace ReportingFramework.Structure.Sections.NetMet.BatSim.Default
{
    public class NetMetBatSimDefaultV0_9 : NetMetBatSimSec
    {
        public override void Generate()
        {
            // #region Desc 1
            //
            // var desc1Name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Desc_1";
            // var desc1Par = (ReportParagraph)GetReportObj(_sectionData, desc1Name);
            // desc1Par.Text = ResHelper.GetResVal(_sectionResName, desc1Name, _ci)
            //     ;
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
            //         .ReplaceVals(new Dictionary<string, string>()
            //         {
            //             {"CompanyName", _template.GlobalSettings.CompanyName}
            //         })
            //     ;
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
            //         .ReplaceVals(new Dictionary<string, string>()
            //         {
            //             {"CompanyName", _template.GlobalSettings.CompanyName}
            //         })
            //     ;
            // AddParagraph(desc3Par);
            //
            // #endregion
            //
            // AddSpace(0.5);
            //
            // #region Chart
            //
            // string chartName;
            // Chart chart;
            // string chartPath;
            //
            // chartName = $"{SubsectionTypeEnum.Chart.Desc()}_NetMet";
            // chart = (Chart)GetReportObj(_sectionData, chartName);
            // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // chart.Title = ResHelper.GetResVal(_sectionResName, $"{chartName}_Title", _ci);
            // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // AddImage(
            //     section: _pdfSection,
            //     imgPath: chartPath,
            //     imgTitle: chart.Title,
            //     imgWidthCm: 13,
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles,
            //     figureNum: _secParams.ReportSettings.AddFigure);
            //
            // #endregion
        }
    }
}