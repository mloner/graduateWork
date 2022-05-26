using System;
using System.Collections.Generic;
using System.Linq;
using CugReportMicroservice.Dtos.ReportingAdapterDataModels;
using SectionModels;

namespace ReportingFramework.SectionAdapter
{
    public abstract class SectionAdapter
    {
        public Dictionary<string, object> CommonData { get; set; }
        public ReportAdapterParameters ReportAdapterParameters { get; set; }
        public CsvReader CsvReader { get; set; }
        
        public SectionAdapter()
        {
            
        }
        public SectionModel SectionModel { get; set; }

        public virtual void Init(SectionArgs args)
        {
            CommonData = args.ReportCommonData;
            ReportAdapterParameters = args.ReportAdapterParameters;
            CsvReader = args.CsvReader;
        }

        public virtual void LoadData()
        {
            
        }

        public virtual SectionModel CreateSectionModel()
        {
            return SectionModel;
        }

        protected int GetPayBackPeriodInMonths(List<double> yearlyCashflow)
        {
            int totalMonths = 0;
            double cumulativeSum = 0;
            int i;
            
            for (i = 0; i < yearlyCashflow.Count; i++)
            {
                
                if (cumulativeSum + yearlyCashflow[i] > 0)
                {
                    totalMonths += (int) (Math.Abs(cumulativeSum / yearlyCashflow[i]) * 12);
                    cumulativeSum += yearlyCashflow[i];
                    break;
                }
                else
                {
                    totalMonths += 12;
                    cumulativeSum += yearlyCashflow[i];
                }
            }

            if (cumulativeSum < 0)
            {
                if (yearlyCashflow.Last() > 0)
                {
                    totalMonths += (int)(Math.Abs(cumulativeSum / yearlyCashflow.Last()) * 12);
                }
                else
                {
                    totalMonths = -1; // no payoff
                }
            }
            
            
            return totalMonths;
        }

        protected List<int> GetPaybackPeriodYearsMonths(List<double> yearlyCashflow)
        {
            var pbPeriodInMonths = GetPayBackPeriodInMonths(yearlyCashflow);
            var res = new List<int>();

            //no payoff
            if (pbPeriodInMonths == -1)
            {
                res.Add(-1);
            }
            else
            {
                int monthsDec = pbPeriodInMonths % 12;
                int years = (pbPeriodInMonths - monthsDec) / 12;

                if (years > 0)
                {
                    res.Add(years);
                }

                if (monthsDec > 0)
                {
                    res.Add(monthsDec);
                }
            }

            return res;
        }
    }
}