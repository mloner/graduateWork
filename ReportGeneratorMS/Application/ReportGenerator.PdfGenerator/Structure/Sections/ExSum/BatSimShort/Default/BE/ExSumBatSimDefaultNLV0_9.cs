using System;

namespace ReportingFramework.Structure.Sections.ExSum.BatSimShort.Default.BE
{
    public class ExSumBatSimShortDefaultBEV0_9 : ExecSumBatSimShortSec
    {
        public override void AddDesc1()
        {
            // var desc1Name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Desc_1";
            // var desc1Par = (ReportParagraph)GetReportObj(_sectionData, desc1Name);
            // desc1Par.Text = ResHelper.GetResVal(_sectionResName, desc1Name, _ci);
            // AddParagraph(
            //     ResHelper.GetResVal(_sectionResName, desc1Name, _resParams.CultureInfo)
            //         .ReplaceVals(new Dictionary<string, string>()
            //         {
            //             {"CompanyName", _template.GlobalSettings.CompanyName},
            //             {"MeasurementCount", _secParams.NumFmtr.Format(desc1Par.Parameters.First(x => x.Key == "MeasurementCount").Value.ToString())},
            //             {"FirstMeasurementDate", DateTime.Parse(desc1Par.Parameters.First(x => x.Key == "FirstMeasurementDate").Value.ToString(), CultureInfo.InvariantCulture).ToString(_template.GlobalSettings.DateFormat)}
            //         })
            // );
        }
        
        public override void AddDesc2()
        {
            // var desc3Name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Desc_3";
            //
            // #region Title
            //
            // var desc3Par = new ReportParagraph();
            // desc3Par.Title = ResHelper.GetResVal(_sectionResName, $"{desc3Name}_Title", _ci);
            // AddParagraph(desc3Par.Title, StyleEnum.H1);
            //
            // #endregion
            //
            // #region Content
            //
            // #region 3_1
            //
            // var desc3_1Name = $"{desc3Name}_1";
            //
            // #region Title
            //
            // var desc3_1Par = new ReportParagraph();
            // desc3_1Par.Title = ResHelper.GetResVal(_sectionResName, $"{desc3_1Name}_Title", _ci);
            // AddParagraph(desc3_1Par.Title, StyleEnum.H3);
            //
            // #endregion
            //
            // #region Content
            //
            // AddParagraph(
            //     ResHelper.GetResVal(_sectionResName, desc3_1Name, ResParams.CultureInfo)
            //         .ReplaceVals(new Dictionary<string, string>()
            //         {
            //             {"CompanyName", Template.GlobalSettings.CompanyName},
            //         })
            // );
            //
            // #endregion
            //
            // #endregion
            //
            // AddSpace(0.3);
            //
            // #region 3_2
            //
            // var desc3_2Name = $"{desc3Name}_2";
            //
            // #region Title
            //
            // var desc3_2Par = new ReportParagraph();
            // desc3_2Par.Title = ResHelper.GetResVal(_sectionResName, $"{desc3_2Name}_Title", _ci);
            // AddParagraph(desc3_2Par.Title, StyleEnum.H3);
            //
            // #endregion
            //
            // #region Content
            //
            // AddParagraph(
            //     ResHelper.GetResVal(_sectionResName, desc3_2Name, ResParams.CultureInfo)
            //         .ReplaceVals(new Dictionary<string, string>()
            //         {
            //             {"CompanyName", Template.GlobalSettings.CompanyName},
            //         })
            // );
            //
            // #endregion
            //
            // #endregion
            //
            // AddSpace(0.3);
            //
            // #region 3_3
            //
            // var desc3_3Name = $"{desc3Name}_3";
            //
            // #region Title
            //
            // var desc3_3Par = new ReportParagraph();
            // desc3_3Par.Title = ResHelper.GetResVal(_sectionResName, $"{desc3_3Name}_Title", _ci);
            // AddParagraph(desc3_3Par.Title, StyleEnum.H3);
            //
            // #endregion
            //
            // #region Content
            //
            // AddParagraph(
            //     ResHelper.GetResVal(_sectionResName, desc3_3Name, ResParams.CultureInfo)
            //         .ReplaceVals(new Dictionary<string, string>()
            //         {
            //             {"CompanyName", Template.GlobalSettings.CompanyName},
            //         })
            // );
            //
            // #endregion
            //
            // #endregion
            //
            // #endregion
        }

        public override void InitSectionModel(string sectionModelJson)
        {
            throw new NotImplementedException();
        }

        public override void GenerateContent()
        {
            throw new NotImplementedException();
        }
    }
}