using System;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using ClosedXML.Excel;
using SectionModels.Excel.SectionModels.Maintenance;

namespace ExcelGenerator.Structure.Sections.Maintenance
{
    public class Maintenance_CugGapsInputErrorsSection : ExcelReportSection
    {
        private new Maintenance_GapsInputsSectionModel SectionModel;
        public Maintenance_CugGapsInputErrorsSection()
        {
            TemplateFileName = "MaintenanceReport/Template_MaintenanceReport_GapsInputsReport.xlsx";
        }
        public override void InitSectionModel(string sectionModelJson)
        {
            base.InitSectionModel(sectionModelJson);
            SectionModel = JsonSerializer.Deserialize<Maintenance_GapsInputsSectionModel>(sectionModelJson);
        }

        public override void GenerateContent()
        {
            //rename sheet
            Worksheet.Name = Worksheet.Name.Replace("CugName", SectionModel.CustomParameters["CugName"])
                .Take(31).Select(x => x.ToString()).Aggregate((prev, current) => prev + current);
             
            
            AddTable();
            
            Worksheet.Columns().AdjustToContents();
        }

        private void AddTable()
        {
            //find table
            var table = Worksheet.Table("GapsInputsErrorsTable");
            
            var firstTableCellAddr = table.FirstCell().Address;
            var rowCountInTable = SectionModel.CugGapsInputsTable.Data.Count;
            var rowCountExist = 2;
            var rowCountNeedToInsert = rowCountInTable - rowCountExist;
            if (rowCountNeedToInsert > 0)
            {
                Worksheet.Row(firstTableCellAddr.RowNumber + 1) // we start to add rows with the first existing row
                    // (to copy the style of the first row)
                    .InsertRowsBelow(rowCountNeedToInsert);
            }
            
            string ZoneId = "Central European Standard Time";
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(ZoneId);
            XLAlignmentHorizontalValues defHorAlign = XLAlignmentHorizontalValues.Left;
            
            //insert data to the table
            for (int i = 0; i < SectionModel.CugGapsInputsTable.Data.Count; i++)
            {
                int x = firstTableCellAddr.ColumnNumber;
                int y = firstTableCellAddr.RowNumber + 1 + i;
                var item = SectionModel.CugGapsInputsTable.Data[i];
                
                Worksheet.Cell(y, x).Value = item.BuildingName;
                Worksheet.Cell(y, x).Style.Alignment.Horizontal = defHorAlign;
                x++;
                
                Worksheet.Cell(y, x).Value = item.AimrId;
                Worksheet.Cell(y, x).Style.Alignment.Horizontal = defHorAlign;
                x++;
                
                Worksheet.Cell(y, x).Value = item.AimrName;
                Worksheet.Cell(y, x).Style.Alignment.Horizontal = defHorAlign;
                x++;
                
                Worksheet.Cell(y, x).Value = item.AimrType;
                Worksheet.Cell(y, x).Style.Alignment.Horizontal = defHorAlign;
                x++;
                
                Worksheet.Cell(y, x).Value = item.InputId;
                Worksheet.Cell(y, x).Style.Alignment.Horizontal = defHorAlign;
                x++;
                
                Worksheet.Cell(y, x).Value = item.Medium;
                Worksheet.Cell(y, x).Style.Alignment.Horizontal = defHorAlign;
                x++;
                
                Worksheet.Cell(y, x).Value = item.InputName;
                Worksheet.Cell(y, x).Style.Alignment.Horizontal = defHorAlign;
                x++;
                
                DateTime dt = DateTime.Parse(item.LastValueTimestamp, CultureInfo.InvariantCulture);
                Worksheet.Cell(y, x).Value = TimeZoneInfo.ConvertTime(dt, timeZone);
                Worksheet.Cell(y, x).Style.Alignment.Horizontal = defHorAlign;
                x++;
                
                Worksheet.Cell(y, x).Value = item.LastValue;
                Worksheet.Cell(y, x).Style.Alignment.Horizontal = defHorAlign;
                x++;
                
                Worksheet.Cell(y, x).Value = item.GateTime;
                Worksheet.Cell(y, x).Style.Alignment.Horizontal = defHorAlign;
                x++;
                
                Worksheet.Cell(y, x).Value = item.Description;
                Worksheet.Cell(y, x).Style.Alignment.Horizontal = defHorAlign;
                x++;
            }
        }
    }
}