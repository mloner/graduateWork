namespace ReportingFramework.Structure.Sections.PerfExpl.AlgoExpl.BatSim.Default
{
    public class AlgoExplSecBatSimDefaultV0_9 : AlgoExplBatSimSec
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
            // #region Charts
            //
            // Chart chart;
            // Table table;
            // Column col;
            // Row row;
            // int rowNum = 0;
            // int colNum = 0;
            // Paragraph imgPar;
            // List<Paragraph> paragraphs;
            // string chartPath;
            //
            // table = _pdfSection.AddTable();
            // col = table.AddColumn(new Unit(GetSectionWidthCm()/2, UnitType.Centimeter));
            // col = table.AddColumn(new Unit(GetSectionWidthCm()/2, UnitType.Centimeter));
            //
            // // var algoExplCharts = _sectionData.Data.ReportObjects.Where(x =>
            // //     x.Name.Contains($"{SubsectionTypeEnum.Chart.Desc()}_AverageHourly"));
            // //
            // // #region Summer
            // //
            // // row = table.AddRow();
            // // row.BottomPadding = new Unit(1, UnitType.Centimeter);
            // // colNum = 0;
            // //
            // // #region work
            // //
            // // chart = algoExplCharts.Skip(0).First() as Chart;
            // // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // // chart.Title = ResHelper.GetResVal(_sectionResName,
            // //     $"{SubsectionTypeEnum.Chart}_{chart.Tag}_Title", _ci);
            // // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // // paragraphs = AddImagePar(
            // //     imgPath: chartPath,
            // //     imgTitle: chart.Title,
            // //     imgWidthCm: GetSectionWidthCm()/2,
            // //     globalSettings: _template.GlobalSettings,
            // //     styles: _styles,
            // //     figureNum: _secParams.ReportSettings.AddFigure,
            // //     titleSize:7);
            // // row.Cells[colNum].Add(paragraphs);
            // //
            // // #endregion
            // //
            // // colNum++;
            // //
            // // #region weekend
            // //
            // // chart = algoExplCharts.Skip(1).First() as Chart;
            // // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // // chart.Title = ResHelper.GetResVal(_sectionResName,
            // //     $"{SubsectionTypeEnum.Chart}_{chart.Tag}_Title", _ci);
            // // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // // paragraphs = AddImagePar(
            // //     imgPath: chartPath,
            // //     imgTitle: chart.Title,
            // //     imgWidthCm: GetSectionWidthCm()/2,
            // //     globalSettings: _template.GlobalSettings,
            // //     styles: _styles,
            // //     figureNum: _secParams.ReportSettings.AddFigure,
            // //     titleSize:7);
            // // row.Cells[colNum].Add(paragraphs);
            // //
            // // #endregion
            // //
            // // #endregion
            // //
            // // #region Winter
            // //
            // // row = table.AddRow();
            // // colNum = 0;
            // //
            // // #region work
            // //
            // // chart = algoExplCharts.Skip(2).First() as Chart;
            // // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // // chart.Title = ResHelper.GetResVal(_sectionResName,
            // //     $"{SubsectionTypeEnum.Chart}_{chart.Tag}_Title", _ci);
            // // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // // paragraphs = AddImagePar(
            // //     imgPath: chartPath,
            // //     imgTitle: chart.Title,
            // //     imgWidthCm: GetSectionWidthCm()/2,
            // //     globalSettings: _template.GlobalSettings,
            // //     styles: _styles,
            // //     figureNum: _secParams.ReportSettings.AddFigure,
            // //     titleSize:7);
            // // row.Cells[colNum].Add(paragraphs);
            // //
            // // #endregion
            // //
            // // colNum++;
            // //
            // // #region weekend
            // //
            // // chart = algoExplCharts.Skip(3).First() as Chart;
            // // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // // chart.Title = ResHelper.GetResVal(_sectionResName,
            // //     $"{SubsectionTypeEnum.Chart}_{chart.Tag}_Title", _ci);
            // // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // // paragraphs = AddImagePar(
            // //     imgPath: chartPath,
            // //     imgTitle: chart.Title,
            // //     imgWidthCm: GetSectionWidthCm()/2,
            // //     globalSettings: _template.GlobalSettings,
            // //     styles: _styles,
            // //     figureNum: _secParams.ReportSettings.AddFigure,
            // //     titleSize:7);
            // // row.Cells[colNum].Add(paragraphs);
            // //
            // //     #endregion
            // //
            // // #endregion
            //
            //
            // #endregion
        }

        public override void GenerateContent()
        {
            throw new System.NotImplementedException();
        }
    }
}