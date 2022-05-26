namespace ReportingFramework.Structure.Sections.AlgoPerfExplRes.BatSimShort.Default
{
    public class AlgoPerfExplResShortSecBatSimShortDefaultV0_9 : AlgoPerfExplResBatSimShortSec
    {
        public override void InitSectionModel(string sectionModelJson)
        {
            throw new System.NotImplementedException();
        }

        public override void Generate()
        {
          //   Table table;
          //   Column col;
          //   Row row;
          //   int colNum = 0;
          //   
          //   string chartName;
          //   Chart chart;
          //   string chartPath;
          //   
          //   #region Self cons
          //
          //   #region Title
          //
          //   _name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_SelfCons_Title";
          //   _repPar = new ReportParagraph();
          //   _repPar.Text = ResHelper.GetResVal(_sectionResName, _name, _ci);
          //   AddParagraph(_repPar, StyleEnum.H1);
          //
          //   #endregion
          //
          //   #region Charts
          //
          //   table = _pdfSection.AddTable();
          //   col = table.AddColumn(new Unit(GetSectionWidthCm() / 3, UnitType.Centimeter));
          //   col = table.AddColumn(new Unit(GetSectionWidthCm() / 3, UnitType.Centimeter));
          //   col = table.AddColumn(new Unit(GetSectionWidthCm() / 3, UnitType.Centimeter));
          //   row = table.AddRow();
          //
          //   colNum = 0;
          //   
          //   #region Ref
          //
          //   chartName = $"{SubsectionTypeEnum.Chart.Desc()}_SelfConsChartRef";
          //   chart = (Chart)GetReportObj(_sectionData, chartName);
          //   chart.Init(_resParams, _template, _secParams.NumFmtr);
          //   chart.Title = ResHelper.GetResVal(_sectionResName, $"{chartName}_Title", _ci);
          //   chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
          //   _paragraphs =  AddImagePar(
          //       imgPath: chartPath,
          //       imgTitle: chart.Title,
          //       titleSize: 8,
          //       isShortTitle: true,
          //       imgWidthCm: GetSectionWidthCm() / 3,
          //       globalSettings: _template.GlobalSettings,
          //       styles: _styles,
          //       figureNum: _secParams.ReportSettings.AddFigure);
          //   row.Cells[colNum].Add(_paragraphs);
          //
          //   #endregion
          //
          //   colNum++;
          //   
          //   #region Alt
          //
          //   chartName = $"{SubsectionTypeEnum.Chart.Desc()}_SelfConsChartAlt";
          //   chart = (Chart)GetReportObj(_sectionData, chartName);
          //   chart.Init(_resParams, _template, _secParams.NumFmtr);
          //   chart.Title = ResHelper.GetResVal(_sectionResName, $"{chartName}_Title", _ci);
          //   chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
          //   _paragraphs =  AddImagePar(
          //       imgPath: chartPath,
          //       imgTitle: chart.Title,
          //       titleSize: 8,
          //       isShortTitle: true,
          //       imgWidthCm: GetSectionWidthCm() / 3,
          //       globalSettings: _template.GlobalSettings,
          //       styles: _styles,
          //       figureNum: _secParams.ReportSettings.AddFigure);
          //   row.Cells[colNum].Add(_paragraphs);
          //
          //   #endregion
          //   
          //   colNum++;
          //   
          //   #region Main
          //
          //   chartName = $"{SubsectionTypeEnum.Chart.Desc()}_SelfConsChartMain";
          //   chart = (Chart)GetReportObj(_sectionData, chartName);
          //   chart.Init(_resParams, _template, _secParams.NumFmtr);
          //   chart.Title = ResHelper.GetResVal(_sectionResName, $"{chartName}_Title", _ci);
          //   chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
          //   _paragraphs =  AddImagePar(
          //       imgPath: chartPath,
          //       imgTitle: chart.Title,
          //       titleSize: 8,
          //       isShortTitle: true,
          //       imgWidthCm: GetSectionWidthCm() / 3,
          //       globalSettings: _template.GlobalSettings,
          //       styles: _styles,
          //       figureNum: _secParams.ReportSettings.AddFigure);
          //   row.Cells[colNum].Add(_paragraphs);
          //
          //   #endregion
          //
          //   #endregion
          //
          //   #endregion
          //   
          //   AddSpace(2);
          //
          //   #region Peak shaving
          //
          //   #region Title
          //
          //   _name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_PeakShav_Title";
          //   _repPar = new ReportParagraph();
          //   _repPar.Text = ResHelper.GetResVal(_sectionResName, _name, _ci);
          //   AddParagraph(_repPar, StyleEnum.H1);
          //
          //   #endregion
          //
          //   #region Chart
          //
          //   chartName = $"{SubsectionTypeEnum.Chart.Desc()}_{ChartEnum.PeakShavAvgDayMultuComp.Desc()}";
          //   chart = (Chart)GetReportObj(_sectionData, chartName);
          //   chart.Init(_resParams, _template, _secParams.NumFmtr);
          //   chart.Title = ResHelper.GetResVal(_sectionResName, $"{chartName}_Title", _ci);
          //   chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
          //   AddImage(
          //       section: _pdfSection,
          //       imgPath: chartPath,
          //       imgTitle: chart.Title,
          //       titleSize: 10,
          //       imgWidthCm: 13,
          //       globalSettings: _template.GlobalSettings,
          //       styles: _styles,
          //       figureNum: _secParams.ReportSettings.AddFigure);
          //
          //   #endregion
          //
          //   #endregion
          //   
          //   AddSpace(2);
          //
          //   #region BuySellEn
          //   
          //   #region Title
          //
          //   _name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_BuySellEn_Title";
          //   _repPar = new ReportParagraph();
          //   _repPar.Text = ResHelper.GetResVal(_sectionResName, _name, _ci);
          //   AddParagraph(_repPar, StyleEnum.H1);
          //
          //   #endregion
          //
          //   #region Content
          //
          // //  AddBuySellEnTable(_sectionData.Data.ReportObjects);
          //
          //   #endregion
          //
          //   #endregion
        }

        public override void GenerateContent()
        {
            throw new System.NotImplementedException();
        }

        // private void AddBuySellEnTable(List<IReportObject> reportObject)
        // {
        //     var tableName = $"{SubsectionTypeEnum.Table}_BuySellEn";
        //     var tableData = GetReportObj(reportObject, tableName) as ReportTable;
        //
        //     #region Table
        //
        //     var prefix = tableName;
        //     var table = _pdfSection.AddTable();
        //     var colIdx = 0;
        //     
        //
        //     #region Columns
        //
        //     #region Create
        //
        //     var tableColumnsCount = 4;
        //     for (var i = 0; i < tableColumnsCount; i++)
        //     {
        //         var col = table.AddColumn();
        //     }
        //
        //     #endregion
        //
        //     #region Columns width
        //
        //     colIdx = 0;
        //     
        //     table.Columns[colIdx++].Width = new Unit(5, UnitType.Centimeter);
        //     table.Columns[colIdx++].Width = new Unit(3, UnitType.Centimeter);
        //     table.Columns[colIdx++].Width = new Unit(3, UnitType.Centimeter);
        //     table.Columns[colIdx++].Width = new Unit(3, UnitType.Centimeter);
        //
        //     colIdx = 0;
        //
        //     #endregion
        //
        //     #endregion
        //
        //     #region Header
        //
        //     #region Create
        //
        //     var header = GlobalFormatting.Tables.InitHeader(SectionExtensions.GetStyle(_styles,
        //         StyleEnum.TableHeader));
        //     table.Rows.Add(header);
        //
        //     #endregion
        //
        //     #region Fill
        //
        //     colIdx = 0;
        //     
        //     // Param
        //     _par = CreateParagraph("", StyleEnum.TableHeader);
        //     header.Cells[colIdx].Add(_par.Clone());
        //     colIdx++;
        //     
        //     // Ref
        //     _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_Ref_Header", _ci), StyleEnum.TableHeader);
        //     header.Cells[colIdx].Add(_par.Clone());
        //     colIdx++;
        //     
        //     // Alt
        //     _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_Alt_Header", _ci), StyleEnum.TableHeader);
        //     header.Cells[colIdx].Add(_par.Clone());
        //     colIdx++;
        //     
        //     // Main
        //     _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_Main_Header", _ci), StyleEnum.TableHeader);
        //     header.Cells[colIdx].Add(_par.Clone());
        //     colIdx++;
        //     
        //     colIdx = 0;
        //     
        //     #endregion
        //
        //     #endregion
        //     
        //     #region Content
        //
        //     #region Prepare table data
        //
        //     var euroSign = "€";
        //     var percentSign = "%";
        //     var pName = "ParamName";
        //     var pValue = "ParamValue";
        //     List<Dictionary<string, string>> newTableRows;
        //     Dictionary<string, string> tmpElem;
        //
        //     #region Filter columns
        //
        //     newTableRows = tableData.TableData.Select(row =>
        //     {
        //         return row;
        //     }).ToList();
        //
        //     #endregion
        //     
        //     #region Transform rows
        //
        //     var newTableRowsFiltered = newTableRows;
        //     
        //     
        //
        //     newTableRows = newTableRowsFiltered;
        //     
        //     #endregion
        //
        //     #endregion
        //
        //     #region Fill
        //     
        //     int j = 0;
        //     //Lowest buy, Highest sell
        //     foreach (var row in newTableRows.Where(x => new List<string>()
        //              {
        //                  "LowestBuy",
        //                  "HighestSell"
        //              }.Contains(x["Param"])))
        //     {
        //         var newRow =
        //             GlobalFormatting.Tables.InitRow(SectionExtensions.GetStyle(_styles, StyleEnum.TableContentDefault));
        //         colIdx = 0;
        //         var fieldData = "";
        //         
        //         //Param
        //         _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_{row["Param"]}", _ci),
        //             StyleEnum.TableContentPrimary);
        //         newRow.Cells[colIdx].Add(_par.Clone());
        //         colIdx++;
        //         
        //         
        //         //Ref
        //         _par = CreateParagraph(_numFmtr.Format(row["Ref"], decimals:4), StyleEnum.TableContentDefault);
        //         newRow.Cells[colIdx].Add(_par.Clone());
        //         colIdx++;
        //         
        //         //Alt
        //         _par = CreateParagraph(_numFmtr.Format(row["Alt"], decimals:4), StyleEnum.TableContentDefault);
        //         newRow.Cells[colIdx].Add(_par.Clone());
        //         colIdx++;
        //         
        //         //Main
        //         _par = CreateParagraph(_numFmtr.Format(row["Main"], decimals:4), StyleEnum.TableContentDefault);
        //         newRow.Cells[colIdx].Add(_par.Clone());
        //         colIdx++;
        //
        //         table.Rows.Add(newRow);
        //         j++;
        //     }
        //
        //     foreach (var row in newTableRows.Where(x => !new List<string>()
        //              {
        //                  "LowestBuy",
        //                  "HighestSell"
        //              }.Contains(x["Param"])))
        //     {
        //         var newRow =
        //             GlobalFormatting.Tables.InitRow(SectionExtensions.GetStyle(_styles, StyleEnum.TableContentDefault));
        //         colIdx = 0;
        //         var isLastRow = j == newTableRows.Count - 1;
        //         var fieldData = "";
        //         
        //         //ParamName
        //         _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_{row["Param"]}", _ci),
        //             StyleEnum.TableContentPrimary);
        //         newRow.Cells[colIdx].Add(_par.Clone());
        //         colIdx++;
        //         
        //         
        //         //Ref
        //         _par = CreateParagraph(_numFmtr.Format(row["Ref"]), StyleEnum.TableContentDefault);
        //         newRow.Cells[colIdx].Add(_par.Clone());
        //         colIdx++;
        //         
        //         //Alt
        //         _par = CreateParagraph(_numFmtr.Format(row["Alt"]), StyleEnum.TableContentDefault);
        //         newRow.Cells[colIdx].Add(_par.Clone());
        //         colIdx++;
        //         
        //         //Main
        //         _par = CreateParagraph(_numFmtr.Format(row["Main"]), StyleEnum.TableContentDefault);
        //         newRow.Cells[colIdx].Add(_par.Clone());
        //         colIdx++;
        //
        //         //last row is bold
        //         if (isLastRow)
        //         {
        //             foreach (Cell newRowCell in newRow.Cells)
        //             {
        //                 foreach (DocumentObject documentElement in newRowCell.Elements)
        //                 {
        //                     ((Paragraph) documentElement).Format.Font.Bold = true;
        //                 }
        //             }
        //         }
        //
        //         table.Rows.Add(newRow);
        //         j++;
        //     }
        //
        //     #endregion
        //     
        //     #endregion
        //
        //     #endregion
        //
        // }
    }
}