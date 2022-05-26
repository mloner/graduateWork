using System;

namespace ReportingFramework.Structure.Sections.ExSum.BatSim
{
    public class ExecSumBatSimSec : PdfExecutiveSummary
    {
        public override void InitSectionModel(string sectionModelJson)
        {
            throw new NotImplementedException();
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
            // AddSpace(0.1);
            //
            // #region Location info
            //
            // var locInfoName = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_LocationInfo";
            // var locInfoObj = GetReportObj(_sectionData, locInfoName);
            //
            // foreach (var documentObject in AddLocationInfoBlock(locInfoObj))
            // {
            //     _pdfSection.Elements.Add((DocumentObject)documentObject.Clone());
            // }
            //
            // #endregion
            //
            // AddSpace();
            //
            // #region Desc 2
            //
            // var desc2Name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Desc_2";
            // var desc2Obj = GetReportObj(_sectionData, desc2Name);
            // var desc2Childs = desc2Obj.ChildObjects;
            //
            // #region Title
            //
            // var desc2Par = (ReportParagraph)GetReportObj(_sectionData, desc2Name);
            // desc2Par.Title = ResHelper.GetResVal(_sectionResName, $"{desc2Name}_Title", _ci);
            // AddParagraph(desc2Par.Title, StyleEnum.H1);
            //
            // #endregion
            //
            // #region Content
            //
            // #region 1
            //
            // var desc2_1Name = $"{desc2Name}_1";
            // var desc2_1Par = (ReportParagraph)desc2Childs[0];
            // AddParagraph(
            //     ResHelper.GetResVal(_sectionResName, desc2_1Name, _resParams.CultureInfo)
            //         .ReplaceVals(new Dictionary<string, string>()
            //         {
            //             {"CompanyName", _template.GlobalSettings.CompanyName},
            //             {"MeasurementCount", _secParams.NumFmtr.Format(desc2_1Par.Parameters.First(x => x.Key == "MeasurementCount").Value.ToString())},
            //             {"FirstMeasurementDate", DateTime.Parse(desc2_1Par.Parameters.First(x => x.Key == "FirstMeasurementDate").Value.ToString(), CultureInfo.InvariantCulture).ToString(_template.GlobalSettings.DateFormat)}
            //         })
            // );
            //
            // #endregion
            //
            // AddSpace(0.3);
            //
            // #region 2
            //
            // var desc2_2Name = $"{desc2Name}_2";
            // var desc2_2Par = (ReportParagraph)desc2Childs[1];
            // AddParagraph(ResHelper.GetResVal(_sectionResName, desc2_2Name, _resParams.CultureInfo));
            //
            // #endregion
            //
            // #endregion
            //
            //
            //
            // #endregion
            //
            // AddSpace();
            //
            // #region Desc 3
            //
            // var desc3Name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Desc_3";
            // var desc3Obj = GetReportObj(_sectionData, desc3Name);
            // var desc3Childs = desc3Obj.ChildObjects;
            //
            // #region Title
            //
            // var desc3Par = (ReportParagraph)GetReportObj(_sectionData, desc3Name);
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
            // var desc3_1Obj = GetReportObj(desc3Par.ChildObjects, desc3_1Name);
            // var desc3_1Childs = desc3_1Obj.ChildObjects;
            //
            // #region Title
            //
            // var desc3_1Par = (ReportParagraph)GetReportObj(desc3Par.ChildObjects, desc3_1Name);
            // desc3_1Par.Title = ResHelper.GetResVal(_sectionResName, $"{desc3_1Name}_Title", _ci);
            // AddParagraph(desc3_1Par.Title, StyleEnum.H3);
            //
            // #endregion
            //
            // #region Content
            //
            // AddParagraph(
            //     ResHelper.GetResVal(_sectionResName, desc3_1Name, _resParams.CultureInfo)
            //         .ReplaceVals(new Dictionary<string, string>()
            //         {
            //             {"CompanyName", _template.GlobalSettings.CompanyName},
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
            // var desc3_2Obj = GetReportObj(desc3Par.ChildObjects, desc3_2Name);
            // var desc3_2Childs = desc3_2Obj.ChildObjects;
            //
            // #region Title
            //
            // var desc3_2Par = (ReportParagraph)GetReportObj(desc3Par.ChildObjects, desc3_2Name);
            // desc3_2Par.Title = ResHelper.GetResVal(_sectionResName, $"{desc3_2Name}_Title", _ci);
            // AddParagraph(desc3_2Par.Title, StyleEnum.H3);
            //
            // #endregion
            //
            // #region Content
            //
            // AddParagraph(
            //     ResHelper.GetResVal(_sectionResName, desc3_2Name, _resParams.CultureInfo)
            //         .ReplaceVals(new Dictionary<string, string>()
            //         {
            //             {"CompanyName", _template.GlobalSettings.CompanyName},
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
            // var desc3_3Obj = GetReportObj(desc3Par.ChildObjects, desc3_3Name);
            // var desc3_3Childs = desc3_3Obj.ChildObjects;
            //
            // #region Title
            //
            // var desc3_3Par = (ReportParagraph)GetReportObj(desc3Par.ChildObjects, desc3_3Name);
            // desc3_3Par.Title = ResHelper.GetResVal(_sectionResName, $"{desc3_3Name}_Title", _ci);
            // AddParagraph(desc3_3Par.Title, StyleEnum.H3);
            //
            // #endregion
            //
            // #region Content
            //
            // AddParagraph(ResHelper.GetResVal(_sectionResName, desc3_3Name, _resParams.CultureInfo)
            //     .ReplaceVals(new Dictionary<string, string>()
            //     {
            //         {"CompanyName", _template.GlobalSettings.CompanyName}
            //     }));
            //
            // #endregion
            //
            // #endregion
            //
            // #endregion
            //
            // #endregion
        }

        public override void GenerateContent()
        {
            throw new NotImplementedException();
        }
    }
}