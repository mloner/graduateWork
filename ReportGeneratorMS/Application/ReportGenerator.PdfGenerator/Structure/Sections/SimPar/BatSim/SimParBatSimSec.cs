using System.Collections.Generic;
using ReportingFramework.Dto;

namespace ReportingFramework.Structure.Sections.SimPar.BatSim
{
    public abstract class SimParBatSimSec : SimParSec
    {
        public override void Generate()
        {
            // var prefix = "";
            //
            // #region Key details
            //
            // prefix = "KeyDetails";
            //
            // var keyDetailsBlockName = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_{prefix}";
            // var keyDetailsBlockObj = GetReportObj(_sectionData, keyDetailsBlockName);
            // var keyDetailsBlockChilds = keyDetailsBlockObj.ChildObjects;
            //
            // #region Desc 1
            //
            // var keyDetailsDesc1Name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_{prefix}_Desc_1";
            //
            // #region Title
            //
            // var keyDetailsDesc1Par = (ReportParagraph)GetReportObj(keyDetailsBlockChilds, keyDetailsDesc1Name);
            // keyDetailsDesc1Par.Title = ResHelper.GetResVal(_sectionResName, $"{keyDetailsDesc1Name}_Title", _ci);
            // AddParagraph(keyDetailsDesc1Par.Title, StyleEnum.H1);
            //
            // #endregion
            //
            // #region Content
            //
            // keyDetailsDesc1Par.Text = ResHelper.GetResVal(_sectionResName, $"{keyDetailsDesc1Name}", _ci);
            // AddParagraph(keyDetailsDesc1Par.Text);
            //
            // #endregion
            //
            // #endregion
            //
            // AddSpace(0.2);
            //
            // #region Table
            //
            // AddKeyDetailsTable(keyDetailsBlockChilds);
            //
            // #endregion
            //
            // #endregion
            //
            // AddSpace(0.4);
            //
            // #region BatInfo
            //
            // prefix = "BatInfo";
            //
            // var batInfoBlockName = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_{prefix}";
            // var batInfoBlockObj = GetReportObj(_sectionData, batInfoBlockName);
            // var batInfoBlockChilds = batInfoBlockObj.ChildObjects;
            //
            // #region Desc 1
            //
            // var batInfoDesc1Name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_{prefix}_Desc_1";
            //
            // #region Title
            //
            // var batInfoDesc1Par = (ReportParagraph)GetReportObj(batInfoBlockChilds, batInfoDesc1Name);
            // batInfoDesc1Par.Title = ResHelper.GetResVal(_sectionResName, $"{batInfoDesc1Name}_Title", _ci);
            // AddParagraph(batInfoDesc1Par.Title, StyleEnum.H1);
            //
            // #endregion
            //
            // #region Content
            //
            // batInfoDesc1Par.Text = ResHelper.GetResVal(_sectionResName, $"{batInfoDesc1Name}", _ci);
            // AddParagraph(batInfoDesc1Par.Text);
            //
            // #endregion
            //
            // #endregion
            //
            // AddSpace(0.2);
            //
            // #region Table
            //
            // AddBatInfoTable(batInfoBlockChilds);
            //
            // #endregion
            //
            // #endregion
        }
        
        private void AddKeyDetailsTable(List<IReportObject> reportObject)
        {
            // var tableData = GetReportObj(reportObject, $"{SubsectionTypeEnum.Table}_KeyDetails") as ReportTable;
            //
            // #region Table
            //
            // var prefix = "KeyDetails_Table";
            // var table = _pdfSection.AddTable();
            // var colIdx = 0;
            //
            //
            // #region Columns
            //
            // #region Create
            //
            // var tableColumnsCount = 2;
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
            // table.Columns[colIdx++].Width = new Unit(GetSectionWidthCm()*2/5, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(GetSectionWidthCm()*3/5, UnitType.Centimeter);
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
            // var header = GlobalFormatting.Tables.InitHeaderWithoutCaptions(SectionExtensions.GetStyle(_styles, StyleEnum.TableHeader));
            // table.Rows.Add(header);
            //
            // #endregion
            //
            // #region Fill
            //
            // colIdx = 0;
            //
            // // ParamName
            // _par = CreateParagraph("", StyleEnum.TableHeader);
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // ParamValue
            // _par = CreateParagraph("", StyleEnum.TableHeader);
            // header.Cells[colIdx].Add(_par.Clone());
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
            // var euroSign = "€";
            // var percentSign = "%";
            // var pName = "ParamName";
            // var pValue = "ParamValue";
            // List<Dictionary<string, string>> newTableRows;
            // Dictionary<string, string> tmpElem;
            //
            // #region Filter columns
            //
            // newTableRows = tableData.TableData.Select(row =>
            // {
            //     var newRow = new Dictionary<string, string>();
            //     var colName = "";
            //     
            //     //ParamName
            //     colName = "ParamName";
            //     newRow.Add(colName, row[colName]);
            //     
            //     //ParamValue
            //     colName = "ParamValue";
            //     newRow.Add(colName, row[colName]);
            //
            //     return newRow;
            // }).ToList();
            //
            // #endregion
            //
            // #region Transform rows
            //
            // var newTableRowsFiltered = new List<Dictionary<string, string>>();
            //
            //
            // //Country
            // newTableRowsFiltered.Add(newTableRows.First(x => x[pName] == "Country"));
            //
            // //Region
            // newTableRowsFiltered.Add(newTableRows.First(x => x[pName] == "Region"));
            //
            // //CapacityPricePerYear
            // tmpElem = newTableRows.First(x => x[pName] == "CapacityPricePerYear");
            // tmpElem[pValue] = $"{euroSign} " +
            //                   $"{_numFmtr.Format(tmpElem[pValue])} " +
            //                   $"{ResHelper.GetResVal(_sectionResName, "PerYear", _ci).ToLower()}";
            // newTableRowsFiltered.Add(tmpElem);
            //
            // //ElectricityPriceRefDayNight
            // var elPrRefDay = newTableRows.First(x => x[pName] == "ElectricityPriceRefDay");
            // var elPrRefNight = newTableRows.First(x => x[pName] == "ElectricityPriceRefNight");
            // tmpElem = newTableRows.First().ToDictionary(x => x.Key, x => x.Value);
            // tmpElem[pName] = "ElectricityPriceRefDayNight";
            // tmpElem[pValue] = $"{euroSign} {_numFmtr.Format(elPrRefDay[pValue], decimals: 2)} / " +
            //                   $"{euroSign} {_numFmtr.Format(elPrRefNight[pValue], decimals: 2)}";
            // newTableRowsFiltered.Add(tmpElem);
            //
            // //ElectricityPriceDamDayNight
            // var elPrBestDay = newTableRows.First(x => x[pName] == "ElectricityPriceDamDay");
            // var elPrBestNight = newTableRows.First(x => x[pName] == "ElectricityPriceDamNight");
            // tmpElem = newTableRows.First().ToDictionary(x => x.Key, x => x.Value);
            // tmpElem[pName] = "ElectricityPriceDamDayNight";
            // tmpElem[pValue] = $"{euroSign} {_numFmtr.Format(elPrBestDay[pValue], decimals: 2)} / " +
            //                   $"{euroSign} {_numFmtr.Format(elPrBestNight[pValue], decimals: 2)}";
            // newTableRowsFiltered.Add(tmpElem);
            //
            // //ElectricityPriceDamBuySell
            // var damBuy = newTableRows.First(x => x[pName] == "DamBuy");
            // var damSell = newTableRows.First(x => x[pName] == "DamSell");
            // tmpElem = newTableRows.First().ToDictionary(x => x.Key, x => x.Value);
            // tmpElem[pName] = "DamBuySell";
            // tmpElem[pValue] = $"{euroSign} {_numFmtr.Format(damBuy[pValue], decimals: 4)} / " +
            //                   $"{euroSign} {_numFmtr.Format(damSell[pValue], decimals: 4)}";
            // newTableRowsFiltered.Add(tmpElem);
            //
            // //InjectionTariff
            // tmpElem = newTableRows.First(x => x[pName] == "InjectionTariff");
            // tmpElem[pValue] = $"{euroSign} " +
            //                   $"{_numFmtr.Format(tmpElem[pValue], decimals: 2)}";
            // newTableRowsFiltered.Add(tmpElem);
            //
            // //FeePerMonth
            // tmpElem = newTableRows.First(x => x[pName] == "FeePerMonth");
            // tmpElem[pValue] = $"{euroSign} " +
            //                   $"{_numFmtr.Format(tmpElem[pValue])}";
            // newTableRowsFiltered.Add(tmpElem);
            //
            // //ElectricityPriiceInflationPercent
            // tmpElem = newTableRows.First(x => x[pName] == "ElectricityPriiceInflationPercent");
            // tmpElem[pValue] = $"{_numFmtr.Format(tmpElem[pValue])} {percentSign}";
            // newTableRowsFiltered.Add(tmpElem);
            //
            // //InjectionTariffInflationPercent
            // tmpElem = newTableRows.First(x => x[pName] == "InjectionTariffInflationPercent");
            // tmpElem[pValue] = $"{_numFmtr.Format(tmpElem[pValue])} {percentSign}";
            // newTableRowsFiltered.Add(tmpElem);
            //
            // //CurrentConnectionCapacity
            // newTableRowsFiltered.Add(newTableRows.First(x => x[pName] == "CurrentConnectionCapacity"));
            //
            // //InterestRatePercent
            // tmpElem = newTableRows.First(x => x[pName] == "InterestRatePercent");
            // tmpElem[pValue] = $"{_numFmtr.Format(tmpElem[pValue])} {percentSign}";
            // newTableRowsFiltered.Add(tmpElem);
            //
            // //SimulationTermYears
            // tmpElem = newTableRows.First(x => x[pName] == "SimulationTermYears");
            // tmpElem[pValue] = $"{_numFmtr.Format(tmpElem[pValue])} {ResHelper.GetResVal(_sectionResName, "Years", _ci).ToLower()}";
            // newTableRowsFiltered.Add(tmpElem);
            //
            // //SimulationPeriod
            // var simPerStart = newTableRows.First(x => x[pName] == "SimulationPeriodStart");
            // var simPerEnd = newTableRows.First(x => x[pName] == "SimulationPeriodEnd");
            // var simPerDays = newTableRows.First(x => x[pName] == "SimulationPeriodDays");
            // tmpElem = newTableRows.First().ToDictionary(x => x.Key, x => x.Value);
            // tmpElem[pName] = "SimulationPeriod";
            // tmpElem[pValue] =
            //     $"{DateTime.Parse(simPerStart[pValue], CultureInfo.InvariantCulture).ToString(_template.GlobalSettings.DateFormat)} — " +
            //     $"{DateTime.Parse(simPerEnd[pValue], CultureInfo.InvariantCulture).ToString(_template.GlobalSettings.DateFormat)} " +
            //     $"({_numFmtr.Format(simPerDays[pValue])} {ResHelper.GetResVal(_sectionResName, "Days", _ci).ToLower()})";
            // newTableRowsFiltered.Add(tmpElem);
            //
            // newTableRows = newTableRowsFiltered;
            //
            // #endregion
            //
            // #endregion
            //
            // #region Fill
            //
            // foreach (var row in newTableRows)
            // {
            //     var newRow =
            //         GlobalFormatting.Tables.InitRow(SectionExtensions.GetStyle(_styles, StyleEnum.TableContentDefault));
            //     colIdx = 0;
            //     var fieldData = "";
            //     
            //     //ParamName
            //     _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_{row["ParamName"]}", _ci),
            //         StyleEnum.TableContentPrimary);
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     
            //     //ParamValue
            //     _par = CreateParagraph(row["ParamValue"], StyleEnum.TableContentDefault);
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
        
        private void AddBatInfoTable(List<IReportObject> reportObject)
        {
            // var tableData = GetReportObj(reportObject, $"{SubsectionTypeEnum.Table}_BatInfo") as ReportTable;
            //
            // #region Table
            //
            // var prefix = "BatInfo_Table";
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
            // table.Columns[colIdx++].Width = new Unit(GetSectionWidthCm() * 6/20, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(GetSectionWidthCm() * 3/20, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(GetSectionWidthCm() * 3/20, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(GetSectionWidthCm() * 3/20, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(GetSectionWidthCm() * 3/20, UnitType.Centimeter);
            // table.Columns[colIdx++].Width = new Unit(GetSectionWidthCm() * 2/20, UnitType.Centimeter);
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
            // // BatteryModel
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_BatteryModel", _ci), StyleEnum.TableHeader);
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // CRate
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_CRate", _ci), StyleEnum.TableHeader);
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // DepthOfDischargePercent
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_DepthOfDischargePercent", _ci), StyleEnum.TableHeader);
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // DegradationPerMonthPercent
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_DegradationPerMonthPercent", _ci), StyleEnum.TableHeader);
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // RTEPercent
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_RTEPercent", _ci), StyleEnum.TableHeader);
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // CyclesTotal
            // _par = CreateParagraph(ResHelper.GetResVal(_sectionResName, $"{prefix}_CyclesTotal", _ci), StyleEnum.TableHeader);
            // header.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
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
            // // BatteryModel
            // _par = CreateParagraph("", StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // CRate
            // _par = CreateParagraph("", StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // DepthOfDischargePercent
            // _par = CreateParagraph(percentSign, StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // DegradationPerMonthPercent
            // _par = CreateParagraph($"{percentSign} / {ResHelper.GetResVal(_sectionResName, "Month", _ci).ToLower()}",
            //     StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // RTEPercent
            // _par = CreateParagraph(percentSign, StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
            // // CyclesTotal
            // _par = CreateParagraph("", StyleEnum.TableSubheader);
            // subheader.Cells[colIdx].Add(_par.Clone());
            // colIdx++;
            //
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
            // List<Dictionary<string, string>> newTableRows;
            // Dictionary<string, string> tmpElem;
            // newTableRows = tableData.TableData.Select(row =>
            // {
            //     return row;
            // }).ToList();
            //
            //
            //
            // #endregion
            //
            // #region Fill
            //
            // foreach (var row in newTableRows)
            // {
            //     var newRow =
            //         GlobalFormatting.Tables.InitRow(SectionExtensions.GetStyle(_styles, StyleEnum.TableContentDefault));
            //     colIdx = 0;
            //     var fieldData = "";
            //     
            //     //BatteryModel
            //     _par = CreateParagraph(row["BatteryModel"], StyleEnum.TableContentPrimary);
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     //CRate
            //     _par = CreateParagraph(_numFmtr.Format(row["CRate"], decimals:1), StyleEnum.TableContentDefault);
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     //DepthOfDischargePercent
            //     _par = CreateParagraph(_numFmtr.Format(row["DepthOfDischargePercent"], decimals:1), StyleEnum.TableContentDefault);
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     //DegradationPerMonthPercent
            //     _par = CreateParagraph(_numFmtr.Format(row["DegradationPerMonthPercent"], decimals:3), StyleEnum.TableContentDefault);
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     //RTEPercent
            //     _par = CreateParagraph(_numFmtr.Format(row["RTEPercent"]), StyleEnum.TableContentDefault);
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //     
            //     //CyclesTotal
            //     _par = CreateParagraph(_numFmtr.Format(row["CyclesTotal"]), StyleEnum.TableContentDefault);
            //     newRow.Cells[colIdx].Add(_par.Clone());
            //     colIdx++;
            //
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