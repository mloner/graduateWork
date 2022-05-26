namespace ReportingFramework.Structure.Sections.Advice.BatSim
{
    public abstract class AdviceBatSimSec : AdviceSec
    {
        // public ReportTable ComparisonTable;
        //
        // public  void InitContent()
        // {
        //    // ComparisonTable = GetReportObj(_sectionData.Data.ReportObjects, "Table_Decisions") as ReportTable;
        // }
        //
        // public override void Generate()
        // {
        //     AddDesc1();
        //     AddSpace();
        //     AddDecisionTables();
        //     AddSpace();
        //     AddDesc2();
        // }
        //
        // public void AddDecisionTables()
        // {
        //     AddDecisionTable(ComparisonTable);
        //     AddSpace(0.5);
        //     AddComparisonTable(ComparisonTable);
        // }
        //
        // #region Decision table
        //
        // private void AddDecisionTable(ReportTable table)
        // {
        //     #region Background Panel
        //
        //     {
        //         var imgPar = new Paragraph();
        //         imgPar.Format.Alignment = ParagraphAlignment.Center;
        //         var img = imgPar.AddImage($"{ResParams.Paths.SectionImages}/BgPanel.png");
        //         img.Width = new Unit(GetSectionWidthCm(), UnitType.Centimeter);
        //         //img.LockAspectRatio = true;
        //         PdfSection.Add(imgPar);
        //
        //         imgPar.Format.SpaceAfter = new Unit(-2.5, UnitType.Centimeter);
        //     }
        //     
        //     #endregion
        //
        //     #region table
        //
        //     var decTable = PdfSection.AddTable();
        //     var firstColWidth = new Unit(9, UnitType.Centimeter);
        //     decTable.AddColumn(firstColWidth);
        //     decTable.AddColumn(GetSectionWidthCm() - firstColWidth);
        //     var row = decTable.AddRow();
        //     row.VerticalAlignment = VerticalAlignment.Center;
        //     
        //     #region Battery info
        //     
        //     var batInfoTbl = AddBatInfoBlock(table);
        //     row.Cells[0].Elements.Add(batInfoTbl.Clone());
        //     
        //     #endregion
        //     
        //     #region investment
        //     
        //     var invTbl = AddInvestmentBlock(table);
        //     row.Cells[1].Elements.Add(invTbl.Clone());
        //
        //     #endregion
        //
        //
        //     #endregion
        // }
        //
        // public Table AddBatInfoBlock(ReportTable table)
        // {
        //     var data = table.TableData[1];
        //     var res = new Table();
        //
        //     //res.Borders.Color = Colors.Black;
        //     res.AddColumn(new Unit(2, UnitType.Centimeter));
        //     res.AddColumn(new Unit(7, UnitType.Centimeter));
        //     var row = res.AddRow();
        //     row.VerticalAlignment = VerticalAlignment.Center;
        //     
        //     #region Icon
        //
        //     var imgPar = new Paragraph();
        //     imgPar.Format.Alignment = ParagraphAlignment.Center;
        //     var img = imgPar.AddImage($"{ResParams.Paths.SectionImages}/Battery.png");
        //     img.Height = new Unit(2, UnitType.Centimeter);
        //     img.LockAspectRatio = true;
        //     row.Cells[0].Add(imgPar.Clone());
        //
        //     #endregion
        //
        //     #region Desc
        //
        //     var styleName = "AdviceTableFont";
        //     row.Cells[1].VerticalAlignment = VerticalAlignment.Top;
        //     
        //     //title
        //     Par = Par = CreateParagraph(
        //         ResHelper.GetResVal(_sectionResName, $"RecommendedConfiguration", _ci),
        //         styleName);
        //     Par.Format.Font.Bold = true;
        //     row.Cells[1].Add(Par.Clone());
        //
        //     //battery name
        //     Par = CreateParagraph(
        //         data["BatteryModel"],
        //         styleName);
        //     row.Cells[1].Add(Par.Clone());
        //     
        //     //battery power
        //     Par = CreateParagraph(
        //         $"{ResHelper.GetResVal(_sectionResName, $"Power", _ci)}: {data["BatteryPower"]} kW",
        //         styleName);
        //     row.Cells[1].Add(Par.Clone());
        //     
        //     //battery capacity
        //     Par = CreateParagraph(
        //         $"{ResHelper.GetResVal(_sectionResName, $"Capacity", _ci)}: {data["BatteryCapacity"]} kWh",
        //         styleName);
        //     row.Cells[1].Add(Par.Clone());
        //     
        //     #endregion
        //
        //     return res;
        // }
        //
        // public Table AddInvestmentBlock(ReportTable table)
        // {
        //     var data = table.TableData[0];
        //     var res = new Table();
        //
        //     //res.Borders.Color = Colors.Black;
        //     res.AddColumn(new Unit(2, UnitType.Centimeter));
        //     res.AddColumn(new Unit(5, UnitType.Centimeter));
        //     var row = res.AddRow();
        //     row.VerticalAlignment = VerticalAlignment.Center;
        //     
        //     #region Icon
        //
        //     var imgPar = new Paragraph();
        //     imgPar.Format.Alignment = ParagraphAlignment.Center;
        //     var img = imgPar.AddImage($"{ResParams.Paths.SectionImages}/Investment.png");
        //     img.Height = new Unit(2, UnitType.Centimeter);
        //     img.LockAspectRatio = true;
        //     row.Cells[0].Add(imgPar.Clone());
        //
        //     #endregion
        //
        //     #region Desc
        //
        //     var styleName = "AdviceTableFont";
        //     row.Cells[1].VerticalAlignment = VerticalAlignment.Center;
        //     
        //     
        //     //battery cost
        //     Par = CreateParagraph(
        //         $"{ResHelper.GetResVal(_sectionResName, $"BatteryCost", _ci)}: € {_numFmtr.Format(data["BatteryCost"])}",
        //         styleName);
        //     row.Cells[1].Add(Par.Clone());
        //     
        //     //battery capacity
        //     var batCap = ResHelper.GetResVal(_sectionResName, $"ServiceFeePerMonth", _ci)
        //         .ReplaceVals(new Dictionary<string, string>()
        //         {
        //             {"CompanyName", Template.GlobalSettings.CompanyName}
        //         });
        //     Par = CreateParagraph(
        //         $"{batCap}: € {_numFmtr.Format(data["AdviceCostPerMonth"], decimals: 1)} {ResHelper.GetResVal(_sectionResName, $"PerMonth", _ci).ToLower()}",
        //         styleName);
        //     row.Cells[1].Add(Par.Clone());
        //     
        //     #endregion
        //
        //     return res;
        // }
        //
        // #endregion
        //
        // #region Comparison table
        //
        // public void AddComparisonTable(ReportTable comparisonTable)
        // {
        //     var table = PdfSection.AddTable();
        //     var tableRow = new Dictionary<string, string>();
        //     double col1Widht = 3;
        //     double col2Widht = (GetSectionWidthCm() - col1Widht) / 2;
        //     double col3Widht = (GetSectionWidthCm() - col1Widht) / 2;
        //     table.AddColumn(new Unit(col1Widht, UnitType.Centimeter));
        //     table.AddColumn(new Unit(col2Widht, UnitType.Centimeter));
        //     table.AddColumn(new Unit(col3Widht, UnitType.Centimeter));
        //     int cellIndex = 0;
        //     var row = new Row();
        //
        //     var prefix = "ComparisonTable";
        //
        //     #region Headers
        //
        //     cellIndex = 0;
        //     
        //     var headerRow = GlobalFormatting.Tables.InitHeader(SectionExtensions.GetStyle(Styles, StyleEnum.TableHeader));
        //     headerRow.VerticalAlignment = VerticalAlignment.Center;
        //     table.Rows.Add(headerRow);
        //     // empty header (icons)
        //     Par = CreateParagraph("", StyleEnum.TableHeader);
        //     headerRow.Cells[cellIndex].Add(Par.Clone());
        //     cellIndex++;
        //     // first case
        //     tableRow = comparisonTable.TableData[0];
        //     Par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_Header", _ci)
        //         .ReplaceVals(new Dictionary<string, string>()
        //         {
        //             {
        //                 "Algo", tableRow["Algo"] == "simple" ? 
        //                     ResHelper.GetResVal(_sectionResName, $"{prefix}_Algo_NoAlgo", _ci) : 
        //                     ResHelper.GetResVal(_sectionResName, $"{prefix}_Algo_Algo", _ci)
        //                         .ReplaceVals(new Dictionary<string, string>()
        //                         {
        //                             {"CompanyName", Template.GlobalSettings.CompanyName}
        //                         })
        //             },
        //             {
        //                 "MarketType", bool.Parse(tableRow["IsDam"]) ? 
        //                     ResHelper.GetResVal(_sectionResName, $"{prefix}_MarketType_Dam", _ci) :
        //                     ResHelper.GetResVal(_sectionResName, $"{prefix}_MarketType_DayNight", _ci)
        //             },
        //             //  {"Algo", ResHelper.GetResVal(_sectionResName, $"{prefix}_Algo_{tableRow["Algo"]}", _ci)}
        //         }), StyleEnum.TableHeader);
        //     headerRow.Cells[cellIndex].Add(Par.Clone());
        //     cellIndex++;
        //     // alt case
        //     tableRow = comparisonTable.TableData[1];
        //     Par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_Header", _ci)
        //         .ReplaceVals(new Dictionary<string, string>()
        //         {
        //             {
        //                 "Algo", tableRow["Algo"] == "simple" ? 
        //                     ResHelper.GetResVal(_sectionResName, $"{prefix}_Algo_NoAlgo", _ci) : 
        //                     ResHelper.GetResVal(_sectionResName, $"{prefix}_Algo_Algo", _ci)
        //                         .ReplaceVals(new Dictionary<string, string>()
        //                         {
        //                             {"CompanyName", Template.GlobalSettings.CompanyName}
        //                         })
        //             },
        //             {
        //                 "MarketType", bool.Parse(tableRow["IsDam"]) ? 
        //                     ResHelper.GetResVal(_sectionResName, $"{prefix}_MarketType_Dam", _ci) :
        //                     ResHelper.GetResVal(_sectionResName, $"{prefix}_MarketType_DayNight", _ci)
        //             },
        //             //{"Algo", ResHelper.GetResVal(_sectionResName, $"{prefix}_Algo_{tableRow["Algo"]}", _ci)}
        //         }), StyleEnum.TableHeader);
        //     headerRow.Cells[cellIndex].Add(Par.Clone());
        //     cellIndex++;
        //     
        //     cellIndex = 0;
        //     
        //     #endregion
        //
        //     #region Content
        //     
        //     var styleName = "AdviceTableFont";
        //     
        //     #region Savings
        //     
        //     row = table.AddRow();
        //     row.Height = new Unit(2.5, UnitType.Centimeter);
        //     row.TopPadding = new Unit(0.3, UnitType.Centimeter);
        //     cellIndex = 0;
        //     
        //     AddComparisonTableIconBlock(comparisonTable.TableData[0], row[cellIndex], "Savings.png");
        //     cellIndex++;
        //     
        //     AddComparisonTableSavingsBlock(comparisonTable.TableData[0], row[cellIndex], styleName);
        //     cellIndex++;
        //     
        //     AddComparisonTableSavingsBlock(comparisonTable.TableData[1], row[cellIndex], styleName);
        //     cellIndex++;
        //     
        //     #endregion
        //     
        //     #region Payback period
        //     
        //     row = table.AddRow();
        //     row.Height = new Unit(2.5, UnitType.Centimeter);
        //     row.TopPadding = new Unit(0.3, UnitType.Centimeter);
        //     cellIndex = 0;
        //     
        //     AddComparisonTableIconBlock(comparisonTable.TableData[0], row[cellIndex], "PaybackPeriod.png");
        //     cellIndex++;
        //     
        //     AddComparisonTablePaybackPeriodBlock(comparisonTable.TableData[0], row[cellIndex], styleName);
        //     cellIndex++;
        //
        //     AddComparisonTablePaybackPeriodBlock(comparisonTable.TableData[1], row[cellIndex], styleName);
        //     cellIndex++;
        //     
        //     #endregion
        //
        //     // #region Return of investment
        //     //
        //     // row = table.AddRow();
        //     // row.Height = new Unit(2.5, UnitType.Centimeter);
        //     // row.TopPadding = new Unit(0.3, UnitType.Centimeter);
        //     // cellIndex = 0;
        //     //
        //     // AddComparisonTableIconBlock(comparisonTable.TableData[0], row[cellIndex], "ReturnOfInvestment.png");
        //     // cellIndex++;
        //     //
        //     // AddComparisonTableRerurnOfInvestmentBlock(comparisonTable.TableData[0], row[cellIndex], styleName);
        //     // cellIndex++;
        //     //
        //     // AddComparisonTableRerurnOfInvestmentBlock(comparisonTable.TableData[1], row[cellIndex], styleName);
        //     // cellIndex++;
        //     //
        //     // #endregion
        //     
        //     #endregion
        // }
        //
        // public void AddComparisonTableIconBlock(Dictionary<string, string> tableRow, Cell cell, string iconName)
        // {
        //     Par = new Paragraph
        //     {
        //         Format =
        //         {
        //             SpaceAfter = 0,
        //             SpaceBefore = 0,
        //             LineSpacingRule = LineSpacingRule.Single,
        //             Alignment = ParagraphAlignment.Left
        //         }
        //     };
        //     Img = Par.AddImage($"{ResParams.Paths.SectionImages}/{iconName}");
        //     Img.Height = new Unit(2, UnitType.Centimeter); 
        //     Img.LockAspectRatio = true;
        //     cell.Add(Par);
        //     cell.Format.Alignment = ParagraphAlignment.Center;
        //     cell.VerticalAlignment = VerticalAlignment.Bottom;
        // }
        //
        // #region Savings block
        //
        // public void AddComparisonTableSavingsBlock(Dictionary<string, string> tableRow, Cell cell, string styleName)
        // {
        //     AddComparisonTableSavingsBlockTitle(cell, styleName);
        //     AddComparisonTableSavingsBlockContent(tableRow, cell, styleName);
        // }
        //
        // public void AddComparisonTableSavingsBlockTitle(Cell cell, string styleName)
        // {
        //     AddComparisonTableBlockTitle(cell, styleName, "Savings");
        // }
        //
        // #endregion
        //
        // #region Payback period block
        //
        // public void AddComparisonTablePaybackPeriodBlock(Dictionary<string, string> tableRow, Cell cell, string styleName)
        // {
        //     AddComparisonTablePaybackPeriodBlockTitle(cell, styleName);
        //     AddComparisonTablePaybackPeriodBlockContent(tableRow, cell, styleName);
        // }
        //
        // public void AddComparisonTablePaybackPeriodBlockTitle(Cell cell, string styleName)
        // {
        //     AddComparisonTableBlockTitle(cell, styleName, "PaybackPeriod");
        // }
        //
        // public void AddComparisonTablePaybackPeriodBlockContent(Dictionary<string, string> tableRow, Cell cell, string styleName)
        // {
        //     if (
        //         bool.Parse(tableRow["IsCase"])
        //         )
        //     {
        //         AddComparisonTablePaybackPeriodBlockContentCase(tableRow, cell, styleName);
        //     }
        //     else
        //     {
        //         AddComparisonTablePaybackPeriodBlockContentNoCase(tableRow, cell, styleName);
        //     }
        //     cell.VerticalAlignment = VerticalAlignment.Top;
        // }
        //
        // public void AddComparisonTablePaybackPeriodBlockContentCase(Dictionary<string, string> tableRow, Cell cell, string styleName)
        // {
        //     var pbPeriodWords = GetPeriodWords(tableRow["PaybackPeriodMonths"]);
        //     Par = CreateParagraph(pbPeriodWords.Aggregate((x,y) => $"{x} {y}"), styleName);
        //     cell.Add(Par.Clone());
        //     
        //     cell.VerticalAlignment = VerticalAlignment.Top;
        // }
        //
        //
        // #endregion
        //
        // #region Roi block
        //
        // public void AddComparisonTableRerurnOfInvestmentBlock(Dictionary<string, string> tableRow, Cell cell, string styleName)
        // {
        //     AddComparisonTableRerurnOfInvestmentBlockTtile(cell, styleName);
        //     AddComparisonTableRerurnOfInvestmentBlockContent(tableRow, cell, styleName);
        // }
        //
        // public void AddComparisonTableRerurnOfInvestmentBlockTtile(Cell cell, string styleName)
        // {
        //     AddComparisonTableBlockTitle(cell, styleName, "ReturnOfInvestment");
        // }
        // public void AddComparisonTableRerurnOfInvestmentBlockContent(Dictionary<string, string> tableRow, Cell cell, string styleName)
        // {
        //     if (
        //         bool.Parse(tableRow["IsCase"])
        //         )
        //     {
        //         AddComparisonTableRerurnOfInvestmentBlockContentCase(tableRow, cell, styleName);
        //     }
        //     else
        //     {
        //         AddComparisonTableRerurnOfInvestmentBlockContentNoCase(tableRow, cell, styleName);
        //     }
        //     cell.VerticalAlignment = VerticalAlignment.Top;
        // }
        //
        // public void AddComparisonTableRerurnOfInvestmentBlockContentCase(Dictionary<string, string> tableRow, Cell cell, string styleName)
        // {
        //     //roi bank
        //     Par = CreateParagraph($"{ResHelper.GetResVal(_sectionResName, "Bank", _ci)}: {_numFmtr.Format(tableRow["ReturnOfInvestmentBank"], decimals:1)} %", styleName);
        //     cell.Add(Par.Clone());
        //     
        //     //roi battery cost
        //     Par = CreateParagraph($"{ResHelper.GetResVal(_sectionResName, "BatteryCost", _ci)}: {_numFmtr.Format(tableRow["ReturnOfInvestmentBattery"])} %", styleName);
        //     cell.Add(Par.Clone());
        // }
        //
        // #endregion
        //
        // public void AddComparisonTableBlockTitle(Cell cell, string styleName, string titleName)
        // {
        //     Par = CreateParagraph(ResHelper.GetResVal(_sectionResName, titleName, _ci), styleName);
        //     Par.Format.Font.Bold = true;
        //     cell.Add(Par.Clone());
        // }
        //
        // #endregion
        //
        // public bool IsAnyCase()
        // {
        //     //return false;
        //     return bool.Parse(ComparisonTable.TableData[0]["IsCase"]) || bool.Parse(ComparisonTable.TableData[1]["IsCase"]);
        // }
        // public void AddDesc1()
        // {
        //     if (IsAnyCase())
        //     {
        //         AddDesc1Case();
        //     }
        //     else
        //     {
        //         AddDesc1NoCase();
        //     }
        // }
        // public void AddDesc2()
        // {
        //     if (IsAnyCase())
        //     {
        //         AddDesc2Case();
        //     }
        //     else
        //     {
        //         AddDesc2NoCase();
        //     }
        // }
        // public abstract void AddDesc1Case();
        // public abstract void AddDesc1NoCase();
        // public abstract void AddDesc2Case();
        // public abstract void AddDesc2NoCase();
        // public abstract void AddComparisonTableSavingsBlockContent(Dictionary<string, string> tableRow, Cell cell, string styleName);
        // public abstract void AddComparisonTablePaybackPeriodBlockContentNoCase(Dictionary<string, string> tableRow, Cell cell, string styleName);
        // public abstract void AddComparisonTableRerurnOfInvestmentBlockContentNoCase(Dictionary<string, string> tableRow, Cell cell, string styleName);
    }
}