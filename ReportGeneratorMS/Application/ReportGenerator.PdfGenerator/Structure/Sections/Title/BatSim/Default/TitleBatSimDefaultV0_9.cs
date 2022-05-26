using System;

namespace ReportingFramework.Structure.Sections.Title.BatSim.Default
{
    public class TitleBatSimDefaultV0_9 : PdfReportSection
    {
        public override void InitSectionModel(string sectionModelJson)
        {
            throw new NotImplementedException();
        }

        public override void Generate()
        {
    //         string elemName;
    //
    //         #region Logo
    //
    //         var imgPar = AddImagePar(
    //             imgPath: $"{_secParams.Paths.CommonResourcesLogos}/{_template.GlobalSettings.Logo}",
    //             imgTitle: "",
    //             imgWidthCm: 14,
    //             globalSettings: _template.GlobalSettings,
    //             styles: _styles,
    //             figureNum: null
    //         )[0];
    //         imgPar.Format.SpaceBefore = new Unit(9, UnitType.Centimeter);
    //         _pdfSection.Add(imgPar);
    //
    //         #endregion
    //
    //         #region Content
    //
    //         #region Header
    //         
    //         elemName = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Header";
    //         var header = GetReportObj(_secParams.AbstractSection, elemName) as ReportParagraph;
    //         header.Title = ResHelper.GetResVal(_sectionResName, $"{elemName}_Title", _ci);
    //         _par = AddText(header.Title, SectionExtensions.GetStyle(_styles, StyleEnum.TitlePageHeader));
    //         _par.Format.SpaceBefore = new Unit(4, UnitType.Centimeter);
    //
    //         #endregion
    //         
    //         #region Subeader
    //         
    //         elemName = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Subheader";
    //         var subheader = GetReportObj(_secParams.AbstractSection, elemName) as ReportParagraph;
    //         subheader.Title = ResHelper.GetResVal(_sectionResName, $"{elemName}_Title", _ci)
    //             .ReplaceVals(new Dictionary<string, string>()
    //             {
    //                 {"ClientName", subheader.Parameters.First(x => x.Key == "Value").Value.ToString()}
    //             });
    //         _par = AddText(subheader.Title, SectionExtensions.GetStyle(_styles, StyleEnum.TitlePageSubheader));
    //         _par.Format.SpaceBefore = new Unit(2, UnitType.Centimeter);
    //
    //         #endregion
    //         
    //         #region Date
    //         
    //         elemName = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Date";
    //         var date = GetReportObj(_secParams.AbstractSection, elemName) as ReportParagraph;
    //         date.Title = "[Date]"
    //             .ReplaceVals(new Dictionary<string, string>()
    //             {
    //                 {"Date", DateTime.Parse(date.Parameters.First(x => x.Key == "Value").Value.ToString(), CultureInfo.InvariantCulture)
    //                     .ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)}
    //             });
    //         _par = AddText(date.Title, SectionExtensions.GetStyle(_styles, StyleEnum.TitlePageSubheader));
    //
    // #endregion
    //
    //         #endregion
        }

        public override void GenerateContent()
        {
            throw new NotImplementedException();
        }
    }
}