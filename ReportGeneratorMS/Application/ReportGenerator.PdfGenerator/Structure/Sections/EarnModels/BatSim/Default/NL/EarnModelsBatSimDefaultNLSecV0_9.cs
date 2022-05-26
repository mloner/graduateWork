namespace ReportingFramework.Structure.Sections.EarnModels.BatSim.Default.NL
{
    public class EarnModelsBatSimDefaultNLSecV0_9 : EarnModelsBatSimSec
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
            //         { "CompanyName", _template.GlobalSettings.CompanyName },
            //     });
            // AddParagraph(desc1Par);
            //
            // AddSpace(0.1);
            //
            // //list
            // var list = ResHelper.GetResVal(_sectionResName, "EarningModelList", _ci).Split(";");
            // for (var i = 0; i < list.Length; i++)
            // {
            //     var elemNum = i + 1;
            //     var par = CreateParagraph($"{elemNum}. {list[i]}");
            //     par.Format.LeftIndent = new Unit(0.5, UnitType.Centimeter);
            //     _pdfSection.Add(par);
            //     AddSpace(0.2);
            // }
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
            //     .ReplaceVals(new Dictionary<string, string>()
            //     {
            //         { "CompanyName", _template.GlobalSettings.CompanyName },
            //     });
            // AddParagraph(desc2Par);
            //
            // #endregion
            //
            // AddSpace(0.3);
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
            // #region 1
            //
            // var desc3_1Name = $"{desc3Name}_1";
            // var desc3_1Par = (ReportParagraph)desc3Childs[0];
            // AddParagraph(
            //     ResHelper.GetResVal(_sectionResName, desc3_1Name, _resParams.CultureInfo)
            // );
            //
            // #endregion
            //
            // AddSpace(0.3);
            //
            // #region 2
            //
            // var desc3_2Name = $"{desc3Name}_2";
            // var desc3_2Par = (ReportParagraph)desc3Childs[1];
            // AddParagraph(
            //     ResHelper.GetResVal(_sectionResName, desc3_2Name, _resParams.CultureInfo)
            //         .ReplaceVals(new Dictionary<string, string>()
            //         {
            //             {"CompanyName", _template.GlobalSettings.CompanyName}
            //         })
            // );
            //
            // #endregion
            //
            // #endregion
            //
            // #endregion
            //
            // AddSpace(1);
            //
            // #region Chart
            //
            // string chartName;
            // Chart chart;
            // string chartPath;
            //
            // chartName = $"{SubsectionTypeEnum.Chart.Desc()}_ElBillStructure";
            // chart = (Chart)GetReportObj(_sectionData, chartName);
            // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // chart.Title = ResHelper.GetResVal(_sectionResName, $"{chartName}_Title", _ci);
            // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // AddImage(
            //     section: _pdfSection,
            //     imgPath: chartPath,
            //     imgTitle: chart.Title,
            //     imgWidthCm: new Unit(13, UnitType.Centimeter).Centimeter,
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles,
            //     figureNum: _secParams.ReportSettings.AddFigure);
            //
            // #endregion
        }

        public override void GenerateContent()
        {
            throw new System.NotImplementedException();
        }
    }
}