using System.Collections.Generic;
using System.Text.Json;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using ReportingFramework.Common.Extentions;
using ReportingFramework.Dto;
using ReportingFramework.Dto.DataModels;
using ReportingFramework.Extentions;
using SectionModels.Pdf.SectionModels.AlgoCompReport;

namespace ReportingFramework.Structure.Sections.ExSum.AlgoComp.Jabba
{
    public class ExecutiveSummaryAlgoComparisonJabbaV0_1 : PdfExecutiveSummary
    {
        public new AlgoComp_ExecSumSectionModel SectionModel;

        public override void Init(AbstractSectionParameters sectionParameters)
        {
            base.Init(sectionParameters);
            AddSectionResName("ExecSum.AlgoComp.Default.V0_1");
        }
        
        public override void InitSectionModel(string sectionModelJson)
        {
            base.InitSectionModel(sectionModelJson);
            SectionModel = JsonSerializer.Deserialize<AlgoComp_ExecSumSectionModel>(sectionModelJson);
        }

        public override void GenerateContent()
        {
            AddReportTitle();
            
            AddSpace(1.5);
            
            AddBasicInfo();
            
            #region Two description paragraphs


            AddParagraph(GetResVal("Desc_1")
                .ReplaceVals(new Dictionary<string, string>()
                {
                    {"Savings", _numFmtr.Format(SectionModel.Savings, decimals:1)}
                }));
            
            AddSpace(0.3);

            AddParagraph(GetResVal("Desc_2")
                .ReplaceVals(new Dictionary<string, string>()
                {
                    {"BatteryModel", SectionModel.BasicInfo.BatteryModel},
                    {"CompanyName", ReportTemplate.GlobalSettings.CompanyName},
                }));
            
            #endregion
            
            AddSpace(2);
            
            #region Peak shaving explanation
            
            #region Title

            Prefix = "PeakShavingExpl";
            AddParagraph(GetResVal($"{Prefix}_Title"), StyleEnum.H1);
            
            #endregion
            
            #region Capacity tariff exmplanation
            
            Prefix = "CapacityTariffExpl";

            #region Title
            
            AddParagraph(GetResVal($"{Prefix}_Title"), StyleEnum.H2);
            
            #endregion
            
            #region Content

            int parCount = 3;
            for(int i = 0; i < parCount; i++)
            {
                Par = AddParagraph(GetResVal($"{Prefix}_{i}"));
                if (i < parCount - 1)
                {
                    Par.Format.SpaceAfter = new Unit(0.3, UnitType.Centimeter);
                }
            }
            
            #endregion
            
            #endregion
            
            PdfSection.AddPageBreak();
            
            #region Net cost exmplanation
            
            Prefix = "NetCostExpl";

            #region Title
            
            AddParagraph(GetResVal($"{Prefix}_Title"), StyleEnum.H2);
            
            #endregion
            
            #region Content
            
            
            //text
            parCount = 4;
            for(int i = 0; i < parCount; i++)
            {
                Par = AddParagraph(GetResVal($"{Prefix}_{i}"));
                if (i < parCount - 1)
                {
                    Par.Format.SpaceAfter = new Unit(0.3, UnitType.Centimeter);
                }
            }
            
            AddSpace(1);
            
            //image
            Prefix = "CostDistribution";
            var imagePath = $"{SecParams.Paths.SectionImages}/{Prefix}.png";
            AddImage(
                section: PdfSection,
                imgPath: imagePath,
                imgTitle: null,
                imgWidthCm: 14,
                globalSettings: ReportTemplate.GlobalSettings,
                styles: Styles,
                figureNum: null
                );
            
            #endregion
            
            #endregion
            
            PdfSection.AddPageBreak();
            
            #region Additional cost explanation
            
            Prefix = "AddCostExpl";

            #region Title
            
            AddParagraph(GetResVal($"{Prefix}_Title"), StyleEnum.H2);
            
            #endregion
            
            #region Content

            parCount = 7;
            for(int i = 0; i < parCount; i++)
            {
                Par = AddParagraph(GetResVal($"{Prefix}_{i}"));
                if (i < parCount - 1)
                {
                    Par.Format.SpaceAfter = new Unit(0.3, UnitType.Centimeter);
                }
            }
            
            #endregion
            
            #endregion
            
            PdfSection.AddPageBreak();
            
            #region Smart peak shaving explanation
            
            Prefix = "SmartPeakShavingExpl";

            #region Title
            
            AddParagraph(GetResVal($"{Prefix}_Title"), StyleEnum.H2);
            
            #endregion
            
            #region Content

            parCount = 5;
            for(int i = 0; i < parCount; i++)
            {
                Par = AddParagraph(GetResVal($"{Prefix}_{i}"));
                if (i < parCount - 1)
                {
                    Par.Format.SpaceAfter = new Unit(0.3, UnitType.Centimeter);
                }
            }
            
            #endregion
            
            #endregion
            
            #endregion
        }

        public new void AddReportTitle()
        {
            Table table;
            Column column1;
            Column column2;
            Row row;
            MigraDoc.DocumentObjectModel.Shapes.Image img;
            
            ShiftedParagraphFromTop(1);
            
            table = PdfSection.AddTable();
            table.BottomPadding = new Unit(0.1, UnitType.Centimeter);
            table.TopPadding = 0;
            table.LeftPadding = 0;
            table.RightPadding = 0;
            
            //table.Borders.Color = Colors.Black;
            
            var colWidth = new Unit(GetSectionWidthCm(), UnitType.Centimeter);
            table.AddColumn().Width = colWidth * 7/25;
            table.AddColumn().Width = colWidth * 1/25;
            table.AddColumn().Width = colWidth * 17/25;
            row = table.AddRow();
            row.Height = new Unit(4.1, UnitType.Centimeter);
            
            table.Columns.Width = new Unit(GetSectionWidthCm(), UnitType.Centimeter);
            
            //logo
            row.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            var imagePath = $"{SecParams.Paths.CommonResourcesLogos}/{ReportTemplate.GlobalSettings.Logo}";
            img = row.Cells[0].AddImage(imagePath);
            img.Width = table.Columns[0].Width;
            
            
            row.Cells[2].VerticalAlignment = VerticalAlignment.Bottom;
            //header
            Par = row.Cells[2].AddParagraph();
            Par.AddText(GetResVal("Header").ToUpper());
            Par.Format = SectionExtensions.GetParagraphFormat(ReportTemplate.Styles, StyleEnum.TitlePageHeader);
            Par.Format.Alignment = ParagraphAlignment.Right;
            //subheader
            Par = row.Cells[2].AddParagraph();
            Par.AddText(GetResVal("Subheader"));
            Par.Format = SectionExtensions.GetParagraphFormat(ReportTemplate.Styles, StyleEnum.TitlePageSubheader);
            Par.Format.Alignment = ParagraphAlignment.Right;
            
        }
        
        protected void AddBasicInfo()
        {
            string prefix = "BasicInfo";
            Row row;
            
            //title
            Par = PdfSection.AddParagraph();
            Par.Format = SectionExtensions.GetParagraphFormat(ReportTemplate.Styles, StyleEnum.Title);
            Par.Elements = FormattedText(GetResVal($"{prefix}_Title")).Elements.Clone();
            
            //table
            var table = PdfSection.AddTable();
            Column col;
            col = table.AddColumn();
            col.Width = new Unit(6, UnitType.Centimeter);
            col = table.AddColumn();
            col.Width = new Unit(5, UnitType.Centimeter);
            
            
            row = table.AddRow();
            AddBasicInfoElement(row, GetResVal($"{prefix}_BuildingName"), SectionModel.BasicInfo.BuildingName);
            row = table.AddRow();
            AddBasicInfoElement(row, GetResVal($"{prefix}_Email"), SectionModel.BasicInfo.Email);
            row = table.AddRow();
            AddBasicInfoElement(row, GetResVal($"{prefix}_ReportDate"), SectionModel.BasicInfo.ReportDate.ToString(ReportTemplate.GlobalSettings.DateFormat));
            row = table.AddRow();
            AddBasicInfoElement(row, GetResVal($"{prefix}_SimPeriod"), $"{SectionModel.BasicInfo.SimulationPeriodStart.ToString(ReportTemplate.GlobalSettings.DateFormat)} - " +
                                                                          $"{SectionModel.BasicInfo.SimulationPeriodEnd.ToString(ReportTemplate.GlobalSettings.DateFormat)}");
            row = table.AddRow();
            AddBasicInfoElement(row, GetResVal($"{prefix}_SimulatedDaysNumer"), _numFmtr.Format(SectionModel.BasicInfo.SimulatedDaysNumer));
            row = table.AddRow();
            AddBasicInfoElement(row, GetResVal($"{prefix}_BatteryModel"), SectionModel.BasicInfo.BatteryModel);
            row = table.AddRow();
            AddBasicInfoElement(row, GetResVal($"{prefix}_BatteryCapacity"), $"{_numFmtr.Format(SectionModel.BasicInfo.BatteryCapacity, decimals:1)} kWh");
            
            
            AddSpace(0.3);
        }

        public void AddBasicInfoElement(Row row, string key, string value)
        {
            Par = row.Cells[0].AddParagraph();
            Par.Format = SectionExtensions.GetParagraphFormat(ReportTemplate.Styles, StyleEnum.Normal);
            Par.AddText(key);
                
            Par = row.Cells[1].AddParagraph();
            Par.Format = SectionExtensions.GetParagraphFormat(ReportTemplate.Styles, StyleEnum.Normal);
            Par.AddText(value);
        }
    }
}