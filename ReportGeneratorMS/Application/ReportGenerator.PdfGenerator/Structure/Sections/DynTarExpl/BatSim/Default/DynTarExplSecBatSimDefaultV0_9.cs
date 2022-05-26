namespace ReportingFramework.Structure.Sections.DynTarExpl.BatSim.Default
{
    public class DynTarExplSecBatSimDefaultV0_9 : DynTarExplBatSimSec
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
            // #region Images
            //
            // Table table;
            // Column col;
            // Row row;
            // int rowNum = 0;
            // int colNum = 0;
            // Paragraph imgPar;
            // List<Paragraph> paragraphs;
            // string chartPath;
            // string chartName;
            // string imgName;
            // Image image;
            //
            // table = _pdfSection.AddTable();
            // col = table.AddColumn(new Unit(GetSectionWidthCm()/2, UnitType.Centimeter));
            // col = table.AddColumn(new Unit(GetSectionWidthCm()/2, UnitType.Centimeter));
            //
            // row = table.AddRow();
            // colNum = 0;
            //
            //
            //
            // #region Image 1
            //
            // imgName = $"{SubsectionTypeEnum.Image.Desc()}_DynTarExpl_1";
            // image = GetReportObj(_sectionData, imgName) as Image;
            // image.Init(_resParams, _template, _secParams.NumFmtr);
            // image.Title = ResHelper.GetResVal(_sectionResName, $"{imgName}_Title", _ci);
            // image.Path = $"{_resParams.Paths.SectionImages}/{image.Path}";
            // paragraphs = AddImagePar(
            //     imgPath: image.Path,
            //     imgTitle: image.Title,
            //     imgWidthCm: GetSectionWidthCm()/2,
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles,
            //     figureNum: _secParams.ReportSettings.AddFigure,
            //     titleSize: 8
            // );
            // row.Cells[colNum].Add(paragraphs);
            //
            // #endregion
            //
            //
            // colNum++;
            //
            // #region Image 2
            //
            // imgName = $"{SubsectionTypeEnum.Image.Desc()}_DynTarExpl_2";
            // image = GetReportObj(_sectionData, imgName) as Image;
            // image.Init(_resParams, _template, _secParams.NumFmtr);
            // image.Title = ResHelper.GetResVal(_sectionResName, $"{imgName}_Title", _ci);
            // image.Path = $"{_resParams.Paths.SectionImages}/{image.Path}";
            // paragraphs = AddImagePar(
            //     imgPath: image.Path,
            //     imgTitle: image.Title,
            //     imgWidthCm: GetSectionWidthCm()/2,
            //     globalSettings: _template.GlobalSettings,
            //     styles: _styles,
            //     figureNum: _secParams.ReportSettings.AddFigure,
            //     titleSize: 8
            // );
            // row.Cells[colNum].Add(paragraphs);
            //
            // #endregion
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
            // {
            //     {"CompanyName", _template.GlobalSettings.CompanyName}
            // });
            // AddParagraph(desc2Par);
            //
            // #endregion
            //
            // AddSpace(0.3);
            //
            // #region Desc 3
            //
            // var desc3Name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Desc_3";
            // var desc3Par = (ReportParagraph)GetReportObj(_sectionData, desc3Name);
            // desc3Par.Text = ResHelper.GetResVal(_sectionResName, desc3Name, _ci)
            //     .ReplaceVals(new Dictionary<string, string>()
            //     {
            //         {"CompanyName", _template.GlobalSettings.CompanyName}
            //     });
            // AddParagraph(desc3Par);
            //
            // #endregion
            //
            // AddSpace(0.3);
            //
            // #region Desc 4
            //
            // var desc4Name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Desc_4";
            // var desc4Par = (ReportParagraph)GetReportObj(_sectionData, desc4Name);
            // desc4Par.Text = ResHelper.GetResVal(_sectionResName, desc4Name, _ci)
            //     .ReplaceVals(new Dictionary<string, string>()
            // {
            //     {"CompanyName", _template.GlobalSettings.CompanyName}
            // });
            // AddParagraph(desc4Par);
            //
            // #endregion
            //
            // _pdfSection.AddPageBreak();
            //
            // #region Examples
            //
            // #region Desc 5
            //
            // var desc5Name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Desc_5";
            // var desc5Par = (ReportParagraph)GetReportObj(_sectionData, desc5Name);
            // desc5Par.Text = ResHelper.GetResVal(_sectionResName, desc5Name, _ci);
            // AddParagraph(desc5Par);
            //
            // #endregion
            //
            // AddSpace(0.3);
            //
            // #region Ex_1
            //
            // var ex1 = (ReportParagraph)GetReportObj(_sectionData, $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Ex_1");
            //
            // #region Title
            //
            // _name = $"{ex1.Name}_Title";
            // AddParagraph(ResHelper.GetResVal(_sectionResName, _name, _ci), StyleEnum.H3);
            //
            // #endregion
            //
            // #region Content
            //
            // #region 1
            //
            // _name = $"{ex1.Name}_1";
            // RepPar = (ReportParagraph)GetReportObj(ex1.ChildObjects, _name);
            // RepPar.Text = ResHelper.GetResVal(_sectionResName, _name, _ci);
            // AddParagraph(RepPar);
            //
            // #endregion
            //
            // #region 2
            //
            // _name = $"{ex1.Name}_2";
            // RepPar = (ReportParagraph)GetReportObj(ex1.ChildObjects, _name);
            // RepPar.Text = ResHelper.GetResVal(_sectionResName, _name, _ci);
            // AddParagraph(RepPar);
            //
            // #endregion
            //
            // #endregion
            //
            // #endregion
            //
            // AddSpace(0.3);
            //
            // #region Ex_2
            //
            // var ex2 = (ReportParagraph)GetReportObj(_sectionData,
            //     $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Ex_2");
            //
            // #region Title
            //
            // _name = $"{ex2.Name}_Title";
            // AddParagraph(ResHelper.GetResVal(_sectionResName, _name, _ci), StyleEnum.H3);
            //
            // #endregion
            //
            // #region Content
            //
            // #region 1
            //
            // _name = $"{ex2.Name}_1";
            // RepPar = (ReportParagraph)GetReportObj(ex2.ChildObjects, _name);
            // RepPar.Text = ResHelper.GetResVal(_sectionResName, _name, _ci)
            //     .ReplaceVals(new Dictionary<string, string>()
            //     {
            //         {"CompanyName", _template.GlobalSettings.CompanyName}
            //     });
            // AddParagraph(RepPar);
            //
            // #endregion
            //
            // #region 2
            //
            // _name = $"{ex2.Name}_2";
            // RepPar = (ReportParagraph)GetReportObj(ex2.ChildObjects, _name);
            // RepPar.Text = ResHelper.GetResVal(_sectionResName, _name, _ci);
            // AddParagraph(RepPar);
            //
            // #endregion
            //
            // #endregion
            //
            // #endregion
            //
            // AddSpace(0.3);
            //
            // #region Ex_3
            //
            // var ex3 = (ReportParagraph)GetReportObj(_sectionData,
            //     $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Ex_3");
            //
            // #region Title
            //
            // _name = $"{ex3.Name}_Title";
            // AddParagraph(ResHelper.GetResVal(_sectionResName, _name, _ci), StyleEnum.H3);
            //
            // #endregion
            //
            // #region Content
            //
            // #region 1
            //
            // _name = $"{ex3.Name}_1";
            // RepPar = (ReportParagraph)GetReportObj(ex3.ChildObjects, _name);
            // RepPar.Text = ResHelper.GetResVal(_sectionResName, _name, _ci);
            // AddParagraph(RepPar);
            //
            // #endregion
            //
            // #endregion
            //
            // #endregion
            //
            // #endregion
            //
            // AddSpace(0.3);
            //
            // #region Desc 6
            //
            // var desc6Name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Desc_6";
            // var desc6Par = (ReportParagraph)GetReportObj(_sectionData, desc6Name);
            // desc6Par.Text = ResHelper.GetResVal(_sectionResName, desc6Name, _ci)
            //     .ReplaceVals(new Dictionary<string, string>()
            //     {
            //         {"CompanyName", _template.GlobalSettings.CompanyName}
            //     });
            // AddParagraph(desc6Par);
            //
            // #endregion
            //
            // AddSpace(0.3);
            //
            // #region Desc 7
            //
            // var desc7Name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Desc_7";
            // var desc7Par = (ReportParagraph)GetReportObj(_sectionData, desc7Name);
            // desc7Par.Text = ResHelper.GetResVal(_sectionResName, desc7Name, _ci);
            // AddParagraph(desc7Par);
            //
            // #endregion

        }

        public override void GenerateContent()
        {
            throw new System.NotImplementedException();
        }
    }
}