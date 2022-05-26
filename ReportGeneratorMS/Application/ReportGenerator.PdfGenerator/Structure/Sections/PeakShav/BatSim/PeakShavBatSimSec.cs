namespace ReportingFramework.Structure.Sections.PeakShav.BatSim
{
    public abstract class PeakShavBatSimSec : PeakShavSec
    {
        public override void Generate()
        {
            // AddDesc();
            //
            // AddSpace(0.5);
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
            // string chartName;
            //
            // table = _pdfSection.AddTable();
            // col = table.AddColumn(new Unit(GetSectionWidthCm()/2, UnitType.Centimeter));
            // col = table.AddColumn(new Unit(GetSectionWidthCm()/2, UnitType.Centimeter));
            //
            //
            // row = table.AddRow();
            // colNum = 0;
            //
            // #region Monthly
            //
            // chartName = $"{SubsectionTypeEnum.Chart.Desc()}_PeakShavMonthly";
            // chart = (Chart)GetReportObj(_sectionData, chartName);
            // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // chart.Title = ResHelper.GetResVal(_sectionResName,
            //     $"{chartName}_{chart.Tag}_Title", _ci);
            // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // paragraphs = AddImagePar(
            //     imgPath: chartPath,
            //     imgTitle: chart.Title,
            //     imgWidthCm: GetSectionWidthCm()/2,
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles,
            //     figureNum: _secParams.ReportSettings.AddFigure,
            //     titleSize:7);
            // row.Cells[colNum].Add(paragraphs);
            //
            //
            // #endregion
            //
            // colNum++;
            //
            // #region Avg day
            //
            // chartName = $"{SubsectionTypeEnum.Chart.Desc()}_PeakShavAvgDay";
            // chart = (Chart)GetReportObj(_sectionData, chartName);
            // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // chart.Title = ResHelper.GetResVal(_sectionResName,
            //     $"{chartName}_{chart.Tag}_Title", _ci);
            // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // paragraphs = AddImagePar(
            //     imgPath: chartPath,
            //     imgTitle: chart.Title,
            //     imgWidthCm: GetSectionWidthCm()/2,
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles,
            //     figureNum: _secParams.ReportSettings.AddFigure,
            //     titleSize:7);
            // row.Cells[colNum].Add(paragraphs);
            //
            //
            // #endregion
            //
            // #endregion
        }

        public abstract void AddDesc();
    }
}