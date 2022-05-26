namespace ReportingFramework.Structure.Sections.SelfCons.BatSim.Default
{
    public class SelfConsSecBatSimDefaultV0_9 : SelfConsBatSimSec
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
            // #region Image
            //
            // string imgName = $"{SubsectionTypeEnum.Image.Desc()}_SelfCons";
            // var image = GetReportObj(_sectionData, imgName) as Image;
            // image.Init(_resParams, _template, _secParams.NumFmtr);
            // image.Title = ResHelper.GetResVal(_sectionResName, $"{imgName}_Title", _ci);
            // image.Path = $"{_resParams.Paths.SectionImages}/{image.Path}";
            // AddImage(
            //     section: _secParams.Section,
            //     imgPath: image.Path,
            //     imgTitle: image.Title,
            //     imgWidthCm: 14,
            //     globalSettings: _template.GlobalSettings,
            //     _styles,
            //     _secParams.ReportSettings.AddFigure
            // );
            //
            // #endregion
        }

        public override void GenerateContent()
        {
            throw new System.NotImplementedException();
        }
    }
}