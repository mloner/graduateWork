using System.Text.Json;
using ReportingFramework.Common.Extentions;
using SectionModels.Excel.SectionModels.MCEM.CugReport;

namespace ExcelGenerator.Structure.Sections.MCEM.CugReport
{
    public class CugReportSectionV0_1 : CugReportSection
    {
        private new CugReportSectionModelV0_1 SectionModel;

        public CugReportSectionV0_1()
        {
            TemplateFileName = "MCEM/Template_MCEM_CugReport.xlsx";
        }

        public override void InitSectionModel(string sectionModelJson)
        {
            base.InitSectionModel(sectionModelJson);
            SectionModel = JsonSerializer.Deserialize<CugReportSectionModelV0_1>(sectionModelJson);
        }

        public override void GenerateContent()
        {
            var cugName = SectionModel.CustomParameters["CugName"];
            
            //rename sheet
            Worksheet.Name = Worksheet.Name.Replace("CugName", cugName);

            //change title
            Worksheet.Cell(1, 1).SetValue(Worksheet.Cell(1, 1).GetString().Replace("[CugName]", cugName));
            
            Worksheet.Cell(5, 1).SetValue(Worksheet.Cell(5, 1).GetString()
                .Replace("[curYear]", SectionModel.CustomParameters["CurYear"])
                .Replace("[refYear]", SectionModel.CustomParameters["RefYear"])
            );
            
            //change headers
            for (int i = 1; i <= 14; i++)
            {
                Worksheet.Cell(7, i).SetValue(Worksheet.Cell(7, i).GetString()
                    .Replace("[curYear]", SectionModel.CustomParameters["CurYear"])
                    .Replace("[refYear]", SectionModel.CustomParameters["RefYear"])
                );
            }

            AddTable();
        }

        private void AddTable()
        {
            //first table cell address
            var firstTableCellAddress = Worksheet.Cell(7, 1).Address;

            Worksheet.Row(firstTableCellAddress.RowNumber + 1)
                .InsertRowsBelow(SectionModel.CugReportTable.Data.Count);
            if (SectionModel.CugReportTable.Data.Count > 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    Worksheet.Row(firstTableCellAddress.RowNumber + 1).Delete();
                }
            }


            var refFormula = $"=IFERROR(((100 - RC[-2] * 100 / RC[-1])), \"{_numFmtr.NullValue}\")";
            
            //insert data to the table
            for (int i = 0; i < SectionModel.CugReportTable.Data.Count; i++)
            {
                int x = firstTableCellAddress.ColumnNumber;
                int y = firstTableCellAddress.RowNumber + 1;
                var item = SectionModel.CugReportTable.Data[i];
                
                Worksheet.Cell(y + i, x++).Value = item.BuildingName;
                Worksheet.Cell(y + i, x++).Value = item.BuildingType;

                Worksheet.Cell(y + i, x++).Value = _numFmtr.Format(item.ElectricityCurrentYear).ToDouble();
                Worksheet.Cell(y + i, x++).Value = _numFmtr.Format(item.ElectricityRefYear).ToDouble();
                Worksheet.Cell(y + i, x++).FormulaR1C1 = refFormula; 
                Worksheet.Cell(y + i, x++).Value = _numFmtr.Format(item.ElectricityKpi).ToDouble();
                
                Worksheet.Cell(y + i, x++).Value = _numFmtr.Format(item.GasCurrentYear).ToDouble();
                Worksheet.Cell(y + i, x++).Value = _numFmtr.Format(item.GasRefYear).ToDouble();
                Worksheet.Cell(y + i, x++).FormulaR1C1 = refFormula; 
                Worksheet.Cell(y + i, x++).Value = _numFmtr.Format(item.GasKpi).ToDouble();
                
                Worksheet.Cell(y + i, x++).Value = _numFmtr.Format(item.SolarCurrentYear).ToDouble();
                Worksheet.Cell(y + i, x++).Value = _numFmtr.Format(item.SolarRefYear).ToDouble();
                Worksheet.Cell(y + i, x++).FormulaR1C1 = refFormula; 
                Worksheet.Cell(y + i, x++).Value = _numFmtr.Format(item.SolarKpi).ToDouble();
                
            }
        }
    }
}