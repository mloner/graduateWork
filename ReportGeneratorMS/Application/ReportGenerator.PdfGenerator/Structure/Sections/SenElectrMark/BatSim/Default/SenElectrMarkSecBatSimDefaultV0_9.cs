namespace ReportingFramework.Structure.Sections.SenElectrMark.BatSim.Default
{
    public class SenElectrMarkSecBatSimDefaultV0_9 : SenElectrMarkBatSimSec
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
            // #region Chart SensitivityMatrix
            //
            // string chartName;
            // Chart chart;
            // string chartPath;
            //
            // chartName = $"{SubsectionTypeEnum.Chart.Desc()}_SensitivityMatrix";
            // chart = (Chart)GetReportObj(_sectionData, chartName);
            // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // chart.Title = ResHelper.GetResVal(_sectionResName, $"{chartName}_Title", _ci);
            // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // AddImage(
            //     section: _pdfSection,
            //     imgPath: chartPath,
            //     imgTitle: chart.Title,
            //     imgWidthCm: new Unit(8, UnitType.Centimeter).Centimeter,
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles,
            //     figureNum: _secParams.ReportSettings.AddFigure);
            //
            // #endregion
            //
            // AddSpace();
            //
            // #region Charts DAM analysis
            //
            // Table table;
            // Column col;
            // Row row;
            // int rowNum = 0;
            // int colNum = 0;
            // Paragraph imgPar;
            // List<Paragraph> paragraphs;
            //
            // table = _pdfSection.AddTable();
            // col = table.AddColumn(new Unit(GetSectionWidthCm()/2, UnitType.Centimeter));
            // col = table.AddColumn(new Unit(GetSectionWidthCm()/2, UnitType.Centimeter));
            //
            // row = table.AddRow();
            //
            // #region Avg day
            //
            // chartName = $"{SubsectionTypeEnum.Chart.Desc()}_AverageHourlyDam";
            // chart = (Chart)GetReportObj(_sectionData, chartName);
            // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // chart.Title = ResHelper.GetResVal(_sectionResName, $"{chartName}_Title", _ci);
            // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // paragraphs = AddImagePar(
            //     imgPath: chartPath,
            //     imgTitle: chart.Title,
            //     imgWidthCm: new Unit(GetSectionWidthCm()/2, UnitType.Centimeter).Centimeter,
            //     titleSize: 7,
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles,
            //     figureNum: _secParams.ReportSettings.AddFigure);
            // row.Cells[colNum].Add(paragraphs);
            //
            // #endregion
            //
            // colNum++;
            //
            // #region Yearly grow
            //
            // chartName = $"{SubsectionTypeEnum.Chart.Desc()}_PriceAndSpreadYearlyGrow";
            // chart = (Chart)GetReportObj(_sectionData, chartName);
            // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // chart.Title = ResHelper.GetResVal(_sectionResName, $"{chartName}_Title", _ci);
            // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // paragraphs = AddImagePar(
            //     imgPath: chartPath,
            //     imgTitle: chart.Title,
            //     imgWidthCm: new Unit(GetSectionWidthCm()/2, UnitType.Centimeter).Centimeter,
            //     titleSize: 7,
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles,
            //     figureNum: _secParams.ReportSettings.AddFigure);
            // row.Cells[colNum].Add(paragraphs);
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