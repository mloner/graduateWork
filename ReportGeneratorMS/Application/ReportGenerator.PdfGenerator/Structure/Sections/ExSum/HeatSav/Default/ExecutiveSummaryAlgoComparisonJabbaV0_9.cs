namespace ReportingFramework.Structure.Sections.ExSum.HeatSav.Default
{
    public class ExecSumHeatSavV0_9 : PdfExecutiveSummary
    {
        public override void InitSectionModel(string sectionModelJson)
        {
            throw new System.NotImplementedException();
        }

        public override void Generate()
        {
            // #region Report title
            //
            // var reportTitle = GetReportObj(_secParams.AbstractSection, "ReportTitle") as BaseReportTitle;
            // reportTitle.Init(_resParams, _template, _secParams.NumFmtr);
            // GenerateReportTitle(_secParams.Section, reportTitle, _template);
            //
            // #endregion
        }

        public override void GenerateContent()
        {
            throw new System.NotImplementedException();
        }
    }
}