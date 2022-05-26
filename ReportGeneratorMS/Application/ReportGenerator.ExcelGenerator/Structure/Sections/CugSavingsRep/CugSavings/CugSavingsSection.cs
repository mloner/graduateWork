namespace ExcelGenerator.Structure.Sections.CugSavingsRep.CugSavings
{
    public class CugSavingsSection : ExcelReportSection
    {
        public override void InitSectionModel(string sectionModelJson)
        {
            throw new System.NotImplementedException();
        }

        public override void Generate()
        {
            //date
            // _worksheet.Cell(3, 2).Value = _sectionData.Parameters["Date"];
            //
            // //Cug name
            // _worksheet.Cell(4, 2).Value = _worksheet.Cell(4, 2).Value.ToString().Replace("[CugName]", _sectionData.Parameters["CugName"]);
            //
            //
            // #region gas consumption table
            //
            // {
            //     //find table data
            //     var tableData = GetReportObj(_sectionData.ReportObjects, "Table_GasConsumption") as ReportTable;
            //
            //     //fill table
            //     var tableFirstCell = _worksheet.Cell(8, 3).Address;
            //
            //     //insert data to the table
            //     for (int i = 0; i < tableData.TableData.Count; i++)
            //     {
            //         int x = tableFirstCell.ColumnNumber + i;
            //         int y = tableFirstCell.RowNumber;
            //         var item = tableData.TableData[i];
            //
            //         _worksheet.Cell(y, x).Value = item["NormalizedRef"];
            //         y++;
            //
            //         _worksheet.Cell(y, x).Value = item["Cons"];
            //         y++;
            //     }
            // }
            //
            // #endregion
            //
            // #region el consumption table
            //
            // {
            //     //find table data
            //     var tableData = GetReportObj(_sectionData.ReportObjects, "Table_ElConsumption") as ReportTable;
            //
            //     //fill table
            //     var tableFirstCell = _worksheet.Cell(8, 10).Address;
            //
            //     //insert data to the table
            //     for (int i = 0; i < tableData.TableData.Count; i++)
            //     {
            //         int x = tableFirstCell.ColumnNumber + i;
            //         int y = tableFirstCell.RowNumber;
            //         var item = tableData.TableData[i];
            //
            //         _worksheet.Cell(y, x).Value = item["NormalizedRef"];
            //         y++;
            //
            //         _worksheet.Cell(y, x).Value = item["Cons"];
            //         y++;
            //     }
            // }
            //
            // #endregion
            //
            // #region Consumption per building table
            //
            // {
            //     //find table data
            //     var tableData = GetReportObj(_sectionData.ReportObjects, "Table_ConsPerBuild") as ReportTable;
            //
            //     var table = _worksheet.Table("Table_ConsPerBuild");
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
            //         _worksheet.Cell(y, x).Value = item["Location"];
            //         x++;
            //         
            //         _worksheet.Cell(y, x).Value = item["RefYearM3"];
            //         x++;
            //         
            //         _worksheet.Cell(y, x).Value = item["PotentialSavingsPercent"];
            //         x++;
            //         
            //         //savings years
            //         foreach (var keyValuePair in item.Where(q => q.Key.Contains("Savings_")))
            //         {
            //             _worksheet.Cell(y, x).Value = keyValuePair.Value;
            //             x++;
            //         }
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