using System;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;


namespace ReportGeneratorTests.ReportTests.PdfReportTests
{
    public class PdfReportTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PdfReportTest_Bliq_1()
        {
            // const string companyName = "Bliq";
            // string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            // string resourcesPath = $"{rootPath}Images";
            // string companyResourcesPath = $"{resourcesPath}\\Companies\\{companyName}";
            // string companyBackgroundsPath = $"{companyResourcesPath}\\Backgrounds";
            // string companyIconsPath = $"{companyResourcesPath}\\Icons";
            //
            // var bliqTemplate = new PdfTemplate()
            // {
            //     Styles = new List<Style>()
            //     {
            //         //TitlePage header
            //         new Style()
            //         {
            //             Name = "TitlePageHeader",
            //             Alignment = AlignmentEnum.Center,
            //             LineSpace = 1,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 36,
            //                 Color = "0,31,78",
            //                 Bold = true
            //             }
            //         },
            //         //TitlePage subheader
            //         new Style()
            //         {
            //             Name = "TitlePageSubheader",
            //             Alignment = AlignmentEnum.Center,
            //             LineSpace = 1,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 16,
            //                 Color = "0,31,78",
            //             }
            //         },
            //         //Bliq section title
            //         new Style()
            //         {
            //             Name = "BliqSectionTitle",
            //             Alignment = AlignmentEnum.Left,
            //             LineSpace = 1,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 26,
            //                 Color = "255,255,255",
            //                 Bold = true
            //             }
            //         },
            //         //Title
            //         new Style()
            //         {
            //             Name = StyleEnum.Title.Desc(),
            //             Alignment = AlignmentEnum.Left,
            //             LineSpace = 1,
            //             SpaceAfter = 0.2,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 16,
            //                 Color = "0,31,78",
            //                 Bold = true
            //             }
            //         },
            //         //H1
            //         new Style()
            //         {
            //             Name = StyleEnum.H1.Desc(),
            //             Alignment = AlignmentEnum.Left,
            //             LineSpace = 1,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 16,
            //                 Color = "0,31,78",
            //                 Bold = true
            //             }
            //         },
            //         //H2
            //         new Style()
            //         {
            //             Name = StyleEnum.H2.Desc(),
            //             Alignment = AlignmentEnum.Left,
            //             LineSpace = 1,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 12,
            //                 Color = "0,31,78",
            //                 Bold = true
            //             }
            //         },
            //         //H3
            //         new Style()
            //         {
            //             Name = StyleEnum.H3.Desc(),
            //             Alignment = AlignmentEnum.Left,
            //             LineSpace = 1,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 10,
            //                 Color = "0,31,78",
            //                 Bold = true
            //             }
            //         },
            //         //Normal
            //         new Style()
            //         {
            //             Name = StyleEnum.Normal.Desc(),
            //             Alignment = AlignmentEnum.Justify,
            //             LineSpace = 1.1,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 11,
            //                 Color = "0,0,0"
            //
            //             }
            //         },
            //         //Header
            //         new Style()
            //         {
            //             Name = StyleEnum.Header.Desc(),
            //             Alignment = AlignmentEnum.Justify,
            //             LineSpace = 1,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 10,
            //                 Color = "0,31,78"
            //
            //             }
            //         },
            //         //Footer
            //         new Style()
            //         {
            //             Name = StyleEnum.Footer.Desc(),
            //             Alignment = AlignmentEnum.Justify,
            //             LineSpace = 1,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 10,
            //                 Color = "0,31,78"
            //
            //             }
            //         },
            //         //Image title
            //         new Style()
            //         {
            //             Name = StyleEnum.ImageTitle.Desc(),
            //             Alignment = AlignmentEnum.Center,
            //             LineSpace = 1,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 10,
            //                 Color = "0,31,78"
            //
            //             }
            //         },
            //     },
            //     SectionTypeTemplates = new List<SectionTypeTemplate>()
            //     {
            //         //TitlePage
            //         new SectionTypeTemplate()
            //         {
            //             Name = PdfSectionStyleEnum.TitlePage,
            //             Margins = new Margins()
            //             {
            //                 Top = 0,
            //                 Bottom = 0,
            //                 Left = 0,
            //                 Right = 0
            //             },
            //             BackgroundImage = $"{companyBackgroundsPath}\\TitlePage.png"
            //         },
            //         //Default
            //         new SectionTypeTemplate()
            //         {
            //             Name = PdfSectionStyleEnum.Default,
            //             Margins = new Margins()
            //             {
            //                 Top = 4.8,
            //                 Bottom = 2.1,
            //                 Left = 2,
            //                 Right = 2.5
            //             },
            //             BackgroundImage = $"{companyBackgroundsPath}\\Default.png",
            //             Title = new Title()
            //             {
            //                 TitleType = TitleType.BliqDefault
            //             },
            //             Footer = new Footer()
            //             {
            //                 FooterType = FooterType.NoFooter
            //             },
            //             Header = new Header()
            //             {
            //                 HeaderType = HeaderType.NoHeader,
            //             },
            //         },
            //         //Appendix
            //         new SectionTypeTemplate()
            //         {
            //             Name = PdfSectionStyleEnum.Appendix,
            //             Margins = new Margins()
            //             {
            //                 Top = 4.8,
            //                 Bottom = 2.1,
            //                 Left = 2,
            //                 Right = 2.5
            //             },
            //             BackgroundImage = $"{companyBackgroundsPath}\\Appendix.png",
            //             Title = new Title()
            //             {
            //                 TitleType = TitleType.BliqAppendix
            //             },
            //             Header = new Header()
            //             {
            //                 HeaderType = HeaderType.NoHeader,
            //             },
            //             Footer = new Footer()
            //             {
            //                 FooterType = FooterType.NoFooter
            //             }
            //         },
            //         //Subsection
            //         new SectionTypeTemplate()
            //         {
            //             Name = PdfSectionStyleEnum.Subsection,
            //             Margins = new Margins()
            //             {
            //                 Top = 4.8,
            //                 Bottom = 2.1,
            //                 Left = 2,
            //                 Right = 2.5
            //             },
            //             BackgroundImage = $"{companyBackgroundsPath}\\Appendix.png",
            //             Title = new Title()
            //             {
            //                 TitleType = TitleType.BliqSubsection
            //             },
            //             Header = new Header()
            //             {
            //                 HeaderType = HeaderType.NoHeader,
            //             },
            //             Footer = new Footer()
            //             {
            //                 FooterType = FooterType.NoFooter
            //             }
            //         },
            //     },
            //     GlobalSettings = new GlobalSettings()
            //     {
            //         DecimalSeparator = ",",
            //         ThousandsSeparator = ".",
            //         Variables = new ReportVariables()
            //         {
            //             AppendixName = "Appendix",
            //             FigureName = "Figure",
            //             FigureShortName = "Fig."
            //         }
            //     }
            // };
            //
            // var reportStructure = new PdfReportModel()
            // {
            //     ReportName = $"{companyName}_report",
            //     OutputFolder = $"{rootPath}\\Reports\\{companyName}",
            //     Template = bliqTemplate,
            //     Sections = new List<ISection>()
            //     // {
            //     //     //TitlePage
            //     //     new PdfSection()
            //     //     {
            //     //         Name = PdfSectionNameEnum.TitlePage,
            //     //         Style = PdfSectionType.TitlePage,
            //     //         Data = new TitlePageSectionData()
            //     //         {
            //     //             Header = "Battery advice report",
            //     //             Subheader = "Familie van de Poel",
            //     //             Date = "22-07-2021"
            //     //         }
            //     //     },
            //     //     //Sensitivity matrix
            //     //     new PdfSection()
            //     //     {
            //     //         Name = PdfSectionNameEnum.SensitivityMatrix,
            //     //         Style = PdfSectionType.Default,
            //     //         Data = new SensitivityMatrixSectionData()
            //     //         {
            //     //             Title = "Sensitivity matrix section",
            //     //             Description = "The payback period is the time it takes to return the investment based on the savings obtained by an offered project. The investment is the @color=249,169,173;bold=true{red} (negative) bar in the chart. The @color=111,147,178;bold=true{blue} bars are the annual savings. The cashflow is based on the most optimal case scenario from the simulation.",
            //     //             SensitivityMatrixChart = new AbstractChart()
            //     //             {
            //     //                 ChartType = ChartEnum.SensitivityMatrix,
            //     //                 ChartData = new SensitivityMatrixChartData()
            //     //                 {
            //     //                     XAxis = new List<string>(){"1","2","3"},
            //     //                     YAxis = new List<string>(){"4","5","6"},
            //     //                     Values = new List<List<double>>()
            //     //                     {
            //     //                         new List<double>(){1,2,1},
            //     //                         new List<double>(){1,3,4},
            //     //                         new List<double>(){1,5,6}
            //     //                     }
            //     //                 },
            //     //                 ChartSettings = new SensitivityMatrixChartSettings()
            //     //                 {
            //     //                     TranslationStrings = new Dictionary<string, string>()
            //     //                     {
            //     //                         {"FeedInInjectionTariff", "Feed-in injection tariff"},
            //     //                         {"ElectricityPriceInflation", "Electricity price inflation"}
            //     //                     },
            //     //                     ShowLegend = false
            //     //                 },
            //     //                 Title = "Sensitivity matrix chart title",
            //     //             }
            //     //         }
            //     //     }
            //     // }
            // };
            //
            // // reportStructure.Sections.Add(new PdfSection()
            // // {
            // //     Name = PdfSectionNameEnum.Title_BatSim_Bliq_NL,
            // //     SectionStyle = PdfSectionStyleEnum.TitlePage,
            // //     Data = new SectionData()
            // //     {
            // //         Parameters = new Dictionary<string, string>()
            // //         {
            // //             {"Header", "Battery advice report"},
            // //             {"Subheader", "Familie van de Poel"},
            // //             {"Date", "22-07-2021"},
            // //         },
            // //         ReportObjects = new List<IReportObject>()
            // //         {
            // //         }
            // //     }
            // // });
            //
            // //serialize report structure to json string
            // string reportStructureJson =  JsonConvert.SerializeObject(reportStructure,
            //     new JsonSerializerSettings()
            //     {
            //         TypeNameHandling = TypeNameHandling.Auto,
            //         NullValueHandling = NullValueHandling.Ignore
            //     });


            // var report = new PdfReportGenerator(reportStructureJson);
            // report.Generate();
            // report.Open();
        }
        
        // [Test]
        // public void PdfReportTest_Bliq_2()
        // {
        //     const string companyName = "Bliq";
        //     string rootPath = AppDomain.CurrentDomain.BaseDirectory;
        //     string resourcesPath = $"{rootPath}Images";
        //     string companyResourcesPath = $"{resourcesPath}\\Companies\\{companyName}";
        //     string companyBackgroundsPath = $"{companyResourcesPath}\\Backgrounds";
        //     string companyIconsPath = $"{companyResourcesPath}\\Icons";
        //
        //     var bliqTemplate = new PdfTemplate()
        //     {
        //         Styles = new List<Style>()
        //         {
        //             //TitlePage header
        //             new Style()
        //             {
        //                 Name = "TitlePageHeader",
        //                 Alignment = AlignmentEnum.Center,
        //                 LineSpace = 1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 36,
        //                     Color = "0,31,78",
        //                     Bold = true
        //                 }
        //             },
        //             //TitlePage subheader
        //             new Style()
        //             {
        //                 Name = "TitlePageSubheader",
        //                 Alignment = AlignmentEnum.Center,
        //                 LineSpace = 1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 16,
        //                     Color = "0,31,78",
        //                 }
        //             },
        //             //Bliq section title
        //             new Style()
        //             {
        //                 Name = "BliqSectionTitle",
        //                 Alignment = AlignmentEnum.Left,
        //                 LineSpace = 1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 26,
        //                     Color = "255,255,255",
        //                     Bold = true
        //                 }
        //             },
        //             //Title
        //             new Style()
        //             {
        //                 Name = StyleEnum.Title.ToStr(),
        //                 Alignment = AlignmentEnum.Left,
        //                 LineSpace = 1,
        //                 SpaceAfter = 0.2,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 16,
        //                     Color = "0,31,78",
        //                     Bold = true
        //                 }
        //             },
        //             //H1
        //             new Style()
        //             {
        //                 Name = StyleEnum.H1.ToStr(),
        //                 Alignment = AlignmentEnum.Left,
        //                 LineSpace = 1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 16,
        //                     Color = "0,31,78",
        //                     Bold = true
        //                 }
        //             },
        //             //H2
        //             new Style()
        //             {
        //                 Name = StyleEnum.H2.ToStr(),
        //                 Alignment = AlignmentEnum.Left,
        //                 LineSpace = 1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 12,
        //                     Color = "0,31,78",
        //                     Bold = true
        //                 }
        //             },
        //             //H3
        //             new Style()
        //             {
        //                 Name = StyleEnum.H3.ToStr(),
        //                 Alignment = AlignmentEnum.Left,
        //                 LineSpace = 1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 10,
        //                     Color = "0,31,78",
        //                     Bold = true
        //                 }
        //             },
        //             //Normal
        //             new Style()
        //             {
        //                 Name = StyleEnum.Normal.ToStr(),
        //                 Alignment = AlignmentEnum.Justify,
        //                 LineSpace = 1.1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 11,
        //                     Color = "0,0,0"
        //
        //                 }
        //             },
        //             //Header
        //             new Style()
        //             {
        //                 Name = StyleEnum.Header.ToStr(),
        //                 Alignment = AlignmentEnum.Justify,
        //                 LineSpace = 1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 10,
        //                     Color = "0,31,78"
        //
        //                 }
        //             },
        //             //Footer
        //             new Style()
        //             {
        //                 Name = StyleEnum.Footer.ToStr(),
        //                 Alignment = AlignmentEnum.Justify,
        //                 LineSpace = 1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 10,
        //                     Color = "0,31,78"
        //
        //                 }
        //             },
        //             //Image title
        //             new Style()
        //             {
        //                 Name = StyleEnum.ImageTitle.ToStr(),
        //                 Alignment = AlignmentEnum.Center,
        //                 LineSpace = 1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 10,
        //                     Color = "0,31,78"
        //
        //                 }
        //             },
        //         },
        //         SectionTypeTemplates = new List<SectionTypeTemplate>()
        //         {
        //             //TitlePage
        //             new SectionTypeTemplate()
        //             {
        //                 Name = PdfSectionType.TitlePage,
        //                 Margins = new Margins()
        //                 {
        //                     Top = 0,
        //                     Bottom = 0,
        //                     Left = 0,
        //                     Right = 0
        //                 },
        //                 BackgroundImage = $"{companyBackgroundsPath}\\TitlePage.png"
        //             },
        //             //Default
        //             new SectionTypeTemplate()
        //             {
        //                 Name = PdfSectionType.Default,
        //                 Margins = new Margins()
        //                 {
        //                     Top = 4.8,
        //                     Bottom = 2.1,
        //                     Left = 2,
        //                     Right = 2.5
        //                 },
        //                 BackgroundImage = $"{companyBackgroundsPath}\\Default.png",
        //                 Title = new Title()
        //                 {
        //                     TitleType = TitleType.BliqDefault
        //                 },
        //                 Footer = new Footer()
        //                 {
        //                     FooterType = FooterType.NoFooter
        //                 },
        //                 Header = new Header()
        //                 {
        //                     HeaderType = HeaderType.NoHeader,
        //                 },
        //             },
        //             //Appendix
        //             new SectionTypeTemplate()
        //             {
        //                 Name = PdfSectionType.Appendix,
        //                 Margins = new Margins()
        //                 {
        //                     Top = 4.8,
        //                     Bottom = 2.1,
        //                     Left = 2,
        //                     Right = 2.5
        //                 },
        //                 BackgroundImage = $"{companyBackgroundsPath}\\Appendix.png",
        //                 Title = new Title()
        //                 {
        //                     TitleType = TitleType.BliqAppendix
        //                 },
        //                 Header = new Header()
        //                 {
        //                     HeaderType = HeaderType.NoHeader,
        //                 },
        //                 Footer = new Footer()
        //                 {
        //                     FooterType = FooterType.NoFooter
        //                 }
        //             },
        //             //Subsection
        //             new SectionTypeTemplate()
        //             {
        //                 Name = PdfSectionType.Subsection,
        //                 Margins = new Margins()
        //                 {
        //                     Top = 4.8,
        //                     Bottom = 2.1,
        //                     Left = 2,
        //                     Right = 2.5
        //                 },
        //                 BackgroundImage = $"{companyBackgroundsPath}\\Appendix.png",
        //                 Title = new Title()
        //                 {
        //                     TitleType = TitleType.BliqSubsection
        //                 },
        //                 Header = new Header()
        //                 {
        //                     HeaderType = HeaderType.NoHeader,
        //                 },
        //                 Footer = new Footer()
        //                 {
        //                     FooterType = FooterType.NoFooter
        //                 }
        //             },
        //         },
        //         GlobalSettings = new GlobalSettings()
        //         {
        //             DecimalSeparator = ",",
        //             ThousandsSeparator = ".",
        //             Variables = new ReportVariables()
        //             {
        //                 AppendixName = "Appendix",
        //                 FigureName = "Figure",
        //                 FigureShortName = "Fig."
        //             }
        //         }
        //     };
        //
        //     var reportStructure = new PdfReportStructure()
        //     {
        //         ReportName = $"{companyName}_report",
        //         OutputFolder = $"{rootPath}\\Reports\\{companyName}",
        //         Template = bliqTemplate,
        //         Sections = new List<PdfSection>()
        //         {
        //             //TitlePage
        //             new PdfSection()
        //             {
        //                 Name = PdfSectionNameEnum.TitlePage,
        //                 Style = PdfSectionType.TitlePage,
        //                 Data = new TitlePageSectionData()
        //                 {
        //                     Header = "Battery advice report",
        //                     Subheader = "Familie van de Poel",
        //                     Date = "22-07-2021"
        //                 }
        //             },
        //             //Sensitivity matrix
        //             new PdfSection()
        //             {
        //                 Name = PdfSectionNameEnum.SensitivityMatrix,
        //                 Style = PdfSectionType.Appendix,
        //                 Data = new SensitivityMatrixSectionData()
        //                 {
        //                     Title = "Sensitivity matrix section",
        //                     Description = "The payback period is the time it takes to return the investment based on the savings obtained by an offered project. The investment is the @color=249,169,173;bold=true{red} (negative) bar in the chart. The @color=111,147,178;bold=true{blue} bars are the annual savings. The cashflow is based on the most optimal case scenario from the simulation.",
        //                     SensitivityMatrixChart = new AbstractChart()
        //                     {
        //                         ChartType = ChartEnum.SensitivityMatrix,
        //                         ChartData = new SensitivityMatrixChartData()
        //                         {
        //                             XAxis = new List<string>(){"1","2","3"},
        //                             YAxis = new List<string>(){"4","5","6"},
        //                             Values = new List<List<double>>()
        //                             {
        //                                 new List<double>(){1,2,1},
        //                                 new List<double>(){1,3,4},
        //                                 new List<double>(){1,5,6}
        //                             }
        //                         },
        //                         ChartSettings = new SensitivityMatrixChartSettings()
        //                         {
        //                             TranslationStrings = new Dictionary<string, string>()
        //                             {
        //                                 {"FeedInInjectionTariff", "Feed-in injection tariff"},
        //                                 {"ElectricityPriceInflation", "Electricity price inflation"}
        //                             },
        //                             ShowLegend = false
        //                         },
        //                         Title = "Sensitivity matrix chart title",
        //                     }
        //                 }
        //             }
        //         }
        //     };
        //
        //     //serialize report structure to json string
        //     string reportStructureJson =  JsonConvert.SerializeObject(reportStructure,
        //         new JsonSerializerSettings()
        //         {
        //             TypeNameHandling = TypeNameHandling.Auto
        //         });
        //     
        //     //chart geenrator
        //     var chartGenerator = new ChartGenerator.ChartGenerator()
        //     {
        //         ChartFolder = $"{rootPath}\\Charts",
        //         Font = FontEnum.Averta,
        //         LangSettings = new Lang(){ThousandsSep = ".", DecimalPoint = ","}
        //     };
        //     
        //     
        //     var report = new PdfReportGenerator(reportStructureJson, chartGenerator);
        //     report.Generate();
        //     report.Open();
        // }
        //
        // [Test]
        // public void PdfReportTest_Ileco_1()
        // {
        //     const string companyName = "iLeco";
        //     string rootPath = AppDomain.CurrentDomain.BaseDirectory;
        //     string resourcesPath = $"{rootPath}Images";
        //     string companyResourcesPath = $"{resourcesPath}\\Companies\\{companyName}";
        //     string companyBackgroundsPath = $"{companyResourcesPath}\\Backgrounds";
        //     string companyIconsPath = $"{companyResourcesPath}\\Icons";
        //     
        //     
        //     var template = new PdfTemplate()
        //     {
        //         Styles = new List<Style>()
        //         {
        //             //TitlePage header
        //             new Style()
        //             {
        //                 Name = StyleEnum.TitlePageHeader.Desc(),
        //                 LineSpace = 1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 28,
        //                     Color = "0,31,78",
        //                     Bold = true
        //                 }
        //             },
        //             //TitlePage subheader
        //             new Style()
        //             {
        //                 Name = StyleEnum.TitlePageSubheader.Desc(),
        //                 LineSpace = 1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 13,
        //                     Color = "0,0,0",
        //                 }
        //             },
        //             //Title
        //             new Style()
        //             {
        //                 Name = StyleEnum.Title.Desc(),
        //                 Alignment = AlignmentEnum.Left,
        //                 LineSpace = 1,
        //                 SpaceAfter = 0.2,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 16,
        //                     Color = "0,0,0",
        //                     Bold = true
        //                 }
        //             },
        //             //H1
        //             new Style()
        //             {
        //                 Name = StyleEnum.H1.Desc(),
        //                 Alignment = AlignmentEnum.Left,
        //                 LineSpace = 1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 16,
        //                     Color = "0,0,0",
        //                     Bold = true
        //                 }
        //             },
        //             //H2
        //             new Style()
        //             {
        //                 Name = StyleEnum.H2.Desc(),
        //                 Alignment = AlignmentEnum.Left,
        //                 LineSpace = 1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 12,
        //                     Color = "0,31,78",
        //                     Bold = true
        //                 }
        //             },
        //             //H3
        //             new Style()
        //             {
        //                 Name = StyleEnum.H3.Desc(),
        //                 Alignment = AlignmentEnum.Left,
        //                 LineSpace = 1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 10,
        //                     Color = "0,31,78",
        //                     Bold = true
        //                 }
        //             },
        //             //Normal
        //             new Style()
        //             {
        //                 Name = StyleEnum.Normal.Desc(),
        //                 Alignment = AlignmentEnum.Justify,
        //                 LineSpace = 1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 10,
        //                     Color = "0,0,0"
        //
        //                 }
        //             },
        //             //Header
        //             new Style()
        //             {
        //                 Name = StyleEnum.Header.Desc(),
        //                 Alignment = AlignmentEnum.Justify,
        //                 LineSpace = 1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 10,
        //                     Color = "0,31,78"
        //
        //                 }
        //             },
        //             //Footer
        //             new Style()
        //             {
        //                 Name = StyleEnum.Footer.Desc(),
        //                 Alignment = AlignmentEnum.Justify,
        //                 LineSpace = 1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 10,
        //                     Color = "0,31,78"
        //
        //                 }
        //             },
        //             //Image title
        //             new Style()
        //             {
        //                 Name = StyleEnum.ImageTitle.ToStr(),
        //                 Alignment = AlignmentEnum.Center,
        //                 LineSpace = 1,
        //                 Font = new Font()
        //                 {
        //                     Name = "averta",
        //                     Size = 10,
        //                     Color = "0,31,78"
        //
        //                 }
        //             },
        //         },
        //         SectionTypeTemplates = new List<SectionTypeTemplate>()
        //         {
        //             //TitlePage
        //             new SectionTypeTemplate()
        //             {
        //                 Name = PdfSectionType.TitlePage,
        //                 Margins = new Margins()
        //                 {
        //                     Top = 2,
        //                     Bottom = 2,
        //                     Left = 2,
        //                     Right = 2
        //                 },
        //                 BackgroundImage = $"{companyBackgroundsPath}\\Default.png"
        //             },
        //             //Default
        //             new SectionTypeTemplate()
        //             {
        //                 Name = PdfSectionType.Default,
        //                 Margins = new Margins()
        //                 {
        //                     Top = 2,
        //                     Bottom = 2,
        //                     Left = 2,
        //                     Right = 2
        //                 },
        //                 BackgroundImage = $"{companyBackgroundsPath}\\Default.png",
        //                 Title = new Title()
        //                 {
        //                     TitleType = TitleType.Default
        //                 },
        //                 Header = new Header()
        //                 {
        //                     HeaderType = HeaderType.NoHeader,
        //                 },
        //                 Footer = new Footer()
        //                 {
        //                     FooterType = FooterType.Default
        //                 }
        //             },
        //             //Appendix
        //             new SectionTypeTemplate()
        //             {
        //                 Name = PdfSectionType.Appendix,
        //                 Margins = new Margins()
        //                 {
        //                     Top = 2,
        //                     Bottom = 2,
        //                     Left = 2,
        //                     Right = 2
        //                 },
        //                 BackgroundImage = $"{companyBackgroundsPath}\\Blank.png",
        //                 Title = new Title()
        //                 {
        //                     TitleType = TitleType.Appendix
        //                 },
        //                 Header = new Header()
        //                 {
        //                     HeaderType = HeaderType.NoHeader,
        //                 },
        //                 Footer = new Footer()
        //                 {
        //                     FooterType = FooterType.Default
        //                 }
        //             },
        //             //Subsection
        //             new SectionTypeTemplate()
        //             {
        //                 Name = PdfSectionType.Subsection,
        //                 Margins = new Margins()
        //                 {
        //                     Top = 2,
        //                     Bottom = 2,
        //                     Left = 2,
        //                     Right = 2
        //                 },
        //                 BackgroundImage = $"{companyBackgroundsPath}\\Blank.png",
        //                 Title = new Title()
        //                 {
        //                     TitleType = TitleType.Subsection
        //                 },
        //                 Header = new Header()
        //                 {
        //                     HeaderType = HeaderType.NoHeader,
        //                 },
        //                 Footer = new Footer()
        //                 {
        //                     FooterType = FooterType.Default
        //                 }
        //             },
        //         },
        //         GlobalSettings = new GlobalSettings()
        //         {
        //             DecimalSeparator = ",",
        //             ThousandsSeparator = ".",
        //             Variables = new ReportVariables()
        //             {
        //                 AppendixName = "Appendix",
        //                 FigureName = "Figure",
        //                 FigureShortName = "Fig."
        //             }
        //         }
        //     };
        //
        //     var reportStructure = new PdfReportStructure()
        //     {
        //         ReportName = $"{companyName}_report",
        //         OutputFolder = $"{rootPath}\\Reports\\{companyName}",
        //         Template = template,
        //         Sections = new List<PdfSection>()
        //         {
        //             //Sensitivity matrix
        //             new PdfSection()
        //             {
        //                 Name = PdfSectionNameEnum.SensitivityMatrix,
        //                 Style = PdfSectionType.Default,
        //                 Data = new SensitivityMatrixSectionData()
        //                 {
        //                     Title = "Sensitivity matrix section",
        //                     Description = "The payback period is the time it takes to return the investment based on the savings obtained by an offered project. The investment is the @color=249,169,173;bold=true{red} (negative) bar in the chart. The @color=111,147,178;bold=true{blue} bars are the annual savings. The cashflow is based on the most optimal case scenario from the simulation.",
        //                     SensitivityMatrixChart = new AbstractChart()
        //                     {
        //                         ChartType = ChartEnum.SensitivityMatrix,
        //                         ChartData = new SensitivityMatrixChartData()
        //                         {
        //                             XAxis = new List<string>(){"1","2","3"},
        //                             YAxis = new List<string>(){"4","5","6"},
        //                             Values = new List<List<double>>()
        //                             {
        //                                 new List<double>(){1,2,1},
        //                                 new List<double>(){1,3,4},
        //                                 new List<double>(){1,5,6}
        //                             }
        //                         },
        //                         ChartSettings = new SensitivityMatrixChartSettings()
        //                         {
        //                             TranslationStrings = new Dictionary<string, string>()
        //                             {
        //                                 {"FeedInInjectionTariff", "Feed-in injection tariff"},
        //                                 {"ElectricityPriceInflation", "Electricity price inflation"}
        //                             },
        //                             ShowLegend = false
        //                         },
        //                         Title = "Sensitivity matrix chart title",
        //                     }
        //                 }
        //             }
        //         }
        //     };
        //     
        //     //serialize report structure to json string
        //     string reportStructureJson =  JsonConvert.SerializeObject(reportStructure,
        //         new JsonSerializerSettings()
        //         {
        //             TypeNameHandling = TypeNameHandling.Auto
        //         });
        //     
        //     //chart generator
        //     var chartGenerator = new ChartGenerator.ChartGenerator()
        //     {
        //         ChartFolder = $"{rootPath}\\Charts",
        //         Font = FontEnum.Averta,
        //         LangSettings = new Lang(){ThousandsSep = ".", DecimalPoint = ","}
        //     };
        //     
        //     
        //     var report = new PdfReportGenerator(reportStructureJson, chartGenerator);
        //     report.Generate();
        //     report.Open();
        // }
        
        [Test]
        public void PdfReportTest_Jabba_FromClass()
        {
            const string companyName = "Jabba";
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            string resourcesPath = $"{rootPath}Images";
            string companyResourcesPath = $"{resourcesPath}\\Companies\\{companyName}";
            string companyBackgroundsPath = $"{companyResourcesPath}\\Backgrounds";
            string companyIconsPath = $"{companyResourcesPath}\\Icons";
            string reportTestsPath = $"{rootPath}ReportTests\\PdfReportTests";
            string testDataPath = $"{reportTestsPath}\\TestData";
            
            
            // var template = new PdfTemplate()
            // {
            //     Styles = new List<Style>()
            //     {
            //         //TitlePage header
            //         new Style()
            //         {
            //             Name = StyleEnum.TitlePageHeader.Desc(),
            //             LineSpace = 1,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 28,
            //                 Color = "0,0,0",
            //                 Bold = true
            //             }
            //         },
            //         //TitlePage subheader
            //         new Style()
            //         {
            //             Name = StyleEnum.TitlePageSubheader.Desc(),
            //             LineSpace = 1,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 12,
            //                 Color = "159, 204, 59",
            //                 Bold = true
            //             }
            //         },
            //         //Title
            //         new Style()
            //         {
            //             Name = StyleEnum.Title.Desc(),
            //             Alignment = AlignmentEnum.Left,
            //             LineSpace = 1,
            //             SpaceAfter = 0.2,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 16,
            //                 Color = "0,0,0",
            //                 Bold = true
            //             }
            //         },
            //         //H1
            //         new Style()
            //         {
            //             Name = StyleEnum.H1.Desc(),
            //             Alignment = AlignmentEnum.Left,
            //             LineSpace = 1,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 16,
            //                 Color = "0,0,0",
            //                 Bold = true
            //             }
            //         },
            //         //H2
            //         new Style()
            //         {
            //             Name = StyleEnum.H2.Desc(),
            //             Alignment = AlignmentEnum.Left,
            //             LineSpace = 1,
            //             SpaceAfter = 0.2,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 12,
            //                 Color = "159, 204, 59",
            //                 Bold = true
            //             }
            //         },
            //         //H3
            //         new Style()
            //         {
            //             Name = StyleEnum.H3.Desc(),
            //             Alignment = AlignmentEnum.Left,
            //             LineSpace = 1,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 10,
            //                 Color = "0,31,78",
            //                 Bold = true
            //             }
            //         },
            //         //Normal
            //         new Style()
            //         {
            //             Name = StyleEnum.Normal.Desc(),
            //             Alignment = AlignmentEnum.Justify,
            //             LineSpace = 1,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 11,
            //                 Color = "0,0,0"
            //
            //             }
            //         },
            //         //Header
            //         new Style()
            //         {
            //             Name = StyleEnum.Header.Desc(),
            //             Alignment = AlignmentEnum.Justify,
            //             LineSpace = 1,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 10,
            //                 Color = "0,31,78"
            //
            //             }
            //         },
            //         //Footer
            //         new Style()
            //         {
            //             Name = StyleEnum.Footer.Desc(),
            //             Alignment = AlignmentEnum.Right,
            //             LineSpace = 1,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 10,
            //                 Color = "128, 128, 128"
            //             }
            //         },
            //         //Image
            //         new Style()
            //         {
            //             Name = StyleEnum.Image.Desc(),
            //             Alignment = AlignmentEnum.Center
            //         },
            //         //Image title
            //         new Style()
            //         {
            //             Name = StyleEnum.ImageTitle.Desc(),
            //             Alignment = AlignmentEnum.Center,
            //             LineSpace = 1,
            //             Font = new Font()
            //             {
            //                 Name = "averta",
            //                 Size = 10,
            //                 Color = "0,31,78"
            //
            //             }
            //         },
            //     },
            //     SectionTypeTemplates = new List<SectionTypeTemplate>()
            //     {
            //         //Title page
            //         new SectionTypeTemplate()
            //         {
            //             Name = PdfSectionStyleEnum.TitlePage,
            //             Margins = new Margins()
            //             {
            //                 Top = 2,
            //                 Bottom = 2,
            //                 Left = 2.5,
            //                 Right = 2.5
            //             },
            //             BackgroundImage = $"{companyBackgroundsPath}\\Default.png",
            //             Title = new Title()
            //             {
            //                 TitleType = TitleType.NoTitle
            //             },
            //             Header = new Header()
            //             {
            //                 HeaderType = HeaderType.NoHeader,
            //             },
            //             Footer = new Footer()
            //             {
            //                 FooterType = FooterType.JabbaStyle,
            //                 Copyright = "© Jabba.energy"
            //             }
            //         },
            //         //Default
            //         new SectionTypeTemplate()
            //         {
            //             Name = PdfSectionStyleEnum.Default,
            //             Margins = new Margins()
            //             {
            //                 Top = 2,
            //                 Bottom = 2,
            //                 Left = 2.5,
            //                 Right = 2.5
            //             },
            //             BackgroundImage = $"{companyBackgroundsPath}\\Default.png",
            //             Title = new Title()
            //             {
            //                 TitleType = TitleType.Default
            //             },
            //             Header = new Header()
            //             {
            //                 HeaderType = HeaderType.NoHeader,
            //             },
            //             Footer = new Footer()
            //             {
            //                 FooterType = FooterType.JabbaStyle,
            //                 Copyright = "© Jabba.energy"
            //             }
            //         },
            //         
            //     },
            //     GlobalSettings = new GlobalSettings()
            //     {
            //         DecimalSeparator = ",",
            //         ThousandsSeparator = ".",
            //         ChartGeneratorSettings = new ChartGeneratorSettings()
            //         {
            //             ChartFolder = $"{rootPath}\\Charts",
            //             Font = FontEnum.Averta,
            //             GlobalSettings = new Global(),
            //             LangSettings = new Lang(){ThousandsSep = " ", DecimalPoint = ","}
            //         }
            //     }
            // };
            //
            // var reportStructure = new PdfReportModel()
            // {
            //     ReportName = $"{companyName}_report",
            //     OutputFolder = $"{rootPath}\\Reports\\{companyName}",
            //     Template = template,
            //     Sections = new List<ISection>()
            // };


            // #region Sections
            //
            // #region Executive summary
            //
            // //Executive summary
            // reportStructure.Sections.Add(new PdfSection()
            // {
            //     Name = PdfSectionNameEnum.ExecSum_AlgoComp_Jabba,
            //     SectionStyle = PdfSectionStyleEnum.TitlePage,
            //     Data = new SectionData()
            //     {
            //         ReportObjects = new List<IReportObject>()
            //         {
            //             new BaseReportTitle()
            //             {
            //                 Name = "ReportTitle",
            //                 ReportHeader = "SIMULATIERAPPORT",
            //                 ReportSubheader = "Capaciteitstarief verminderen met Smart Peak Shaving",
            //                 LogoImgPath = $"{companyResourcesPath}\\logo.png"
            //             },
            //             new BaseBasicInfo()
            //             {
            //                 Name = "BasicInfo",
            //                 Title = "BASISGEGEVENS",
            //                 Values = new List<KeyValuePair<string, string>>()
            //                 {
            //                     new KeyValuePair<string, string>
            //                         ("Gebouw", "Jabba 01"),
            //                     
            //                     new KeyValuePair<string, string>
            //                         ("Gebruiker", "jef_noelmans@hotmail.com"),
            //                     
            //                     new KeyValuePair<string, string>
            //                         ("Rapport datum", "01/09/2021"),
            //                     
            //                     new KeyValuePair<string, string>
            //                         ("Simulatie periode", "01/08/2021 - 31/08/2021"),
            //                     
            //                     new KeyValuePair<string, string>
            //                         ("Aantal gesimuleerde dagen", "31"),
            //                     
            //                     new KeyValuePair<string, string>
            //                         ("Batterij model", "Alpha ESS Smile 5"),
            //                     
            //                     new KeyValuePair<string, string>
            //                         ("Opslagcapaciteit", "11.5 kWh"),
            //                 }
            //             },
            //             new ReportParagraph()
            //             {
            //                 Name = "Desc1",
            //                 Text = "Upgraden naar Smart Peak Shaving zou over de gesimuleerde periode een {b}bijkomende besparing van € 18,4 / maand opleveren.{/b} Wil je weten hoe? In dit rapport vind je de gedetailleerde uitleg."
            //             },
            //             new ReportParagraph()
            //             {
            //                 Name = "Desc2",
            //                 Text = "{b}Jouw AlphaESS thuisbatterij is hier volledig klaar voor.{/b} Wanneer het capaciteitstarief effectief ingevoerd wordt, kan je je inschrijven voor de Smart Peak Shaving service van Jabba energy."
            //             },
            //             new ReportParagraph()
            //             {
            //                 Name = "PeakShavingExpl",
            //                 Title = "CASE VOOR SMART PEAK SHAVING",
            //                 ChildObjects = new List<IReportObject>()
            //                 {
            //                     new ReportParagraph()
            //                     {
            //                         Name = "CapacityTariffExpl",
            //                         Title = "Invoering capaciteitstarief",
            //                         ChildObjects = new List<IReportObject>()
            //                         {
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "Distributienetten zullen in de toekomst meer en anders gebruikt worden, mede door meer {b}lokale hernieuwbare energie{/b}, meer elektrische voertuigen en meer warmtepompen. Daarnaast zullen ze blootgesteld worden aan grotere, gelijktijdige piekbelastingen"
            //                             },
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "Die piekbelastingen kunnen ertoe leiden dat de distributienetbeheerders {b}zware investeringen moeten doen om het net betrouwbaar te houden{/b}, waardoor de  distributienettarieven sterk kunnen toenemen. Om dit te vermijden, willen de  netbeheerders gezinnen en bedrijven bewust maken dat hoge pieken in hun verbruik  extra kosten voor het net met zich kunnen meebrengen en hen aanmoedigen om het net  efficiënter te gebruiken."
            //                             },
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "De distributienettarieven zullen daarom vanaf medio 2022 deels aangerekend worden via een {b}capaciteitstarief{/b}."
            //                             }
            //                         }
            //                     },
            //                     new ReportParagraph()
            //                     {
            //                         Name = "NetCostExpl",
            //                         Title = "Netkosten",
            //                         ChildObjects = new List<IReportObject>()
            //                         {
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "De elektriciteitsfactuur bestaat uit verschillende onderdelen. De distributienettarieven zijn de tarieven die je betaalt om energie tot bij jouw thuis of tot bij jouw onderneming of organisatie te krijgen. Iedereen die aangesloten is op het distributienet voor elektriciteit betaalt distributienettarieven aan Fluvius."
            //                             },
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "Een deel van die distributienettarieven dekken de netkosten. Dat zijn de kosten voor het aanleggen, onderhouden en beheren van de netten en het vervoer van elektriciteit. Het zijn op deze netkosten dat het capaciteitstarief wordt toegepast."
            //                             },
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "Voor een gemiddeld gezin omvatten deze kosten {b}ongeveer 21% van de huidige elektriciteitsfactuur{\b}."
            //                             },
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "Het capaciteitstarief is dus geen extra tarief, maar een andere manier van aanrekenen. Het merendeel van de elektriciteitsfactuur blijft ook na invoering van het capaciteitstarief kWh-gebaseerd. Zuinig omgaan met elektriciteit blijft dus lonen."
            //                             },
            //                             new Image()
            //                             {
            //                                 Name = "costDistribution",
            //                                 Path = $"{companyResourcesPath}\\costDistribution.png",
            //                             }
            //                         }
            //                     },
            //                     new ReportParagraph()
            //                     {
            //                         Name = "AddCostExpl",
            //                         Title = "Meerkost",
            //                         ChildObjects = new List<IReportObject>()
            //                         {
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "Het capaciteitstarief wordt aangerekend op basis van de {b}‘gemiddelde maandpiek’{/b} (kW)."
            //                             },
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "Iedere maand wordt het hoogste kwartiervermogen (ofwel ‘piekvermogen’) gemeten, het kwartier waarin het hoogste gemiddelde vermogen wordt gevraagd van het net."
            //                             },
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "Dat wil zeggen dat als je de hele maand zuinig bent, maar op een bepaald moment een aantal verschillende toestellen tegelijk laat draaien, het piekvermogen voor die maand  toch hoog kan liggen. Dit kan dan wel worden uitgebalanceerd in de andere maanden,  want het gemiddelde van de 12 maandpieken bepaalt hoeveel capaciteitstarief iemand  in een jaar moet betalen."
            //                             },
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "Dit wordt geregistreerd door de digitale meter. Het maakt hierbij niet uit hoe vaak – tijdens 1 of meerdere kwartieren – je dit piekvermogen hebt gebruikt. Als er nog geen  meetgegevens van 12 maanden beschikbaar zijn, bv. na de vervanging van een klassieke  meter door een digitale meter, wordt de gemiddelde maandpiek berekend op basis van  alle beschikbare maandpieken."
            //                             },
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "Wanneer een maandpiek kleiner is dan 2,5 kW, wordt voor die maand een {b}minimumwaarde van 2,5 kW{/b} verondersteld. Hierdoor zal iedereen een minimale  jaarlijkse bijdrage betalen in de netkosten. Deze bijdrage is gelijk aan 2,5 kW  vermenigvuldigd met het tarief voor de gemiddelde maandpiek."
            //                             },
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "Voor de duidelijkheid: het kwartiervermogen is het gemiddelde vermogen over een kwartier. Dus wanneer je tijdens een kwartier de eerste vijf minuten 10 kW verbruikt, en  vervolgens 10 minuten aan 5 kW verbruikt, is je kwartierpiek gelijk aan 6,7 kW."
            //                             },
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "Het exacte tarief is {b}momenteel nog niet vastgelegd, maar momenteel circuleert het bedrag van €4 per maand per kW boven de 2,5 kW{/b}. Dus voor een maandpiek van 10 kW  zou je 10 – 2,5 = 7,5 kW x €4 / kW, oftewel 30 EUR per maand extra betalen."
            //                             }
            //                         }
            //                     },
            //                     new ReportParagraph()
            //                     {
            //                         Name = "SmartPeakShavingExpl",
            //                         Title = "Smart Peak Shaving",
            //                         ChildObjects = new List<IReportObject>()
            //                         {
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "Wat kan je doen om extra kosten van de piekbelasting te vermijden? Je kan natuurlijk je gedrag gaan wijzigen en het gebruik van energieverslinders zo veel mogelijk spreiden, zodat je {b}pieken verminderen{/b}."
            //                             },
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "Dit kan vaak (semi) geautomatiseerd en zonder dat je aan comfort moet inboeten. Bijvoorbeeld door het laadvermogen van het laadpunt van je elektrische wagen zo laag mogelijk in te stellen, maar nog net hoog genoeg zodat je wagen ’s morgens weer volgeladen is. Of door de startuitstel-functie van je vaatwasser zo te programmeren dat je toestel geactiveerd wordt wanneer je zonnepanelen goed produceren."
            //                             },
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "Een andere optie is natuurlijk om piekbelastingen (deels) met je thuisbatterij op te gaan vangen. Hierdoor zal je je piekverbruik afvlakken. Dit noemen we {b}‘peak shaving’{/b}."
            //                             },
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "Smart peak shaving is natuurlijk wel belangrijk, zodat je thuisbatterij niet domweg onmiddellijk en altijd gaat ingrijpen. Je riskeert dan bijvoorbeeld dat je thuisbatterij al leeg is net op het moment dat de piek die er die maand toe gaat doen eraan komt."
            //                             },
            //                             new ReportParagraph()
            //                             {
            //                                 Text = "Het inzetten van je thuisbatterij voor peak shaving heeft een kostprijs, dus elke beslissing van je batterij moet weloverwogen zijn. De smart peak shaving functie van het Jabba platform zal op ieder moment de afweging maken: is het zinvol om een Wh uit je thuisbatterij in te zetten om een piek af te vlakken, of is het beter diezelfde Wh op te sparen om later in te zetten voor een grotere piek of om je zelfconsumptie te verhogen?"
            //                             }
            //                         }
            //                     }
            //                 }
            //             },
            //         }
            //         
            //     }
            // });
            //
            // #endregion
            //
            // #region Peak shaving comparison
            //
            // //Peak shaving comparison
            //
            // //grid power test data
            // var csvReader = new AlgoCompJabbaCsvReader();
            // var gridPowerData = csvReader.GetGridPowerDataModels($"{testDataPath}\\GridPowerTestData.csv");
            //
            // reportStructure.Sections.Add(new PdfSection()
            // {
            //     Name = PdfSectionNameEnum.PeakShavingComparison_AlgoComp_Jabba,
            //     SectionStyle = PdfSectionStyleEnum.Default,
            //     Data = new SectionData()
            //     {
            //         Title = "SIMULATIE",
            //         ReportObjects = new List<IReportObject>()
            //         {
            //             // //Ref case
            //             // new ReportParagraph()
            //             // {
            //             //     Name = "RefCase",
            //             //     Title = "Referentiecase",
            //             //     ChildObjects = new List<IReportObject>()
            //             //     {
            //             //         new ReportParagraph()
            //             //         {
            //             //             Text = "Je thuisbatterij draait op het standaard algoritme van optimalisatie van de zelfconsumptie. Dit neemt niet weg dat er hier en daar al aan peak shaving wordt gedaan. Op het moment dat je zonnepanelen produceren worden de verbuikers in je huis gedekt. Enkel wanneer er meer vermogen gevraagd wordt dan de productie wordt er energie uit het net betrokken en kan er een piek optreden. Eventueel gaat je thuisbatterij op die momenten nog eerst bijspringen."
            //             //         },
            //             //         new BaseChart()
            //             //         {
            //             //             Name = "PeakShavingRef",
            //             //             Tag = "Ref",
            //             //             ChartType = ChartEnum.PeakShavingMonth,
            //             //             ChartData = new PeakShavingMonthChartData()
            //             //             {
            //             //                 GridPower =
            //             //                     gridPowerData
            //             //                         .GroupBy(x => new
            //             //                         {
            //             //                             x.DateTime.Year, x.DateTime.Month
            //             //                         })
            //             //                         .First()
            //             //                         .Select(x => new DateTimeSeries()
            //             //                         {
            //             //                             DateTime = x.DateTime,
            //             //                             Value = x.Value.Value / 1000
            //             //                         }).ToList()
            //             //             },
            //             //             ChartSettings = new PeakShavingMonthChartSettings()
            //             //             {
            //             //                 Color = Color.FromArgb(143, 180, 119),
            //             //                 YMax = gridPowerData.Select(x => x.Value).Max().Value / 1000,
            //             //                 TranslationStrings = new Dictionary<string, string>()
            //             //                 {
            //             //                     {"GridPower", "Net aankoop"},
            //             //                     {"MonthPeak", "Gemiddelde maandpiek"}
            //             //                 }
            //             //             }
            //             //         },
            //             //         new ReportParagraph()
            //             //         {
            //             //             Text = "Je hoogste gemiddelde maandpiek bedroeg 4,5 kW, en kwam voor op 27/09/2021 tussen 14:00 en 14:15."
            //             //         },
            //             //         new ReportParagraph()
            //             //         {
            //             //             Text = "Dit betekent een capaciteitstarief voor de simulatieperiode van €8/maand."
            //             //         },
            //             //         
            //             //     }
            //             // },
            //             // //Best case
            //             // new ReportParagraph()
            //             // {
            //             //     Name = "BestCase",
            //             //     Title = "Optimalisatie",
            //             //     ChildObjects = new List<IReportObject>()
            //             //     {
            //             //         new ReportParagraph()
            //             //         {
            //             //             Text = "Je installatie wordt gestuurd volgens het slimme Jabba-algoritme."
            //             //         },
            //             //         new BaseChart()
            //             //         {
            //             //             Name = "PeakShavingBest",
            //             //             Tag = "Best",
            //             //             ChartType = ChartEnum.PeakShavingMonth,
            //             //             ChartData = new PeakShavingMonthChartData()
            //             //             {
            //             //                 GridPower =
            //             //                     gridPowerData
            //             //                         .GroupBy(x => new
            //             //                         {
            //             //                             x.DateTime.Year, x.DateTime.Month
            //             //                         })
            //             //                         .First()
            //             //                         .Select(x => new DateTimeSeries()
            //             //                         {
            //             //                             DateTime = x.DateTime,
            //             //                             Value = x.Value.Value / 1000
            //             //                         }).ToList()
            //             //             },
            //             //             ChartSettings = new PeakShavingMonthChartSettings()
            //             //             {
            //             //                 Color = Color.FromArgb(228, 191, 102),
            //             //                 YMax = gridPowerData.Select(x => x.Value).Max().Value / 1000,
            //             //                 TranslationStrings = new Dictionary<string, string>()
            //             //                 {
            //             //                     {"GridPower", "Net aankoop"},
            //             //                     {"MonthPeak", "Gemiddelde maandpiek"}
            //             //                 }
            //             //             }
            //             //         },
            //             //         new ReportParagraph()
            //             //         {
            //             //             Text = "Je gemiddelde maandpiek zou nu 2,8 kW bedragen."
            //             //         },
            //             //         new ReportParagraph()
            //             //         {
            //             //             Text = "Dit betekent een capaciteitstarief voor de simulatieperiode van €1,2/maand. Dat is een {b}bijkomende besparing van €6,8/maand{/b} over de simulatieperiode van één maand dankzij het slimme Jabba-algoritme. Dus extra bovenop de ‘gewone’ besparingen die je nog steeds reaiiseert met je AlphaESS thuisbatterij door het verhogen van je netonafhankelijkheid."
            //             //         },
            //             //         
            //             //     }
            //             // }
            //         }
            //     }
            // });
            //
            // #endregion
            //
            // #region Conclusion
            //
            // reportStructure.Sections.Add(new PdfSection()
            // {
            //     Name = PdfSectionNameEnum.Conclusion_AlgoComp_Jabba,
            //     SectionStyle = PdfSectionStyleEnum.Default,
            //     Data = new SectionData()
            //     {
            //         Title = "CONCLUSIE",
            //         ReportObjects = new List<IReportObject>()
            //         {
            //             new ReportParagraph()
            //             {
            //                 Text = "Met het Smart Peak Shaving algoritme van Jabba zou je over de gesimuleerde periode van één maand een {b}bijkomende besparing van €6,8/maand{\b} realiseren."
            //             },
            //             new ReportParagraph()
            //             {
            //                 Text = "Jouw AlphaESS thuisbatterij is hier volledig klaar voor. Wanneer het capaciteitstarief effectief ingevoerd wordt, kan je je inschrijven voor de Smart Peak Shaving service van Jabba energy."
            //             },
            //         }
            //     }
            // });
            //
            // #endregion
            //
            // #region Disclaimer
            //
            // reportStructure.Sections.Add(new PdfSection()
            // {
            //     Name = PdfSectionNameEnum.Disclaimer_AlgoComp_Jabba,
            //     SectionStyle = PdfSectionStyleEnum.Default,
            //     Data = new SectionData()
            //     {
            //         Title = "DISCLAIMER",   
            //         ReportObjects = new List<IReportObject>()
            //         {
            //             new ReportParagraph()
            //             {
            //                 Text = "De resultaten van deze simulatie zijn louter informatief en hebben geen juridische bewijskracht. Onjuist gebruik van verkeerde gegevens, gewijzigde parameters en wijzigingen in uw verbruiksprofiel kunnen zorgen voor een simulatieresultaat dat uiteindelijk zal verschillen van uw toekomstige factuur."
            //             }
            //         }
            //     }
            // });
            //
            // #endregion
            //
            // #endregion
            
            
            
            
            // //serialize report structure to json string
            // string reportStructureJson =  JsonConvert.SerializeObject(reportStructure,
            //     new JsonSerializerSettings()
            //     {
            //         TypeNameHandling = TypeNameHandling.Auto,
            //         NullValueHandling = NullValueHandling.Ignore
            //     });
            //
            // File.WriteAllText($"{rootPath}ReportTests\\PdfReportTests\\TestData\\PdfTemplates\\Pdf_Jabba_1.json",
            //     reportStructureJson);


            // var report = new PdfReportGenerator(reportStructureJson);
            // report.Generate();
            // report.Open();
        }

        [Test]
        public void PdfReportTest_Jabba_FromJson()
        {
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            
            var reportStructureJson = File.ReadAllText(
                $"{rootPath}\\ReportTests\\PdfReportTests\\TestData\\PdfTemplates\\Pdf_Jabba_1.json");
            
            
            // var report = new PdfReportGenerator(reportStructureJson);
            // report.Generate();
            // report.Open();
        }
    }
}