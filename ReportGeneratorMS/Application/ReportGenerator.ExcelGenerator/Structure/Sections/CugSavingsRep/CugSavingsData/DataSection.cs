namespace ExcelGenerator.Structure.Sections.CugSavingsRep.CugSavingsData
{
    public class DataSection : ExcelReportSection
    {
        public override void InitSectionModel(string sectionModelJson)
        {
            throw new System.NotImplementedException();
        }

        public override void Generate()
        {
            // #region gas warranty table
            //
            // {
            //     //find table data
            //     var tableData = GetReportObj(_sectionData.ReportObjects, "Table_GasWarranty") as ReportTable;
            //
            //     //fill table
            //     var tableFirstCell = _worksheet.Cell(2, 1).Address;
            //
            //     //insert data to the table
            //     for (int i = 0; i < tableData.TableData[0].Count; i++)
            //     {
            //         int x = tableFirstCell.ColumnNumber + i;
            //         int y = tableFirstCell.RowNumber;
            //         var item = tableData.TableData[0];
            //
            //         _worksheet.Cell(y, x).Value = item[$"GasWarranty_{i + 1}"];
            //     }
            // }
            //
            // #endregion
            //
            // #region el warranty table
            //
            // {
            //     //find table data
            //     var tableData = GetReportObj(_sectionData.ReportObjects, "Table_ElWarranty") as ReportTable;
            //
            //     //fill table
            //     var tableFirstCell = _worksheet.Cell(5, 1).Address;
            //
            //     //insert data to the table
            //     for (int i = 0; i < tableData.TableData[0].Count; i++)
            //     {
            //         int x = tableFirstCell.ColumnNumber + i;
            //         int y = tableFirstCell.RowNumber;
            //         var item = tableData.TableData[0];
            //
            //         _worksheet.Cell(y, x).Value = item[$"ElWarranty_{i + 1}"];
            //     }
            // }
            //
            // #endregion
            //
            // #region heating savings table
            //
            // {
            //     //find table data
            //     var tableData = GetReportObj(_sectionData.ReportObjects, "Table_HeatingSavings") as ReportTable;
            //     
            //     //table first cell
            //     var tableFirstCell = _worksheet.Cell(8, 2).Address;
            //
            //     
            //     for (var i = 0; i < tableData.TableData.Count; i++) //year
            //     {
            //         var items = tableData.TableData[i].Values.ToList();
            //         for (var j = 0; j < tableData.TableData[i].Count; j++) // month
            //         {
            //             int x = tableFirstCell.ColumnNumber + j;
            //             int y = tableFirstCell.RowNumber + i;
            //             
            //             var item = items[j];
            //             
            //             _worksheet.Cell(y, x).Value = item;
            //         }
            //     }
            //     
            // }
            //
            // #endregion
            //
            // #region potential savings and prognosis table
            //
            // {
            //     //find table data
            //     var tableData =
            //         GetReportObj(_sectionData.ReportObjects, "Table_PotSavAndProg") as ReportTable;
            //
            //     var table = _worksheet.Table("Table_PotSavAndProg");
            //     
            //     //fill table
            //     var tableFirstCell = table.FirstCell().Address;
            //     
            //     //insert data to the table
            //     for (int i = 0; i < tableData.TableData.Count; i++)
            //     {
            //         var item = tableData.TableData[i];
            //
            //         if (i != 0)
            //         {
            //             table.InsertRowsBelow(1);
            //         }
            //         
            //         var row = table.LastRow();
            //         int x = row.FirstCell().Address.ColumnNumber;
            //         int y = row.FirstCell().Address.RowNumber;
            //
            //         _worksheet.Cell(y, x).Value = item["Name"];
            //         x++;
            //         
            //         _worksheet.Cell(y, x).Value = item["PotentialSavingsPercent"];
            //         x++;
            //         
            //         _worksheet.Cell(y, x).Value = item["EstimatedSavingsCurrentYearPercent"];
            //         x++;
            //         
            //         _worksheet.Cell(y, x).Value = item["PotentialSavingsM3"];
            //         x++;
            //         
            //         _worksheet.Cell(y, x).Value = item["EstimatedSavingsCurrentYearM3"];
            //         x++;
            //
            //
            //     }
            // }
            //
            // #endregion
        }

        public override void GenerateContent()
        {
            throw new System.NotImplementedException();
        }
    }
}