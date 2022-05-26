using System;
using System.Collections.Generic;
using System.Linq;
using MigraDoc.DocumentObjectModel;
using ReportingFramework.Common.Extentions;
using ReportingFramework.Common.Template.Style;
using ReportingFramework.Dto;
using Style = ReportingFramework.Dto.Style;

namespace ReportingFramework.Extentions
{
    public static class SectionExtensions
    {
        // public static MigraDoc.DocumentObjectModel.Section CreateSection(
        //     this PdfSection pdfSectionData,
        //     PdfTemplate documentTemplate,
        //     ref ReportSettings reportSettings,
        //     IChartGenerator chartGenerator,
        //     ReportPaths paths)
        // {
        //     Section section = new MigraDoc.DocumentObjectModel.Section();
        //     SectionTypeTemplate sectionTemplate = GetTemplateBySectionType(documentTemplate.SectionTypeTemplates,
        //         pdfSectionData.SectionStyle);
        //     List<Style> reportStyles = documentTemplate.Styles;
        //     //PdfReportSection pdfReportSection = PdfSectionHelperHelper.GetSectionHelper(pdfSectionData);
        //
        //     paths = SectionHelper.SetPathsForSection(paths, pdfSectionData.Name.Desc(), pdfSectionData.Version);
        //
        //     // generate section content
        //     var resParams = new ResourceParameters()
        //     {
        //         Paths = paths,
        //         CultureInfo = new CultureInfo(documentTemplate.GlobalSettings.Language)
        //     };
        //     SetBackgroundImage(section, $"{paths.CompanyBackgrounds}/{sectionTemplate.BackgroundImage}");
        //     SetMargins(section, sectionTemplate.Margins);
        //     SetHeader(section, sectionTemplate.Header, GetParagraphFormat(reportStyles, StyleEnum.Header));
        //     SetFooter(section, sectionTemplate.Footer, GetParagraphFormat(reportStyles, StyleEnum.Footer), sectionTemplate, paths);
        //     //SetTitle(section, sectionTemplate.Title, reportStyles, pdfSectionData, documentTemplate, resParams, ref reportSettings);
        //     
        //     
        //     // pdfReportSection.Init(new PdfSectionParameters()
        //     // {
        //     //     Section = section,
        //     //     AbstractSection = pdfSectionData,
        //     //     Template = documentTemplate,
        //     //     ReportSettings = reportSettings,
        //     //     ChartGeneratorClient = chartGenerator,
        //     //     ResourceParameters = resParams,
        //     //     Paths = paths,
        //     //     NumFmtr = new NumberFormatter()
        //     //     {
        //     //         NullValue = "-",
        //     //         DecimalSeparator = documentTemplate.GlobalSettings.DecimalSeparator,
        //     //         GroupSeparator = documentTemplate.GlobalSettings.ThousandsSeparator
        //     //     }
        //     // });
        //     // pdfReportSection.Generate();
        //     
        //     return section;
        // }
        //
        // private static SectionTypeTemplate GetTemplateBySectionType(
        //     List<SectionTypeTemplate> sectionTypeTemplates,
        //     PdfSectionStyleEnum pdfSectionStyleEnum)
        // {
        //     SectionTypeTemplate result = sectionTypeTemplates.First(x => x.Name == pdfSectionStyleEnum);
        //     if (result == null)
        //     {
        //         throw new Exception($"No such a template in the list: {pdfSectionStyleEnum.Desc()}");
        //     }
        //
        //     return result;
        // }
        //
        public static ParagraphFormat GetParagraphFormat(List<Style> styles, string style)
        {
            return GetStyle(styles, style).ToParagraphFormat();
        }
        
        public static ParagraphFormat GetParagraphFormat(List<Style> styles, StyleEnum style)
        {
            return GetStyle(styles, style.Desc()).ToParagraphFormat();
        }
        
        public static Style GetStyle(List<Style> styles, StyleEnum style)
        {
            return GetStyle(styles, style.Desc());
        }
        
        public static Style GetStyle(List<Style> styles, string style)
        {
            try
            {
                return styles.First(x => x.Name == style);
            }
            catch (Exception e)
            {
                throw new Exception("GetStyle error");
            }
        }
        //
        // private static void SetBackgroundImage(MigraDoc.DocumentObjectModel.Section section, string imagePath)
        // {
        //     if (imagePath == null)
        //     {
        //         return;
        //     }
        //     
        //     TextFrame frame;
        //     Image img;
        //     frame = section.Headers.Primary.AddTextFrame();
        //     frame.RelativeHorizontal = RelativeHorizontal.Page;
        //     frame.RelativeVertical = RelativeVertical.Page;
        //     frame.WrapFormat = new WrapFormat()
        //     {
        //         Style = WrapStyle.Through,
        //         DistanceTop = "0cm",
        //         DistanceLeft = "0cm"
        //     };
        //     img = frame.AddImage(imagePath);
        //     img.Height = section.PageSetup.PageHeight;
        //     img.Width = section.PageSetup.PageWidth;
        //     img.RelativeVertical = RelativeVertical.Page;
        //     img.RelativeHorizontal = RelativeHorizontal.Page;
        //     img.WrapFormat.Style = WrapStyle.Through;
        // }
        //
        // private static void SetMargins(MigraDoc.DocumentObjectModel.Section section, Margins margins)
        // {
        //     if (margins == null)
        //     {
        //         return;
        //     }
        //
        //     try
        //     {
        //         section.PageSetup = new Document().DefaultPageSetup.Clone();
        //         section.PageSetup.LeftMargin = new Unit(margins.Left, UnitType.Centimeter);
        //         section.PageSetup.RightMargin = new Unit(margins.Right, UnitType.Centimeter);
        //         section.PageSetup.BottomMargin = new Unit(margins.Bottom, UnitType.Centimeter);
        //         section.PageSetup.TopMargin = new Unit(margins.Top, UnitType.Centimeter);
        //     }
        //     catch (Exception e)
        //     {
        //         throw new Exception("Set margins error");
        //     }
        // }
        //
        // private static void SetFooter(
        //     MigraDoc.DocumentObjectModel.Section section,
        //     Footer footer,
        //     ParagraphFormat footerStyle,
        //     SectionTypeTemplate sectionTypeTemplate,
        //     ReportPaths reportPaths)
        // {
        //     if (footer == null)
        //     {
        //         return;
        //     }
        //     
        //     Paragraph par;
        //     Column col;
        //     Row row;
        //     Image img;
        //     Table footerTable;
        //     float sectionWidth = section.PageSetup.PageWidth - section.PageSetup.LeftMargin - section.PageSetup.RightMargin;
        //     float columnWidth;
        //     try
        //     {
        //         switch (footer.FooterType)
        //         {
        //             case FooterType.NoFooter:
        //                 section.Footers.Primary = new HeaderFooter();
        //                 break;
        //             case FooterType.Default:
        //                 columnWidth = sectionWidth;
        //                 footerTable = new Table();
        //                 footerTable.Borders.Top.Color = Colors.Black;
        //                 col = footerTable.AddColumn();
        //                 col.Width = columnWidth;
        //                 row = footerTable.AddRow();
        //                 par = new Paragraph();
        //                 par.Format = footerStyle.Clone();
        //                 par.AddPageField();
        //                 par.AddText("/");
        //                 par.AddNumPagesField();
        //                 row.Cells[0].Add(par);
        //                 row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
        //                 section.Footers.Primary.Add(footerTable.Clone());
        //                 break;
        //             case FooterType.JabbaStyle:
        //                 columnWidth = sectionWidth;
        //                 footerTable = new Table();
        //                 col = footerTable.AddColumn();
        //                 col.Width = columnWidth;
        //                 row = footerTable.AddRow();
        //                 par = new Paragraph();
        //                 par.Format = footerStyle.Clone();
        //                 par.AddText("p.");
        //                 par.AddPageField();
        //                 par.AddText($" {footer.Copyright} {DateTime.Now.Year}");
        //                 row.Cells[0].Add(par);
        //                 row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
        //                 section.Footers.Primary.Add(footerTable.Clone());
        //                 break;
        //             case FooterType.BliqStyle:
        //                 columnWidth = sectionWidth;
        //                 footerTable = new Table();
        //                 //footerTable.Borders.Color = Colors.Black;
        //                 col = footerTable.AddColumn();
        //                 col.Width = columnWidth;
        //                 row = footerTable.AddRow();
        //                 row.Height = new Unit(1, UnitType.Centimeter);
        //                 row.VerticalAlignment = VerticalAlignment.Center;
        //                 par = new Paragraph();
        //                 par.Format = footerStyle.Clone();
        //                 par.Format.LeftIndent = new Unit(0.7, UnitType.Centimeter);
        //                 par.AddText($"© {DateTime.Now.Year} {footer.Copyright}");
        //                 row.Cells[0].Add(par);
        //                 row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
        //                 section.Footers.Primary.Add(footerTable.Clone());
        //                 section.PageSetup.FooterDistance = new Unit(0.57, UnitType.Centimeter);
        //                 break;
        //             case FooterType.NumberAndCopyright:
        //                 columnWidth = sectionWidth / 2;
        //                 footerTable = new Table();
        //                 footerTable.Borders.Top.Color = Colors.Black;
        //                 
        //                 col = footerTable.AddColumn();
        //                 col.Width = columnWidth;
        //                 
        //                 col = footerTable.AddColumn();
        //                 col.Width = columnWidth;
        //                 
        //                 row = footerTable.AddRow();
        //                 row.TopPadding = new Unit(0.1, UnitType.Centimeter);
        //                 
        //                 //logo
        //                 par = new Paragraph();
        //                 par.Format = footerStyle.Clone();
        //                 par.Format.Alignment = ParagraphAlignment.Left;
        //                 img = par.AddImage($"{reportPaths.CommonResourcesLogos}/{footer.Logo}");
        //                 img.Height = new Unit(0.5, UnitType.Centimeter);
        //                 img.LockAspectRatio = true;
        //                 row.Cells[0].Add(par);
        //                 row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
        //                 
        //                 //pages
        //                 par = new Paragraph();
        //                 par.Format = footerStyle.Clone();
        //                 par.Format.Alignment = ParagraphAlignment.Right;
        //                 par.AddPageField();
        //                 par.AddText("/");
        //                 par.AddNumPagesField();
        //                 row.Cells[1].Add(par);
        //                 row.Cells[1].Format.Alignment = ParagraphAlignment.Right;
        //                 
        //                 
        //                 section.Footers.Primary.Add(footerTable.Clone());
        //                 break;
        //             
        //             default:
        //                 throw new Exception();
        //         }
        //     }
        //     catch (Exception e)
        //     {
        //         throw new Exception("SetFooter error");
        //     }
        // }
        //
        // private static void SetHeader(MigraDoc.DocumentObjectModel.Section section, Header header, ParagraphFormat headerStyle)
        // {
        //     if (header == null)
        //     {
        //         return;
        //     }
        //
        //     TextFrame frame;
        //     Paragraph par;
        //     Image img;
        //     try
        //     {
        //         switch (header.HeaderType)
        //         {
        //             case HeaderType.NoHeader:
        //                 return;
        //             case HeaderType.Default:
        //                 frame = section.Headers.Primary.AddTextFrame();
        //                 frame.RelativeHorizontal = RelativeHorizontal.Page;
        //                 frame.RelativeVertical = RelativeVertical.Page;
        //                 frame.WrapFormat = new WrapFormat()
        //                 {
        //                     Style = WrapStyle.None,
        //                     DistanceTop = "0.9cm",
        //                     DistanceLeft = "173mm"
        //                 };
        //                 par = frame.AddParagraph();
        //                 img = par.AddImage(header.LogoImgPath);
        //                 img.Height = "0.9cm";
        //                 img.LockAspectRatio = true;
        //                 break;
        //         }
        //     }
        //     catch (Exception e)
        //     {
        //         throw new Exception("SetHeader error");
        //     }
        // }
        //
        // private static void SetTitle(MigraDoc.DocumentObjectModel.Section section,
        //     Title title,
        //     List<Style> reportstyles,
        //     SectionData sectionData,
        //     PdfTemplate pdfTemplate,
        //     ResourceParameters resParams,
        //     ref ReportSettings reportSettings)
        // {
        //     if (title == null)
        //     {
        //         return;
        //     }
        //     if (!new List<TitleType>()
        //     {
        //         TitleType.NoTitle,
        //         TitleType.BliqAppendixNoTitle,
        //     }.Contains(title.TitleType))
        //     {
        //         sectionData.Title =
        //             ResHelper.GetResVal(resParams.Paths.SectionTextResourceNamespace, "Title", resParams.CultureInfo);
        //     }
        //
        //     TextFrame frame;
        //     Paragraph par;
        //     Image img;
        //     try
        //     {
        //         switch (title.TitleType)
        //         {
        //             case TitleType.NoTitle:
        //                 return;
        //             case TitleType.Default:
        //                 par = section.AddParagraph();
        //                 par.AddText(sectionData.Title);
        //                 par.Format = GetParagraphFormat(reportstyles, StyleEnum.Title);
        //                 break;
        //             case TitleType.BliqAppendix:
        //                 par = section.AddParagraph();
        //                 par.AddText(
        //                     $"{ResHelper.GetResVal(resParams.Paths.CommonTextResourceNameSpace, "Appendix", resParams.CultureInfo)} " +
        //                     $"{reportSettings.AddAppendix}");
        //                 par.Format = GetParagraphFormat(reportstyles, "BliqSectionTitle");
        //                 par.Format.SpaceBefore = -section.PageSetup.TopMargin + 
        //                                          new Unit(2.8, UnitType.Centimeter);
        //                 par.Format.SpaceAfter = new Unit(0.8, UnitType.Centimeter);
        //                 par = section.AddParagraph();
        //                 par.AddText(sectionData.Title);
        //                 par.Format = GetParagraphFormat(reportstyles, StyleEnum.Title);
        //                 break;
        //             case TitleType.BliqAppendixNoTitle:
        //                 par = section.AddParagraph();
        //                 par.AddText(
        //                     $"{ResHelper.GetResVal(resParams.Paths.CommonTextResourceNameSpace, "Appendix", resParams.CultureInfo)} " +
        //                     $"{reportSettings.AddAppendix}");
        //                 par.Format = GetParagraphFormat(reportstyles, "BliqSectionTitle");
        //                 par.Format.SpaceBefore = -section.PageSetup.TopMargin + 
        //                                          new Unit(2.8, UnitType.Centimeter);
        //                 par.Format.SpaceAfter = new Unit(0.8, UnitType.Centimeter);
        //                 break;
        //             case TitleType.BliqDefault:
        //                 par = section.AddParagraph();
        //                 par.AddText($"{sectionData.Title}");
        //                 par.Format = GetParagraphFormat(reportstyles, "BliqSectionTitle");
        //                 par.Format.SpaceBefore = -section.PageSetup.TopMargin + 
        //                                          new Unit(2.8, UnitType.Centimeter);
        //                 par.Format.SpaceAfter = new Unit(0.8, UnitType.Centimeter);
        //                 break;
        //             case TitleType.BliqSubsection:
        //                 par = section.AddParagraph();
        //                 par.AddText(sectionData.Title);
        //                 par.Format = GetParagraphFormat(reportstyles, StyleEnum.Title);
        //                 par.Format.SpaceBefore = -section.PageSetup.TopMargin + 
        //                                          new Unit(4.8, UnitType.Centimeter);
        //                 break;
        //             case TitleType.Appendix:
        //                 break;
        //         }
        //     }
        //     catch (Exception e)
        //     {
        //         throw new Exception("SetTitle error");
        //     }
        //     
        // }
    }
}