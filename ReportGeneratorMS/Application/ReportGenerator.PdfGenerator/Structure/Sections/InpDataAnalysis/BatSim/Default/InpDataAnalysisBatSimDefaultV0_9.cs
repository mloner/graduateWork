namespace ReportingFramework.Structure.Sections.InpDataAnalysis.BatSim.Default
{
    public class InpDataAnalysisSecBatSimDefaultV0_9 : InpDataAnalysisBatSimSec
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
            //         { "NumberOfMonths", _numFmtr.Format(desc1Par.Parameters.First(x => x.Key == "NumberOfMonths").Value.ToString()) },
            //     });
            // AddParagraph(desc1Par);
            //
            // #endregion
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
            //
            // string chartPath;
            //
            // table = _pdfSection.AddTable();
            // col = table.AddColumn(new Unit(GetSectionWidthCm()/2, UnitType.Centimeter));
            // col = table.AddColumn(new Unit(GetSectionWidthCm()/2, UnitType.Centimeter));
            //
            //
            //
            // var consumptionChartsBlockName = $"ConsumptionCharts";
            // var consumptionChartsBlock = (ReportParagraph)GetReportObj(_sectionData,
            //     consumptionChartsBlockName);
            //
            // var productionChartsBlockName = $"ProductionCharts";
            // var productionChartsBlock = (ReportParagraph)GetReportObj(_sectionData,
            //     productionChartsBlockName);
            //
            // #region line 1
            //
            // row = table.AddRow();
            // colNum = 0;
            //
            // //consumption
            // chart = consumptionChartsBlock.ChildObjects.Skip(0).First() as Chart;
            // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // _paragraphs = AddImagePar(
            //     imgPath: chartPath,
            //     imgTitle: chart.Title,
            //     imgWidthCm: GetSectionWidthCm()/2,
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles);
            // row.Cells[colNum].Add(_paragraphs);
            //
            // colNum++;
            //
            // //production
            // chart = productionChartsBlock.ChildObjects.Skip(0).First() as Chart;
            // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // _paragraphs = AddImagePar(
            //     imgPath: chartPath,
            //     imgTitle: chart.Title,
            //     imgWidthCm: GetSectionWidthCm()/2,
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles);
            // row.Cells[colNum].Add(_paragraphs);
            //
            // #endregion
            //
            // #region line 2
            //
            // row = table.AddRow();
            // colNum = 0;
            //
            // //consumption
            // chart = consumptionChartsBlock.ChildObjects.Skip(1).First() as Chart;
            // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // _paragraphs = AddImagePar(
            //     imgPath: chartPath,
            //     imgTitle: chart.Title,
            //     imgWidthCm: GetSectionWidthCm()/2,
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles);
            // row.Cells[colNum].Add(_paragraphs);
            //
            // colNum++;
            //
            // //production
            // chart = productionChartsBlock.ChildObjects.Skip(1).First() as Chart;
            // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // _paragraphs = AddImagePar(
            //     imgPath: chartPath,
            //     imgTitle: chart.Title,
            //     imgWidthCm: GetSectionWidthCm()/2,
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles);
            // row.Cells[colNum].Add(_paragraphs);
            //
            // #endregion
            //
            // #region line 3
            //
            // row = table.AddRow();
            // colNum = 0;
            //
            // //consumption
            // chart = consumptionChartsBlock.ChildObjects.Skip(2).First() as Chart;
            // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // _paragraphs = AddImagePar(
            //     imgPath: chartPath,
            //     imgTitle: ResHelper.GetResVal(_sectionResName, $"ConsumptionChart_Title", _ci)
            //         .ReplaceVals(new Dictionary<string, string>()
            //         {
            //             {"MonthCount", _numFmtr.Format(consumptionChartsBlock.Parameters["MonthCount"])}
            //         }),
            //     imgWidthCm: GetSectionWidthCm()/2,
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles,
            //     titleSize: 7,
            //     figureNum: _secParams.ReportSettings.AddFigure);
            // row.Cells[colNum].Add(_paragraphs);
            //
            // colNum++;
            //
            // //production
            // chart = productionChartsBlock.ChildObjects.Skip(2).First() as Chart;
            // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // _paragraphs = AddImagePar(
            //     imgPath: chartPath,
            //     imgTitle: ResHelper.GetResVal(_sectionResName, $"ProductionChart_Title", _ci)
            //         .ReplaceVals(new Dictionary<string, string>()
            //         {
            //             {"MonthCount", _numFmtr.Format(productionChartsBlock.Parameters["MonthCount"])}
            //         }),
            //     imgWidthCm: GetSectionWidthCm()/2,
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles,
            //     titleSize: 7,
            //     figureNum: _secParams.ReportSettings.AddFigure);
            // row.Cells[colNum].Add(_paragraphs);
            //
            // #endregion
            //
            // #endregion
        }

        public override void GenerateContent()
        {
            throw new System.NotImplementedException();
        }
    }
}