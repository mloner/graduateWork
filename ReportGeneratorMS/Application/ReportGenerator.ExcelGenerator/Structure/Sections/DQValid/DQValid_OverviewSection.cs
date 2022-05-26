using System.Collections.Generic;
using System.Text.Json;
using ClosedXML.Excel;
using SectionModels.Excel.SectionModels.DQValid;

namespace ExcelGenerator.Structure.Sections.DQValid
{
    public class DQValid_OverviewSection : ExcelReportSection
    {
        private new DQValid_OverviewSectionModel SectionModel;

        public DQValid_OverviewSection()
        {
            TemplateFileName = "DQValidReport/Template_DQValidReport_Overview.xlsx";
        }
        public override void InitSectionModel(string sectionModelJson)
        {
            base.InitSectionModel(sectionModelJson);
            SectionModel = JsonSerializer.Deserialize<DQValid_OverviewSectionModel>(sectionModelJson);
        }

        public override void GenerateContent()
        {
            var condFormatts = new Dictionary<string, XLColor>()
            {
                {"Issues not found", XLColor.LightGreen},
                {"Type is defined", XLColor.LightGreen},
                {"Profile is defined", XLColor.LightGreen},
                {"Ok", XLColor.LightGreen},
                {"Issues found", XLColor.LightCoral},
                {"cannot be defined", XLColor.LightCyan},
                {"Processing failed", XLColor.LightYellow}
            };
            
            
            //find table
            var table = Worksheet.Table("Table_Overview");
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
                 IXLCell cell;
                 string value;
                 string fieldValue;
            
                 value = item["CugName"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.Value = value;
                 
                 value = item["BuildingName"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.Value = value;
                 
                 value = item["MeasurementsNames"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.Value = value;
                 
                 value = item["InputName"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.Value = value;
                 
                 value = item["InputType"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.Value = value;
                 
                 value = item["MediumUnit"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.Value = value;
                 
                 value = item["GateTime"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.Value = value;
                 
                 value = item["IsForecast"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.Value = value;
                 
                 value = item["IsValid"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.Value = value;
                 
                 value = item["Status"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.AddCustomConditionalFormats(condFormatts);
                 cell.Value = value;
                 
                 value = item["FirstDate"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.Value = value;
                 
                 value = item["EndDate"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.Value = value;
                 
                 
                 //DataFromFuture Checker
                 value = item["DataFromFutureStatus"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.AddCustomConditionalFormats(condFormatts);
                 cell.Value = value;
                 
                 value = item["FuturePointsCount"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.Value = value;
                 
                 
                 //Gaps Checker
                 value = item["GapsStatus"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.AddCustomConditionalFormats(condFormatts);
                 cell.Value = value;
                 
                 value = item["GapsCount"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.Value = value;
                 
                 //Outliers Checker
                 value = item["OutliersStatus"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.AddCustomConditionalFormats(condFormatts);
                 cell.Value = value;
                 
                 value = item["OutliersCount"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.AddCustomConditionalFormats(condFormatts);
                 cell.Value = value;

                 
                 //Anomalies Checker
                 value = item["AnomaliesStatus"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.AddCustomConditionalFormats(condFormatts);
                 cell.Value = value;
                 
                 value = item["AnomaliesCount"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.Value = value;
                 
                 //Input Type Classifier
                 value = item["InputTypeStatus"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.AddCustomConditionalFormats(condFormatts);
                 cell.Value = value;
                 
                 //Input Profile Classifier
                 value = item["InputProfileStatus"];
                 cell = Worksheet.Cell(y + i, x++);
                 cell.AddCustomConditionalFormats(condFormatts);
                 cell.Value = value;
                 
             }
            
             Worksheet.Columns().AdjustToContents();
        }
    }
}