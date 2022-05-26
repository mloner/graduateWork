using System;
using System.Collections.Generic;
using System.IO;
using ClosedXML.Excel;
using MigraDoc.DocumentObjectModel;
using ReportingFramework.Dto.DataModels;
using ReportingFramework.Dto.GlobalSettings;
using SectionModels;
using Style = ReportingFramework.Dto.Style;

namespace ExcelGenerator.Structure
{
    public abstract class ExcelReportSection : AbstractReportSection
    {
        protected new ExcelSectionParameters SecParams;

        protected string TemplateFileName;
        protected IXLWorkbook TemplateWorkbook;
        protected IXLWorksheet Worksheet;
        protected IXLWorkbook OutWorkbook;

        public override void Generate()
        {
            InitWorksheet();
            GenerateContent();
            AddSheetsToOutWorkbook();
        }

        private void InitWorksheet()
        {
            try
            {
                Worksheet = TemplateWorkbook.Worksheet(1);
            }
            catch (Exception e)
            {
                //ignored
            }
        }

        public virtual void AddSheetsToOutWorkbook()
        {
            foreach (var xlWorksheet in TemplateWorkbook.Worksheets)
            {
                OutWorkbook.AddWorksheet(xlWorksheet);
            }
        }

        public override void Init(AbstractSectionParameters sectionParameters)
        {
            base.Init(sectionParameters);
            InitSectionParameters(sectionParameters);
            LoadTemplateFile(sectionParameters);
            OutWorkbook = ((ExcelSectionParameters)sectionParameters).OutWorkbook;
        }

        public override void InitSectionParameters(AbstractSectionParameters sectionParameters)
        {
            base.InitSectionParameters(sectionParameters);
            SecParams = (ExcelSectionParameters)sectionParameters;
        }

        protected virtual void LoadTemplateFile(AbstractSectionParameters sectionParameters)
        {
            FileInfo fi = new FileInfo($"{sectionParameters.Paths.ExcelTemplates}/{TemplateFileName}");
            TemplateWorkbook = new XLWorkbook(fi.FullName);
        }

        public override void AddImage(Section section, string imgPath, string imgTitle, double imgWidthCm, GlobalSettings globalSettings, List<Style> styles, int? figureNum = null, double titleSize = 10, bool isShortTitle = false)
        {
            throw new NotImplementedException();
        }
    }
}