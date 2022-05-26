namespace ReportingFramework.Structure.Sections.Subsidy.BatSim.Default
{
    public class SubsidySecBatSimDefaultSecV0_9 : SubsidyBatSimSec
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
            // #region Table
            //
            // AddYearlySubsidiesTable();
            //
            // #endregion
            //
            // AddSpace(0.5);
            //
            // #region Chart
            //
            // string chartName;
            // Chart chart;
            // string chartPath;
            //
            // // chartName = $"{SubsectionTypeEnum.Chart.Desc()}_BatterySubsidy";
            // // chart = (Chart)GetReportObj(_sectionData, chartName);
            // // chart.Init(_resParams, _template, _secParams.NumFmtr);
            // // chart.Title = ResHelper.GetResVal(_sectionResName, $"{chartName}_Title", _ci);
            // // chartPath = _secParams.ChartGeneratorClient.CreateChart(chart);
            // // AddImage(
            // //     section: _pdfSection,
            // //     imgPath: chartPath,
            // //     imgTitle: chart.Title,
            // //     imgWidthCm: 13,
            // //     globalSettings: _template.GlobalSettings,
            // //     styles: _styles,
            // //     figureNum: _secParams.ReportSettings.AddFigure);
            //
            // #endregion
            //
            // AddSpace(0.3);
            //
            // #region Desc 2
            //
            // var desc2Name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Desc_2";
            // var desc2Par = (ReportParagraph)GetReportObj(_sectionData, desc2Name);
            // desc2Par.Text = ResHelper.GetResVal(_sectionResName, desc2Name, _ci);
            // AddParagraph(desc2Par);
            //
            // #endregion
        }

        public override void GenerateContent()
        {
            throw new System.NotImplementedException();
        }

        private void AddYearlySubsidiesTable()
        {
            //var prefix = $"{SubsectionTypeEnum.Table.Desc()}_Yearly_Subsidies";
         //   var tableData = GetReportObj(_sectionData.Data.ReportObjects, prefix) as ReportTable;

            // #region Table
            //
            // var table = _pdfSection.AddTable();
            // var colIdx = 0;
            //
            //
            // #region Columns
            //
            // #region Create
            //
            // var tableColumnsCount = 6;
            // for (var i = 0; i < tableColumnsCount; i++)
            // {
            //     var col = table.AddColumn();
            // }
            //
            // #endregion
            //
            // #region Columns width
            //
            // colIdx = 0;
            //
            // table.Columns[colIdx++].Width = new Unit(GetSectionWidthCm() * 1/7, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(GetSectionWidthCm() * 1/7, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(GetSectionWidthCm() * 1/7, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(GetSectionWidthCm() * 1/7, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(GetSectionWidthCm() * 1/7, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(GetSectionWidthCm() * 2/7, UnitType.Centimeter);
            //
            // colIdx = 0;
            //
            // #endregion
            //
            // #endregion
            //
            // #region Header
            //
            // #region Create
            //
            // var header = GlobalFormatting.Tables.InitHeader(SectionExtensions.GetStyle(_styles, StyleEnum.TableHeader));
            // table.Rows.Add(header);
            //
            // #endregion
            //
            // #region Fill
            //
            // colIdx = 0;
            //
            // // Date
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_Date", _ci), StyleEnum.TableHeader);
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // From0to4
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_From0to4", _ci), StyleEnum.TableHeader);
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // From4to6
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_From4to6", _ci), StyleEnum.TableHeader);
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // From6to9
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_From6to9", _ci), StyleEnum.TableHeader);
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // From9
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_From9", _ci), StyleEnum.TableHeader);
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // Maximum
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_Maximum", _ci), StyleEnum.TableHeader);
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            //     
            // colIdx = 0;
            //
            // #endregion
            //
            // #endregion
            //
            // #region Subheader
            //
            // #region Create
            //
            // var subheader = GlobalFormatting.Tables.InitSubheader(SectionExtensions.GetStyle(_styles, StyleEnum.TableSubheader));
            // table.Rows.Add(subheader);
            //
            // #endregion
            //
            // #region Fill
            //
            // colIdx = 0;
            //
            // var euroSign = "€";
            // var eurokWhSign = "€/kWh";
            //
            // // Date
            // _par = CreateParagraph("", StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // From0to4
            // _par = CreateParagraph(eurokWhSign, StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // From4to6
            // _par = CreateParagraph(eurokWhSign, StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // From6to9
            // _par = CreateParagraph(eurokWhSign, StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // From9
            // _par = CreateParagraph(eurokWhSign, StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // Maximum
            // _par = CreateParagraph(euroSign, StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // colIdx = 0;
            //
            // #endregion
            //
            // #endregion
            //
            // #region Content
            //
            // #region Prepare table data
            //
            // var tableRows = new List<Dictionary<string, string>>();
            // tableRows = tableData.TableData.Select(row =>
            // {
            //     var newRow = new Dictionary<string, string>();
            //     var colName = "";
            //
            //     return row;
            // }).ToList();
            //
            // #endregion
            //
            // #region Fill
            //
            // foreach (var row in tableRows)
            // {
            //     var newRow =
            //         GlobalFormatting.Tables.InitRow(SectionExtensions.GetStyle(_styles,
            //             StyleEnum.TableContentDefault));
            //     colIdx = 0;
            //     var fieldData = "";
            //     
            //     // Date
            //     _par = CreateParagraph(row["Date"], StyleEnum.TableContentPrimary);
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //
            //     // From0to4
            //     _par = CreateParagraph(_numFmtr.Format(row["From0to4"], decimals:1), StyleEnum.TableContentDefault);
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     // From4to6
            //     _par = CreateParagraph(_numFmtr.Format(row["From4to6"], decimals:1), StyleEnum.TableContentDefault);
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     // From6to9
            //     _par = CreateParagraph(_numFmtr.Format(row["From6to9"], decimals:1), StyleEnum.TableContentDefault);
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     // From9
            //     _par = CreateParagraph(_numFmtr.Format(row["From9"], decimals:1), StyleEnum.TableContentDefault);
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     // Maximum
            //     var maximumFieldData = row["Maximum"];
            //     try
            //     {
            //         var maximumFieldDataNumbers = maximumFieldData.Split(";")
            //             .Select(x => double.Parse(x, CultureInfo.InvariantCulture)).ToList();
            //         fieldData = ResHelper.GetResVal(_sectionResName, $"{prefix}_Maximum_CellData", _ci)
            //             .ReplaceVals(new Dictionary<string, string>()
            //             {
            //                 {"Price", _numFmtr.Format(maximumFieldDataNumbers[0], decimals:1)},
            //                 {"Percent", _numFmtr.Format(maximumFieldDataNumbers[1], decimals:1)},
            //             });
            //     }
            //     catch (Exception e)
            //     {
            //         fieldData = 0.ToString(CultureInfo.InvariantCulture);
            //     }
            //     _par = CreateParagraph(fieldData, StyleEnum.TableContentDefault);
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //
            //     table.Rows.Add(newRow);
            // }
            //
            // #endregion
            //
            // #endregion
            //
            // #endregion

        }
    }
}