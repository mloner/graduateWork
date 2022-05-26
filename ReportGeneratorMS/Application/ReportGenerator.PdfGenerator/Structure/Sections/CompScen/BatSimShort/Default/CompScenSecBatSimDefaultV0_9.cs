namespace ReportingFramework.Structure.Sections.CompScen.BatSimShort.Default
{
    public class CompScenBatSimShortDefaultV0_9 : CompScenBatSimShortSec
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
            // #region Tables comparison scenarios
            //
            // AddCompatisonScenariosTable();
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
            // var desc3Par = (ReportParagraph)GetReportObj(_sectionData, desc3Name);
            // desc3Par.Text = ResHelper.GetResVal(_sectionResName, desc3Name, _ci)
            //     .ReplaceVals(new Dictionary<string, string>()
            //     {
            //         { "CompanyName", _template.GlobalSettings.CompanyName },
            //     });
            // AddParagraph(desc3Par);
            //
            // #endregion
        }

        public override void GenerateContent()
        {
            throw new System.NotImplementedException();
        }

        private void AddCompatisonScenariosTable()
        {
            // var tableData = GetReportObj(_sectionData.Data.ReportObjects,
            //     $"{SubsectionTypeEnum.Table}_ComparisonScenarios") as ReportTable;
            //
            // #region Table
            //
            // var prefix = "ComparisonScenariosTable";
            // var table = _pdfSection.AddTable();
            // var colIdx = 0;
            //
            //
            // #region Columns
            //
            // #region Create
            //
            // var tableColumnsCount = 10;
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
            // table.Columns[colIdx++].Width = new Unit(0.5, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(2.3, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(1.2, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(1.4, UnitType.Centimeter);
            // //table.Columns[colIdx++].Width = new Unit(1.3, UnitType.Centimeter);
            // //table.Columns[colIdx++].Width = new Unit(1.3, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(1.3, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(1.5, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(1.5, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(1.3, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(1.6, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(1.35, UnitType.Centimeter);
            // //table.Columns[colIdx++].Width = new Unit(1.3, UnitType.Centimeter);
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
            // var headerFontSize = 6;
            // colIdx = 0;
            //
            // // CaseNum
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_CaseNum", _ci), StyleEnum.TableHeader);
            // _par.Format.Font.Size = headerFontSize;
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // CaseName
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_CaseName", _ci), StyleEnum.TableHeader);
            // _par.Format.Font.Size = headerFontSize;
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // TariffName
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_TariffName", _ci), StyleEnum.TableHeader);
            // _par.Format.Font.Size = headerFontSize;
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // Algo
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_Algo", _ci), StyleEnum.TableHeader);
            // _par.Format.Font.Size = headerFontSize;
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // // Investment
            // // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_Investment", _ci), StyleEnum.TableHeader);
            // // _par.Format.Font.Size = headerFontSize;
            // // header.Cells[colIdx].Add(_par.Clone());
            // // colIdx++;
            //
            // // // ServiceCost
            // // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_ServiceCost", _ci), StyleEnum.TableHeader);
            // // _par.Format.Font.Size = headerFontSize;
            // // header.Cells[colIdx].Add(_par.Clone());
            // // colIdx++;
            //
            // // CapacityCost
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_CapacityCost", _ci), StyleEnum.TableHeader);
            // _par.Format.Font.Size = headerFontSize;
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // ConsumptionCost
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_ConsumptionCost", _ci), StyleEnum.TableHeader);
            // _par.Format.Font.Size = headerFontSize;
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // InjectionCost
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_InjectionCost", _ci), StyleEnum.TableHeader);
            // _par.Format.Font.Size = headerFontSize;
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // CyclesUsedPercent
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_CyclesUsedPercent", _ci), StyleEnum.TableHeader);
            // _par.Format.Font.Size = headerFontSize;
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // OperationalCost
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_OperationalCost", _ci), StyleEnum.TableHeader);
            // _par.Format.Font.Size = headerFontSize;
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // TotalSavings
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_TotalSavings", _ci), StyleEnum.TableHeader);
            // _par.Format.Font.Size = headerFontSize;
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // // Npv
            // // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_Npv", _ci), StyleEnum.TableHeader);
            // // _par.Format.Font.Size = headerFontSize;
            // // header.Cells[colIdx].Add(_par.Clone());
            // // colIdx++;
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
            // var percentSign = "%";
            //
            // // CaseNum
            // _par = CreateParagraph("", StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // CaseName
            // _par = CreateParagraph("", StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // TariffName
            // _par = CreateParagraph("", StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // Algo
            // _par = CreateParagraph("", StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // // Investment
            // // _par = CreateParagraph(euroSign, StyleEnum.TableSubheader);
            // // subheader.Cells[colIdx].Add(_par.Clone());
            // // colIdx++;
            //
            // // // ServiceCost
            // // _par = CreateParagraph(euroSign, StyleEnum.TableSubheader);
            // // subheader.Cells[colIdx].Add(_par.Clone());
            // // colIdx++;
            //
            // // CapacityCost
            // _par = CreateParagraph(euroSign, StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // ConsumptionCost
            // _par = CreateParagraph(euroSign, StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // InjectionCost
            // _par = CreateParagraph(euroSign, StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // CyclesUsedPercent
            // _par = CreateParagraph(percentSign, StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // OperationalCost
            // _par = CreateParagraph(euroSign, StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // TotalSavings
            // _par = CreateParagraph(euroSign, StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // // Npv
            // // _par = CreateParagraph(euroSign, StyleEnum.TableSubheader);
            // // subheader.Cells[colIdx].Add(_par.Clone());
            // // colIdx++;
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
            //     //CaseNId
            //     colName = "CaseId";
            //     newRow.Add(colName, row[colName]);
            //     
            //     //CaseName
            //     colName = "CaseName";
            //     newRow.Add(colName, row[colName]);
            //     
            //     //IsDynamicTariff
            //     colName = "IsDynamicTariff";
            //     newRow.Add(colName, row[colName]);
            //     
            //     //Algo
            //     colName = "Algo";
            //     newRow.Add(colName, row[colName]);
            //     
            //     // //Investment
            //     // colName = "Investment";
            //     // newRow.Add(colName, row[colName]);
            //     
            //     // //ServiceCost
            //     // colName = "ServiceCost";
            //     // newRow.Add(colName, row[colName]);
            //     
            //     //CapacityCost
            //     colName = "CapacityCost";
            //     newRow.Add(colName, row[colName]);
            //     
            //     //ConsumptionCost
            //     colName = "ConsumptionCost";
            //     newRow.Add(colName, row[colName]);
            //     
            //     //InjectionCost
            //     colName = "InjectionCost";
            //     newRow.Add(colName, row[colName]);
            //     
            //     //CyclesUsedPercent
            //     colName = "CyclesUsedPercent";
            //     newRow.Add(colName, row[colName]);
            //     
            //     //OperationalCost
            //     colName = "OperationalCost";
            //     newRow.Add(colName, row[colName]);
            //     
            //     //TotalSavings
            //     colName = "TotalSavings";
            //     newRow.Add(colName, row[colName]);
            //     
            //     // //NPV
            //     // colName = "Npv";
            //     // newRow.Add(colName, row[colName]);
            //     
            //     return newRow;
            // }).ToList();
            //
            // #endregion
            //
            // #region Fill
            //
            // var tableContentDefaultFontSize = 9;
            //
            // foreach (var row in tableRows)
            // {
            //     var newRow =
            //         GlobalFormatting.Tables.InitRow(SectionExtensions.GetStyle(_styles, StyleEnum.TableContentDefault));
            //     var isRefCase = row["CaseId"] == "0";
            //     var isBestCase = row["CaseId"] == tableData.Parameters["BestCaseId"];
            //     colIdx = 0;
            //     var fieldData = "";
            //     
            //     //CaseId
            //     _par = CreateParagraph(row["CaseId"], StyleEnum.TableContentPrimary);
            //     _par.Format.Font.Size = 8;
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     //CaseName
            //     if (isRefCase)
            //     {
            //         fieldData = $"{ResHelper.GetResVal(_sectionResName, $"{prefix}_RefCaseNoBattery", _ci)}";
            //     }
            //     else if (isBestCase)
            //     {
            //         fieldData = $"{row["CaseName"]} ({ResHelper.GetResVal(_sectionResName, $"{prefix}_Recommended", _ci)})";
            //     }
            //     else
            //     {
            //         fieldData = row["CaseName"];
            //     }
            //     _par = CreateParagraph(fieldData, StyleEnum.TableContentPrimary);
            //     _par.Format.Font.Size = 7.5;
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     //IsDynamicTariff
            //     var isDynamicTariff = bool.Parse(row["IsDynamicTariff"]);
            //     if (isDynamicTariff)
            //     {
            //         fieldData = tableData.Parameters["DynamicTariffName"];
            //     }
            //     else
            //     {
            //         fieldData = ResHelper.GetResVal(_sectionResName, $"{prefix}_Tariff_Single", _ci);
            //     }
            //     _par = CreateParagraph(fieldData, StyleEnum.TableContentDefault);
            //     _par.Format.Font.Size = 7;
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     //Algo
            //     if (isRefCase)
            //     {
            //         fieldData = "-";
            //     }
            //     else if (row["CaseId"] == "1")
            //     {
            //         fieldData = ResHelper.GetResVal(_sectionResName, $"{prefix}_AlgoNoControl", _ci);
            //     }
            //     else
            //     {
            //         fieldData = row["Algo"].FirstCharToUpper();
            //     }
            //     _par = CreateParagraph(fieldData, StyleEnum.TableContentDefault);
            //     _par.Format.Font.Size = 7;
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     // //Investment
            //     // _par = CreateParagraph(_numFmtr.Format(row["Investment"]), StyleEnum.TableContentDefault);
            //     // _par.Format.Font.Size = tableContentDefaultFontSize;
            //     // newRow.Cells[colIdx].Add(_par.Clone());
            //     // colIdx++;
            //     //
            //     // //ServiceCost
            //     // _par = CreateParagraph(_numFmtr.Format(row["ServiceCost"]), StyleEnum.TableContentDefault);
            //     // _par.Format.Font.Size = tableContentDefaultFontSize;
            //     // newRow.Cells[colIdx].Add(_par.Clone());
            //     // colIdx++;
            //     
            //     //CapacityCost
            //     _par = CreateParagraph(_numFmtr.Format(row["CapacityCost"]), StyleEnum.TableContentDefault);
            //     _par.Format.Font.Size = tableContentDefaultFontSize;
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     //ConsumptionCost
            //     _par = CreateParagraph(_numFmtr.Format(row["ConsumptionCost"]), StyleEnum.TableContentDefault);
            //     _par.Format.Font.Size = tableContentDefaultFontSize;
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     //InjectionCost
            //     _par = CreateParagraph(_numFmtr.Format(row["InjectionCost"]), StyleEnum.TableContentDefault);
            //     _par.Format.Font.Size = tableContentDefaultFontSize;
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     //CyclesUsedPercent
            //     var cyclesUsedPercent = (int)Math.Round(double.Parse(row["CyclesUsedPercent"], CultureInfo.InvariantCulture));
            //     _par = CreateParagraph(_numFmtr.Format(cyclesUsedPercent), StyleEnum.TableContentDefault);
            //     //mark danger if cycles are over the limit
            //     if (cyclesUsedPercent > int.Parse(tableData.Parameters["CyclesPercentLimit"], CultureInfo.InvariantCulture))
            //     {
            //         _par.Format = SectionExtensions.GetParagraphFormat(_styles, StyleEnum.TableContentDanger);
            //     }
            //     _par.Format.Font.Size = tableContentDefaultFontSize;
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     //OperationalCost
            //     _par = CreateParagraph(_numFmtr.Format(row["OperationalCost"]), StyleEnum.TableContentDefault);
            //     _par.Format.Font.Size = tableContentDefaultFontSize;
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     //TotalSavings
            //     _par = CreateParagraph(_numFmtr.Format(row["TotalSavings"]), StyleEnum.TableContentDefault);
            //     _par.Format.Font.Size = tableContentDefaultFontSize;
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     // //Npv
            //     // _par = CreateParagraph(_numFmtr.Format(row["Npv"]), StyleEnum.TableContentDefault);
            //     // _par.Format.Font.Size = tableContentDefaultFontSize;
            //     // newRow.Cells[colIdx].Add(_par.Clone());
            //     // colIdx++;
            //     
            //     //make best case bold
            //     if (isBestCase)
            //     {
            //         foreach (Cell newRowCell in newRow.Cells)
            //         {
            //             foreach (DocumentObject documentElement in newRowCell.Elements)
            //             {
            //                 ((Paragraph) documentElement).Format.Font.Bold = true;
            //             }
            //         }
            //     }
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