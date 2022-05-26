namespace ReportingFramework.Structure.Sections.PeakShav.BatSim.Default.NL
{
    public class PeakShavSecBatSimDefaultNLV0_9 : PeakShavBatSimSec
    {
        public override void AddDesc()
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
            //     ;
            // AddParagraph(desc2Par);
            //
            // #endregion
        }

        public override void InitSectionModel(string sectionModelJson)
        {
            throw new System.NotImplementedException();
        }

        public override void GenerateContent()
        {
            throw new System.NotImplementedException();
        }
    }
}