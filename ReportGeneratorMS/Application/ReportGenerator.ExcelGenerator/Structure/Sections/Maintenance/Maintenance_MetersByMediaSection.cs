using System.Linq;
using System.Text.Json;
using SectionModels.Excel.SectionModels.Maintenance;

namespace ExcelGenerator.Structure.Sections.Maintenance
{
    public class Maintenance_MetersByMediaSection : ExcelReportSection
    {
        private new Maintenance_MetersByMediaSectionModel SectionModel;
        public Maintenance_MetersByMediaSection()
        {
            TemplateFileName = "MaintenanceReport/Template_MaintenanceReport_MetersByMedia.xlsx";
        }
        public override void InitSectionModel(string sectionModelJson)
        {
            base.InitSectionModel(sectionModelJson);
            SectionModel = JsonSerializer.Deserialize<Maintenance_MetersByMediaSectionModel>(sectionModelJson);
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
            var table = Worksheet.Table("MetersByMediaTable");
            var firstTableCellAddress = table.FirstCell().Address;
            
            var rowCountNeedToInsert = SectionModel.MetersByMediaTable.Data.Count - 1;
            if (rowCountNeedToInsert > 0)
            {
                Worksheet.Row(firstTableCellAddress.RowNumber)
                    .InsertRowsBelow(rowCountNeedToInsert);
            }
            
            //insert data to the table
            for (int i = 0; i < SectionModel.MetersByMediaTable.Data.Count; i++)
            {
                int x = firstTableCellAddress.ColumnNumber;
                int y = firstTableCellAddress.RowNumber + 1;
                var item = SectionModel.MetersByMediaTable.Data[i];
                Worksheet.Cell(y + i, x++).Value = item.BuildingName;
                Worksheet.Cell(y + i, x++).Value = item.Medium;
                Worksheet.Cell(y + i, x++).Value = item.Sum;
            }
        }
    }
}