using System.Text.Json;
using ReportingFramework.Dto.DataModels;
using SectionModels.Pdf.SectionModels.AlgoCompReport;

namespace ReportingFramework.Structure.Sections.PeakShavComp.AlgoComp.Jabba
{
    public class AlgoComparisonPeakShavingComparisonJabbaV0_1 : PdfReportSection
    {
        public new AlgoComp_PeakShavCompSectionModel SectionModel;

        public override void Init(AbstractSectionParameters sectionParameters)
        {
            base.Init(sectionParameters);
            AddSectionResName("PeakShavComp.AlgoComp.Default.V0_1");
        }
        
        public override void InitSectionModel(string sectionModelJson)
        {
            base.InitSectionModel(sectionModelJson);
            SectionModel = JsonSerializer.Deserialize<AlgoComp_PeakShavCompSectionModel>(sectionModelJson);
        }

        public override void GenerateContent()
        { 
            // string parName;
            //
            // #region Ref case
            //
            // Prefix = "RefCase";
            //
            // #region Title
            //
            // AddParagraph(GetResVal($"{Prefix}_Title"), StyleEnum.H2);
            //
            // #endregion
            //
            // #region Content
            //
            // AddParagraph(GetResVal($"{Prefix}_Desc_1"));
            //
            // #region Chart
            //
            // var path = SecParams.ChartGeneratorClient.SaveChartDirectLink(
            //     SectionModel.RefCase.Chart.Url,
            //     SecParams.Paths.ReportCharts);
            //
            // AddImage(
            //     section: PdfSection,
            //     imgPath: path,
            //     imgTitle: $"{Prefix}_Chart_Title",
            //     imgWidthCm: 14,
            //     globalSettings: ReportTemplate.GlobalSettings,
            //     styles: ReportTemplate.Styles,
            //     figureNum: null
            // );
            //
            // #endregion
            //
            // AddParagraph(GetResVal($"{Prefix}_Desc_2")
            //     .ReplaceVals(new Dictionary<string, string>()
            //     {
            //         {"Value", _numFmtr.Format(SectionModel.RefCase.Peak, decimals:1)},
            //         {"Date", SectionModel.RefCase.PeakDateTimeStart.ToString(ReportTemplate.GlobalSettings.DateFormat)},
            //         {"Time1", SectionModel.RefCase.PeakDateTimeStart.AddMinutes(-SectionModel.RefCase.TimeGate).ToString(ReportTemplate.GlobalSettings.TimeFormat)},
            //         {"Time2", SectionModel.RefCase.PeakDateTimeStart.ToString(ReportTemplate.GlobalSettings.TimeFormat)},
            //     }));
            //
            // AddParagraph(GetResVal($"{Prefix}_Desc_3")
            //     .ReplaceVals(new Dictionary<string, string>()
            //     {
            //         {"Value", _numFmtr.Format(SectionModel.RefCase.CapTariff, decimals:1)},
            //     }));
            //
            //
            // #endregion
            //
            // #endregion
            //
            // PdfSection.AddPageBreak();
            //
            // #region Best case
            //
            // Prefix = "BestCase";
            //
            // #region Title
            //
            // AddParagraph(GetResVal($"{Prefix}_Title"), StyleEnum.H2);
            //
            // #endregion
            //
            // #region Content
            //
            // AddParagraph(GetResVal($"{Prefix}_Desc_1")
            //     .ReplaceVals(new Dictionary<string, string>()
            // {
            //     {"CompanyName", ReportTemplate.GlobalSettings.CompanyName},
            // }));
            //
            // #region Chart
            //
            // path = SecParams.ChartGeneratorClient.SaveChartDirectLink(
            //     SectionModel.BestCase.Chart.Url,
            //     SecParams.Paths.ReportCharts);
            //
            // AddImage(
            //     section: PdfSection,
            //     imgPath: path,
            //     imgTitle: $"{Prefix}_Chart_Title",
            //     imgWidthCm: 14,
            //     globalSettings: ReportTemplate.GlobalSettings,
            //     styles: ReportTemplate.Styles,
            //     figureNum: null
            // );
            //
            // #endregion
            //
            // AddParagraph(GetResVal($"{Prefix}_Desc_2")
            //     .ReplaceVals(new Dictionary<string, string>()
            //     {
            //         {"Value", _numFmtr.Format(SectionModel.BestCase.Peak, decimals:1)},
            //         {"CompanyName", ReportTemplate.GlobalSettings.CompanyName},
            //     }));
            //
            // AddSpace();
            //
            // AddParagraph(GetResVal($"{Prefix}_Desc_3")
            //     .ReplaceVals(new Dictionary<string, string>()
            //     {
            //         {"Price1", _numFmtr.Format(SectionModel.BestCase.CapTariff, decimals:1)},
            //         {"Price2", _numFmtr.Format(SectionModel.BestCase.Savings, decimals:1)},
            //         {"BatteryName", SectionModel.BestCase.BatteryModel},
            //         {"CompanyName", ReportTemplate.GlobalSettings.CompanyName},
            //     }));
            //
            // #endregion
            //
            // #endregion
        }
    }
}