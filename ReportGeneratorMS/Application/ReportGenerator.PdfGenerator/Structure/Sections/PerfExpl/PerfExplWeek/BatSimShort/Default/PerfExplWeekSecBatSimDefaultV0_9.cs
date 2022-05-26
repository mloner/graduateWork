namespace ReportingFramework.Structure.Sections.PerfExpl.PerfExplWeek.BatSimShort.Default
{
    public class PerfExplWeekSecBatSimShortDefaultV0_9 : PerfExplWeekBatSimShortSec
    {
        public override void InitSectionModel(string sectionModelJson)
        {
            throw new System.NotImplementedException();
        }

        public override void Generate()
        {
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
            // #region Ref
            //
            // _name = $"{SubsectionTypeEnum.Chart.Desc()}_{ChartEnum.PerfExplWeek.Desc()}_Ref";
            // chart = (Chart)GetReportObj(_sectionData, _name);
            // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // chart.Title = ResHelper.GetResVal(_sectionResName,
            //     $"{_name}_{chart.Tag}_Title", _ci);
            // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // AddImage(
            //     section: _pdfSection,
            //     imgPath: chartPath,
            //     imgTitle: chart.Title,
            //     imgWidthCm: GetSectionWidthCm() - 1,
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles,
            //     figureNum: _secParams.ReportSettings.AddFigure,
            //     titleSize:10);
            //
            // #endregion
            //
            // AddSpace(1);
            //
            // #region Alt
            //
            // _name = $"{SubsectionTypeEnum.Chart.Desc()}_{ChartEnum.PerfExplWeek.Desc()}_Alt";
            // chart = (Chart)GetReportObj(_sectionData, _name);
            // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // chart.Title = ResHelper.GetResVal(_sectionResName,
            //     $"{_name}_{chart.Tag}_Title", _ci);
            // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // AddImage(
            //     section: _pdfSection,
            //     imgPath: chartPath,
            //     imgTitle: chart.Title,
            //     imgWidthCm: GetSectionWidthCm() - 1,
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles,
            //     figureNum: _secParams.ReportSettings.AddFigure,
            //     titleSize:10);
            //
            // #endregion
            //
            // AddSpace(1);
            //
            // #region Main
            //
            // _name = $"{SubsectionTypeEnum.Chart.Desc()}_{ChartEnum.PerfExplWeek.Desc()}_Main";
            // chart = (Chart)GetReportObj(_sectionData, _name);
            // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // chart.Title = ResHelper.GetResVal(_sectionResName,
            //     $"{_name}_{chart.Tag}_Title", _ci);
            // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // AddImage(
            //     section: _pdfSection,
            //     imgPath: chartPath,
            //     imgTitle: chart.Title,
            //     imgWidthCm: GetSectionWidthCm() - 1,
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles,
            //     figureNum: _secParams.ReportSettings.AddFigure,
            //     titleSize:10);
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