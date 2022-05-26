using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using ReportingFramework.Common;
using ReportingFramework.Common.Extentions;
using ReportingFramework.Common.Template.SectionTypeTemplate;
using ReportingFramework.Common.Template.Style;
using ReportingFramework.Common.TemplateLoader;
using ReportingFramework.Dto;
using ReportingFramework.Dto.DataModels;
using ReportingFramework.Dto.GlobalSettings;
using ReportingFramework.Extentions;
using ReportingFramework.Structure.SectionElements.FooterSetter;
using ReportingFramework.Structure.SectionElements.HeaderSetter;
using ReportingFramework.Structure.SectionElements.TitleSetter;
using SectionModels;
using Font = MigraDoc.DocumentObjectModel.Font;
using Section = MigraDoc.DocumentObjectModel.Section;
using Style = ReportingFramework.Dto.Style;

namespace ReportingFramework.Structure
{
    public abstract class PdfReportSection : AbstractReportSection
    {
        protected Paragraph Par;
        //protected ReportParagraph RepPar;
        protected List<Paragraph> Paragraphs;
        protected string Name;
        protected string ChildName;
        protected string Str;
        protected Image Img;

        public PdfSectionParameters SecParams;
        protected PdfTemplate ReportTemplate;
        protected List<Style> Styles;
        
        
        protected ResourceParameters ResParams;
        protected ISection SectionData;
        protected Section PdfSection;
        protected Document Document;

        protected SectionTypeTemplate SectionTemplate;


        public override void Generate()
        {
            PdfSection = new Section();

            InitSectionPaths();
            
            SetSectionTemplate();

            SetMargins();
            SetHeader();
            SetFooter();
            SetTitle();
            SetBackground();
            
            GenerateContent();

            AddSectionToDocument();
        }

        private void InitSectionPaths()
        {
            var paths = SecParams.Paths;

            paths.SectionResources = $"{paths.Data}/SectionsResources/{SectionResName.Replace(".","/")}";
            paths.SectionImages = $"{paths.SectionResources}/Images";

            SecParams.Paths = paths;
        }

        private void SetSectionTemplate()
        {
            var sectionTemplateNum = SecParams.ReportTemplate.SectionToTemplateRelations[SectionModel.Subtype];
            SectionTemplate = SecParams.ReportTemplate.SectionTypeTemplates
                .First(x => x.Name == (PdfSectionStyleEnum)sectionTemplateNum);
        }
        
        private void SetBackground()
        {
            var imagePath = $"{SecParams.Paths.CompanyBackgrounds}/{SectionTemplate.BackgroundImage}";
            
            TextFrame frame;
            Image img;
            frame = PdfSection.Headers.Primary.AddTextFrame();
            frame.RelativeHorizontal = RelativeHorizontal.Page;
            frame.RelativeVertical = RelativeVertical.Page;
            frame.WrapFormat = new WrapFormat()
            {
                Style = WrapStyle.Through,
                DistanceTop = "0cm",
                DistanceLeft = "0cm"
            };
            img = frame.AddImage(imagePath);
            img.Height = PdfSection.PageSetup.PageHeight;
            img.Width = PdfSection.PageSetup.PageWidth;
            img.RelativeVertical = RelativeVertical.Page;
            img.RelativeHorizontal = RelativeHorizontal.Page;
            img.WrapFormat.Style = WrapStyle.Through;
        }

        private void SetTitle()
        {
            TitleSetterHelper
               .GetTitleSetter(SectionTemplate.Title.TitleType)
               .Set(
                   PdfSection,
                   SectionTemplate.Title,
                   Styles.First(x => x.Name == StyleEnum.Title.Desc()).ToParagraphFormat(),
                   GetResVal("Title")
                   );
        }

        private void SetFooter()
        {
            FooterSetterHelper
                .GetFooterSetter(SectionTemplate.Footer.FooterType)
                .Set(
                    PdfSection,
                    SectionTemplate.Footer,
                    Styles.First(x => x.Name == StyleEnum.Footer.Desc()).ToParagraphFormat()
                    );
        }

        private void SetHeader()
        {
            HeaderSetterHelper
                .GetHeaderSetter(SectionTemplate.Header.HeaderType)
                .Set(
                    PdfSection,
                    SectionTemplate.Header
                    );
        }

        private void SetMargins()
        {
            var margins = SectionTemplate.Margins;
            
            PdfSection.PageSetup = new Document().DefaultPageSetup.Clone();
            PdfSection.PageSetup.LeftMargin = new Unit(margins.Left, UnitType.Centimeter);
            PdfSection.PageSetup.RightMargin = new Unit(margins.Right, UnitType.Centimeter);
            PdfSection.PageSetup.BottomMargin = new Unit(margins.Bottom, UnitType.Centimeter);
            PdfSection.PageSetup.TopMargin = new Unit(margins.Top, UnitType.Centimeter);
        }
        
        public virtual void AddSectionToDocument()
        {
            Document.Add(PdfSection);
        }


        public override void Init(AbstractSectionParameters sectionParameters)
        {
            base.Init(sectionParameters);
            InitSectionParameters(sectionParameters);
        }

        public override void InitSectionParameters(AbstractSectionParameters sectionParameters)
        {
            base.InitSectionParameters(sectionParameters);
            SecParams = (PdfSectionParameters)sectionParameters;
            Document = ((PdfSectionParameters)sectionParameters).Document;
            Styles = SecParams.ReportTemplate.Styles;
            ReportTemplate = SecParams.ReportTemplate;
        }

        public override void GenerateContent()
        {
            PdfSection.AddParagraph("SAMPLE SAMPLE SAMPLE SAMPLE SAMPLE SAMPLE SAMPLE SAMPLE SAMPLE SAMPLE SAMPLE");
        }


        public override void AddImage(
            MigraDoc.DocumentObjectModel.Section section,
            string imgPath,
            string imgTitle,
            double imgWidthCm,
            GlobalSettings globalSettings,
            List<Style> styles,
            int? figureNum = null,
            double titleSize = 10,
            bool isShortTitle = false)
        {
            foreach (var paragraph in AddImagePar(
                         imgPath: imgPath,
                         imgTitle: imgTitle,
                         imgWidthCm: imgWidthCm,
                         globalSettings: globalSettings,
                         styles: styles,
                         figureNum: figureNum,
                         titleSize: titleSize,
                         isShortTitle: isShortTitle
                     ))
            {
                section.Add(paragraph);
            }
        }

        protected List<MigraDoc.DocumentObjectModel.Paragraph> AddImagePar(
            string imgPath,
            string imgTitle,
            double imgWidthCm,
            GlobalSettings globalSettings,
            List<Style> styles,
            double? imgHeightCm = null,
            int? figureNum = null,
            double? titleSize = null,
            bool isShortTitle = false)
        {
            if (!File.Exists(imgPath))
            {
                Console.WriteLine($"Image FAIL: {imgPath}");
            }
            
            var res = new List<MigraDoc.DocumentObjectModel.Paragraph>();

            var imgPar = new Paragraph();
            
            res.Add(imgPar);
            imgPar.Format.Alignment = SectionExtensions.GetParagraphFormat(styles, StyleEnum.Image).Alignment;
            var img = imgPar.AddImage(imgPath);
            img.Width = new Unit(imgWidthCm, UnitType.Centimeter);
            img.LockAspectRatio = true;

            
            if (!string.IsNullOrEmpty(imgTitle)
                && titleSize != null
                && titleSize != 0
                && figureNum != null
                && figureNum != 0)
            {
                var imgTitlePar = new Paragraph();
                res.Add(imgTitlePar);
                string name;
                if (isShortTitle)
                {
                    name = ResHelper.GetResVal(SectionResName, "FigureShortName",_ci);
                    imgTitlePar.Format = SectionExtensions.GetParagraphFormat(styles, StyleEnum.ImageTitle);
                }
                else
                {
                    name = ResHelper.GetResVal(SectionResName, "FigureName",_ci);
                    imgTitlePar.Format = SectionExtensions.GetParagraphFormat(styles, StyleEnum.ImageTitle);
                }

                if (titleSize != null)
                {
                    imgTitlePar.Format.Font.Size = titleSize.Value;
                }

                imgTitlePar.AddFormattedText($"{name} {figureNum}: {imgTitle}");
            }

            return res;
        }

        protected Paragraph AddText(string text, ParagraphFormat style)
        {
            Par = FormattedText(text);
            Par.Format = style;
            PdfSection.Add(Par);

            return Par;
        }

        public Paragraph FormattedText(string text)
        {
            Paragraph resultPar = new Paragraph();
            string s = "";
            FormattedText formattedText = new FormattedText();
            var defColor = formattedText.Color;
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                if (c == '{')
                {
                    formattedText.AddText(s);
                    s = "";
                    resultPar.Add(formattedText.Clone());
                    formattedText.Elements = new ParagraphElements();

                    var match = Regex.Match(text.Substring(i), @"(\{\/*[^\{]+})").Value.Replace("{", "")
                        .Replace("}", "");
                    switch (match.Split("=").First())
                    {
                        case "b":
                            formattedText.Bold = true;
                            break;
                        case "/b":
                            formattedText.Bold = false;
                            break;
                        
                        case "i":
                            formattedText.Italic = true;
                            break;
                        case "/i":
                            formattedText.Italic = false;
                            break;
                        
                        case "color":
                            var colorComponents = match.Split("=")[1]
                                .Replace(" ", "")
                                .Split(",")
                                .Select(x => byte.Parse(x))
                                .ToList();
                            if (colorComponents.Count == 3)
                            {
                                formattedText.Color = new Color(colorComponents[0], colorComponents[1],
                                    colorComponents[2]);
                            }
                            else if (colorComponents.Count == 4)
                            {
                                formattedText.Color = new Color(colorComponents[0], colorComponents[1],
                                    colorComponents[2], colorComponents[3]);
                            }
                            break;
                        case "/color":
                            formattedText.Color = defColor;
                            break;
                        
                        case "sub":
                            formattedText.Subscript = true;
                            break;
                        case "/sub":
                            formattedText.Subscript = false;
                            break;
                        
                        case "link":
                            formattedText.Font.Underline = Underline.Single;
                            break;
                        case "/link":
                            formattedText.Font.Underline = Underline.None;
                            break;
                        
                        default:
                            break;
                    }

                    i += match.Length + 2 - 1;
                }
                else
                {
                    s += c.ToString();
                }
            }

            if (s.Length > 0)
            {
                formattedText.AddText(s);
                s = "";
                resultPar.Add(formattedText.Clone());
            }

            return resultPar;
        }

        protected double GetSectionWidthCm()
        {
            return new Unit(PdfSection.PageSetup.PageWidth - PdfSection.PageSetup.LeftMargin - PdfSection.PageSetup.RightMargin).Centimeter;
        }

        public void FillPage(string symbols, int count)
        {
            var par = PdfSection.AddParagraph("");
            for (int i = 0; i < count; i++)
            {
                par.AddText($"{symbols} ");
            }
        }

        public void AddSpace(double spaceCm = 0.3)
        {
            AddSpace(new Unit(spaceCm, UnitType.Centimeter));
        }

        public void AddSpace(int spaceCm)
        {
            AddSpace(new Unit(spaceCm, UnitType.Centimeter));
        }

        public void AddSpace(Unit space)
        {
            var par = PdfSection.AddParagraph();
            par.Format = new ParagraphFormat()
            {
                SpaceBefore = 0,
                SpaceAfter = space,
                LineSpacing = 1,
                LineSpacingRule = LineSpacingRule.Single,
                Font = new Font()
                {
                    Size = 1e-6
                }
            };
        }

        public void ShiftedParagraphFromTop(double distanceCm)
        {
            Par = PdfSection.AddParagraph();
            Par.Format = new ParagraphFormat()
            {
                SpaceBefore = -PdfSection.PageSetup.TopMargin + new Unit(distanceCm, UnitType.Centimeter),
                SpaceAfter = 0,
                LineSpacing = 1,
                Font = new Font()
                {
                    Size = 1e-4
                }
            };
        }

        public Paragraph AddParagraph(string text, StyleEnum style = StyleEnum.Normal)
        {
            var paragraphFormat = SectionExtensions.GetStyle(SecParams.ReportTemplate.Styles, style);
            Par = AddText(text, paragraphFormat);
            
            
            return Par;
        }
        
        public Paragraph CreateParagraph(string text, StyleEnum style = StyleEnum.Normal)
        {
            var paragraphFormat = SectionExtensions.GetParagraphFormat(ReportTemplate.Styles, style);
            Par = FormattedText(text);
            Par.Format = paragraphFormat;

            return Par;
        }
        
        public Paragraph CreateParagraph(string text, string styleName)
        {
            var paragraphFormat = SectionExtensions.GetParagraphFormat(ReportTemplate.Styles, styleName);
            Par = FormattedText(text);
            Par.Format = paragraphFormat;

            return Par;
        }
        
        public Paragraph AddText(string text, Style style)
        {
            if (text == null)
            {
                throw new Exception("Text is null");
            }
            Par = new Paragraph();
            Par.Elements = FormattedText(text).Elements.Clone();
            var result = AddText(Par, style);

            return result;
        }
        
        public Paragraph AddText(Paragraph paragraph, Style style)
        {
            Par = PdfSection.AddParagraph();
            Par.Elements = paragraph.Elements.Clone();
            Par.Format = style.ToParagraphFormat();

            return Par;
        }

    }
}