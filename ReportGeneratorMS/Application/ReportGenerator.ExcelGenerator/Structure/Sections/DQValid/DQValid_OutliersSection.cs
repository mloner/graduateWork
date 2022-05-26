using System;
using System.Globalization;
using System.Text.Json;
using SectionModels.Excel.SectionModels.DQValid;

namespace ExcelGenerator.Structure.Sections.DQValid
{
    public class DQValid_OutliersSection : ExcelReportSection
    {
        private new DQValid_OutliersSectionModel SectionModel;

        public DQValid_OutliersSection()
        {
            TemplateFileName = "DQValidReport/Template_DQValidReport_Outliers.xlsx";
        }
        public override void InitSectionModel(string sectionModelJson)
        {
            base.InitSectionModel(sectionModelJson);
            SectionModel = JsonSerializer.Deserialize<DQValid_OutliersSectionModel>(sectionModelJson);
        }

        public override void GenerateContent()
        {
            //find table
            var table = Worksheet.Table("Table_Outliers");
            var firstTableCellAddr = table.FirstCell().Address;
            var rowCountInTable = SectionModel.Data.Count;
            var rowCountExist = 2;
            var rowCountNeedToInsert = rowCountInTable - rowCountExist;
            if (rowCountNeedToInsert > 0)
            {
                Worksheet.Row(firstTableCellAddr.RowNumber + 1) // we start to add rows with the first existing row
                                                                // (to copy the style of the first row)
                    .InsertRowsBelow(rowCountNeedToInsert);
            }
            
            //insert data to table
             for (int i = 0; i < SectionModel.Data.Count; i++)
             {
                 int x = firstTableCellAddr.ColumnNumber;
                 int y = firstTableCellAddr.RowNumber + 1;
                 var item = SectionModel.Data[i];
                 string value;
                 string fieldValue;
            
                 value = item["CugName"];
                 Worksheet.Cell(y + i, x++).Value = value;
                 
                 value = item["BuildingName"];
                 Worksheet.Cell(y + i, x++).Value = value;
                 
                 value = item["MeasurementsNames"];
                 Worksheet.Cell(y + i, x++).Value = value;
                 
                 value = item["InputName"];
                 Worksheet.Cell(y + i, x++).Value = value;
                 
                 value = item["Timestamp"];
                 DateTime dt = DateTime.Parse(value, CultureInfo.InvariantCulture);
                 string ZoneId = "Central European Standard Time";
                 TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(ZoneId);
                 Worksheet.Cell(y + i, x++).Value = TimeZoneInfo.ConvertTime(dt, timeZone);
                 
                 value = item["Value"];
                 Worksheet.Cell(y + i, x++).Value = value;
             }
            
             Worksheet.Columns().AdjustToContents();
        }
    }
}