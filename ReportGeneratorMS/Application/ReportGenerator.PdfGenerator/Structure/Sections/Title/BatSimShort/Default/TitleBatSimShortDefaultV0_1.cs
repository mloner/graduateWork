using System.Collections.Generic;
using System.Text.Json;
using MigraDoc.DocumentObjectModel;
using ReportingFramework.Common.Extentions;
using ReportingFramework.Dto;
using ReportingFramework.Dto.DataModels;
using SectionModels.Pdf.SectionModels;

namespace ReportingFramework.Structure.Sections.Title.BatSimShort.Default
{
    public class TitleBatSimShortDefaultV0_1 : PdfReportSection
    {
        private new TitleSectionModel SectionModel;

        public override void Init(AbstractSectionParameters sectionParameters)
        {
            base.Init(sectionParameters);
            AddSectionResName("Title.BatSimShort.Default.V0_1");
        }
        

        public override void InitSectionModel(string sectionModelJson)
        {
            base.InitSectionModel(sectionModelJson);
            SectionModel = JsonSerializer.Deserialize<TitleSectionModel>(sectionModelJson);
        }

        public override void GenerateContent()
        {
            //header
            Par = AddParagraph(
                GetResVal("Header").ReplaceVals(new Dictionary<string, string>()
                {
                    {"CompanyName", SecParams.ReportTemplate.GlobalSettings.CompanyName}
                }),
                StyleEnum.TitlePageHeader);
            Par.Format.SpaceBefore = new Unit(15, UnitType.Centimeter);
            
            //subheader
            Par = AddParagraph(SectionModel.CustomerName, StyleEnum.TitlePageSubheader);
            Par.Format.SpaceBefore = new Unit(2, UnitType.Centimeter);
            
            //date
            Par = AddParagraph(SectionModel.ReportDate.ToString(SecParams.ReportTemplate.GlobalSettings.DateFormat), StyleEnum.TitlePageSubheader);
        }
        
    }
}