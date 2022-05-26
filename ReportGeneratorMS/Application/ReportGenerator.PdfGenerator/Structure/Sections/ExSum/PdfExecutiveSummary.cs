namespace ReportingFramework.Structure.Sections.ExSum
{
    public abstract class PdfExecutiveSummary : PdfReportSection
    {
        // public void GenerateReportTitle(
        //     Section section,
        //     BaseReportTitle reportTitle,
        //     PdfTemplate pdfTemplate
        // )
        // {
        //     Table table;
        //     Column column1;
        //     Column column2;
        //     Row row;
        //     Image img;
        //
        //     ShiftedUpParagraphFromTop(0.5);
        //
        //     table = section.AddTable();
        //     table.BottomPadding = new Unit(0.1, UnitType.Centimeter);
        //     table.TopPadding = 0;
        //     table.LeftPadding = 0;
        //     table.RightPadding = 0;
        //     
        //     
        //     table.Borders.Color = Colors.Black;
        //     table.Borders.Bottom.Color = Colors.Gray;
        //
        //     var colWidth = new Unit(GetSectionWidthCm(), UnitType.Centimeter);
        //     table.AddColumn().Width = colWidth * 5/20;
        //     table.AddColumn().Width = colWidth * 1/20;
        //     table.AddColumn().Width = colWidth * 14/20;
        //     row = table.AddRow();
        //     
        //     table.Columns.Width = new Unit(GetSectionWidthCm(), UnitType.Centimeter);
        //
        //     //logo
        //     row.Cells[0].VerticalAlignment = VerticalAlignment.Top;
        //     row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
        //     img = row.Cells[0].AddImage(reportTitle.LogoImgPath);
        //     img.Width = row.Cells[0].Column.Width;
        //  
        //     
        //     row.Cells[2].VerticalAlignment = VerticalAlignment.Top;
        //     //header
        //     Par = row.Cells[2].AddParagraph();
        //     Par.AddText(reportTitle.ReportHeader);
        //     Par.Format = SectionExtensions.GetParagraphFormat(pdfTemplate.Styles, StyleEnum.TitlePageHeader);
        //     Par.Format.Alignment = ParagraphAlignment.Right;
        //     //subheader
        //     Par = row.Cells[2].AddParagraph();
        //     Par.AddText(reportTitle.ReportSubheader);
        //     Par.Format = SectionExtensions.GetParagraphFormat(pdfTemplate.Styles, StyleEnum.TitlePageSubheader);
        //     Par.Format.Alignment = ParagraphAlignment.Right;
        //     
        //     //space
        //     AddSpace(1.0);
        // }
        //
        // protected void AddBasicInfo(Section section, PdfTemplate template, BaseBasicInfo basicInfo, ResourceParameters resourceParameters)
        // {
        //     //title
        //     Par = section.AddParagraph();
        //     Par.Format = SectionExtensions.GetParagraphFormat(template.Styles, StyleEnum.Title);
        //     Par.Elements = FormattedText(basicInfo.Title).Elements.Clone();
        //     
        //     //table
        //     var table = section.AddTable();
        //     Column col;
        //     col = table.AddColumn();
        //     col.Width = new Unit(6, UnitType.Centimeter);
        //     col = table.AddColumn();
        //     col.Width = new Unit(5, UnitType.Centimeter);
        //     var row = table.AddRow();
        //     
        //     foreach (var kvPair in basicInfo.Values)
        //     {
        //         Par = row.Cells[0].AddParagraph();
        //         Par.Format = SectionExtensions.GetParagraphFormat(template.Styles, StyleEnum.Normal);
        //         Par.AddText(kvPair.Key);
        //         
        //         Par = row.Cells[1].AddParagraph();
        //         Par.Format = SectionExtensions.GetParagraphFormat(template.Styles, StyleEnum.Normal);
        //         Par.AddText(kvPair.Value);
        //     }
        //     
        //     AddSpace(0.3);
        // }

        // protected List<DocumentObject> AddLocationInfoBlock(
        //     IReportObject reportObject)
        // {
        //     // var res = new List<DocumentObject>();
        //     //
        //     // #region Title
        //     //
        //     // _name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Location";
        //     // var locTitle = GetReportObj(reportObject.ChildObjects, _name) as ReportParagraph;
        //     // locTitle.Title = ResHelper.GetResVal(_sectionResName, $"{_name}_Title", _ci);
        //     // var locTitlePar = CreateParagraph(locTitle.Title, StyleEnum.H1);
        //     // res.Add(locTitlePar);
        //     //
        //     // #endregion
        //     //
        //     // AddSpace(0.1);
        //     //
        //     // #region Tables
        //     //
        //     // var locInfoTbl = new Table();
        //     // locInfoTbl.AddColumn(new Unit(GetSectionWidthCm() / 2, UnitType.Centimeter));
        //     // locInfoTbl.AddColumn(new Unit(GetSectionWidthCm() / 2, UnitType.Centimeter));
        //     // var row = locInfoTbl.AddRow();
        //     //
        //     // #region Location
        //     //
        //     // RepPar = GetReportObj(reportObject.ChildObjects, $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Location") as ReportParagraph;
        //     // var locTbl = AddLocationBlock(_template, _secParams.ResourceParameters, _secParams.Template.GlobalSettings, _styles, RepPar);
        //     // row.Cells[0].Elements.Add(locTbl.Clone());
        //     //
        //     // #endregion
        //     //
        //     // #region Consumption info
        //     //
        //     // RepPar = GetReportObj(reportObject.ChildObjects, $"{SubsectionTypeEnum.CommonDataObj.Desc()}_ConsumptionInfo") as ReportParagraph;
        //     // var consInfoTbl = CreateConsumptionInfoBlock(_template, _secParams, _styles, RepPar);
        //     // row.Cells[1].Elements.Add(consInfoTbl.Clone());
        //     //
        //     // #endregion
        //     //
        //     // res.Add(locInfoTbl);
        //     //
        //     // #endregion
        //     //
        //     // return res;
        // }

        // protected Table AddLocationBlock(
        //     PdfTemplate template,
        //     ResourceParameters resourceParameters,
        //     GlobalSettings globalSettings,
        //     List<Style> styles,
        //     AbstractReportObject reportObject)
        // {
        //     var res = new Table();
        //
        //     //res.Borders.Color = Colors.Black;
        //     res.AddColumn(new Unit(1.3, UnitType.Centimeter));
        //     res.AddColumn(new Unit(5, UnitType.Centimeter));
        //     var row = res.AddRow();
        //     row.VerticalAlignment = VerticalAlignment.Center;
        //     
        //     #region Icon
        //
        //     var imgPar = new Paragraph();
        //     imgPar.Format.Alignment = ParagraphAlignment.Left;
        //     var img = imgPar.AddImage($"{resourceParameters.Paths.SectionImages}/Location.png");
        //     img.Height = new Unit(1.17, UnitType.Centimeter);
        //     img.LockAspectRatio = true;
        //     row.Cells[0].Add(imgPar.Clone());
        //
        //     #endregion
        //
        //     #region Desc
        //
        //     Par = CreateParagraph(reportObject.Parameters["Name"], StyleEnum.Normal);
        //     row.Cells[1].Add(Par.Clone());
        //     Par = CreateParagraph(reportObject.Parameters["Building"], StyleEnum.Normal);
        //     row.Cells[1].Add(Par.Clone());
        //     Par = CreateParagraph(reportObject.Parameters["Index"], StyleEnum.Normal);
        //     row.Cells[1].Add(Par.Clone());
        //
        //     #endregion
        //
        //     return res;
        // }
        //
        // protected Table CreateConsumptionInfoBlock(
        //     PdfTemplate template,
        //     PdfSectionParameters sectionParams,
        //     List<Style> styles,
        //     AbstractReportObject repObj)
        // {
        //     var resParams = sectionParams.ResourceParameters;
        //
        //     var res = new Table();
        //
        //     //res.Borders.Color = Colors.Black;
        //     res.AddColumn(new Unit(1.3, UnitType.Centimeter));
        //     res.AddColumn(new Unit(5, UnitType.Centimeter));
        //     var row = res.AddRow();
        //     row.VerticalAlignment = VerticalAlignment.Center;
        //
        //     #region Icon
        //
        //     var imgPar = new Paragraph();
        //     imgPar.Format.Alignment = ParagraphAlignment.Left;
        //     var img = imgPar.AddImage($"{resParams.Paths.SectionImages}/Energy.png");
        //     img.Height = new Unit(1.17, UnitType.Centimeter);
        //     img.LockAspectRatio = true;
        //     row.Cells[0].Add(imgPar.Clone());
        //
        //     #endregion
        //
        //     #region Desc
        //
        //     var prefix = "LocationInfo_ConsumptionInfo";
        //     var recordFormat = "{0}: {1} kWh";
        //     
        //     //Consumption
        //     Str =
        //         $"{ResHelper.GetResVal(resParams.Paths.SectionTextResourceNamespace, $"{prefix}_Consumption", resParams.CultureInfo)}";
        //     Str = string.Format(recordFormat, Str, sectionParams.NumFmtr.Format(repObj.Parameters["Consumption"]));
        //     Par = CreateParagraph(Str, StyleEnum.Normal);
        //     row.Cells[1].Add(Par.Clone());
        //     
        //     //Generation
        //     Str =
        //         $"{ResHelper.GetResVal(resParams.Paths.SectionTextResourceNamespace, $"{prefix}_Generation", resParams.CultureInfo)}";
        //     Str = string.Format(recordFormat, Str, sectionParams.NumFmtr.Format(repObj.Parameters["Generation"]));
        //     Par = CreateParagraph(Str, StyleEnum.Normal);
        //     row.Cells[1].Add(Par.Clone());
        //     
        //     //Injection
        //     Str =
        //         $"{ResHelper.GetResVal(resParams.Paths.SectionTextResourceNamespace, $"{prefix}_Injection", resParams.CultureInfo)}";
        //     Str = string.Format(recordFormat, Str, sectionParams.NumFmtr.Format(repObj.Parameters["Injection"]));
        //     Par = CreateParagraph(Str, StyleEnum.Normal);
        //     row.Cells[1].Add(Par.Clone());
        //
        //     #endregion
        //     
        //     return res;
        // }
        
    }
}