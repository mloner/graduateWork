using System.Globalization;
using System.Text.Json;
using ReportingFramework.Common;
using ReportingFramework.Dto;
using ReportingFramework.Dto.DataModels;
using ReportingFramework.Dto.GlobalSettings;

namespace SectionModels
{
    public abstract class AbstractReportSection : IReportSection
    {
        public string SectionResName;
        protected CultureInfo _ci;
        public SectionModel SectionModel;
        protected INumberFormatter _numFmtr;
        public AbstractSectionParameters SecParams;
        protected List<string> SectionTextResNames;
        protected string Prefix;

        public AbstractReportSection()
        {
            SectionTextResNames = new List<string>();
        }
        
        public virtual void InitSectionModel(string sectionModelJson)
        {
            SectionModel = JsonSerializer.Deserialize<SectionModel>(sectionModelJson);
        }

        public virtual void Init(AbstractSectionParameters sectionParameters)
        {
            _numFmtr = sectionParameters.NumFmtr;
            SectionResName = sectionParameters.Paths.TextResourceNameSpaceTemplate
                .Replace("[resName]", "")
                .Replace("..", ".")
                .Replace("SectionResources", "CommonResources");
            SectionTextResNames.Insert(0, SectionResName);
        }

        public virtual void InitSectionParameters(AbstractSectionParameters sectionParameters)
        {
            SecParams = sectionParameters;
        }
        
        
        protected void AddSectionResName(string sectionResName)
        {
            SectionResName = sectionResName;
            SectionTextResNames.Insert(0, SecParams.Paths.TextResourceNameSpaceTemplate
                .Replace("[resName]", sectionResName));
        }
        

        public abstract void Generate();
        public abstract void GenerateContent();

        public abstract void AddImage(
            MigraDoc.DocumentObjectModel.Section section,
            string imgPath,
            string imgTitle,
            double imgWidthCm,
            GlobalSettings globalSettings,
            List<Style> styles,
            int? figureNum = null,
            double titleSize = 10,
            bool isShortTitle = false);
        
        
        
        
        

        protected List<string> GetPeriodWords(string periodMonths)
        {
            return GetPeriodWords(int.Parse(periodMonths));
        }
        protected List<string> GetPeriodWords(int periodMonths)
        {
            var res = new List<string>();
            int monthsDec = periodMonths % 12;
            int years = (periodMonths - monthsDec) / 12;

            if (years > 0)
            {
                var yearsWord = years > 1 ? 
                    ResHelper.GetResVal(SectionResName, "Years", _ci).ToLower() :
                    ResHelper.GetResVal(SectionResName, "Year", _ci).ToLower();
                res.Add($"{years} {yearsWord}");
            }

            if (monthsDec > 0)
            {
                var monthsWord = monthsDec > 1 ? 
                    ResHelper.GetResVal(SectionResName, "Months", _ci).ToLower() :
                    ResHelper.GetResVal(SectionResName, "Month", _ci).ToLower();
                res.Add($"{monthsDec} {monthsWord}");
            }

            return res;
        }
        protected List<double> GetPaybackPeriodYearsMonths(int pbPeriodMonths)
        {
            var res = new List<double>();
            int monthsDec = pbPeriodMonths % 12;
            int years = (pbPeriodMonths - monthsDec) / 12;

            if (years > 0)
            {
                res.Add(years);
            }

            if (monthsDec > 0)
            {
                res.Add(monthsDec);
            }

            return res;
        }



        public virtual string? GetResVal(string key)
        {
            return ResHelper.GetResVal(SectionTextResNames, key, SecParams.ResourceParameters.CultureInfo);
        }
        
    }
}