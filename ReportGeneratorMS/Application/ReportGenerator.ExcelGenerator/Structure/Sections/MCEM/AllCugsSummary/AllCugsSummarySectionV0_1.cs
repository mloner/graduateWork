using System;
using System.Linq;
using System.Text.Json;
using ClosedXML.Excel.Drawings;
using ReportingFramework.Common;
using ReportingFramework.Common.Extentions;
using SectionModels.Excel.SectionModels.MCEM.AllCugsSummary;

namespace ExcelGenerator.Structure.Sections.MCEM.AllCugsSummary
{
    public class AllCugsSummarySectionV0_1 : AllCugsSummarySection
    {
        private new AllCugsSummarySectionModelV0_1 SectionModel;
        private new string _sectionResName;

        public AllCugsSummarySectionV0_1()
        {
            TemplateFileName = "MCEM/Template_MCEM.xlsx";
            _sectionResName = "dfghfgh";
        }

        public override string? GetResVal(string key)
        {
            try
            {
                return ResHelper.GetResVal(_sectionResName, key, SecParams.ResourceParameters.CultureInfo);
            }
            catch (Exception e)
            {
                return base.GetResVal(key);
            }
        }

        public override void InitSectionModel(string sectionModelJson)
        {
            base.InitSectionModel(sectionModelJson);
            SectionModel = JsonSerializer.Deserialize<AllCugsSummarySectionModelV0_1>(sectionModelJson);
        }

        public override void GenerateContent()
        {
            //GetResVal("234");
            SetLogo();
            
            //rename sheet
            Worksheet.Name = Worksheet.Name.Replace("SheetName", SectionModel.CustomParameters["SheetName"])
                .Take(31).Select(x => x.ToString()).Aggregate((prev, current) => prev + current);


            //change title
            Worksheet.Cell(39, 1).SetValue(Worksheet.Cell(39, 1).GetString()
                .Replace("[curYear]", SectionModel.CustomParameters["CurYear"])
                .Replace("[refYear]", SectionModel.CustomParameters["RefYear"])
            );
            //change headers
            for (int i = 2; i <= 13; i++)
            {
                Worksheet.Cell(41, i).SetValue(Worksheet.Cell(41, i).GetString()
                    .Replace("[curYear]", SectionModel.CustomParameters["CurYear"])
                    .Replace("[refYear]", SectionModel.CustomParameters["RefYear"])
                );
            }

            AddTable();

            Worksheet.Columns().AdjustToContents();
        }

        private void SetLogo()
        {
            var logo = Worksheet.Picture("logo");
            var imagePath = $"{SecParams.Paths.CommonResourcesLogos}/{SecParams.Template.GlobalSettings.Logo}";
            var image = Worksheet.AddPicture(imagePath)
                .MoveTo(logo.TopLeftCell, logo.GetOffset(XLMarkerPosition.TopLeft))
                .WithPlacement(XLPicturePlacement.FreeFloating);
            image.Width = logo.Width;
            image.Height = logo.Height;
        }

        private void AddTable()
        {
            //first table cell address
            var firstTableCellAddress = Worksheet.Cell(41, 1).Address;

            Worksheet.Row(firstTableCellAddress.RowNumber + 1)
                .InsertRowsBelow(SectionModel.AllCugsSummaryTable.Data.Count);
            if (SectionModel.AllCugsSummaryTable.Data.Count > 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    Worksheet.Row(firstTableCellAddress.RowNumber + 1).Delete();
                }
            }
            
            _numFmtr.Decimals = 2;
            _numFmtr.GroupSeparator = "";
            _numFmtr.NullValue = "-";

            var refFormula = $"=IFERROR(((100 - RC[-2] * 100 / RC[-1])), \"{_numFmtr.NullValue}\")";
            
            //insert data to the table
            for (int i = 0; i < SectionModel.AllCugsSummaryTable.Data.Count; i++)
            {
                int x = firstTableCellAddress.ColumnNumber;
                int y = firstTableCellAddress.RowNumber + 1;
                var item = SectionModel.AllCugsSummaryTable.Data[i];
                
                Worksheet.Cell(y + i, x++).Value = item.CugName;

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